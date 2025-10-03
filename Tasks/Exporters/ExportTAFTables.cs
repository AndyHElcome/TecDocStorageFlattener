using System.Diagnostics;
using TecDocStorageFlattener.Helpers;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using TecDocStorageFlattener.Models;
using TecDocStorageFlattener.Models.Tecdoc;
using TafLoader.Models.Tecdoc;
using TecDocStorageFlattener.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;



namespace TecDocStorageFlattener.Tasks.Exporters;

public class ExportTAFTables
{

    public string ConnectionString;
    public List<DefinitionTable>? tdTables;
    public string ExportPath;

    public async Task ExportDatFiles(string clientName, string BrandNo, string BrandName)
    {
        //LogMessage(clientName, "### Exporting dat file system => started");

        try
        {
            //using var scope = serviceProvider.CreateScope();
            //using Services.DatabaseFactory dbContextFactory = scope.ServiceProvider.GetRequiredService<Services.DatabaseFactory>();
            //using TRCDataContext trcDataContext = dbContextFactory.GetTRCDataContext(clientName);


            // do we need to create more files other than the default
            //var createDotDatFileVersionOfExportedDatFiles = configuration.GetSection("Application:CreateDotDatFileVersionOfExportedDatFiles").Get<List<string>>()?.Any(c => c.Equals(clientName, StringComparison.InvariantCultureIgnoreCase)) ?? false;

            //if (createDotDatFileVersionOfExportedDatFiles)
            //{
            //    LogMessage(clientName, $"Config => creating extra dat file version (createDotDatFileVersionOfExportedDatFiles)");
            //}

            // get configuration settings
            //var headers = await trcDataContext.ConfigurationTcCfg001.AsNoTracking().ToListAsync();



            //string pathForFilesToZip = string.Format(configuration.GetValue<string>("Application:Settings:BaseDatFileExportPath"), clientName, header.BrandName);
            //string pathForZipFile = $"{pathForFilesToZip}\\{header.BrandName}.zip";
            //string moveToHere = Path.Join(string.Format(configuration.GetValue<string>("Application:Settings:BaseFileLocation"), clientName), Path.GetFileName(pathForZipFile));

            await WriteDats(clientName, BrandNo, BrandName, false);

            // zip and move branded file extension files
            //await Utils.ZipFiles(
            //    pathForFilesToZip,
            //    pathForZipFile,
            //    $".{header.BrandNo}",
            //    false);
            //Utils.MoveFile(
            //    pathForZipFile,
            //    moveToHere
            //    );

            // zip and move dat file extension files (if required)
            //if (createDotDatFileVersionOfExportedDatFiles)
            //{
            //    string pathForZipFile2 = $"{pathForFilesToZip}\\{header.BrandName}_DATFILES.zip";
            //    string moveToHere2 = Path.Join(string.Format(configuration.GetValue<string>("Application:Settings:BaseFileLocation"), clientName), Path.GetFileName(pathForZipFile2));
            //    await Utils.ZipFiles(
            //        pathForFilesToZip,
            //        pathForZipFile2,
            //        ".dat",
            //        false);
            //    Utils.MoveFile(
            //        pathForZipFile2,
            //        moveToHere2
            //        );
            //}

            //trcDataContext.SystemLog.Add(new SystemLog
            //{
            //    Type = "system",
            //    KeyName = "dat-name",
            //    Description = Path.GetFileName(pathForZipFile)
            //});
            //await trcDataContext.SaveChangesAsync();





            //LogMessage(clientName, "### Exporting dat file system => finished");
        }
        catch (Exception exception)
        {
            //LogMessage(clientName, exception?.ToString() ?? String.Empty);
            throw new Exception("", exception);
        }
    }
    

    private async Task WriteDats(string clientName, string brandNo, string brandName, bool createDotDatFileVersionOfExportedDatFiles)
    {
        //LogMessage(clientName, $"Start => ### WriteDats for Brand: {brandName}");
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        if (tdTables != null && tdTables != null)
        {
            foreach (var t in tdTables)
            {
                if (t.Column == null)
                {
                    //LogMessage(clientName, $"ExportTasks Message:No columns defined for table {t.Name}. Please check and amend the TecdocTableDefn.json file. Export of this table will not continue.");
                    continue;
                }

                // do a quick check to ensure the essential fields are populated
                var defCheck = from c in t.Column
                               where string.IsNullOrEmpty(c.Length) || string.IsNullOrEmpty(c.NameInTable)
                               select c;

                if (defCheck.Count() > 0)
                {
                    //LogMessage(clientName, $"ExportTasks Message:Length or NameInTable field is not populated or has been misnamed for table {t.Name}. Please check and amend the TecdocTableDefn.json file. Export of this table will not continue.");
                    continue;
                }

                List<string> datList = new List<string>();

                using var supplierDataContext = new SupplierDBConfig() { ConnectionStringConfig = new() { ConnectionStringTemplate = "Server=dev-sql;Database=idp_6402;Integrated Security=False;User Id=sa;Password=elcome_b055;TrustServerCertificate=True" } }.Context;
                var dbSetProp = supplierDataContext.GetType()
                                                   .GetProperties()
                                                   .Where(p => p.PropertyType.IsGenericType &&
                                                               p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                                                               p.Name == $"T{t.Name}")
                                                   .FirstOrDefault();

                   
                var entityType = dbSetProp.PropertyType.GetGenericArguments()[ 0 ];
                var dbSet = dbSetProp.GetValue(supplierDataContext);

                var list = ((IQueryable)dbSet).Cast<object>().AsAsyncEnumerable()
                                                                //.Where(c => !string.IsNullOrEmpty(c?.Article?.ArtNo))
                                                                .Chunk(50);
                int i = 0;
                await foreach (var chunk in list)
                    foreach (var item in chunk)
                    {
                        var datLine = ProcessDatLine(item, t);
                        datList.Add(datLine);
                        i++;
                    }

                Console.WriteLine($"Table: {dbSetProp.Name}, Rows: {i}");

                await SaveDatFile(datList, t.Name ?? "", clientName, brandName, brandNo, createDotDatFileVersionOfExportedDatFiles);
                
            }
        }

        stopwatch.Stop();
        //LogMessage(clientName, $"End => ### WriteDats for Brand: {brandName} | {stopwatch.ElapsedMilliseconds}ms");
    }

    private string ProcessDatLine(object dataSet, DefinitionTable t)
    {
        StringBuilder datLine = new StringBuilder();
        if (t.Column != null)
        {
            foreach (var c in t.Column)
            {
                var colProp = dataSet.AllTecdocFieldAttribute(c.NameInTable).FirstOrDefault();

                var val = colProp is null ? string.Empty : colProp.GetValue(dataSet);

                if (colProp is not null && (colProp.PropertyType == typeof(bool) || colProp.PropertyType == typeof(bool?))) 
                    val = (bool?)val == true ? "1" : "0";

                string fldValue =  Convert.ToString(val) ?? "";
                int Length;
                int.TryParse(c.Length, out Length);

                //ensure string is no longer than allowed length
                if (!string.IsNullOrEmpty(fldValue) && fldValue.Length > Length)
                {
                    fldValue = fldValue.Substring(0, Length);
                }
                //now pad it out
                //get pad character
                char padChar = ' ';

                if (!String.IsNullOrEmpty(fldValue))//apparently if number type field value is completely blank then pad with space
                {
                    switch (c.Type)
                    {
                        case "N":
                        case "(N)":
                            padChar = '0';
                            break;
                        case "U":
                        case "C":
                        case "(C)":
                            padChar = ' ';
                            break;
                    }
                }
                int padlength = Length - fldValue.Length;
                StringBuilder padString = new StringBuilder();

                if (new string[] { "C", "U", "(C)" }.Contains(c.Type))//text - pad right
                {
                    padString.Append(fldValue);
                    padString.Append(padChar, padlength);
                }
                else
                {
                    padString.Append(padChar, padlength);//numbers - pad left
                    padString.Append(fldValue);
                }

                datLine.Append(padString);
            }
        }
        return datLine.ToString();

    }

    private async Task SaveDatFile(List<string> listDat, string tablename, string clientName, string brandName, string brandNumber, bool createDotDatFileVersionOfExportedDatFiles)
    {
        // standard copy
        //string exportPath = $"{string.Format(configuration.GetValue<string>("Application:Settings:BaseDatFileExportPath"), clientName, brandName)}\\{tablename}.{brandNumber.FormatPadding(4)}";
        string exportPath = $"{ExportPath}\\{tablename}.{brandNumber}";

        bool exportAsUnicode = false;

        //LogMessage(clientName, $"{exportPath}");

        await Task.Run(() =>
        {
            if (!string.IsNullOrEmpty(exportPath))
            {
                if (!Directory.Exists(Path.GetDirectoryName(exportPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(exportPath) ?? "");
                }

                if (File.Exists(exportPath))
                {
                    File.Delete(exportPath);
                }

                //write out our list of strings
                using (StreamWriter sw = exportAsUnicode ? new StreamWriter(new FileStream(exportPath, FileMode.OpenOrCreate), Encoding.UTF8) : new StreamWriter(exportPath))
                {
                    foreach (var l in listDat)
                    {
                        sw.WriteLine(l);
                    }
                }

                // save a copy in a different format
                //if (createDotDatFileVersionOfExportedDatFiles)
                //{
                //    string exportPathDifferentVersion = $"{string.Format(configuration.GetValue<string>("Application:Settings:BaseDatFileExportPath"), clientName, brandName)}\\{tablename}.dat";
                //    File.Copy(exportPath, exportPathDifferentVersion, true);
                //}
            }
        });
    }
}

