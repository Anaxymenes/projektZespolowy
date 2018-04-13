﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Repository;
using System;

namespace Repository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20180413080957_Migration_13042018_0002")]
    partial class Migration_13042018_0002
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.DBModels.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordSalt");

                    b.Property<int?>("RoleId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Data.DBModels.AccountDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountDetails");
                });

            modelBuilder.Entity("Data.DBModels.AccountHobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountHobby");
                });

            modelBuilder.Entity("Data.DBModels.Hobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountHobbyId");

                    b.Property<int?>("AdministratorId");

                    b.Property<string>("Color");

                    b.Property<string>("Description");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AccountHobbyId");

                    b.HasIndex("AdministratorId");

                    b.ToTable("Hobby");
                });

            modelBuilder.Entity("Data.DBModels.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Data.DBModels.Account", b =>
                {
                    b.HasOne("Data.DBModels.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Data.DBModels.AccountDetails", b =>
                {
                    b.HasOne("Data.DBModels.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("Data.DBModels.AccountHobby", b =>
                {
                    b.HasOne("Data.DBModels.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("Data.DBModels.Hobby", b =>
                {
                    b.HasOne("Data.DBModels.AccountHobby")
                        .WithMany("Hobbies")
                        .HasForeignKey("AccountHobbyId");

                    b.HasOne("Data.DBModels.Account", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorId");
                });
#pragma warning restore 612, 618
        }
    }
}
