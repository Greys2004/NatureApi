using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace natureApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed_20251009 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "PlaceId", "Url" },
                values: new object[] { "Reserva de la Biósfera Mariposa Monarca", 1, "https://www.patrimoniomundial.com.mx/wp-content/uploads/2013/10/Monarcas1.jpg" });

            migrationBuilder.UpdateData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "PlaceId", "Url" },
                values: new object[] { "Reserva de la Biósfera Mariposa Monarca", 1, "https://programadestinosmexico.com/wp-content/uploads/2023/12/RESERVA-DE-LA-MARIPOSA-MONARCA.jpg" });

            migrationBuilder.UpdateData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "PlaceId", "Url" },
                values: new object[] { "Sótano de las Golondrinas", 2, "https://transpais.com.mx/wp-content/uploads/2023/04/golondrinas.jpg" });

            migrationBuilder.UpdateData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "PlaceId", "Url" },
                values: new object[] { "Sótano de las Golondrinas", 2, "https://revistaaventurero.com.mx/wp-content/uploads/2018/01/SOTANO-DE-LAS-GOLONDRINAS-www.puntofape.com_.jpg" });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "Description", "PlaceId", "Url", "idPlace" },
                values: new object[,]
                {
                    { 6, "Sótano de las Golondrinas", 2, "https://img.travesiasdigital.com/cdn-cgi/image/quality=90,format=auto,onerror=redirect/2019/03/sotano-de-las-golondrinas-aves.jpg", 0 },
                    { 7, "Cráteres de El Pinacate", 3, "https://rocateca.unison.mx/wp-content/uploads/2020/09/el-elegante.jpg", 0 },
                    { 8, "Cráteres de El Pinacate", 3, "https://sic.cultura.gob.mx/images/38880", 0 },
                    { 9, "Cráteres de El Pinacate", 3, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqkp-cTeUXQ1sl7yLsu1K4v-DKs-CzdWrvrg&s", 0 },
                    { 10, "Prismas Basálticos", 4, "https://www.huascaguiaturistica.com/huasca-imagenes/1-prismas-basalticos.jpg", 0 },
                    { 11, "Prismas Basálticos", 4, "https://www.mexicodestinos.com/blog/wp-content/uploads/2021/07/prismas-630x420.jpg", 0 },
                    { 12, "Prismas Basálticos", 4, "https://www.huascaguiaturistica.com/huasca-imagenes/1-prismas-basalticos.jpg", 0 },
                    { 13, "Sima de las Cotorras", 5, "https://mxc.com.mx/wp-content/uploads/2021/02/sima-de-las-cotorras-1024x576.jpg", 0 },
                    { 14, "Sima de las Cotorras", 5, "https://www.mexicodesconocido.com.mx/wp-content/uploads/2016/09/WhatsApp-Image-2020-07-15-at-19.03.28.jpeg", 0 },
                    { 15, "Sima de las Cotorras", 5, "https://disfrutachiapas.com/wp-content/uploads/2023/12/simacotorras-1024x683.jpg", 0 },
                    { 16, "Cenote Ik Kil", 6, "https://dexter.cancunairporttransportations.com/vendor/blog/gallery/2022/05/cenote_ik_kil-tour.jpg", 0 },
                    { 17, "Cenote Ik Kil", 6, "https://topyucatan.com/storage/uploads/178495071-1332905113762718-8561404485712747862-n-1626902981.jpg", 0 },
                    { 18, "Cenote Ik Kil", 6, "https://static.vecteezy.com/system/resources/previews/060/531/480/large_2x/cenote-ik-kil-yucatan-mexico-sunlight-illuminating-turquoise-water-in-a-mysterious-cave-photo.jpg", 0 },
                    { 19, "Cascada Basaseachi", 7, "https://www.gob.mx/cms/uploads/image/file/247330/Basaseachi__foto_Teresita_Lasso__18_.JPG", 0 },
                    { 20, "Cascada Basaseachi", 7, "https://mxc.com.mx/wp-content/uploads/2020/07/292750-684x1024.jpg", 0 },
                    { 21, "Cascada Basaseachi", 7, "https://chihuahua.gob.mx/sites/default/files/grupos/user599/cascada_de_basaseachi_2.jpg", 0 },
                    { 22, "Reserva de la Biósfera Sian Ka'an", 8, "https://media-cdn.tripadvisor.com/media/attractions-splice-spp-674x446/06/6f/10/c3.jpg", 0 },
                    { 23, "Reserva de la Biósfera Sian Ka'an", 8, "https://caleatulum.com/wp-content/uploads/2025/04/Reserva-de-la-Biosfera-Sian-Kaan--1078x595.jpg", 0 },
                    { 24, "Reserva de la Biósfera Sian Ka'an", 8, "https://elmomentoqroo.mx/wp-content/uploads/2025/06/Preservacion-de-la-flora-y-fauna-en-la-Reserva-de-Sian-Kaan-Foto-por-Patrimonio-Mundial-de-Mexico-UNESCO.png", 0 }
                });

            migrationBuilder.InsertData(
                table: "PlaceAmenity",
                columns: new[] { "AmenityId", "PlaceId" },
                values: new object[,]
                {
                    { 2, 6 },
                    { 3, 6 },
                    { 1, 7 },
                    { 4, 7 },
                    { 1, 8 },
                    { 3, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PlaceAmenity",
                keyColumns: new[] { "AmenityId", "PlaceId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "PlaceAmenity",
                keyColumns: new[] { "AmenityId", "PlaceId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "PlaceAmenity",
                keyColumns: new[] { "AmenityId", "PlaceId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "PlaceAmenity",
                keyColumns: new[] { "AmenityId", "PlaceId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "PlaceAmenity",
                keyColumns: new[] { "AmenityId", "PlaceId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "PlaceAmenity",
                keyColumns: new[] { "AmenityId", "PlaceId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.UpdateData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "PlaceId", "Url" },
                values: new object[] { "Sótano de las Golondrinas", 2, "https://transpais.com.mx/wp-content/uploads/2023/04/golondrinas.jpg" });

            migrationBuilder.UpdateData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "PlaceId", "Url" },
                values: new object[] { "Cráteres de El Pinacate", 3, "https://rocateca.unison.mx/wp-content/uploads/2020/09/el-elegante.jpg" });

            migrationBuilder.UpdateData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "PlaceId", "Url" },
                values: new object[] { "Prismas Basálticos", 4, "https://www.huascaguiaturistica.com/huasca-imagenes/1-prismas-basalticos.jpg" });

            migrationBuilder.UpdateData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "PlaceId", "Url" },
                values: new object[] { "Sima de las Cotorras", 5, "https://mxc.com.mx/wp-content/uploads/2021/02/sima-de-las-cotorras-1024x576.jpg" });
        }
    }
}
