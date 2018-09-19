using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Urbann.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ThumbnailFileName = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Places_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Places_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(nullable: true),
                    PlaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Factory" },
                    { 2, "Church" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Poland" },
                    { 2, "Italy" },
                    { 3, "Spain" },
                    { 4, "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "CountryId", "Street" },
                values: new object[,]
                {
                    { 6, "Uppsala", 4, "kungsgatan 76" },
                    { 1, "Cracow", 1, "Tyniecka 22" },
                    { 2, "Cracow", 1, "Drukarska 10" },
                    { 5, "Madrid", 3, "calle menorca 2" },
                    { 4, "Rome", 2, "via imperia 5" },
                    { 3, "Rome", 2, "via catania 32" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "PlaceId", "AddressId", "CategoryId", "Description", "Name", "ThumbnailFileName" },
                values: new object[,]
                {
                    { 60, null, 1, null, "Place: 60", "1.jpeg" },
                    { 77, null, 1, null, "Place: 77", "1.jpeg" },
                    { 76, null, 1, null, "Place: 76", "1.jpeg" },
                    { 75, null, 1, null, "Place: 75", "1.jpeg" },
                    { 74, null, 1, null, "Place: 74", "1.jpeg" },
                    { 73, null, 1, null, "Place: 73", "1.jpeg" },
                    { 72, null, 1, null, "Place: 72", "1.jpeg" },
                    { 71, null, 1, null, "Place: 71", "1.jpeg" },
                    { 70, null, 1, null, "Place: 70", "1.jpeg" },
                    { 69, null, 1, null, "Place: 69", "1.jpeg" },
                    { 78, null, 1, null, "Place: 78", "1.jpeg" },
                    { 67, null, 1, null, "Place: 67", "1.jpeg" },
                    { 66, null, 1, null, "Place: 66", "1.jpeg" },
                    { 65, null, 1, null, "Place: 65", "1.jpeg" },
                    { 64, null, 1, null, "Place: 64", "1.jpeg" },
                    { 63, null, 1, null, "Place: 63", "1.jpeg" },
                    { 62, null, 1, null, "Place: 62", "1.jpeg" },
                    { 61, null, 1, null, "Place: 61", "1.jpeg" },
                    { 59, null, 1, null, "Place: 59", "1.jpeg" },
                    { 68, null, 1, null, "Place: 68", "1.jpeg" },
                    { 79, null, 1, null, "Place: 79", "1.jpeg" },
                    { 58, null, 1, null, "Place: 58", "1.jpeg" },
                    { 99, null, 1, null, "Place: 99", "1.jpeg" },
                    { 98, null, 1, null, "Place: 98", "1.jpeg" },
                    { 97, null, 1, null, "Place: 97", "1.jpeg" },
                    { 96, null, 1, null, "Place: 96", "1.jpeg" },
                    { 95, null, 1, null, "Place: 95", "1.jpeg" },
                    { 94, null, 1, null, "Place: 94", "1.jpeg" },
                    { 93, null, 1, null, "Place: 93", "1.jpeg" },
                    { 92, null, 1, null, "Place: 92", "1.jpeg" },
                    { 80, null, 1, null, "Place: 80", "1.jpeg" },
                    { 91, null, 1, null, "Place: 91", "1.jpeg" },
                    { 89, null, 1, null, "Place: 89", "1.jpeg" },
                    { 88, null, 1, null, "Place: 88", "1.jpeg" },
                    { 87, null, 1, null, "Place: 87", "1.jpeg" },
                    { 86, null, 1, null, "Place: 86", "1.jpeg" },
                    { 85, null, 1, null, "Place: 85", "1.jpeg" },
                    { 84, null, 1, null, "Place: 84", "1.jpeg" },
                    { 83, null, 1, null, "Place: 83", "1.jpeg" },
                    { 82, null, 1, null, "Place: 82", "1.jpeg" },
                    { 90, null, 1, null, "Place: 90", "1.jpeg" },
                    { 81, null, 1, null, "Place: 81", "1.jpeg" },
                    { 57, null, 1, null, "Place: 57", "1.jpeg" },
                    { 55, null, 1, null, "Place: 55", "1.jpeg" },
                    { 30, null, 1, null, "Place: 30", "1.jpeg" },
                    { 29, null, 1, null, "Place: 29", "1.jpeg" },
                    { 28, null, 1, null, "Place: 28", "1.jpeg" },
                    { 27, null, 1, null, "Place: 27", "1.jpeg" },
                    { 26, null, 1, null, "Place: 26", "1.jpeg" },
                    { 25, null, 1, null, "Place: 25", "1.jpeg" },
                    { 24, null, 1, null, "Place: 24", "1.jpeg" },
                    { 23, null, 1, null, "Place: 23", "1.jpeg" },
                    { 22, null, 1, null, "Place: 22", "1.jpeg" },
                    { 31, null, 1, null, "Place: 31", "1.jpeg" },
                    { 21, null, 1, null, "Place: 21", "1.jpeg" },
                    { 19, null, 1, null, "Place: 19", "1.jpeg" },
                    { 18, null, 1, null, "Place: 18", "1.jpeg" },
                    { 17, null, 1, null, "Place: 17", "1.jpeg" },
                    { 16, null, 1, null, "Place: 16", "1.jpeg" },
                    { 15, null, 1, null, "Place: 15", "1.jpeg" },
                    { 14, null, 1, null, "Place: 14", "1.jpeg" },
                    { 13, null, 1, null, "Place: 13", "1.jpeg" },
                    { 12, null, 1, null, "Place: 12", "1.jpeg" },
                    { 11, null, 1, null, "Place: 11", "1.jpeg" },
                    { 20, null, 1, null, "Place: 20", "1.jpeg" },
                    { 56, null, 1, null, "Place: 56", "1.jpeg" },
                    { 32, null, 1, null, "Place: 32", "1.jpeg" },
                    { 34, null, 1, null, "Place: 34", "1.jpeg" },
                    { 54, null, 1, null, "Place: 54", "1.jpeg" },
                    { 53, null, 1, null, "Place: 53", "1.jpeg" },
                    { 52, null, 1, null, "Place: 52", "1.jpeg" },
                    { 51, null, 1, null, "Place: 51", "1.jpeg" },
                    { 50, null, 1, null, "Place: 50", "1.jpeg" },
                    { 49, null, 1, null, "Place: 49", "1.jpeg" },
                    { 48, null, 1, null, "Place: 48", "1.jpeg" },
                    { 47, null, 1, null, "Place: 47", "1.jpeg" },
                    { 46, null, 1, null, "Place: 46", "1.jpeg" },
                    { 33, null, 1, null, "Place: 33", "1.jpeg" },
                    { 45, null, 1, null, "Place: 45", "1.jpeg" },
                    { 43, null, 1, null, "Place: 43", "1.jpeg" },
                    { 42, null, 1, null, "Place: 42", "1.jpeg" },
                    { 41, null, 1, null, "Place: 41", "1.jpeg" },
                    { 40, null, 1, null, "Place: 40", "1.jpeg" },
                    { 39, null, 1, null, "Place: 39", "1.jpeg" },
                    { 38, null, 1, null, "Place: 38", "1.jpeg" },
                    { 37, null, 1, null, "Place: 37", "1.jpeg" },
                    { 36, null, 1, null, "Place: 36", "1.jpeg" },
                    { 35, null, 1, null, "Place: 35", "1.jpeg" },
                    { 44, null, 1, null, "Place: 44", "1.jpeg" },
                    { 10, null, 1, null, "Place: 10", "1.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "PlaceId", "AddressId", "CategoryId", "Description", "Name", "ThumbnailFileName" },
                values: new object[,]
                {
                    { 1, 1, 1, null, "Place 1", "1.jpeg" },
                    { 2, 2, 1, null, "Place 2", "2.jpeg" },
                    { 3, 3, 1, null, "Place 3", "3.jpeg" },
                    { 4, 4, 2, null, "Place 4", "4.jpeg" },
                    { 5, 5, 2, null, "Place 5", "5.jpeg" },
                    { 6, 6, 2, null, "Place 6", "6.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PhotoId", "FileName", "PlaceId" },
                values: new object[,]
                {
                    { 1, "1.jpeg", 1 },
                    { 2, "2.jpeg", 1 },
                    { 3, "3.jpeg", 1 },
                    { 4, "4.jpeg", 1 },
                    { 5, "5.jpeg", 2 },
                    { 6, "6.jpeg", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

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
                name: "IX_Photos_PlaceId",
                table: "Photos",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_AddressId",
                table: "Places",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Places_CategoryId",
                table: "Places",
                column: "CategoryId");
        }

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
                name: "Photos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
