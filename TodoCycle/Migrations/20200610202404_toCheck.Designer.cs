﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoCycle.Models.DB.Contexts;

namespace TodoCycle.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200610202404_toCheck")]
    partial class toCheck
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("TodoCycle.Models.DB.TodoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TodoListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TodoListId");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("TodoCycle.Models.DB.TodoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TodoLists");
                });

            modelBuilder.Entity("TodoCycle.Models.DB.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<int?>("TodoListId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TodoListId1")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TodoListId");

                    b.HasIndex("TodoListId1");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TodoCycle.Models.DB.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TodoListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TodoListId");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("TodoCycle.Models.DB.TodoItem", b =>
                {
                    b.HasOne("TodoCycle.Models.DB.TodoList", null)
                        .WithMany("TodoItems")
                        .HasForeignKey("TodoListId");
                });

            modelBuilder.Entity("TodoCycle.Models.DB.User", b =>
                {
                    b.HasOne("TodoCycle.Models.DB.TodoList", null)
                        .WithMany("AllUsersWithAccess")
                        .HasForeignKey("TodoListId");

                    b.HasOne("TodoCycle.Models.DB.TodoList", null)
                        .WithMany("Users")
                        .HasForeignKey("TodoListId1");

                    b.HasOne("TodoCycle.Models.DB.UserGroup", null)
                        .WithMany("UsersInGroup")
                        .HasForeignKey("UserGroupId");
                });

            modelBuilder.Entity("TodoCycle.Models.DB.UserGroup", b =>
                {
                    b.HasOne("TodoCycle.Models.DB.TodoList", null)
                        .WithMany("UserGroups")
                        .HasForeignKey("TodoListId");
                });
#pragma warning restore 612, 618
        }
    }
}
