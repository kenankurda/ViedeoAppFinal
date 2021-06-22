﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ViedeoAppFinal.Data;

namespace ViedeoAppFinal.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210622082155_InitCreateDB")]
    partial class InitCreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActorVideo", b =>
                {
                    b.Property<int>("ActorsActorId")
                        .HasColumnType("int");

                    b.Property<int>("VideosVideoId")
                        .HasColumnType("int");

                    b.HasKey("ActorsActorId", "VideosVideoId");

                    b.HasIndex("VideosVideoId");

                    b.ToTable("ActorVideo");
                });

            modelBuilder.Entity("ViedeoAppFinal.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DayOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            ActorId = 1,
                            DayOfBirth = new DateTime(1970, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Kenan",
                            LastName = "Kurda"
                        },
                        new
                        {
                            ActorId = 2,
                            DayOfBirth = new DateTime(1956, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Harrison",
                            LastName = "Ford"
                        },
                        new
                        {
                            ActorId = 3,
                            DayOfBirth = new DateTime(1945, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Antony",
                            LastName = "Hopkins"
                        },
                        new
                        {
                            ActorId = 4,
                            DayOfBirth = new DateTime(1980, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Johny",
                            LastName = "Dep"
                        });
                });

            modelBuilder.Entity("ViedeoAppFinal.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            GenreId = 3,
                            Name = "Action-Comedy"
                        },
                        new
                        {
                            GenreId = 4,
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("ViedeoAppFinal.Models.Video", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VideoId");

                    b.HasIndex("GenreId");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            VideoId = 1,
                            GenreId = 1,
                            Name = "Indiana Johnes"
                        },
                        new
                        {
                            VideoId = 2,
                            GenreId = 1,
                            Name = "Call of wild"
                        },
                        new
                        {
                            VideoId = 3,
                            GenreId = 3,
                            Name = "Pirates of the Caribean"
                        });
                });

            modelBuilder.Entity("ActorVideo", b =>
                {
                    b.HasOne("ViedeoAppFinal.Models.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViedeoAppFinal.Models.Video", null)
                        .WithMany()
                        .HasForeignKey("VideosVideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ViedeoAppFinal.Models.Video", b =>
                {
                    b.HasOne("ViedeoAppFinal.Models.Genre", "Genres")
                        .WithMany("Videos")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("ViedeoAppFinal.Models.Genre", b =>
                {
                    b.Navigation("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}