﻿// <auto-generated />
using JSONAmveraAPIApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JSONAmveraAPIApp.Migrations
{
    [DbContext(typeof(PostgreSQLDBContext))]
    [Migration("20221226165438_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JSONAmveraAPIApp.Model.Entities.KnownHost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("HostName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("KnownHosts");
                });

            modelBuilder.Entity("JSONAmveraAPIApp.Model.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("KnownHostId")
                        .HasColumnType("integer");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isHttps")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("KnownHostId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("JSONAmveraAPIApp.Model.Entities.Request", b =>
                {
                    b.HasOne("JSONAmveraAPIApp.Model.Entities.KnownHost", "KnownHost")
                        .WithMany()
                        .HasForeignKey("KnownHostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KnownHost");
                });
#pragma warning restore 612, 618
        }
    }
}
