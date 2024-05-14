﻿// <auto-generated />
using System;
using InsightHive.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InsightHive.Persistence.Migrations
{
    [DbContext(typeof(InsightHiveDbContext))]
    [Migration("20240512213953_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BadgeReviewer", b =>
                {
                    b.Property<int>("BadgesId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewersId")
                        .HasColumnType("int");

                    b.HasKey("BadgesId", "ReviewersId");

                    b.HasIndex("ReviewersId");

                    b.ToTable("BadgeReviewer");
                });

            modelBuilder.Entity("CategoryFilter", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("FiltersId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "FiltersId");

                    b.HasIndex("FiltersId");

                    b.ToTable("CategoryFilter");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Attachment", b =>
                {
                    b.Property<string>("Image")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.HasKey("Image", "BusinessId");

                    b.HasIndex("BusinessId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Badge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Filter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Filters");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FilterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilterId");

                    b.ToTable("Option");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Rate")
                        .HasColumnType("real");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.ReviewReaction", b =>
                {
                    b.Property<int?>("ReviewId")
                        .HasColumnType("int");

                    b.Property<int>("ReactionId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ReviewId", "ReactionId", "ReviewerId");

                    b.HasIndex("ReactionId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("ReviewsReaction");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BadgeReviewer", b =>
                {
                    b.HasOne("InsightHive.Domain.Entities.Badge", null)
                        .WithMany()
                        .HasForeignKey("BadgesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsightHive.Domain.Entities.Reviewer", null)
                        .WithMany()
                        .HasForeignKey("ReviewersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryFilter", b =>
                {
                    b.HasOne("InsightHive.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsightHive.Domain.Entities.Filter", null)
                        .WithMany()
                        .HasForeignKey("FiltersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Attachment", b =>
                {
                    b.HasOne("InsightHive.Domain.Entities.Business", "Business")
                        .WithMany("Attachments")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Business", b =>
                {
                    b.HasOne("InsightHive.Domain.Entities.Owner", "Owner")
                        .WithOne("Business")
                        .HasForeignKey("InsightHive.Domain.Entities.Business", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsightHive.Domain.Entities.SubCategory", "SubCategory")
                        .WithMany("Businesses")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Comment", b =>
                {
                    b.HasOne("InsightHive.Domain.Entities.Review", "Review")
                        .WithMany("Comments")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsightHive.Domain.Entities.Reviewer", "Reviewer")
                        .WithMany("Comments")
                        .HasForeignKey("ReviewerId");

                    b.Navigation("Review");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Option", b =>
                {
                    b.HasOne("InsightHive.Domain.Entities.Filter", "Filter")
                        .WithMany("Options")
                        .HasForeignKey("FilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filter");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Owner", b =>
                {
                    b.HasOne("InsightHive.Domain.Entities.User", "User")
                        .WithOne("Owner")
                        .HasForeignKey("InsightHive.Domain.Entities.Owner", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Review", b =>
                {
                    b.HasOne("InsightHive.Domain.Entities.Business", "Business")
                        .WithMany("Reviews")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsightHive.Domain.Entities.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId");

                    b.Navigation("Business");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.ReviewReaction", b =>
                {
                    b.HasOne("InsightHive.Domain.Entities.Reaction", "Reaction")
                        .WithMany("ReviewReactions")
                        .HasForeignKey("ReactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsightHive.Domain.Entities.Review", "Review")
                        .WithMany("ReviewReactions")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("InsightHive.Domain.Entities.Reviewer", "Reviewer")
                        .WithMany("ReviewReactions")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reaction");

                    b.Navigation("Review");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Reviewer", b =>
                {
                    b.HasOne("InsightHive.Domain.Entities.User", "User")
                        .WithOne("Reviewer")
                        .HasForeignKey("InsightHive.Domain.Entities.Reviewer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.SubCategory", b =>
                {
                    b.HasOne("InsightHive.Domain.Entities.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.User", b =>
                {
                    b.HasOne("InsightHive.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Business", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Filter", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Owner", b =>
                {
                    b.Navigation("Business")
                        .IsRequired();
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Reaction", b =>
                {
                    b.Navigation("ReviewReactions");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Review", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ReviewReactions");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Reviewer", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ReviewReactions");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.SubCategory", b =>
                {
                    b.Navigation("Businesses");
                });

            modelBuilder.Entity("InsightHive.Domain.Entities.User", b =>
                {
                    b.Navigation("Owner");

                    b.Navigation("Reviewer");
                });
#pragma warning restore 612, 618
        }
    }
}