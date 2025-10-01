using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TecDocStorageFlattener.Models.Contexts.TecdocReference22;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

partial class TecdocReference22DbContext
{
    void OnModelCreating_NonUnicode(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<In010>(entity =>
        {
            entity.Property(e => e.Isocode2).IsUnicode(false);

            entity.Property(e => e.Isocode3).IsUnicode(false);

            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);

            entity.Property(e => e.Verkehr).IsUnicode(false);

            entity.Property(e => e.Vorwahl).IsUnicode(false);

            entity.Property(e => e.Wkz).IsUnicode(false);
        });

        modelBuilder.Entity<In012>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In013>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Lkzgrp).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In014>(entity =>
        {
            entity.Property(e => e.Extension).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In020>(entity =>
        {
            entity.Property(e => e.Isocode).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In030>(entity =>
        {
            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In050>(entity =>
        {
            entity.Property(e => e.MaxLen).IsUnicode(false);

            entity.Property(e => e.Typ).IsUnicode(false);
        });

        modelBuilder.Entity<In051>(entity =>
        {
            entity.Property(e => e.Reserviert).IsUnicode(false);

            entity.Property(e => e.TabTyp).IsUnicode(false);
        });

        modelBuilder.Entity<In052>(entity =>
        {
            entity.Property(e => e.Key).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In053>(entity =>
        {
            entity.Property(e => e.MaxLen).IsUnicode(false);

            entity.Property(e => e.Typ).IsUnicode(false);
        });

        modelBuilder.Entity<In100>(entity =>
        {
            entity.Property(e => e.Hkz).IsUnicode(false);
        });

        modelBuilder.Entity<In103>(entity =>
        {
            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In121>(entity =>
        {
            entity.Property(e => e.Abenr).IsUnicode(false);

            entity.Property(e => e.Kbanr).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);

            entity.Property(e => e.StatHer).IsUnicode(false);

            entity.Property(e => e.StatTyp).IsUnicode(false);
        });

        modelBuilder.Entity<In122>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In124>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In125>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In143>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Muster).IsUnicode(false);
        });

        modelBuilder.Entity<In144>(entity =>
        {
            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In145>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Muster).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In147>(entity =>
        {
            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In155>(entity =>
        {
            entity.Property(e => e.Mcode).IsUnicode(false);

            entity.Property(e => e.VkBez).IsUnicode(false);
        });

        modelBuilder.Entity<In156>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);
        });

        modelBuilder.Entity<In160>(entity =>
        {
            entity.Property(e => e.Bezeichnung).IsUnicode(false);

            entity.Property(e => e.Nabensystem).IsUnicode(false);
        });

        modelBuilder.Entity<In161>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Muster).IsUnicode(false);
        });

        modelBuilder.Entity<In162>(entity =>
        {
            entity.Property(e => e.AchsPos).IsUnicode(false);
        });

        modelBuilder.Entity<In163>(entity =>
        {
            entity.Property(e => e.Bezeichnung).IsUnicode(false);
        });

        modelBuilder.Entity<In164>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);
        });

        modelBuilder.Entity<In301>(entity =>
        {
            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In302>(entity =>
        {
            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In304>(entity =>
        {
            entity.Property(e => e.KritWert).IsUnicode(false);
        });

        modelBuilder.Entity<In305>(entity =>
        {
            entity.Property(e => e.BildName).IsUnicode(false);
        });

        modelBuilder.Entity<In323>(entity =>
        {
            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In324>(entity =>
        {
            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In325>(entity =>
        {
            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In327>(entity =>
        {
            entity.Property(e => e.Bez).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In328>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In329>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In330>(entity =>
        {
            entity.Property(e => e.KritWert).IsUnicode(false);
        });

        modelBuilder.Entity<In532>(entity =>
        {
            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In533>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In534>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In535>(entity =>
        {
            entity.Property(e => e.Bez).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In536>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In537>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In538>(entity =>
        {
            entity.Property(e => e.HerIdNr).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In539>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In540>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In541>(entity =>
        {
            entity.Property(e => e.Baumuster).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In542>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In543>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In550>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In551>(entity =>
        {
            entity.Property(e => e.Lkz).IsUnicode(false);

            entity.Property(e => e.Reserviert).IsUnicode(false);
        });

        modelBuilder.Entity<In554>(entity =>
        {
            entity.Property(e => e.HerId).IsUnicode(false);
        });
    }
}
