//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
//using TecDocServices;
//using TRCServices.Helpers;
//using TRCServices.Models.Configuration;
//using TRCServices.Models.Contexts.Client;
//using TRCServices.Models.DTO;
//using TRCServices.Models.Json;
//using TRCServices.Models.Settings;
//using TRCServices.Services;
//using static TRCServices.Models.Settings.Settings;

/*namespace TRCServices.Tasks
{
    public class ExportTasks
    {
        readonly IServiceProvider serviceProvider;
        readonly IConfiguration configuration;
        readonly ILogger<ExportTasks> logger;
        readonly IWebHostEnvironment hostEnvironment;
        private List<DefinitionTable>? tdTables;
        private readonly TecdocServices tecdocServices;
        private readonly ReportingPostOutputTasks reportingTasks;

        public ExportTasks(IConfiguration config, ILogger<ExportTasks> logger, IWebHostEnvironment hostEnvironment, IServiceProvider serviceProvider, [FromServices] JsonSerializerOptions jsonOptions, TecdocServices tecdocServices, ReportingPostOutputTasks reportingTasks)
        {
            this.configuration = config;
            this.logger = logger;
            this.hostEnvironment = hostEnvironment;
            this.serviceProvider = serviceProvider;
            this.tecdocServices = tecdocServices;
            this.reportingTasks = reportingTasks;
            tdTables = configuration.GetSection("DefinitionTable").Get<List<DefinitionTable>>();
            if (tdTables == null)
            {
                logger.LogInformation("ExportTasks Message:Failed to load the TecdocTableDefn.json");
            }
        }
        public void LogMessage(string clientName, string message)
        {
            logger.LogInformation($"{{ClientName}} | ExportTask: {message}", clientName.ToLower());
        }



        //public async Task<Boolean> SendReportStatusToFrontEnd(OnceClientDTO clientDTO)
        //{
        //    LogMessage(clientDTO.ClientName, $"Send result status to {clientDTO.XcheckerWebsiteUrl} => started");

        //    DataSet dataSet = await CreateDatasetForReport(clientDTO.ClientName);
        //    var uploadState = await tecdocServices.SendUploadState(clientDTO.ClientName, clientDTO.XcheckerWebsiteUrl, dataSet);
        //    LogMessage(clientDTO.ClientName, $"status for SendUploadState = {(uploadState == true ? "success" : "failed")}");
        //    if (uploadState == false)
        //    {
        //        LogMessage(clientDTO.ClientName, "check xchecker log file for issue or incident reports in xc_central");
        //    }
        //    LogMessage(clientDTO.ClientName, "Send result status => finished");
        //    return uploadState;
        //}

        // xchecker takes care of previous and differences - we just send current counts
        public async Task<Boolean> SendCountsToFrontEnd(TRCDataContext context, OnceClientDTO clientDTO)
        {
            LogMessage(clientDTO.ClientName, $"Send result counts to {clientDTO.XcheckerWebsiteUrl} => started");
            string supportingFileLocation = Path.Join($"{string.Format(configuration.GetValue<string>("Application:Settings:SupportingFileLocation"), clientDTO.ClientName)}");
            var headers = await context.ConfigurationTcCfg001.AsNoTracking().ToListAsync();

            foreach (var header in headers)
            {
                // set our header brand so we can filter by this
                string headerBrandName = header.BrandName ?? string.Empty;

                // "Count Of Parts & Links by GenArt"
                var countPartLinkGenArt = Utils.ReadOperationJson<List<CountPartLinkGenArt>>(Path.Join(supportingFileLocation, $"{ApplicationConstants.CountPartsAndLinks}.json"))
                    ?.Where(c => !string.IsNullOrEmpty(c.HeaderBrand) && c.HeaderBrand.Equals(headerBrandName, StringComparison.InvariantCultureIgnoreCase))
                    ?.Select(c => new
                    {
                        Brand = c.HeaderBrand,
                        c.Description,
                        c.GenArtNr,
                        Parts = c.CurrentParts,
                        Links = c.CurrentLinks
                    })
                    ?.ToList();
                var countPartLinkGenArtTotals = new
                {
                    Brand = string.Empty,
                    Description = string.Empty,
                    GenArtNr = "Total",
                    Parts = countPartLinkGenArt?.Sum(c => c.Parts) ?? 0,
                    Links = countPartLinkGenArt?.Sum(c => c.Links) ?? 0
                };
                countPartLinkGenArt?.Add(countPartLinkGenArtTotals!);

                // "Vehicle Types Covered by GenArt"
                var vehicleTypesByGenericArticle = Utils.ReadOperationJson<List<VehicleTypesByGenericArticle>>(Path.Join(supportingFileLocation, $"{ApplicationConstants.VehicleTypesByGenart}.json"))
                    ?.Where(c => !string.IsNullOrEmpty(c.HeaderBrand) && c.HeaderBrand.Equals(headerBrandName, StringComparison.InvariantCultureIgnoreCase))
                    ?.Select(c => new
                    {
                        Brand = c.HeaderBrand,
                        Description = c.GenericArticleDescription,
                        GenArtNr = c.GenericArticle,
                        KTypNrs = c.PassengerCurrent,
                        NTypNrs = c.CommercialCurrent,
                        MotNrs = c.EngineCurrent,
                        Axles = c.AxleCurrent,
                        Total = (c.PassengerCurrent + c.CommercialCurrent + c.EngineCurrent + c.AxleCurrent)
                    })
                    ?.ToList();
                var vehicleTypesByGenericArticleTotals = new
                {
                    Brand = string.Empty,
                    Description = string.Empty,
                    GenArtNr = "Total",
                    KTypNrs = vehicleTypesByGenericArticle?.Sum(c => c.KTypNrs) ?? 0,
                    NTypNrs = vehicleTypesByGenericArticle?.Sum(c => c.NTypNrs) ?? 0,
                    MotNrs = vehicleTypesByGenericArticle?.Sum(c => c.MotNrs) ?? 0,
                    Axles = vehicleTypesByGenericArticle?.Sum(c => c.Axles) ?? 0,
                    Total = vehicleTypesByGenericArticle?.Sum(c => c.Total) ?? 0
                };
                vehicleTypesByGenericArticle?.Add(vehicleTypesByGenericArticleTotals!);

                // "Various Counts"
                var variousCounts = Utils.ReadOperationJson<List<VariousCount>>(Path.Join(supportingFileLocation, $"{ApplicationConstants.VariousCounts}.json"))
                    ?.Where(c => !string.IsNullOrEmpty(c.HeaderBrand) && c.HeaderBrand.Equals(headerBrandName, StringComparison.InvariantCultureIgnoreCase))
                    ?.Select(c => new
                    {
                        Brand = c.HeaderBrand,
                        Various_Counts = c.Description,
                        Dat = c.Current
                    })
                    ?.ToList();

                // "Parts linked In 400 by GenArt"
                var partLinked400 = Utils.ReadOperationJson<List<PartLinked400>>(Path.Join(supportingFileLocation, $"{ApplicationConstants.PartsLinkedIn400ByGenArt}.json"))
                    ?.Where(c => !string.IsNullOrEmpty(c.HeaderBrand) && c.HeaderBrand.Equals(headerBrandName, StringComparison.InvariantCultureIgnoreCase))
                    ?.Select(c => new
                    {
                        Brand = c.HeaderBrand,
                        c.Description,
                        c.GenArtNr,
                        Parts = c.Current
                    })
                    ?.ToList();
                var partLinked400Totals = new
                {
                    Brand = string.Empty,
                    Description = string.Empty,
                    GenArtNr = "Total",
                    Parts = partLinked400?.Sum(c => c.Parts) ?? 0,
                };
                partLinked400?.Add(partLinked400Totals!);

                // "TecDoc Row Counts"
                var tecDocRowCount = Utils.ReadOperationJson<List<TecDocRowCount>>(Path.Join(supportingFileLocation, $"{ApplicationConstants.TecDocRowCount}.json"))
                    ?.Where(c => !string.IsNullOrEmpty(c.HeaderBrand) && c.HeaderBrand.Equals(headerBrandName, StringComparison.InvariantCultureIgnoreCase))
                    ?.Select(c => new
                    {
                        Brand = c.HeaderBrand,
                        c.TableName,
                        TableDesc = c.Description,
                        RecordCount = c.Current
                    })
                    ?.ToList();

                // "XC/Dat Counts"
                var xcheckerAndDatCounts = Utils.ReadOperationJson<List<XcheckerAndDatCounts>>(Path.Join(supportingFileLocation, $"{ApplicationConstants.SourceAndDatCounts}.json"))
                    ?.Where(c => !string.IsNullOrEmpty(c.HeaderBrand) && c.HeaderBrand.Equals(headerBrandName, StringComparison.InvariantCultureIgnoreCase))
                    ?.Select(c => new
                    {
                        Brand = c.HeaderBrand,
                        XC_Tables = c.XcheckerTables,
                        XC = c.SourceCurrent,
                        Dats = c.DatCurrent
                    })
                    ?.ToList();

                // "XChecker Part Statuses" note brand and not header brand as we want the source brand here
                var xcheckerPartStatus = Utils.ReadOperationJson<List<XCheckerPartStatus>>(Path.Join(supportingFileLocation, $"{ApplicationConstants.SourcePartStatus}.json"))
                    ?.Where(c => !string.IsNullOrEmpty(c.HeaderBrand) && c.HeaderBrand.Equals(headerBrandName, StringComparison.InvariantCultureIgnoreCase))
                    ?.Select(c => new
                    {
                        c.Brand,
                        c.PartStatus,
                        XC = c.Current
                    })
                    ?.ToList();


                // "Check Failures"
                var checkFailures = Utils.ReadOperationJson<List<ReportSummary>>(Path.Join(supportingFileLocation, $"{ApplicationConstants.ReportSummary}.json"))
                   ?.Where(c => c.StatusId == TecdocExportStatusIdentifiction.Failed || c.StatusId == TecdocExportStatusIdentifiction.Review)
                   ?.Select(c => new
                   {
                       CheckId = c.ReportId,
                       CheckName = c.ReportDescription,
                       c.Status,
                       Errors = c.CurrentErrors,
                       c.RunDate,
                   })
                   ?.ToList();

                // "Check Summary"      
                var checkSummary = Utils.ReadOperationJson<List<ReportSummary>>(Path.Join(supportingFileLocation, $"{ApplicationConstants.ReportSummary}.json"))
                   ?.Select(c => new
                   {
                       CheckId = c.ReportId,
                       CheckName = c.ReportDescription,
                       c.Status,
                       Errors = c.CurrentErrors,
                       c.RunDate,
                   })
                   ?.ToList();

                // convert our lists to data table and add to data set
                DataSet dataSet = new();
                dataSet.Tables.Add(ToDataTable(countPartLinkGenArt, "Count of Parts & Links by GenArt"));
                dataSet.Tables.Add(ToDataTable(vehicleTypesByGenericArticle, "Vehicle Types Covered by GenArt"));
                dataSet.Tables.Add(ToDataTable(variousCounts, "Various Counts"));
                dataSet.Tables.Add(ToDataTable(partLinked400, "Parts linked in 400 by GenArt"));
                dataSet.Tables.Add(ToDataTable(tecDocRowCount, "TecDoc Row Counts"));
                dataSet.Tables.Add(ToDataTable(xcheckerAndDatCounts, "XC/Dat Counts"));
                dataSet.Tables.Add(ToDataTable(xcheckerPartStatus, "XChecker Part Statuses"));
                dataSet.Tables.Add(ToDataTable(checkFailures, "Check Failures"));
                dataSet.Tables.Add(ToDataTable(checkSummary, "Check Summary"));

                // add the data to the object for sending
                List<DatCounts> datCounts = new();
                datCounts.Add(new DatCounts
                {
                    checkId = $"{headerBrandName}counts", // TODO ?
                    fileName = ApplicationConstants.CountFileNamingConvention.Replace("{brand}", headerBrandName).Replace(".xlsx", ""),
                    datCountsDataset = dataSet
                });

                // send to end point
                var countsToSend = datCounts.ToArray();
                uploadDatCountsResponse? uploadState = await tecdocServices.UploadDatCounts(clientDTO.ClientName, clientDTO.XcheckerWebsiteUrl, countsToSend);

                if (uploadState is not null && uploadState.uploadDatCountsResult.Any())
                {
                    if (uploadState.uploadDatCountsResult[0].sucess)
                    {
                        LogMessage(clientDTO.ClientName, $"status UploadDatCounts for brand {headerBrandName} = success");
                    }
                    else
                    {
                        LogMessage(clientDTO.ClientName, $"status UploadDatCounts for brand {headerBrandName} = failed");
                    }
                }
                else
                {
                    LogMessage(clientDTO.ClientName, $"status UploadDatCounts for brand {headerBrandName} = return empty");
                }
            }

            LogMessage(clientDTO.ClientName, "Send result counts => finished");
            return true;
        }

        //public DataTable ToDataTable<T>(IList<T> list, string tableName)
        //{
        //    Type elementType = typeof(T);
        //    DataTable dataTable = new DataTable();

        //    dataTable.TableName = !String.IsNullOrEmpty(tableName) ? tableName : "unknown";

        //    //add a column to table for each public property on T
        //    foreach (var propInfo in elementType.GetProperties())
        //    {
        //        Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

        //        dataTable.Columns.Add(propInfo.Name.Replace("_", " "), ColType);
        //    }

        //    //go through each property on T and add each value to the table
        //    foreach (T item in list)
        //    {
        //        DataRow row = dataTable.NewRow();

        //        foreach (var propInfo in elementType.GetProperties())
        //        {
        //            row[propInfo.Name.Replace("_", " ")] = propInfo.GetValue(item, null) ?? DBNull.Value;
        //        }

        //        dataTable.Rows.Add(row);
        //    }

        //    return dataTable;
        //}

        //public DataSet ToDataSet<T>(IList<T> list, string tableName)
        //{
        //    Type elementType = typeof(T);
        //    DataSet dataSet = new DataSet();
        //    DataTable dataTable = new DataTable();
        //    dataSet.Tables.Add(dataTable);

        //    dataTable.TableName = !String.IsNullOrEmpty(tableName) ? tableName : "unknown";

        //    //add a column to table for each public property on T
        //    foreach (var propInfo in elementType.GetProperties())
        //    {
        //        Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

        //        dataTable.Columns.Add(propInfo.Name.Replace("_", " "), ColType);
        //    }

        //    //go through each property on T and add each value to the table
        //    foreach (T item in list)
        //    {
        //        DataRow row = dataTable.NewRow();

        //        foreach (var propInfo in elementType.GetProperties())
        //        {
        //            row[propInfo.Name.Replace("_", " ")] = propInfo.GetValue(item, null) ?? DBNull.Value;
        //        }

        //        dataTable.Rows.Add(row);
        //    }

        //    return dataSet;
        //}

        //private async Task<DataSet> CreateDatasetForReport(string clientName)
        //{
        //    List<List<XElement>> listXE = new();
        //    List<ArrayOfXElement> XECounts = new List<ArrayOfXElement>();
        //    DataSet ds = new();

        //    try
        //    {
        //        listXE = await reportingTasks.ExceReportSummaryToXML(clientName);
        //    }
        //    catch (Exception exception)
        //    {
        //        LogMessage(clientName, exception?.ToString() ?? String.Empty);
        //    }

        //    foreach (var list in listXE)
        //    {
        //        DataSet tempDS = new DataSet();
        //        foreach (var item in list)
        //        {
        //            using (XmlReader xr = item.CreateReader())
        //            {
        //                xr.MoveToContent();
        //                xr.Read();

        //                ArrayOfXElement arrayOfX = new ArrayOfXElement();
        //                arrayOfX.ReadXml(xr);
        //                XECounts.Add(arrayOfX);
        //                string rawXml = item.ToString();

        //                try
        //                {
        //                    tempDS.ReadXml(new StringReader(rawXml)); //reading into a temporary dataset.
        //                }
        //                catch (Exception exception)
        //                {
        //                    LogMessage(clientName, exception?.ToString() ?? String.Empty);
        //                }
        //            }
        //        }

        //        try
        //        {
        //            ds.Tables.Add(tempDS.Tables[0].Copy());//add the first table to the dataset that we'll return.
        //        }
        //        catch (Exception exception)
        //        {
        //            LogMessage(clientName, exception?.ToString() ?? String.Empty);
        //        }
        //    }

        //    return ds;
        //}

        
    }
}
*/