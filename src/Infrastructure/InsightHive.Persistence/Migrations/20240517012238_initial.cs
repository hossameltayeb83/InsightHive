using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsightHive.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFilter",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    FiltersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFilter", x => new { x.CategoriesId, x.FiltersId });
                    table.ForeignKey(
                        name: "FK_CategoryFilter_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryFilter_Filters_FiltersId",
                        column: x => x.FiltersId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FilterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Filters_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owners_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviewers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviewers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Businesses_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BadgeReviewer",
                columns: table => new
                {
                    BadgesId = table.Column<int>(type: "int", nullable: false),
                    ReviewersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadgeReviewer", x => new { x.BadgesId, x.ReviewersId });
                    table.ForeignKey(
                        name: "FK_BadgeReviewer_Badges_BadgesId",
                        column: x => x.BadgesId,
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BadgeReviewer_Reviewers_ReviewersId",
                        column: x => x.ReviewersId,
                        principalTable: "Reviewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => new { x.Image, x.BusinessId });
                    table.ForeignKey(
                        name: "FK_Attachments_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessOption",
                columns: table => new
                {
                    BusinessesId = table.Column<int>(type: "int", nullable: false),
                    OptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessOption", x => new { x.BusinessesId, x.OptionsId });
                    table.ForeignKey(
                        name: "FK_BusinessOption_Businesses_BusinessesId",
                        column: x => x.BusinessesId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessOption_Options_OptionsId",
                        column: x => x.OptionsId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    ReviewerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Reviewers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Reviewers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    ReviewerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Reviewers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Reviewers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewsReaction",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    ReactionId = table.Column<int>(type: "int", nullable: false),
                    ReviewerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsReaction", x => new { x.ReviewId, x.ReactionId, x.ReviewerId });
                    table.ForeignKey(
                        name: "FK_ReviewsReaction_Reactions_ReactionId",
                        column: x => x.ReactionId,
                        principalTable: "Reactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewsReaction_Reviewers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Reviewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewsReaction_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Badges/1_img.png", "TopContributor" },
                    { 2, "Badges/2_img.png", "CommentsMaster" },
                    { 3, "Badges/3_img.png", "ReviewsEmperor" },
                    { 4, "Badges/4_img.png", "ReactionsLord" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Jewelery" },
                    { 2, "Games" },
                    { 3, "Computers" },
                    { 4, "Outdoors" }
                });

            migrationBuilder.InsertData(
                table: "Filters",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Games, Computers & Outdoors" },
                    { 2, "Tools & Music" },
                    { 3, "Movies, Health & Clothing" },
                    { 4, "Sports, Health & Health" },
                    { 5, "Tools & Health" }
                });

            migrationBuilder.InsertData(
                table: "Reactions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Like" },
                    { 2, "Dislike" },
                    { 3, "Helpful" },
                    { 4, "Exciting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Content", "FilterId" },
                values: new object[,]
                {
                    { 1, "Gorgeous Fresh Shoes", 1 },
                    { 2, "partnerships", 1 },
                    { 3, "Associate", 1 },
                    { 4, "Buckinghamshire", 1 },
                    { 5, "Assistant", 1 },
                    { 6, "Borders", 2 },
                    { 7, "target", 2 },
                    { 8, "rich", 2 },
                    { 9, "Manager", 3 },
                    { 10, "hack", 3 },
                    { 11, "channels", 4 },
                    { 12, "Field", 4 },
                    { 13, "web-readiness", 4 },
                    { 14, "seamless", 4 },
                    { 15, "calculating", 5 },
                    { 16, "systems", 5 },
                    { 17, "Handcrafted Metal Table", 5 }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Games" },
                    { 2, 1, "Computers" },
                    { 3, 1, "Outdoors" },
                    { 4, 1, "Health" },
                    { 5, 1, "Tools" },
                    { 6, 2, "Industrial" },
                    { 7, 2, "Movies" },
                    { 8, 3, "Clothing" },
                    { 9, 3, "Industrial" },
                    { 10, 3, "Sports" },
                    { 11, 4, "Health" },
                    { 12, 4, "Baby" },
                    { 13, 4, "Tools" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "RoleId" },
                values: new object[,]
                {
                    { 1, "owner1@gmail.com", "Pansy89", 1 },
                    { 2, "reviewer1@gmail.com", "Gust.Breitenberg49", 2 },
                    { 3, "reviewer2@gmail.com", "Winnifred.Schuppe", 2 },
                    { 4, "owner2@gmail.com", "Gabriella_Kunze", 1 },
                    { 5, "owner3@gmail.com", "William.Emmerich60", 1 },
                    { 6, "owner4@gmail.com", "Chase41", 1 },
                    { 7, "reviewer3@gmail.com", "Felicia_Morissette", 2 },
                    { 8, "reviewer4@gmail.com", "Hazle69", 2 },
                    { 9, "reviewer5@gmail.com", "Helmer81", 2 },
                    { 10, "reviewer6@gmail.com", "Rosie.McKenzie", 2 },
                    { 11, "reviewer7@gmail.com", "Pasquale80", 2 },
                    { 12, "reviewer8@gmail.com", "Jarrod_Roberts92", 2 },
                    { 13, "owner5@gmail.com", "Rupert_Blanda20", 1 },
                    { 14, "owner6@gmail.com", "Lori_Turner20", 1 },
                    { 15, "owner7@gmail.com", "Jasen67", 1 },
                    { 16, "reviewer9@gmail.com", "Norbert_McClure", 2 },
                    { 17, "reviewer10@gmail.com", "Hilton.Fritsch56", 2 },
                    { 18, "owner8@gmail.com", "Dewitt.Pacocha76", 1 },
                    { 19, "reviewer11@gmail.com", "Kenton.Balistreri", 2 },
                    { 20, "owner9@gmail.com", "Nathanael.Wilkinson", 1 }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "BusinessId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 4 },
                    { 3, 3, 5 },
                    { 4, 4, 6 },
                    { 5, 5, 13 },
                    { 6, 6, 14 },
                    { 7, 7, 15 },
                    { 8, 8, 18 },
                    { 9, 9, 20 }
                });

            migrationBuilder.InsertData(
                table: "Reviewers",
                columns: new[] { "Id", "Age", "Gender", "Image", "UserId" },
                values: new object[,]
                {
                    { 1, 82, 0, "Review\\1_img.png", 2 },
                    { 2, 98, 0, "Review\\2_img.png", 3 },
                    { 3, 57, 1, "Review\\3_img.png", 7 },
                    { 4, 47, 2, "Review\\4_img.png", 8 },
                    { 5, 35, 2, "Review\\5_img.png", 9 },
                    { 6, 32, 1, "Review\\6_img.png", 10 },
                    { 7, 21, 1, "Review\\7_img.png", 11 },
                    { 8, 87, 2, "Review\\8_img.png", 12 },
                    { 9, 72, 1, "Review\\9_img.png", 16 },
                    { 10, 87, 1, "Review\\10_img.png", 17 },
                    { 11, 98, 2, "Review\\11_img.png", 19 }
                });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "Id", "Description", "Logo", "Name", "OwnerId", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, "Odit maiores quasi quos impedit maiores. Voluptatum deleniti facilis quis dolores ex asperiores eos voluptatibus. Voluptas voluptatem id molestiae. Qui numquam esse eaque.", "Business\\1_img.png", "Cremin, Flatley and Trantow", 1, 11 },
                    { 2, "Quam fuga voluptatem optio distinctio nihil aut dicta. Voluptas pariatur officia cupiditate ipsam maiores temporibus culpa velit. Itaque voluptatum maxime rerum reiciendis non provident at architecto. Quidem sed aut quidem et tenetur accusamus sed. Voluptatum natus fugit cum laboriosam. Culpa officia molestiae ut et magnam assumenda esse similique.", "Business\\2_img.png", "Morissette - Hintz", 2, 2 },
                    { 3, "Magni similique accusantium esse quia rerum maxime tenetur dolorum. Fugit officia veniam est dolore. Quibusdam ea quia in laboriosam id tenetur facilis nihil.", "Business\\3_img.png", "Gislason, Pacocha and Rippin", 3, 4 },
                    { 4, "Dolores accusantium non ut doloribus. Voluptatem neque quia. Harum nemo ut ipsam distinctio atque eligendi voluptatem sunt. Enim laborum omnis molestiae cupiditate laborum. Asperiores enim pariatur quia incidunt reiciendis.", "Business\\4_img.png", "Schamberger, Leuschke and Reilly", 4, 12 },
                    { 5, "Aliquam minus sed et alias error. Ullam esse sit omnis vel aspernatur numquam quidem. Aut occaecati magnam aut. Vel nihil ut at ad fuga ea voluptas blanditiis. Aut qui ipsam et ex. Doloremque laborum non quisquam modi adipisci ab ut non facere.", "Business\\5_img.png", "Wunsch LLC", 5, 7 },
                    { 6, "Et omnis debitis accusantium ut. Est itaque corporis aut sapiente repellat. Est dolor voluptatem minima dolore voluptatibus voluptates ipsa. Animi sit expedita aperiam molestiae occaecati.", "Business\\6_img.png", "Mertz, Schmitt and Blanda", 6, 6 },
                    { 7, "Autem beatae voluptas consectetur voluptas distinctio rerum rerum enim. Dolore ut illo in minima ut. Ipsam omnis explicabo omnis ut enim tenetur eligendi quis. Laudantium sed corporis quos.", "Business\\7_img.png", "Schroeder - Ledner", 7, 2 },
                    { 8, "Sit sapiente hic officia laboriosam voluptatem assumenda. Aliquid rerum id blanditiis facilis omnis autem dolores ut quis. Cupiditate consequatur vel dolores a. Quia soluta ut molestiae quibusdam expedita. Quo impedit hic debitis consequatur delectus facere provident et nemo. Maxime assumenda dolor qui et molestias repellat.", "Business\\8_img.png", "Mayert - Casper", 8, 13 },
                    { 9, "Quia totam doloribus dolorem dolorem laboriosam et aperiam omnis. Tempore quod itaque animi sint. Consequatur sed temporibus accusantium. Non placeat consectetur facilis ex doloremque praesentium.", "Business\\9_img.png", "Greenfelder - Schneider", 9, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BusinessId", "Content", "CreatedDate", "Image", "LastModifiedDate", "Rate", "ReviewerId" },
                values: new object[,]
                {
                    { 1, 1, "My scarab beetle loves to play with it.", new DateTime(2024, 5, 9, 9, 59, 26, 248, DateTimeKind.Unspecified).AddTicks(1043), "Review\\1_img.png", null, 4.5769377f, 1 },
                    { 2, 1, "I tried to hang it but got jelly bean all over it.", new DateTime(2024, 5, 1, 19, 26, 32, 739, DateTimeKind.Unspecified).AddTicks(3181), "Review\\2_img.png", null, 4.937152f, 1 },
                    { 3, 1, "My neighbor Montserrat has one of these. She works as a circus performer and she says it looks shriveled.", new DateTime(2024, 4, 29, 5, 24, 46, 918, DateTimeKind.Unspecified).AddTicks(4510), "Review\\3_img.png", null, 4.9407034f, 1 },
                    { 4, 1, "I saw one of these in Spratly Islands and I bought one.", new DateTime(2024, 4, 29, 17, 21, 23, 763, DateTimeKind.Unspecified).AddTicks(1055), "Review\\4_img.png", null, 3.5735576f, 1 },
                    { 5, 1, "The box this comes in is 4 mile by 5 inch and weights 19 megaton!", new DateTime(2024, 4, 29, 3, 21, 43, 972, DateTimeKind.Unspecified).AddTicks(3736), "Review\\5_img.png", null, 4.9788556f, 1 },
                    { 6, 1, "My co-worker Alek has one of these. He says it looks white.", new DateTime(2024, 5, 7, 11, 44, 24, 890, DateTimeKind.Unspecified).AddTicks(4267), "Review\\6_img.png", null, 1.6003393f, 2 },
                    { 7, 1, "i use it once a week when i'm in my firetruck.", new DateTime(2024, 5, 1, 3, 44, 13, 982, DateTimeKind.Unspecified).AddTicks(5934), "Review\\7_img.png", null, 2.8085613f, 2 },
                    { 8, 1, "this product is ratty.", new DateTime(2024, 5, 1, 12, 4, 15, 445, DateTimeKind.Unspecified).AddTicks(7077), "Review\\8_img.png", null, 2.4010842f, 2 },
                    { 9, 1, "heard about this on wonky radio, decided to give it a try.", new DateTime(2024, 5, 2, 20, 2, 33, 342, DateTimeKind.Unspecified).AddTicks(8886), "Review\\9_img.png", null, 3.9565077f, 2 },
                    { 10, 1, "I tried to scratch it but got cheeseburger all over it.", new DateTime(2024, 4, 25, 6, 24, 12, 638, DateTimeKind.Unspecified).AddTicks(3194), "Review\\10_img.png", null, 3.7901113f, 2 },
                    { 11, 4, "I tried to behead it but got truffle all over it.", new DateTime(2024, 5, 10, 22, 9, 46, 507, DateTimeKind.Unspecified).AddTicks(4440), "Review\\11_img.png", null, 4.243056f, 3 },
                    { 12, 2, "one of my hobbies is piano. and when i'm playing piano this works great.", new DateTime(2024, 4, 18, 12, 49, 24, 836, DateTimeKind.Unspecified).AddTicks(20), "Review\\12_img.png", null, 3.102196f, 3 },
                    { 13, 1, "My co-worker Luka has one of these. He says it looks purple.", new DateTime(2024, 4, 14, 9, 54, 30, 620, DateTimeKind.Unspecified).AddTicks(557), "Review\\13_img.png", null, 3.3245635f, 3 },
                    { 14, 4, "I saw one of these in Barbados and I bought one.", new DateTime(2024, 4, 15, 22, 15, 1, 357, DateTimeKind.Unspecified).AddTicks(6776), "Review\\14_img.png", null, 3.9765985f, 4 },
                    { 15, 4, "talk about sadness!!", new DateTime(2024, 4, 14, 15, 42, 18, 756, DateTimeKind.Unspecified).AddTicks(7247), "Review\\15_img.png", null, 3.1285903f, 4 },
                    { 16, 1, "It only works when I'm Argentina.", new DateTime(2024, 5, 11, 17, 20, 31, 472, DateTimeKind.Unspecified).AddTicks(7433), "Review\\16_img.png", null, 3.5396192f, 4 },
                    { 17, 4, "It only works when I'm Mauritania.", new DateTime(2024, 5, 10, 21, 18, 50, 420, DateTimeKind.Unspecified).AddTicks(2169), "Review\\17_img.png", null, 4.6170497f, 4 },
                    { 18, 2, "i use it every Tuesday when i'm in my homeless shelter.", new DateTime(2024, 4, 17, 20, 57, 31, 334, DateTimeKind.Unspecified).AddTicks(541), "Review\\18_img.png", null, 2.188744f, 4 },
                    { 19, 4, "It only works when I'm Wake Island.", new DateTime(2024, 5, 10, 13, 34, 38, 382, DateTimeKind.Unspecified).AddTicks(9827), "Review\\19_img.png", null, 2.3572834f, 5 },
                    { 20, 4, "one of my hobbies is piano. and when i'm playing piano this works great.", new DateTime(2024, 4, 26, 14, 54, 49, 146, DateTimeKind.Unspecified).AddTicks(5914), "Review\\20_img.png", null, 4.706365f, 5 },
                    { 21, 2, "My tyrannosaurus rex loves to play with it.", new DateTime(2024, 5, 1, 2, 9, 44, 825, DateTimeKind.Unspecified).AddTicks(6520), "Review\\21_img.png", null, 4.076521f, 5 },
                    { 22, 3, "heard about this on folktronica radio, decided to give it a try.", new DateTime(2024, 4, 26, 23, 56, 8, 35, DateTimeKind.Unspecified).AddTicks(139), "Review\\22_img.png", null, 2.0507066f, 5 },
                    { 23, 3, "My co-worker Alek has one of these. He says it looks white.", new DateTime(2024, 5, 8, 18, 28, 17, 960, DateTimeKind.Unspecified).AddTicks(8875), "Review\\23_img.png", null, 1.5176834f, 6 },
                    { 24, 3, "This product works considerably well. It mildly improves my basketball by a lot.", new DateTime(2024, 5, 13, 4, 49, 15, 34, DateTimeKind.Unspecified).AddTicks(7007), "Review\\24_img.png", null, 1.7034367f, 6 },
                    { 25, 2, "talk about interest!!", new DateTime(2024, 4, 21, 15, 30, 34, 415, DateTimeKind.Unspecified).AddTicks(7851), "Review\\25_img.png", null, 3.4851463f, 6 },
                    { 26, 3, "one of my hobbies is cooking. and when i'm cooking this works great.", new DateTime(2024, 5, 10, 12, 56, 59, 286, DateTimeKind.Unspecified).AddTicks(16), "Review\\26_img.png", null, 2.1358194f, 6 },
                    { 27, 1, "My co-worker Bryton has one of these. He says it looks ragged.", new DateTime(2024, 4, 19, 8, 40, 22, 974, DateTimeKind.Unspecified).AddTicks(6949), "Review\\27_img.png", null, 2.6193151f, 7 },
                    { 28, 4, "The box this comes in is 3 light-year by 5 meter and weights 10 ounce!", new DateTime(2024, 5, 2, 0, 47, 29, 610, DateTimeKind.Unspecified).AddTicks(1333), "Review\\28_img.png", null, 3.4222252f, 7 },
                    { 29, 3, "heard about this on alternative dance radio, decided to give it a try.", new DateTime(2024, 5, 1, 8, 12, 5, 25, DateTimeKind.Unspecified).AddTicks(1833), "Review\\29_img.png", null, 4.155887f, 8 },
                    { 30, 1, "It only works when I'm Bolivia.", new DateTime(2024, 4, 22, 6, 26, 38, 606, DateTimeKind.Unspecified).AddTicks(9906), "Review\\30_img.png", null, 2.1141865f, 8 },
                    { 31, 4, "I saw one of these in New Zealand and I bought one.", new DateTime(2024, 5, 13, 4, 30, 50, 747, DateTimeKind.Unspecified).AddTicks(3887), "Review\\31_img.png", null, 2.3907282f, 8 },
                    { 32, 1, "My terrier loves to play with it.", new DateTime(2024, 5, 11, 8, 45, 23, 348, DateTimeKind.Unspecified).AddTicks(2821), "Review\\32_img.png", null, 1.6538465f, 8 },
                    { 33, 3, "My goldfinch loves to play with it.", new DateTime(2024, 4, 24, 23, 8, 50, 316, DateTimeKind.Unspecified).AddTicks(5079), "Review\\33_img.png", null, 3.1554272f, 9 },
                    { 34, 3, "I saw one of these in The Gambia and I bought one.", new DateTime(2024, 4, 24, 3, 5, 38, 467, DateTimeKind.Unspecified).AddTicks(8535), "Review\\34_img.png", null, 3.764409f, 9 },
                    { 35, 5, "This product works considerably well. It recklessly improves my basketball by a lot.", new DateTime(2024, 5, 11, 7, 39, 30, 569, DateTimeKind.Unspecified).AddTicks(4789), "Review\\35_img.png", null, 2.077986f, 9 },
                    { 36, 5, "This product works very well. It persistently improves my soccer by a lot.", new DateTime(2024, 4, 20, 17, 40, 48, 350, DateTimeKind.Unspecified).AddTicks(7542), "Review\\36_img.png", null, 3.0954583f, 9 },
                    { 37, 6, "I saw this on TV and wanted to give it a try.", new DateTime(2024, 5, 2, 13, 38, 28, 387, DateTimeKind.Unspecified).AddTicks(6093), "Review\\37_img.png", null, 2.2403383f, 9 },
                    { 38, 7, "talk about pleasure!", new DateTime(2024, 5, 7, 2, 34, 46, 378, DateTimeKind.Unspecified).AddTicks(8842), "Review\\38_img.png", null, 1.3325554f, 10 },
                    { 39, 2, "My neighbor Allean has one of these. She works as a sky diver and she says it looks weedy.", new DateTime(2024, 4, 27, 4, 35, 12, 595, DateTimeKind.Unspecified).AddTicks(9786), "Review\\39_img.png", null, 2.5034802f, 10 },
                    { 40, 5, "My scarab beetle loves to play with it.", new DateTime(2024, 4, 27, 21, 55, 1, 348, DateTimeKind.Unspecified).AddTicks(7364), "Review\\40_img.png", null, 1.0002134f, 11 },
                    { 41, 3, "My vulture loves to play with it.", new DateTime(2024, 4, 22, 19, 21, 5, 782, DateTimeKind.Unspecified).AddTicks(8536), "Review\\41_img.png", null, 2.663874f, 11 },
                    { 42, 2, "The box this comes in is 3 yard by 6 light-year and weights 11 megaton!!", new DateTime(2024, 4, 21, 5, 6, 26, 557, DateTimeKind.Unspecified).AddTicks(3298), "Review\\42_img.png", null, 1.3914783f, 11 },
                    { 43, 5, "i use it barely when i'm in my store.", new DateTime(2024, 4, 24, 22, 47, 8, 37, DateTimeKind.Unspecified).AddTicks(5118), "Review\\43_img.png", null, 1.0362005f, 11 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedDate", "LastModifiedDate", "ReviewId", "ReviewerId" },
                values: new object[,]
                {
                    { 1, "My scarab beetle loves to play with it.", new DateTime(2024, 5, 9, 9, 59, 26, 248, DateTimeKind.Unspecified).AddTicks(1043), null, 2, 1 },
                    { 2, "I saw one of these in South Korea and I bought one.", new DateTime(2024, 4, 17, 4, 9, 4, 289, DateTimeKind.Unspecified).AddTicks(8596), null, 5, 1 },
                    { 3, "I tried to hang it but got jelly bean all over it.", new DateTime(2024, 5, 1, 19, 26, 32, 739, DateTimeKind.Unspecified).AddTicks(3181), null, 3, 1 },
                    { 4, "this product is brown.", new DateTime(2024, 4, 14, 11, 18, 45, 649, DateTimeKind.Unspecified).AddTicks(9719), null, 3, 1 },
                    { 5, "My neighbor Montserrat has one of these. She works as a circus performer and she says it looks shriveled.", new DateTime(2024, 4, 29, 5, 24, 46, 918, DateTimeKind.Unspecified).AddTicks(4510), null, 1, 1 },
                    { 6, "I saw one of these in Barbados and I bought one.", new DateTime(2024, 4, 19, 10, 21, 59, 69, DateTimeKind.Unspecified).AddTicks(5743), null, 5, 2 },
                    { 7, "It only works when I'm Nepal.", new DateTime(2024, 4, 29, 13, 21, 27, 53, DateTimeKind.Unspecified).AddTicks(159), null, 8, 2 },
                    { 8, "I saw one of these in Cote d'Ivoire and I bought one.", new DateTime(2024, 5, 2, 20, 37, 48, 816, DateTimeKind.Unspecified).AddTicks(259), null, 10, 2 },
                    { 9, "I saw this on TV and wanted to give it a try.", new DateTime(2024, 5, 3, 9, 9, 45, 425, DateTimeKind.Unspecified).AddTicks(8885), null, 9, 2 },
                    { 10, "talk about boredom!!!", new DateTime(2024, 5, 9, 20, 9, 23, 823, DateTimeKind.Unspecified).AddTicks(9051), null, 5, 2 },
                    { 11, "I tried to maim it but got nectarine all over it.", new DateTime(2024, 4, 21, 0, 17, 2, 505, DateTimeKind.Unspecified).AddTicks(4582), null, 5, 3 },
                    { 12, "This product works outstandingly well. It beautifully improves my basketball by a lot.", new DateTime(2024, 4, 25, 19, 46, 52, 424, DateTimeKind.Unspecified).AddTicks(1937), null, 7, 3 },
                    { 13, "i use it once in a while when i'm in my ring.", new DateTime(2024, 4, 30, 10, 27, 32, 253, DateTimeKind.Unspecified).AddTicks(5648), null, 3, 4 },
                    { 14, "this product is ratty.", new DateTime(2024, 5, 1, 12, 4, 15, 445, DateTimeKind.Unspecified).AddTicks(7077), null, 18, 4 },
                    { 15, "The box this comes in is 3 meter by 6 yard and weights 12 pound.", new DateTime(2024, 4, 25, 12, 58, 38, 121, DateTimeKind.Unspecified).AddTicks(3135), null, 4, 5 },
                    { 16, "My neighbor Frona has one of these. She works as a gambler and she says it looks bearded.", new DateTime(2024, 4, 18, 14, 34, 54, 901, DateTimeKind.Unspecified).AddTicks(8514), null, 14, 5 },
                    { 17, "It only works when I'm Rwanda.", new DateTime(2024, 5, 1, 10, 41, 52, 914, DateTimeKind.Unspecified).AddTicks(8797), null, 10, 5 },
                    { 18, "It only works when I'm Juan de Nova Island.", new DateTime(2024, 4, 23, 1, 46, 47, 807, DateTimeKind.Unspecified).AddTicks(89), null, 6, 6 },
                    { 19, "I tried to nail it but got strawberry all over it.", new DateTime(2024, 5, 1, 7, 42, 35, 494, DateTimeKind.Unspecified).AddTicks(6477), null, 11, 6 },
                    { 20, "heard about this on Kansas City jazz radio, decided to give it a try.", new DateTime(2024, 4, 19, 16, 14, 59, 711, DateTimeKind.Unspecified).AddTicks(4886), null, 18, 7 },
                    { 21, "one of my hobbies is piano. and when i'm playing piano this works great.", new DateTime(2024, 4, 18, 12, 49, 24, 836, DateTimeKind.Unspecified).AddTicks(20), null, 11, 7 },
                    { 22, "This product, does exactly what it's suppose to do.", new DateTime(2024, 5, 4, 13, 31, 7, 100, DateTimeKind.Unspecified).AddTicks(3628), null, 14, 8 },
                    { 23, "one of my hobbies is antique-shopping. and when i'm antique-shopping this works great.", new DateTime(2024, 4, 20, 8, 5, 12, 51, DateTimeKind.Unspecified).AddTicks(6436), null, 20, 8 },
                    { 24, "My co-worker Erick has one of these. He says it looks fluffy.", new DateTime(2024, 5, 7, 23, 31, 42, 207, DateTimeKind.Unspecified).AddTicks(6390), null, 5, 8 },
                    { 25, "I saw one of these in Barbados and I bought one.", new DateTime(2024, 4, 15, 22, 15, 1, 357, DateTimeKind.Unspecified).AddTicks(6776), null, 23, 8 },
                    { 26, "talk about pleasure!", new DateTime(2024, 4, 17, 9, 7, 53, 703, DateTimeKind.Unspecified).AddTicks(7827), null, 4, 9 },
                    { 27, "I saw one of these in Juan de Nova Island and I bought one.", new DateTime(2024, 4, 16, 2, 40, 11, 401, DateTimeKind.Unspecified).AddTicks(7442), null, 4, 9 },
                    { 28, "this product is vertical.", new DateTime(2024, 4, 18, 8, 8, 7, 321, DateTimeKind.Unspecified).AddTicks(209), null, 30, 9 },
                    { 29, "It only works when I'm Mauritania.", new DateTime(2024, 4, 23, 20, 23, 46, 836, DateTimeKind.Unspecified).AddTicks(4041), null, 32, 9 },
                    { 30, "It only works when I'm Mauritania.", new DateTime(2024, 5, 10, 21, 18, 50, 420, DateTimeKind.Unspecified).AddTicks(2169), null, 21, 10 },
                    { 31, "talk about interest!!", new DateTime(2024, 4, 16, 20, 55, 51, 727, DateTimeKind.Unspecified).AddTicks(1512), null, 13, 10 },
                    { 32, "My Shih-Tzu loves to play with it.", new DateTime(2024, 5, 7, 22, 59, 8, 708, DateTimeKind.Unspecified).AddTicks(2762), null, 25, 11 },
                    { 33, "one of my hobbies is baking. and when i'm baking this works great.", new DateTime(2024, 4, 29, 16, 29, 9, 252, DateTimeKind.Unspecified).AddTicks(6465), null, 9, 11 },
                    { 34, "It only works when I'm Wake Island.", new DateTime(2024, 5, 10, 13, 34, 38, 382, DateTimeKind.Unspecified).AddTicks(9827), null, 35, 11 },
                    { 35, "My co-worker Linnie has one of these. He says it looks wide.", new DateTime(2024, 5, 3, 19, 41, 20, 433, DateTimeKind.Unspecified).AddTicks(3972), null, 41, 11 },
                    { 36, "one of my hobbies is piano. and when i'm playing piano this works great.", new DateTime(2024, 4, 26, 14, 54, 49, 146, DateTimeKind.Unspecified).AddTicks(5914), null, 21, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_BusinessId",
                table: "Attachments",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BadgeReviewer_ReviewersId",
                table: "BadgeReviewer",
                column: "ReviewersId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_OwnerId",
                table: "Businesses",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_SubCategoryId",
                table: "Businesses",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessOption_OptionsId",
                table: "BusinessOption",
                column: "OptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFilter_FiltersId",
                table: "CategoryFilter",
                column: "FiltersId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReviewerId",
                table: "Comments",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReviewId",
                table: "Comments",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_FilterId",
                table: "Options",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_UserId",
                table: "Owners",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviewers_UserId",
                table: "Reviewers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BusinessId",
                table: "Reviews",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsReaction_ReactionId",
                table: "ReviewsReaction",
                column: "ReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsReaction_ReviewerId",
                table: "ReviewsReaction",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "BadgeReviewer");

            migrationBuilder.DropTable(
                name: "BusinessOption");

            migrationBuilder.DropTable(
                name: "CategoryFilter");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ReviewsReaction");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Reviewers");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
