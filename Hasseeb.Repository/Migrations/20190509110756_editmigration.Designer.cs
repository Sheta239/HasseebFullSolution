﻿// <auto-generated />
using System;
using Hasseeb.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hasseeb.Repository.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20190509110756_editmigration")]
    partial class editmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hasseeb.Application.Domain.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountDesc");

                    b.Property<string>("AccountName");

                    b.Property<int?>("AccountNatureID");

                    b.Property<string>("AccountSerial");

                    b.Property<bool>("Active");

                    b.Property<DateTime>("AddDate");

                    b.Property<int>("GroupOrder");

                    b.Property<bool>("IsMain");

                    b.Property<int?>("ParentAccountID");

                    b.HasKey("ID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Hasseeb.Application.Domain.AccountNature", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNatureName");

                    b.HasKey("ID");

                    b.ToTable("AccountNatures");
                });
#pragma warning restore 612, 618
        }
    }
}
