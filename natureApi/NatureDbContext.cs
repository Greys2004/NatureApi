using Microsoft.EntityFrameworkCore;
using StoreApi.Models.Entities;

namespace NatureApi;

public class NatureDbContext : DbContext
{

    public DbSet<Place> Place { get; set; }
    public DbSet<Trail> Trail { get; set; }
    public DbSet<Photo> Photo { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<Amenity> Amenity { get; set; }
    public DbSet<PlaceAmenity> PlaceAmenity { get; set; }

    public NatureDbContext(DbContextOptions<NatureDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PlaceAmenity>()
            .HasKey(pa => new { pa.PlaceId, pa.AmenityId });


        modelBuilder.Entity<Amenity>().HasData(
            new Amenity { Id = 1, Name = "Baños" },
            new Amenity { Id = 2, Name = "Estacionamiento" },
            new Amenity { Id = 3, Name = "Mirador" },
            new Amenity { Id = 4, Name = "Área de comida" },
            new Amenity { Id = 5, Name = "Zona de campamento" }
        );

        modelBuilder.Entity<Place>().HasData(
            new Place
            {
                Id = 1,
                Name = "Reserva de la Biósfera Mariposa Monarca",
                Description = "Santuario natural en Michoacán, hábitat invernal de la mariposa monarca.",
                Category = "reserva",
                Latitude = 19.631, Longitude = -100.283,
                ElevationMeters = 3000, Accessible = true,
                EntryFee = 70, OpeningHours = "09:00-17:00",
                CreatedAt = new DateTime(2024, 06, 05)
            },
            new Place
            {
                Id = 2,
                Name = "Sótano de las Golondrinas",
                Description = "Cueva vertical en San Luis Potosí famosa por el vuelo de miles de aves.",
                Category = "cueva",
                Latitude = 21.597, Longitude = -99.098,
                ElevationMeters = 900, Accessible = true,
                EntryFee = 100, OpeningHours = "07:00-18:00",
                CreatedAt = new DateTime(2024, 03, 25)
            },
            new Place
            {
                Id = 3,
                Name = "Cráteres de El Pinacate",
                Description = "Campo volcánico con cráteres impresionantes en Sonora.",
                Category = "volcán",
                Latitude = 31.783, Longitude = -113.533,
                ElevationMeters = 1200, Accessible = true,
                EntryFee = 70, OpeningHours = "08:00-17:00",
                CreatedAt = new DateTime(2024, 02, 26)
            },
            new Place
            {
                Id = 4,
                Name = "Prismas Basálticos",
                Description = "Formaciones geométricas de basalto en Hidalgo.",
                Category = "formación geológica",
                Latitude = 20.211, Longitude = -98.581,
                ElevationMeters = 2100, Accessible = true,
                EntryFee = 80, OpeningHours = "09:00-18:00",
                CreatedAt = new DateTime(2024, 03, 14)
            },
            new Place
            {
                Id = 5,
                Name = "Sima de las Cotorras",
                Description = "Hundimiento natural en Chiapas con selva en el interior.",
                Category = "sima",
                Latitude = 16.726, Longitude = -93.368,
                ElevationMeters = 900, Accessible = true,
                EntryFee = 60, OpeningHours = "07:00-17:00",
                CreatedAt = new DateTime(2024, 01, 01)
            }
        );

        modelBuilder.Entity<Trail>().HasData(
            new Trail
            {
                Id = 1, PlaceId = 1, Name = "Sendero Mariposas",
                DistanceKm = 2.5, EstimatedTimeMinutes = 60, Difficulty = "easy", IsLoop = true,
                Path = "[[19.6305,-100.2825],[19.6312,-100.2835],[19.632,-100.284]]"
            },
            new Trail
            {
                Id = 2, PlaceId = 2, Name = "Descenso al sótano",
                DistanceKm = 1.2, EstimatedTimeMinutes = 90, Difficulty = "hard", IsLoop = false,
                Path = "[[21.597,-99.098],[21.5975,-99.097],[21.598,-99.096]]"
            },
            new Trail
            {
                Id = 3, PlaceId = 3, Name = "Ruta cráter El Elegante",
                DistanceKm = 3.5, EstimatedTimeMinutes = 120, Difficulty = "moderate", IsLoop = true,
                Path = "[[31.783,-113.533],[31.784,-113.532],[31.785,-113.531]]"
            },
            new Trail
            {
                Id = 4, PlaceId = 4, Name = "Sendero Prismas",
                DistanceKm = 1.0, EstimatedTimeMinutes = 30, Difficulty = "easy", IsLoop = true,
                Path = "[[20.211,-98.581],[20.212,-98.5805],[20.2125,-98.580]]"
            },
            new Trail
            {
                Id = 5, PlaceId = 5, Name = "Sendero Sima",
                DistanceKm = 2.0, EstimatedTimeMinutes = 60, Difficulty = "moderate", IsLoop = false,
                Path = "[[16.726,-93.368],[16.727,-93.367],[16.728,-93.366]]"
            }
        );

        modelBuilder.Entity<Photo>().HasData(
            new Photo
            {
                Id = 1, PlaceId = 1,
                Url = "https://cdn.milenio.com/uploads/media/2015/10/23/tala-ilegal-reserva-biosfera-mariposa.jpeg",
                Description = "Reserva de la Biósfera Mariposa Monarca"
            },
            new Photo
            {
                Id = 2, PlaceId = 1,
                Url = "https://www.patrimoniomundial.com.mx/wp-content/uploads/2013/10/Monarcas1.jpg",
                Description = "Reserva de la Biósfera Mariposa Monarca"
            },
            new Photo
            {
                Id = 3, PlaceId = 1,
                Url = "https://programadestinosmexico.com/wp-content/uploads/2023/12/RESERVA-DE-LA-MARIPOSA-MONARCA.jpg",
                Description = "Reserva de la Biósfera Mariposa Monarca"
            },
            new Photo
            {
                Id = 4, PlaceId = 2,
                Url = "https://transpais.com.mx/wp-content/uploads/2023/04/golondrinas.jpg",
                Description = "Sótano de las Golondrinas"
            },
            new Photo
            {
                Id = 5, PlaceId = 2,
                Url = "https://revistaaventurero.com.mx/wp-content/uploads/2018/01/SOTANO-DE-LAS-GOLONDRINAS-www.puntofape.com_.jpg",
                Description = "Sótano de las Golondrinas"
            },
            new Photo
            {
                Id = 6, PlaceId = 2,
                Url = "https://img.travesiasdigital.com/cdn-cgi/image/quality=90,format=auto,onerror=redirect/2019/03/sotano-de-las-golondrinas-aves.jpg",
                Description = "Sótano de las Golondrinas"
            },
            new Photo
            {
                Id = 7, PlaceId = 3,
                Url = "https://rocateca.unison.mx/wp-content/uploads/2020/09/el-elegante.jpg",
                Description = "Cráteres de El Pinacate"
            },
            new Photo
            {
                Id = 8, PlaceId = 3,
                Url = "https://sic.cultura.gob.mx/images/38880",
                Description = "Cráteres de El Pinacate"
            },
            new Photo
            {
                Id = 9, PlaceId = 3,
                Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqkp-cTeUXQ1sl7yLsu1K4v-DKs-CzdWrvrg&s",
                Description = "Cráteres de El Pinacate"
            },
            new Photo
            {
                Id = 10, PlaceId = 4,
                Url = "https://www.huascaguiaturistica.com/huasca-imagenes/1-prismas-basalticos.jpg",
                Description = "Prismas Basálticos"
            },
            new Photo
            {
                Id = 11, PlaceId = 4,
                Url = "https://www.mexicodestinos.com/blog/wp-content/uploads/2021/07/prismas-630x420.jpg",
                Description = "Prismas Basálticos"
            },
            new Photo
            {
                Id = 12, PlaceId = 4,
                Url = "https://www.huascaguiaturistica.com/huasca-imagenes/1-prismas-basalticos.jpg",
                Description = "Prismas Basálticos"
            },
            new Photo
            {
                Id = 13, PlaceId = 5,
                Url = "https://mxc.com.mx/wp-content/uploads/2021/02/sima-de-las-cotorras-1024x576.jpg",
                Description = "Sima de las Cotorras"
            },
            new Photo
            {
                Id = 14, PlaceId = 5,
                Url = "https://www.mexicodesconocido.com.mx/wp-content/uploads/2016/09/WhatsApp-Image-2020-07-15-at-19.03.28.jpeg",
                Description = "Sima de las Cotorras"
            },
            new Photo
            {
                Id = 15, PlaceId = 5,
                Url = "https://disfrutachiapas.com/wp-content/uploads/2023/12/simacotorras-1024x683.jpg",
                Description = "Sima de las Cotorras"
            },
            new Photo
            {
                Id = 16, PlaceId = 6,
                Url = "https://dexter.cancunairporttransportations.com/vendor/blog/gallery/2022/05/cenote_ik_kil-tour.jpg",
                Description = "Cenote Ik Kil"
            },
            new Photo
            {
                Id = 17, PlaceId = 6,
                Url = "https://topyucatan.com/storage/uploads/178495071-1332905113762718-8561404485712747862-n-1626902981.jpg",
                Description = "Cenote Ik Kil"
            },
            new Photo
            {
                Id = 18, PlaceId = 6,
                Url = "https://static.vecteezy.com/system/resources/previews/060/531/480/large_2x/cenote-ik-kil-yucatan-mexico-sunlight-illuminating-turquoise-water-in-a-mysterious-cave-photo.jpg",
                Description = "Cenote Ik Kil"
            },
            new Photo
            {
                Id = 19, PlaceId = 7,
                Url = "https://www.gob.mx/cms/uploads/image/file/247330/Basaseachi__foto_Teresita_Lasso__18_.JPG",
                Description = "Cascada Basaseachi"
            },
            new Photo
            {
                Id = 20, PlaceId = 7,
                Url = "https://mxc.com.mx/wp-content/uploads/2020/07/292750-684x1024.jpg",
                Description = "Cascada Basaseachi"
            },
            new Photo
            {
                Id = 21, PlaceId = 7,
                Url = "https://chihuahua.gob.mx/sites/default/files/grupos/user599/cascada_de_basaseachi_2.jpg",
                Description = "Cascada Basaseachi"
            },
            new Photo
            {
                Id = 22, PlaceId = 8,
                Url = "https://media-cdn.tripadvisor.com/media/attractions-splice-spp-674x446/06/6f/10/c3.jpg",
                Description = "Reserva de la Biósfera Sian Ka'an"
            },
            new Photo
            {
                Id = 23, PlaceId = 8,
                Url = "https://caleatulum.com/wp-content/uploads/2025/04/Reserva-de-la-Biosfera-Sian-Kaan--1078x595.jpg",
                Description = "Reserva de la Biósfera Sian Ka'an"
            },
            new Photo
            {
                Id = 24, PlaceId = 8,
                Url = "https://elmomentoqroo.mx/wp-content/uploads/2025/06/Preservacion-de-la-flora-y-fauna-en-la-Reserva-de-Sian-Kaan-Foto-por-Patrimonio-Mundial-de-Mexico-UNESCO.png",
                Description = "Reserva de la Biósfera Sian Ka'an"
            }
        );

        modelBuilder.Entity<PlaceAmenity>().HasData(
            new PlaceAmenity { PlaceId = 1, AmenityId = 1 },
            new PlaceAmenity { PlaceId = 1, AmenityId = 2 },
            new PlaceAmenity { PlaceId = 2, AmenityId = 3 },
            new PlaceAmenity { PlaceId = 3, AmenityId = 2 },
            new PlaceAmenity { PlaceId = 3, AmenityId = 5 },
            new PlaceAmenity { PlaceId = 4, AmenityId = 1 },
            new PlaceAmenity { PlaceId = 4, AmenityId = 4 },
            new PlaceAmenity { PlaceId = 5, AmenityId = 2 },
            new PlaceAmenity { PlaceId = 5, AmenityId = 3 },
            new PlaceAmenity { PlaceId = 6, AmenityId = 2 },
            new PlaceAmenity { PlaceId = 6, AmenityId = 3 },
            new PlaceAmenity { PlaceId = 7, AmenityId = 1 },
            new PlaceAmenity { PlaceId = 7, AmenityId = 4 },
            new PlaceAmenity { PlaceId = 8, AmenityId = 3 },
            new PlaceAmenity { PlaceId = 8, AmenityId = 1 }
        );
    }
}
