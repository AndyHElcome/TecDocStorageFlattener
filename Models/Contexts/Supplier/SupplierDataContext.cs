using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class SupplierDataContext : DbContext
{
    public SupplierDataContext()
    {
    }

    public SupplierDataContext(DbContextOptions<SupplierDataContext> options)
        : base(options)
    {
    }

    
    public virtual DbSet<Dat001> Dat001 { get; set; } = null!;
    public virtual DbSet<Dat030> Dat030 { get; set; } = null!;
    public virtual DbSet<Dat035> Dat035 { get; set; } = null!;
    public virtual DbSet<Dat040> Dat040 { get; set; } = null!;
    public virtual DbSet<Dat043> Dat043 { get; set; } = null!;
    public virtual DbSet<Dat200> Dat200 { get; set; } = null!;
    public virtual DbSet<Dat201> Dat201 { get; set; } = null!;
    public virtual DbSet<Dat202> Dat202 { get; set; } = null!;
    public virtual DbSet<Dat203> Dat203 { get; set; } = null!;
    public virtual DbSet<Dat204> Dat204 { get; set; } = null!;
    public virtual DbSet<Dat205> Dat205 { get; set; } = null!;
    public virtual DbSet<Dat206> Dat206 { get; set; } = null!;
    public virtual DbSet<Dat207> Dat207 { get; set; } = null!;
    public virtual DbSet<Dat208> Dat208 { get; set; } = null!;
    public virtual DbSet<Dat209> Dat209 { get; set; } = null!;
    public virtual DbSet<Dat210> Dat210 { get; set; } = null!;
    public virtual DbSet<Dat211> Dat211 { get; set; } = null!;
    public virtual DbSet<Dat212> Dat212 { get; set; } = null!;
    public virtual DbSet<Dat213> Dat213 { get; set; } = null!;
    public virtual DbSet<Dat215> Dat215 { get; set; } = null!;
    public virtual DbSet<Dat217> Dat217 { get; set; } = null!;
    public virtual DbSet<Dat222> Dat222 { get; set; } = null!;
    public virtual DbSet<Dat231> Dat231 { get; set; } = null!;
    public virtual DbSet<Dat232> Dat232 { get; set; } = null!;
    public virtual DbSet<Dat233> Dat233 { get; set; } = null!;
    public virtual DbSet<Dat400> Dat400 { get; set; } = null!;
    public virtual DbSet<Dat401> Dat401 { get; set; } = null!;
    public virtual DbSet<Dat403> Dat403 { get; set; } = null!;
    public virtual DbSet<Dat404> Dat404 { get; set; } = null!;
    public virtual DbSet<Dat410> Dat410 { get; set; } = null!;
    public virtual DbSet<Dat432> Dat432 { get; set; } = null!;
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Dat001>(entity =>
        {
            entity.Property(e => e.BrandName).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.DataRelease).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Format).HasMaxLength(550);

            entity.Property(e => e.Full).HasMaxLength(550);

            entity.Property(e => e.ManNo).HasMaxLength(550);

            entity.Property(e => e.RefDataVersion).HasMaxLength(550);

            entity.Property(e => e.Reserved).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.VersionDate).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat030>(entity =>
        {
            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.LangNo).HasMaxLength(550);

            entity.Property(e => e.Reserved).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.Term).HasMaxLength(550);

            entity.Property(e => e.TermNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat035>(entity =>
        {
            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Fixed).HasMaxLength(550);

            entity.Property(e => e.LangNo).HasMaxLength(550);

            entity.Property(e => e.Reserved).HasMaxLength(550);

            entity.Property(e => e.SeqNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.Text).HasMaxLength(550);

            entity.Property(e => e.TxtModNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat040>(entity =>
        {
            entity.Property(e => e.AdrType).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.City1).HasMaxLength(550);

            entity.Property(e => e.City2).HasMaxLength(550);

            entity.Property(e => e.CountryPrefix).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Email).HasMaxLength(550);

            entity.Property(e => e.Fax).HasMaxLength(550);

            entity.Property(e => e.Phone).HasMaxLength(550);

            entity.Property(e => e.PoBox).HasMaxLength(550);

            entity.Property(e => e.PostCode).HasMaxLength(550);

            entity.Property(e => e.PostCodeCus).HasMaxLength(550);

            entity.Property(e => e.PostCodePoBox).HasMaxLength(550);

            entity.Property(e => e.Street1).HasMaxLength(550);

            entity.Property(e => e.Street2).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.Term1).HasMaxLength(550);

            entity.Property(e => e.Term2).HasMaxLength(550);

            entity.Property(e => e.Web).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat043>(entity =>
        {
            entity.Property(e => e.AdrType).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.City1).HasMaxLength(550);

            entity.Property(e => e.City2).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.CountryPrefix).HasMaxLength(550);

            entity.Property(e => e.DLNr).HasMaxLength(4);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Email).HasMaxLength(550);

            entity.Property(e => e.Fax).HasMaxLength(550);

            entity.Property(e => e.Phone).HasMaxLength(550);

            entity.Property(e => e.PoBox).HasMaxLength(550);

            entity.Property(e => e.PostCode).HasMaxLength(550);

            entity.Property(e => e.PostCodeCus).HasMaxLength(550);

            entity.Property(e => e.PostCodePoBox).HasMaxLength(550);

            entity.Property(e => e.Street1).HasMaxLength(550);

            entity.Property(e => e.Street2).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.Term1).HasMaxLength(550);

            entity.Property(e => e.Term2).HasMaxLength(550);

            entity.Property(e => e.Web).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat200>(entity =>
        {
            entity.Property(e => e.Accesory).HasMaxLength(550);

            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BatchSize1).HasMaxLength(550);

            entity.Property(e => e.BatchSize2).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.MatCert).HasMaxLength(550);

            entity.Property(e => e.Remanufact).HasMaxLength(550);

            entity.Property(e => e.Selferv).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.TermNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat201>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.CurCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.DiscGroup).HasMaxLength(550);

            entity.Property(e => e.Discount).HasMaxLength(550);

            entity.Property(e => e.PrQuantUnit).HasMaxLength(550);

            entity.Property(e => e.PrType).HasMaxLength(550);

            entity.Property(e => e.PrUnit).HasMaxLength(550);

            entity.Property(e => e.Price).HasMaxLength(550);

            entity.Property(e => e.Reserved).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.ValidFrom).HasMaxLength(550);

            entity.Property(e => e.ValidTo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat202>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat203>(entity =>
        {
            entity.Property(e => e.Additive).HasMaxLength(550);

            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.ManNo).HasMaxLength(550);

            entity.Property(e => e.RefNo).HasMaxLength(550);

            entity.Property(e => e.ReferenceInfo).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat204>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.SupersNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat205>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.PartGenArtNo).HasMaxLength(550);

            entity.Property(e => e.PartNo).HasMaxLength(550);

            entity.Property(e => e.Quantity).HasMaxLength(550);

            entity.Property(e => e.SeqNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat206>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.FirstPage).HasMaxLength(550);

            entity.Property(e => e.InfType).HasMaxLength(550);

            entity.Property(e => e.Reserved).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.TxtModNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat207>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.FirstPage).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.TradeNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat208>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CritNo).HasMaxLength(550);

            entity.Property(e => e.CritVal).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Reserved).HasMaxLength(550);

            entity.Property(e => e.Reserved2).HasMaxLength(550);

            entity.Property(e => e.SeqNo).HasMaxLength(550);

            entity.Property(e => e.SeqNo2).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat209>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.GTIN).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat210>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.CritNo).HasMaxLength(550);

            entity.Property(e => e.CritVal).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.FirstPage).HasMaxLength(550);

            entity.Property(e => e.Reserved).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat211>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(22);

            entity.Property(e => e.BrandNo).HasMaxLength(4);

            entity.Property(e => e.DeleteFlag).HasMaxLength(1);

            entity.Property(e => e.GenArtNo).HasMaxLength(5);

            entity.Property(e => e.TableNo).HasMaxLength(3);
        });

        modelBuilder.Entity<Dat212>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.ArtStat).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.QuantityPerUnit).HasMaxLength(550);

            entity.Property(e => e.QuantityUnit).HasMaxLength(550);

            entity.Property(e => e.StatusDat).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat213>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.CritNo).HasMaxLength(550);

            entity.Property(e => e.CritVal).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.FirstPage).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat215>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.SeqNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat217>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CoordNo).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.DocNo).HasMaxLength(550);

            entity.Property(e => e.DocType).HasMaxLength(550);

            entity.Property(e => e.LangNo).HasMaxLength(550);

            entity.Property(e => e.SeqNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat222>(entity =>
        {
            entity.Property(e => e.AccArtNo).HasMaxLength(550);

            entity.Property(e => e.AccGenArtNo).HasMaxLength(550);

            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.LnkType).HasMaxLength(550);

            entity.Property(e => e.LnkVal).HasMaxLength(550);

            entity.Property(e => e.Quantity).HasMaxLength(550);

            entity.Property(e => e.Reserved).HasMaxLength(550);

            entity.Property(e => e.SeqNo).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.TermNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat231>(entity =>
        {
            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.Colors).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.DocContentType).HasMaxLength(550);

            entity.Property(e => e.DocName).HasMaxLength(550);

            entity.Property(e => e.DocNo).HasMaxLength(550);

            entity.Property(e => e.DocTermNorm).HasMaxLength(550);

            entity.Property(e => e.DocType).HasMaxLength(550);

            entity.Property(e => e.FileExtension).HasMaxLength(550);

            entity.Property(e => e.Hash).HasMaxLength(550);

            entity.Property(e => e.Height).HasMaxLength(550);

            entity.Property(e => e.LangNo).HasMaxLength(550);

            entity.Property(e => e.Reserved).HasMaxLength(550);

            entity.Property(e => e.SourceUrl).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.TermNo).HasMaxLength(550);

            entity.Property(e => e.Url).HasMaxLength(550);

            entity.Property(e => e.Width).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat232>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.DocNo).HasMaxLength(550);

            entity.Property(e => e.DocType).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat233>(entity =>
        {
            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CoordNo).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.DocNo).HasMaxLength(550);

            entity.Property(e => e.DocType).HasMaxLength(550);

            entity.Property(e => e.LangNo).HasMaxLength(550);

            entity.Property(e => e.SeqNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.TargetPartNumber).HasMaxLength(550);

            entity.Property(e => e.Type).HasMaxLength(550);

            entity.Property(e => e.X1).HasMaxLength(550);

            entity.Property(e => e.X2).HasMaxLength(550);

            entity.Property(e => e.Y1).HasMaxLength(550);

            entity.Property(e => e.Y2).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat400>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.GenArtNo).HasMaxLength(550);

            entity.Property(e => e.LnkTargetNo).HasMaxLength(550);

            entity.Property(e => e.LnkTargetType).HasMaxLength(550);

            entity.Property(e => e.SeqNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat401>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.FirstPage).HasMaxLength(550);

            entity.Property(e => e.GenArtNo).HasMaxLength(550);

            entity.Property(e => e.InfType).HasMaxLength(550);

            entity.Property(e => e.LnkTargetNo).HasMaxLength(550);

            entity.Property(e => e.LnkTargetType).HasMaxLength(550);

            entity.Property(e => e.SeqNo).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);

            entity.Property(e => e.TxtModNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat403>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.GenArtNo).HasMaxLength(550);

            entity.Property(e => e.LnkTargetNo).HasMaxLength(550);

            entity.Property(e => e.LnkTargetType).HasMaxLength(550);

            entity.Property(e => e.SeqNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat404>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.GenArtNo).HasMaxLength(550);

            entity.Property(e => e.LnkTargetNo).HasMaxLength(550);

            entity.Property(e => e.LnkTargetType).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat410>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.CritNo).HasMaxLength(550);

            entity.Property(e => e.CritVal).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.FirstPage).HasMaxLength(550);

            entity.Property(e => e.GenArtNo).HasMaxLength(550);

            entity.Property(e => e.LnkTargetNo).HasMaxLength(550);

            entity.Property(e => e.LnkTargetType).HasMaxLength(550);

            entity.Property(e => e.SeqNo).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });

        modelBuilder.Entity<Dat432>(entity =>
        {
            entity.Property(e => e.ArtNo).HasMaxLength(550);

            entity.Property(e => e.BrandNo).HasMaxLength(550);

            entity.Property(e => e.CountryCode).HasMaxLength(550);

            entity.Property(e => e.DeleteFlag).HasMaxLength(550);

            entity.Property(e => e.DocNo).HasMaxLength(550);

            entity.Property(e => e.DocType).HasMaxLength(550);

            entity.Property(e => e.Exclude).HasMaxLength(550);

            entity.Property(e => e.GenArtNo).HasMaxLength(550);

            entity.Property(e => e.LnkTargetNo).HasMaxLength(550);

            entity.Property(e => e.LnkTargetType).HasMaxLength(550);

            entity.Property(e => e.SeqNo).HasMaxLength(550);

            entity.Property(e => e.SortNo).HasMaxLength(550);

            entity.Property(e => e.TableNo).HasMaxLength(550);
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
