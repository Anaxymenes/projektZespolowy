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
    [Migration("20180509191216_Migration_Initial")]
    partial class Migration_Initial
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

                    b.Property<int>("RoleId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Data.DBModels.AccountDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("AccountDetails");
                });

            modelBuilder.Entity("Data.DBModels.AccountHobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<int?>("HobbyId");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("HobbyId");

                    b.ToTable("AccountHobby");
                });

            modelBuilder.Entity("Data.DBModels.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Data.DBModels.Conversation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FirstUserId");

                    b.Property<string>("Name");

                    b.Property<int?>("SecondUserId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("FirstUserId");

                    b.HasIndex("SecondUserId");

                    b.ToTable("Conversation");
                });

            modelBuilder.Entity("Data.DBModels.EventDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndAt");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<int?>("PostId");

                    b.Property<DateTime>("StartAt");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("EventDetails");
                });

            modelBuilder.Entity("Data.DBModels.Hobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdministratorId");

                    b.Property<string>("Color");

                    b.Property<string>("Description");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("Hobby");
                });

            modelBuilder.Entity("Data.DBModels.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorId");

                    b.Property<string>("Content");

                    b.Property<int?>("ConversationId");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ConversationId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Data.DBModels.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("Data.DBModels.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostTypeId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostTypeId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Data.DBModels.PostHobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HobbyId");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("HobbyId");

                    b.HasIndex("PostId");

                    b.ToTable("PostHobby");
                });

            modelBuilder.Entity("Data.DBModels.PostType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PostType");
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
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.DBModels.AccountDetails", b =>
                {
                    b.HasOne("Data.DBModels.Account", "Account")
                        .WithOne("AccountDetails")
                        .HasForeignKey("Data.DBModels.AccountDetails", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.DBModels.AccountHobby", b =>
                {
                    b.HasOne("Data.DBModels.Account", "Account")
                        .WithMany("AccountHobbies")
                        .HasForeignKey("AccountId");

                    b.HasOne("Data.DBModels.Hobby", "Hobby")
                        .WithMany("AccountHobbies")
                        .HasForeignKey("HobbyId");
                });

            modelBuilder.Entity("Data.DBModels.Comment", b =>
                {
                    b.HasOne("Data.DBModels.Account", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.DBModels.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.DBModels.Conversation", b =>
                {
                    b.HasOne("Data.DBModels.Account", "FirstUser")
                        .WithMany("FirstUserConversation")
                        .HasForeignKey("FirstUserId");

                    b.HasOne("Data.DBModels.Account", "SecondUser")
                        .WithMany("SecondUserConversation")
                        .HasForeignKey("SecondUserId");
                });

            modelBuilder.Entity("Data.DBModels.EventDetails", b =>
                {
                    b.HasOne("Data.DBModels.Post", "Post")
                        .WithMany("EventDetails")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("Data.DBModels.Hobby", b =>
                {
                    b.HasOne("Data.DBModels.Account", "Administrator")
                        .WithMany("Hobbies")
                        .HasForeignKey("AdministratorId");
                });

            modelBuilder.Entity("Data.DBModels.Message", b =>
                {
                    b.HasOne("Data.DBModels.Account", "Author")
                        .WithMany("Messages")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Data.DBModels.Conversation", "Conversation")
                        .WithMany("Messages")
                        .HasForeignKey("ConversationId");
                });

            modelBuilder.Entity("Data.DBModels.Picture", b =>
                {
                    b.HasOne("Data.DBModels.Post", "Post")
                        .WithMany("Pictures")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.DBModels.Post", b =>
                {
                    b.HasOne("Data.DBModels.Account", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.DBModels.PostType", "PostType")
                        .WithMany("Posts")
                        .HasForeignKey("PostTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.DBModels.PostHobby", b =>
                {
                    b.HasOne("Data.DBModels.Hobby", "Hooby")
                        .WithMany("PostHobbies")
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.DBModels.Post", "Post")
                        .WithMany("PostHobbies")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}