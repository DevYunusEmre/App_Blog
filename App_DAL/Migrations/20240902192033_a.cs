using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App_DAL.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "LikeUserStories",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StoryId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DropDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeUserStories", x => new { x.StoryId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTopicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DropDate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DropDate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTopic",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DropDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTopic", x => new { x.UserId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_UserTopic_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTopic_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoryTopic",
                columns: table => new
                {
                    StoryId = table.Column<int>(type: "integer", nullable: false),
                    TopicId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DropDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryTopic", x => new { x.StoryId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_StoryTopic_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoryTopic_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreateDate", "DropDate", "Status", "SubTopicName", "TopicName", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7054), null, "Created", "Business", "Work", null },
                    { 2, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7057), null, "Created", "Marketing", "Work", null },
                    { 3, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7059), null, "Created", "Leadership", "Work", null },
                    { 4, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7061), null, "Created", "Remote Work", "Work", null },
                    { 5, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7063), null, "Created", "Entrepreneurship", "Business", null },
                    { 6, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7065), null, "Created", "Freelancing", "Business", null },
                    { 7, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7066), null, "Created", "Small Business", "Business", null },
                    { 8, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7068), null, "Created", "Startups", "Business", null },
                    { 9, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7070), null, "Created", "Venture Capital", "Business", null },
                    { 10, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7148), null, "Created", "Advertising", "Marketing", null },
                    { 11, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7150), null, "Created", "Branding", "Marketing", null },
                    { 12, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7152), null, "Created", "Content Marketing", "Marketing", null },
                    { 13, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7153), null, "Created", "Content Strategy", "Marketing", null },
                    { 14, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7155), null, "Created", "Digital Marketing", "Marketing", null },
                    { 15, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7157), null, "Created", "SEO", "Marketing", null },
                    { 16, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7158), null, "Created", "Social Media Marketing", "Marketing", null },
                    { 17, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7160), null, "Created", "Storytelling For Business", "Marketing", null },
                    { 18, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7173), null, "Created", "Employee Engagement", "Leadership", null },
                    { 19, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7174), null, "Created", "Leadership Coaching", "Leadership", null },
                    { 20, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7176), null, "Created", "Leadership Development", "Leadership", null },
                    { 21, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7177), null, "Created", "Management", "Leadership", null },
                    { 22, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7180), null, "Created", "Meetings", "Leadership", null },
                    { 23, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7182), null, "Created", "Org Charts", "Leadership", null },
                    { 24, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7184), null, "Created", "Thought Leadership", "Leadership", null },
                    { 25, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7196), null, "Created", "Company Retreats", "Remote Work", null },
                    { 26, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7200), null, "Created", "Digital Nomads", "Remote Work", null },
                    { 27, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7202), null, "Created", "Distributed Teams", "Remote Work", null },
                    { 28, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7203), null, "Created", "Future Of Work", "Remote Work", null },
                    { 29, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7205), null, "Created", "Work From Home", "Remote Work", null },
                    { 30, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7213), null, "Created", "Family", "Life", null },
                    { 31, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7215), null, "Created", "Health", "Life", null },
                    { 32, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7218), null, "Created", "Relationships", "Life", null },
                    { 33, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7219), null, "Created", "Sexuality", "Life", null },
                    { 34, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7222), null, "Created", "Home", "Life", null },
                    { 35, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7224), null, "Created", "Food", "Life", null },
                    { 36, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7225), null, "Created", "Pets", "Life", null },
                    { 37, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7227), null, "Created", "Adoption", "Family", null },
                    { 38, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7228), null, "Created", "Children", "Family", null },
                    { 39, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7232), null, "Created", "Elder Care", "Family", null },
                    { 40, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7234), null, "Created", "Fatherhood", "Family", null },
                    { 41, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7235), null, "Created", "Motherhood", "Family", null },
                    { 42, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7237), null, "Created", "Parenting", "Family", null },
                    { 43, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7238), null, "Created", "Pregnancy", "Family", null },
                    { 44, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7239), null, "Created", "Seniors", "Family", null },
                    { 45, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7249), null, "Created", "Aging", "Health", null },
                    { 46, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7251), null, "Created", "Coronavirus", "Health", null },
                    { 47, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7253), null, "Created", "Covid-19", "Health", null },
                    { 48, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7254), null, "Created", "Death And Dying", "Health", null },
                    { 49, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7255), null, "Created", "Disease", "Health", null },
                    { 50, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7257), null, "Created", "Fitness", "Health", null },
                    { 51, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7258), null, "Created", "Mens Health", "Health", null },
                    { 52, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7259), null, "Created", "Nutrition", "Health", null },
                    { 53, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7261), null, "Created", "Sleep", "Health", null },
                    { 54, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7262), null, "Created", "Trans Healthcare", "Health", null },
                    { 55, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7263), null, "Created", "Vaccines", "Health", null },
                    { 56, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7264), null, "Created", "Weight Loss", "Health", null },
                    { 57, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7268), null, "Created", "Womens Health", "Health", null },
                    { 58, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7334), null, "Created", "Dating", "Relationships", null },
                    { 59, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7335), null, "Created", "Divorce", "Relationships", null },
                    { 60, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7337), null, "Created", "Friendship", "Relationships", null },
                    { 61, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7338), null, "Created", "Love", "Relationships", null },
                    { 62, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7339), null, "Created", "Marriage", "Relationships", null },
                    { 63, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7340), null, "Created", "Polyamory", "Relationships", null },
                    { 64, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7349), null, "Created", "BDSM", "Sexuality", null },
                    { 65, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7350), null, "Created", "Erotica", "Sexuality", null },
                    { 66, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7351), null, "Created", "Kink", "Sexuality", null },
                    { 67, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7353), null, "Created", "Sex", "Sexuality", null },
                    { 68, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7354), null, "Created", "Sexual Health", "Sexuality", null },
                    { 69, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7362), null, "Created", "Architecture", "Home", null },
                    { 70, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7364), null, "Created", "Home Improvement", "Home", null },
                    { 71, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7365), null, "Created", "Homeownership", "Home", null },
                    { 72, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7366), null, "Created", "Interior Design", "Home", null },
                    { 73, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7368), null, "Created", "Rental Property", "Home", null },
                    { 74, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7369), null, "Created", "Vacation Rental", "Home", null },
                    { 75, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7377), null, "Created", "Baking", "Food", null },
                    { 76, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7379), null, "Created", "Coffee", "Food", null },
                    { 77, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7380), null, "Created", "Cooking", "Food", null },
                    { 78, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7381), null, "Created", "Foodies", "Food", null },
                    { 79, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7382), null, "Created", "Restaurants", "Food", null },
                    { 80, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7384), null, "Created", "Tea", "Food", null },
                    { 81, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7393), null, "Created", "Cats", "Pets", null },
                    { 82, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7395), null, "Created", "Dog Training", "Pets", null },
                    { 83, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7396), null, "Created", "Dogs", "Pets", null },
                    { 84, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7397), null, "Created", "Hamsters", "Pets", null },
                    { 85, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7398), null, "Created", "Horses", "Pets", null },
                    { 86, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7400), null, "Created", "Pet Care", "Pets", null },
                    { 88, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7408), null, "Created", "Artificial Intelligence", "Technology", null },
                    { 89, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7409), null, "Created", "Blockchain", "Technology", null },
                    { 90, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7410), null, "Created", "Data Science", "Technology", null },
                    { 91, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7412), null, "Created", "Gadgets", "Technology", null },
                    { 92, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7414), null, "Created", "Makers", "Technology", null },
                    { 93, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7415), null, "Created", "Security", "Technology", null },
                    { 94, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7417), null, "Created", "Tech Companies", "Technology", null },
                    { 95, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7418), null, "Created", "Design", "Technology", null },
                    { 96, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7419), null, "Created", "Product Management", "Technology", null },
                    { 97, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7420), null, "Created", "ChatGPT", "Artificial Intelligence", null },
                    { 98, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7422), null, "Created", "Conversational AI", "Artificial Intelligence", null },
                    { 99, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7423), null, "Created", "Deep Learning", "Artificial Intelligence", null },
                    { 100, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7424), null, "Created", "Large Language Models", "Artificial Intelligence", null },
                    { 101, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7425), null, "Created", "Machine Learning", "Artificial Intelligence", null },
                    { 102, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7427), null, "Created", "NLP", "Artificial Intelligence", null },
                    { 103, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7428), null, "Created", "Voice Assistant", "Artificial Intelligence", null },
                    { 104, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7473), null, "Created", "Bitcoin", "Blockchain", null },
                    { 105, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7474), null, "Created", "Cryptocurrency", "Blockchain", null },
                    { 106, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7476), null, "Created", "Decentralized Finance", "Blockchain", null },
                    { 107, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7477), null, "Created", "Ethereum", "Blockchain", null },
                    { 108, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7479), null, "Created", "NFT", "Blockchain", null },
                    { 109, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7480), null, "Created", "Web3", "Blockchain", null },
                    { 110, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7489), null, "Created", "Analytics", "Data Science", null },
                    { 111, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7490), null, "Created", "Data Engineering", "Data Science", null },
                    { 112, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7491), null, "Created", "Data Visualization", "Data Science", null },
                    { 113, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7493), null, "Created", "Database Design", "Data Science", null },
                    { 114, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7494), null, "Created", "SQL", "Data Science", null },
                    { 115, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7501), null, "Created", "eBook", "Gadgets", null },
                    { 116, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7502), null, "Created", "Internet of Things", "Gadgets", null },
                    { 117, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7504), null, "Created", "iPad", "Gadgets", null },
                    { 118, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7506), null, "Created", "Smart Home", "Gadgets", null },
                    { 119, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7507), null, "Created", "Smartphones", "Gadgets", null },
                    { 120, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7509), null, "Created", "Wearables", "Gadgets", null },
                    { 121, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7517), null, "Created", "3D Printing", "Makers", null },
                    { 122, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7518), null, "Created", "Arduino", "Makers", null },
                    { 123, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7519), null, "Created", "DIY", "Makers", null },
                    { 124, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7521), null, "Created", "Raspberry Pi", "Makers", null },
                    { 125, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7522), null, "Created", "Robotics", "Makers", null },
                    { 126, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7529), null, "Created", "Cybersecurity", "Security", null },
                    { 127, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7530), null, "Created", "Data Security", "Security", null },
                    { 128, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7532), null, "Created", "Encryption", "Security", null },
                    { 129, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7535), null, "Created", "Infosec", "Security", null },
                    { 130, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7536), null, "Created", "Passwords", "Security", null },
                    { 131, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7538), null, "Created", "Privacy", "Security", null },
                    { 132, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7546), null, "Created", "Accessibility", "Design", null },
                    { 133, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7547), null, "Created", "Design Systems", "Design", null },
                    { 134, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7550), null, "Created", "Design Thinking", "Design", null },
                    { 135, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7551), null, "Created", "Graphic Design", "Design", null },
                    { 136, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7552), null, "Created", "Icon Design", "Design", null },
                    { 137, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7553), null, "Created", "Inclusive Design", "Design", null },
                    { 138, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7555), null, "Created", "Product Design", "Design", null },
                    { 139, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7556), null, "Created", "Typography", "Design", null },
                    { 140, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7557), null, "Created", "UX Design", "Design", null },
                    { 141, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7558), null, "Created", "UX Research", "Design", null },
                    { 142, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7571), null, "Created", "Agile", "Product Management", null },
                    { 143, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7572), null, "Created", "Innovation", "Product Management", null },
                    { 144, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7574), null, "Created", "Kanban", "Product Management", null },
                    { 145, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7575), null, "Created", "Lean Startup", "Product Management", null },
                    { 146, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7576), null, "Created", "MVP", "Product Management", null },
                    { 147, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7577), null, "Created", "Product", "Product Management", null },
                    { 148, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7579), null, "Created", "Strategy", "Product Management", null },
                    { 1000, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7137), null, "Created", null, "Entrepreneurship", null },
                    { 1001, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7139), null, "Created", null, "Freelancing", null },
                    { 1002, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7141), null, "Created", null, "Small Business", null },
                    { 1003, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7145), null, "Created", null, "Startups", null },
                    { 1004, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7146), null, "Created", null, "Venture Capital", null },
                    { 1005, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7161), null, "Created", null, "Advertising", null },
                    { 1006, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7163), null, "Created", null, "Branding", null },
                    { 1007, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7164), null, "Created", null, "Content Marketing", null },
                    { 1008, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7166), null, "Created", null, "Content Strategy", null },
                    { 1009, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7167), null, "Created", null, "Digital Marketing", null },
                    { 1010, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7168), null, "Created", null, "SEO", null },
                    { 1011, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7170), null, "Created", null, "Social Media Marketing", null },
                    { 1012, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7171), null, "Created", null, "Storytelling For Business", null },
                    { 1013, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7185), null, "Created", null, "Employee Engagement", null },
                    { 1014, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7186), null, "Created", null, "Leadership Coaching", null },
                    { 1015, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7188), null, "Created", null, "Leadership Development", null },
                    { 1016, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7190), null, "Created", null, "Management", null },
                    { 1017, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7191), null, "Created", null, "Meetings", null },
                    { 1018, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7193), null, "Created", null, "Org Charts", null },
                    { 1019, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7194), null, "Created", null, "Thought Leadership", null },
                    { 1020, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7206), null, "Created", null, "Company Retreats", null },
                    { 1021, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7207), null, "Created", null, "Digital Nomads", null },
                    { 1022, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7209), null, "Created", null, "Distributed Teams", null },
                    { 1023, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7210), null, "Created", null, "Future Of Work", null },
                    { 1024, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7212), null, "Created", null, "Work From Home", null },
                    { 1025, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7240), null, "Created", null, "Family", null },
                    { 1026, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7242), null, "Created", null, "Health", null },
                    { 1027, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7243), null, "Created", null, "Relationships", null },
                    { 1028, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7244), null, "Created", null, "Sexuality", null },
                    { 1029, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7245), null, "Created", null, "Home", null },
                    { 1030, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7246), null, "Created", null, "Food", null },
                    { 1031, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7248), null, "Created", null, "Pets", null },
                    { 1040, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7270), null, "Created", null, "Aging", null },
                    { 1041, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7272), null, "Created", null, "Coronavirus", null },
                    { 1042, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7274), null, "Created", null, "Covid-19", null },
                    { 1043, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7275), null, "Created", null, "Death And Dying", null },
                    { 1044, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7276), null, "Created", null, "Disease", null },
                    { 1045, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7277), null, "Created", null, "Fitness", null },
                    { 1046, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7325), null, "Created", null, "Mens Health", null },
                    { 1047, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7326), null, "Created", null, "Nutrition", null },
                    { 1048, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7328), null, "Created", null, "Sleep", null },
                    { 1049, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7329), null, "Created", null, "Trans Healthcare", null },
                    { 1050, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7330), null, "Created", null, "Vaccines", null },
                    { 1051, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7331), null, "Created", null, "Weight Loss", null },
                    { 1052, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7333), null, "Created", null, "Womens Health", null },
                    { 1053, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7342), null, "Created", null, "Dating", null },
                    { 1054, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7343), null, "Created", null, "Divorce", null },
                    { 1055, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7344), null, "Created", null, "Friendship", null },
                    { 1056, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7345), null, "Created", null, "Love", null },
                    { 1057, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7346), null, "Created", null, "Marriage", null },
                    { 1058, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7347), null, "Created", null, "Polyamory", null },
                    { 1059, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7355), null, "Created", null, "BDSM", null },
                    { 1060, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7356), null, "Created", null, "Erotica", null },
                    { 1061, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7359), null, "Created", null, "Kink", null },
                    { 1062, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7360), null, "Created", null, "Sex", null },
                    { 1063, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7361), null, "Created", null, "Sexual Health", null },
                    { 1064, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7370), null, "Created", null, "Architecture", null },
                    { 1065, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7371), null, "Created", null, "Home Improvement", null },
                    { 1066, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7372), null, "Created", null, "Homeownership", null },
                    { 1067, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7374), null, "Created", null, "Interior Design", null },
                    { 1068, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7375), null, "Created", null, "Rental Property", null },
                    { 1069, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7376), null, "Created", null, "Vacation Rental", null },
                    { 1070, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7386), null, "Created", null, "Baking", null },
                    { 1071, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7387), null, "Created", null, "Coffee", null },
                    { 1072, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7389), null, "Created", null, "Cooking", null },
                    { 1073, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7390), null, "Created", null, "Foodies", null },
                    { 1074, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7391), null, "Created", null, "Restaurants", null },
                    { 1075, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7392), null, "Created", null, "Tea", null },
                    { 1076, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7401), null, "Created", null, "Cats", null },
                    { 1077, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7402), null, "Created", null, "Dog Training", null },
                    { 1078, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7403), null, "Created", null, "Dogs", null },
                    { 1079, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7404), null, "Created", null, "Hamsters", null },
                    { 1080, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7405), null, "Created", null, "Horses", null },
                    { 1081, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7407), null, "Created", null, "Pet Care", null },
                    { 1082, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7429), null, "Created", null, "ChatGPT", null },
                    { 1083, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7430), null, "Created", null, "Conversational AI", null },
                    { 1084, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7431), null, "Created", null, "Deep Learning", null },
                    { 1085, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7432), null, "Created", null, "Large Language Models", null },
                    { 1086, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7468), null, "Created", null, "Machine Learning", null },
                    { 1087, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7470), null, "Created", null, "NLP", null },
                    { 1088, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7472), null, "Created", null, "Voice Assistant", null },
                    { 1089, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7481), null, "Created", null, "Bitcoin", null },
                    { 1090, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7483), null, "Created", null, "Cryptocurrency", null },
                    { 1091, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7484), null, "Created", null, "Decentralized Finance", null },
                    { 1092, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7485), null, "Created", null, "Ethereum", null },
                    { 1093, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7486), null, "Created", null, "NFT", null },
                    { 1094, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7487), null, "Created", null, "Web3", null },
                    { 1095, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7495), null, "Created", null, "Analytics", null },
                    { 1096, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7496), null, "Created", null, "Data Engineering", null },
                    { 1097, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7497), null, "Created", null, "Data Visualization", null },
                    { 1098, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7499), null, "Created", null, "Database Design", null },
                    { 1099, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7500), null, "Created", null, "SQL", null },
                    { 1100, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7510), null, "Created", null, "eBook", null },
                    { 1101, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7511), null, "Created", null, "Internet of Things", null },
                    { 1102, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7512), null, "Created", null, "iPad", null },
                    { 1103, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7513), null, "Created", null, "Smart Home", null },
                    { 1104, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7514), null, "Created", null, "Smartphones", null },
                    { 1105, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7516), null, "Created", null, "Wearables", null },
                    { 1106, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7523), null, "Created", null, "3D Printing", null },
                    { 1107, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7524), null, "Created", null, "Arduino", null },
                    { 1108, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7526), null, "Created", null, "DIY", null },
                    { 1109, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7527), null, "Created", null, "Raspberry Pi", null },
                    { 1110, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7528), null, "Created", null, "Robotics", null },
                    { 1111, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7539), null, "Created", null, "Cybersecurity", null },
                    { 1112, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7540), null, "Created", null, "Data Security", null },
                    { 1113, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7541), null, "Created", null, "Encryption", null },
                    { 1114, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7542), null, "Created", null, "Infosec", null },
                    { 1115, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7544), null, "Created", null, "Passwords", null },
                    { 1116, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7545), null, "Created", null, "Privacy", null },
                    { 1117, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7560), null, "Created", null, "Accessibility", null },
                    { 1118, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7561), null, "Created", null, "Design Systems", null },
                    { 1119, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7562), null, "Created", null, "Design Thinking", null },
                    { 1120, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7563), null, "Created", null, "Graphic Design", null },
                    { 1121, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7564), null, "Created", null, "Icon Design", null },
                    { 1122, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7565), null, "Created", null, "Inclusive Design", null },
                    { 1123, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7567), null, "Created", null, "Product Design", null },
                    { 1124, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7568), null, "Created", null, "Typography", null },
                    { 1125, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7569), null, "Created", null, "UX Design", null },
                    { 1126, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7570), null, "Created", null, "UX Research", null },
                    { 1127, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7607), null, "Created", null, "Agile", null },
                    { 1128, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7610), null, "Created", null, "Innovation", null },
                    { 1129, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7612), null, "Created", null, "Kanban", null },
                    { 1130, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7613), null, "Created", null, "Lean Startup", null },
                    { 1131, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7614), null, "Created", null, "MVP", null },
                    { 1132, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7615), null, "Created", null, "Product", null },
                    { 1133, new DateTime(2024, 9, 2, 22, 20, 33, 383, DateTimeKind.Local).AddTicks(7617), null, "Created", null, "Strategy", null }
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
                name: "IX_Stories_UserId",
                table: "Stories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryTopic_TopicId",
                table: "StoryTopic",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTopic_TopicId",
                table: "UserTopic",
                column: "TopicId");
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
                name: "LikeUserStories");

            migrationBuilder.DropTable(
                name: "StoryTopic");

            migrationBuilder.DropTable(
                name: "UserTopic");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
