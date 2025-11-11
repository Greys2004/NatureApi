using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace natureApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ElevationMeters = table.Column<int>(type: "int", nullable: true),
                    Accessible = table.Column<bool>(type: "bit", nullable: false),
                    EntryFee = table.Column<double>(type: "float", nullable: true),
                    OpeningHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AmenityPlace",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(type: "int", nullable: false),
                    PlacesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityPlace", x => new { x.AmenitiesId, x.PlacesId });
                    table.ForeignKey(
                        name: "FK_AmenityPlace_Amenity_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "Amenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenityPlace_Place_PlacesId",
                        column: x => x.PlacesId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idPlace = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaceAmenity",
                columns: table => new
                {
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceAmenity", x => new { x.PlaceId, x.AmenityId });
                    table.ForeignKey(
                        name: "FK_PlaceAmenity_Amenity_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceAmenity_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idPlace = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanceKm = table.Column<double>(type: "float", nullable: false),
                    EstimatedTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLoop = table.Column<bool>(type: "bit", nullable: false),
                    idPlace = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trail_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Baños" },
                    { 2, "Estacionamiento" },
                    { 3, "Mirador" },
                    { 4, "Área de comida" },
                    { 5, "Zona de campamento" }
                });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "Accessible", "Category", "CreatedAt", "Description", "ElevationMeters", "EntryFee", "Latitude", "Longitude", "Name", "OpeningHours" },
                values: new object[,]
                {
                    { 1, true, "reserva", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Santuario natural en Michoacán, hábitat invernal de la mariposa monarca.", 3000, 70.0, 19.631, -100.283, "Reserva de la Biósfera Mariposa Monarca", "09:00-17:00" },
                    { 2, true, "cueva", new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cueva vertical en San Luis Potosí famosa por el vuelo de miles de aves.", 900, 100.0, 21.597000000000001, -99.097999999999999, "Sótano de las Golondrinas", "07:00-18:00" },
                    { 3, true, "volcán", new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Campo volcánico con cráteres impresionantes en Sonora.", 1200, 70.0, 31.783000000000001, -113.533, "Cráteres de El Pinacate", "08:00-17:00" },
                    { 4, true, "formación geológica", new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Formaciones geométricas de basalto en Hidalgo.", 2100, 80.0, 20.210999999999999, -98.581000000000003, "Prismas Basálticos", "09:00-18:00" },
                    { 5, true, "sima", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hundimiento natural en Chiapas con selva en el interior.", 900, 60.0, 16.725999999999999, -93.367999999999995, "Sima de las Cotorras", "07:00-17:00" }
                });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "Description", "PlaceId", "Url", "idPlace" },
                values: new object[,]
                {
                    { 1, "Reserva de la Biósfera Mariposa Monarca", 1, "https://cdn.milenio.com/uploads/media/2015/10/23/tala-ilegal-reserva-biosfera-mariposa.jpeg", 0 },
                    { 2, "Sótano de las Golondrinas", 2, "https://transpais.com.mx/wp-content/uploads/2023/04/golondrinas.jpg", 0 },
                    { 3, "Cráteres de El Pinacate", 3, "https://rocateca.unison.mx/wp-content/uploads/2020/09/el-elegante.jpg", 0 },
                    { 4, "Prismas Basálticos", 4, "https://www.huascaguiaturistica.com/huasca-imagenes/1-prismas-basalticos.jpg", 0 },
                    { 5, "Sima de las Cotorras", 5, "https://mxc.com.mx/wp-content/uploads/2021/02/sima-de-las-cotorras-1024x576.jpg", 0 }
                });

            migrationBuilder.InsertData(
                table: "PlaceAmenity",
                columns: new[] { "AmenityId", "PlaceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 2, 3 },
                    { 5, 3 },
                    { 1, 4 },
                    { 4, 4 },
                    { 2, 5 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Trail",
                columns: new[] { "Id", "Difficulty", "DistanceKm", "EstimatedTimeMinutes", "IsLoop", "Name", "Path", "PlaceId", "idPlace" },
                values: new object[,]
                {
                    { 1, "easy", 2.5, 60, true, "Sendero Mariposas", "[[19.6305,-100.2825],[19.6312,-100.2835],[19.632,-100.284]]", 1, 0 },
                    { 2, "hard", 1.2, 90, false, "Descenso al sótano", "[[21.597,-99.098],[21.5975,-99.097],[21.598,-99.096]]", 2, 0 },
                    { 3, "moderate", 3.5, 120, true, "Ruta cráter El Elegante", "[[31.783,-113.533],[31.784,-113.532],[31.785,-113.531]]", 3, 0 },
                    { 4, "easy", 1.0, 30, true, "Sendero Prismas", "[[20.211,-98.581],[20.212,-98.5805],[20.2125,-98.580]]", 4, 0 },
                    { 5, "moderate", 2.0, 60, false, "Sendero Sima", "[[16.726,-93.368],[16.727,-93.367],[16.728,-93.366]]", 5, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenityPlace_PlacesId",
                table: "AmenityPlace",
                column: "PlacesId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PlaceId",
                table: "Photo",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceAmenity_AmenityId",
                table: "PlaceAmenity",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_PlaceId",
                table: "Review",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Trail_PlaceId",
                table: "Trail",
                column: "PlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenityPlace");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "PlaceAmenity");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Trail");

            migrationBuilder.DropTable(
                name: "Amenity");

            migrationBuilder.DropTable(
                name: "Place");
        }
    }
}
