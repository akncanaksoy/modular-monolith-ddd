using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Octovis.Location.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitLocationSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "location");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "location",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Locations_Id",
                        column: x => x.Id,
                        principalSchema: "location",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AddressType = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Locations_Id",
                        column: x => x.Id,
                        principalSchema: "location",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AddressType = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dealers_Locations_Id",
                        column: x => x.Id,
                        principalSchema: "location",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Locations_Id",
                        column: x => x.Id,
                        principalSchema: "location",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLocations",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "location",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "location",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uuid", nullable: false),
                    Longitude = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Latitude = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "location",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "location",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "location",
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressType = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "location",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Regions_Locations_Id",
                        column: x => x.Id,
                        principalSchema: "location",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                schema: "location",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                schema: "location",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                schema: "location",
                table: "Addresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                schema: "location",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                schema: "location",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_AddressId",
                schema: "location",
                table: "Regions",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_LocationId",
                schema: "location",
                table: "UserLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_UserId_LocationId",
                schema: "location",
                table: "UserLocations",
                columns: new[] { "UserId", "LocationId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas",
                schema: "location");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "location");

            migrationBuilder.DropTable(
                name: "Dealers",
                schema: "location");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "location");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "location");

            migrationBuilder.DropTable(
                name: "UserLocations",
                schema: "location");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "location");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "location");

            migrationBuilder.DropTable(
                name: "Districts",
                schema: "location");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "location");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "location");
        }
    }
}
