using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TecDocStorageFlattener.Models.Contexts.TecdocReference22;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

public partial class TecdocReference22DbContext : DbContext
{
    public TecdocReference22DbContext()
    {
    }

    public TecdocReference22DbContext(DbContextOptions<TecdocReference22DbContext> options)
        : base(options)
    {
    }

    #region DbSets
    public virtual DbSet<In001> In001s => Set<In001>();
    public virtual DbSet<In010> In010s => Set<In010>();
    public virtual DbSet<In012> In012s => Set<In012>();
    public virtual DbSet<In013> In013s => Set<In013>();
    public virtual DbSet<In014> In014s => Set<In014>();
    public virtual DbSet<In020> In020s => Set<In020>();
    public virtual DbSet<In030> In030s => Set<In030>();
    public virtual DbSet<In031> In031s => Set<In031>();
    public virtual DbSet<In050> In050s => Set<In050>();
    public virtual DbSet<In051> In051s => Set<In051>();
    public virtual DbSet<In052> In052s => Set<In052>();
    public virtual DbSet<In053> In053s => Set<In053>();
    public virtual DbSet<In100> In100s => Set<In100>();
    public virtual DbSet<In103> In103s => Set<In103>();
    public virtual DbSet<In110> In110s => Set<In110>();
    public virtual DbSet<In120> In120s => Set<In120>();
    public virtual DbSet<In121> In121s => Set<In121>();
    public virtual DbSet<In122> In122s => Set<In122>();
    public virtual DbSet<In124> In124s => Set<In124>();
    public virtual DbSet<In125> In125s => Set<In125>();
    public virtual DbSet<In140> In140s => Set<In140>();
    public virtual DbSet<In143> In143s => Set<In143>();
    public virtual DbSet<In144> In144s => Set<In144>();
    public virtual DbSet<In145> In145s => Set<In145>();
    public virtual DbSet<In146> In146s => Set<In146>();
    public virtual DbSet<In147> In147s => Set<In147>();
    public virtual DbSet<In155> In155s => Set<In155>();
    public virtual DbSet<In156> In156s => Set<In156>();
    public virtual DbSet<In160> In160s => Set<In160>();
    public virtual DbSet<In161> In161s => Set<In161>();
    public virtual DbSet<In162> In162s => Set<In162>();
    public virtual DbSet<In163> In163s => Set<In163>();
    public virtual DbSet<In164> In164s => Set<In164>();
    public virtual DbSet<In180> In180s => Set<In180>();
    public virtual DbSet<In301> In301s => Set<In301>();
    public virtual DbSet<In302> In302s => Set<In302>();
    public virtual DbSet<In304> In304s => Set<In304>();
    public virtual DbSet<In305> In305s => Set<In305>();
    public virtual DbSet<In306> In306s => Set<In306>();
    public virtual DbSet<In307> In307s => Set<In307>();
    public virtual DbSet<In320> In320s => Set<In320>();
    public virtual DbSet<In323> In323s => Set<In323>();
    public virtual DbSet<In324> In324s => Set<In324>();
    public virtual DbSet<In325> In325s => Set<In325>();
    public virtual DbSet<In327> In327s => Set<In327>();
    public virtual DbSet<In328> In328s => Set<In328>();
    public virtual DbSet<In329> In329s => Set<In329>();
    public virtual DbSet<In330> In330s => Set<In330>();
    public virtual DbSet<In331> In331s => Set<In331>();
    public virtual DbSet<In332> In332s => Set<In332>();
    public virtual DbSet<In333> In333s => Set<In333>();
    public virtual DbSet<In334> In334s => Set<In334>();
    public virtual DbSet<In340> In340s => Set<In340>();
    public virtual DbSet<In532> In532s => Set<In532>();
    public virtual DbSet<In533> In533s => Set<In533>();
    public virtual DbSet<In534> In534s => Set<In534>();
    public virtual DbSet<In535> In535s => Set<In535>();
    public virtual DbSet<In536> In536s => Set<In536>();
    public virtual DbSet<In537> In537s => Set<In537>();
    public virtual DbSet<In538> In538s => Set<In538>();
    public virtual DbSet<In539> In539s => Set<In539>();
    public virtual DbSet<In540> In540s => Set<In540>();
    public virtual DbSet<In541> In541s => Set<In541>();
    public virtual DbSet<In542> In542s => Set<In542>();
    public virtual DbSet<In543> In543s => Set<In543>();
    public virtual DbSet<In550> In550s => Set<In550>();
    public virtual DbSet<In551> In551s => Set<In551>();
    public virtual DbSet<In554> In554s => Set<In554>();
    public virtual DbSet<In555> In555s => Set<In555>();
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=TecdocReference22");
        }
    }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Possible null reference return.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<In010>(entity =>
        {
            entity.HasIndex(e => new { e.IstGruppe, e.Lkz })
                .HasDatabaseName("IDX_Ex2");
        });

        modelBuilder.Entity<In012>(entity =>
        {
            entity.HasIndex(e => new { e.SprachNr, e.LbezNr })
                .HasDatabaseName("idx_1");

            entity.HasIndex(e => new { e.SprachNr, e.LbezNr, e.Lkz })
                .HasDatabaseName("idx_2");
        });

        modelBuilder.Entity<In013>(entity =>
        {
            entity.HasIndex(e => e.Lkzgrp)
                .HasDatabaseName("IDX_Ex1");

            entity.HasIndex(e => new { e.Lkz, e.Lkzgrp })
                .HasDatabaseName("idx_IsVehicleInRegion");
        });

        modelBuilder.Entity<In030>(entity =>
        {
            entity.HasIndex(e => new { e.BezNr, e.SprachNr })
                .HasDatabaseName("idx_Read2");

            entity.HasIndex(e => new { e.SprachNr, e.BezNr })
                .HasDatabaseName("idx_1");
        });

        modelBuilder.Entity<In031>(entity =>
        {
            entity.HasIndex(e => new { e.BezNr, e.SprachNr })
                .HasDatabaseName("idx_Read2");

            entity.HasIndex(e => new { e.SprachNr, e.BezNr })
                .HasDatabaseName("idx_1");
        });

        modelBuilder.Entity<In050>(entity =>
        {
            entity.HasIndex(e => e.TabNr)
                .HasDatabaseName("idx_Crit2");
        });

        modelBuilder.Entity<In051>(entity =>
        {
            entity.HasIndex(e => e.TabNr)
                .HasDatabaseName("idx_Crit3");
        });

        modelBuilder.Entity<In053>(entity =>
        {
            entity.HasIndex(e => e.TabNr)
                .HasDatabaseName("idx_Crit2");
        });

        modelBuilder.Entity<In100>(entity =>
        {
            entity.HasIndex(e => new { e.LbezNr, e.HerNr })
                .HasDatabaseName("idx_tEngine_LangNeutral")
                .IsUnique();
        });

        modelBuilder.Entity<In120>(entity =>
        {
            entity.HasIndex(e => e.KtypNr)
                .HasDatabaseName("idx_K1");
        });

        modelBuilder.Entity<In122>(entity =>
        {
            entity.HasIndex(e => e.KtypNr)
                .HasDatabaseName("idx_K1");

            entity.HasIndex(e => new { e.KtypNr, e.Exclude })
                .HasDatabaseName("idx_K2");

            entity.HasIndex(e => new { e.KtypNr, e.Exclude, e.Lkz })
                .HasDatabaseName("idx_K3");

            entity.HasIndex(e => new { e.Lkz, e.KtypNr, e.Exclude })
                .HasDatabaseName("idx_IsVehicleInRegion");
        });

        modelBuilder.Entity<In532>(entity =>
        {
            entity.HasIndex(e => e.NtypNr)
                .HasDatabaseName("idx_N1");
        });

        modelBuilder.Entity<In533>(entity =>
        {
            entity.HasIndex(e => e.NtypNr)
                .HasDatabaseName("idx_N1");

            entity.HasIndex(e => new { e.NtypNr, e.Exclude })
                .HasDatabaseName("idx_N2");

            entity.HasIndex(e => new { e.Lkz, e.NtypNr, e.Exclude })
                .HasDatabaseName("idx_IsVehicleInRegion");

            entity.HasIndex(e => new { e.NtypNr, e.Exclude, e.Lkz })
                .HasDatabaseName("idx_N3");
        });

        OnModelCreatingPartial(modelBuilder);
    }
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
