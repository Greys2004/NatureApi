using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using natureApi;
using NatureApi.Models.DTOs;
using OpenAI.Chat;
using StoreApi.Models.Entities;

namespace NatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlaceController : ControllerBase
    {
        private readonly NatureDbContext _context;
        private readonly IConfiguration _config;

        public PlaceController(NatureDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces(
            [FromQuery] string? category,
            [FromQuery] string? difficulty)
        {
            var query = _context.Place
                .Include(p => p.Trails)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category == category);

            if (!string.IsNullOrEmpty(difficulty))
                query = query.Where(p => p.Trails.Any(t => t.Difficulty == difficulty));

            var places = await query.ToListAsync();
            return Ok(places);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetPlace(int id)
        {
            var place = await _context.Place
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.Category,
                    p.Latitude,
                    p.Longitude,
                    p.ElevationMeters,
                    p.Accessible,
                    p.EntryFee,
                    p.OpeningHours,
                    p.CreatedAt,

                    photos = p.Photos.Select(ph => new {
                        ph.Id, ph.PlaceId, ph.Url, ph.Description
                    }).ToList(),

                    // a partir del join, construyo el array plano "amenities"
                    amenities = p.PlaceAmenities
                        .Select(pa => new { pa.Amenity.Id, pa.Amenity.Name })
                        .ToList(),

                    trails = p.Trails.Select(t => new {
                        t.Id, t.PlaceId, t.Name, t.DistanceKm, t.EstimatedTimeMinutes,
                        t.Difficulty, t.Path, t.IsLoop
                    }).ToList()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (place == null) return NotFound();
            return Ok(place);
        }


        [HttpPost]
        public async Task<ActionResult> CreatePlace([FromBody] PlaceDto dto)
        {
            try
            {
                var newPlace = new Place
                {
                    Name = dto.Name,
                    Category = dto.Category,
                    Latitude = dto.Latitude,
                    Longitude = dto.Longitude,
                    Description = dto.Description, 
                    ElevationMeters = dto.ElevationMeters,    
                    Accessible = dto.Accessible,
                    EntryFee = dto.EntryFee,
                    OpeningHours = dto.OpeningHours,
                    CreatedAt = DateTime.Now
                };

                _context.Place.Add(newPlace);
                await _context.SaveChangesAsync();


                if (!string.IsNullOrEmpty(dto.Difficulty))
                {
                    var trail = new Trail
                    {
                        PlaceId = newPlace.Id,
                        Name = "Sendero principal",
                        DistanceKm = 1.0,
                        EstimatedTimeMinutes = 30,
                        Difficulty = dto.Difficulty,
                        Path = "",
                        IsLoop = false
                    };
                    _context.Trail.Add(trail);
                    await _context.SaveChangesAsync();
                }

                return Ok(newPlace);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
        
        [HttpGet("ai-analyze")]
        public async Task<ActionResult> AnalyzePlacesWithAI()
        {
            // 1. Obtener la key de OpenAI desde config
            var openAIKey = _config["OpenAIKey"];
            if (string.IsNullOrWhiteSpace(openAIKey))
            {
                return Problem("OpenAIKey no está configurada.");
            }

            var client = new ChatClient(
                model: "gpt-5-mini",
                apiKey: openAIKey
            );

            // 2. Obtener datos de la BD
            var places = await _context.Place
                .Include(p => p.Trails)
                .Include(p => p.PlaceAmenities)
                    .ThenInclude(pa => pa.Amenity)
                .AsNoTracking()
                .ToListAsync();

            var summary = places.Select(p => new
            {
                p.Id,
                p.Name,
                p.Category,
                p.Accessible,
                p.EntryFee,
                p.OpeningHours,
                Trails = p.Trails.Select(t => new
                {
                    t.Name,
                    t.DistanceKm,
                    t.EstimatedTimeMinutes,
                    t.Difficulty,
                    t.IsLoop
                }),
                Amenities = p.PlaceAmenities.Select(pa => pa.Amenity.Name)
            });

            var jsonData = JsonSerializer.Serialize(summary);

            // 3. Generar prompt
            var prompt = Prompts.GeneratePlacesPrompt(jsonData);

            // 4. Llamar a la IA
            var result = await client.CompleteChatAsync([
                new UserChatMessage(prompt)
            ]);

            var responseText = result.Value.Content[0].Text?.Trim();

            if (string.Equals(responseText, "error", StringComparison.OrdinalIgnoreCase))
            {
                return Problem("La IA no pudo generar el análisis.");
            }

            // 5. Regresar el JSON TAL CUAL al front
            return Content(responseText, "application/json");
        }
    }
    
    
    [Route("api/[controller]")]
    [ApiController]
    public class TrailsController : ControllerBase
    {
        private readonly NatureDbContext _context;
        private readonly IConfiguration _config;

        public TrailsController(NatureDbContext context,  IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: /api/trails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trail>>> GetTrails(
            [FromQuery] int? placeId,
            [FromQuery] string? difficulty)
        {
            var query = _context.Trail.AsQueryable();

            if (placeId.HasValue)
                query = query.Where(t => t.PlaceId == placeId.Value);

            if (!string.IsNullOrEmpty(difficulty))
                query = query.Where(t => t.Difficulty == difficulty);

            var trails = await query.ToListAsync();
            return Ok(trails);
        }

        // GET: /api/trails/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Trail>> GetTrail(int id)
        {
            var trail = await _context.Trail.FindAsync(id);
            if (trail == null) return NotFound();
            return Ok(trail);
        }
        
        // GET: /api/trails/ai-analyze
        [HttpGet("ai-analyze")]
        public async Task<ActionResult> AnalyzeTrailsWithAI()
        {
            // 1. Leer OpenAIKey desde configuración (appsettings/variables)
            var openAIKey = _config["OpenAIKey"];
            if (string.IsNullOrWhiteSpace(openAIKey))
            {
                return Problem("OpenAIKey no está configurada.");
            }

            // 2. Crear cliente de OpenAI
            var client = new ChatClient(
                model: "gpt-5-mini",
                apiKey: openAIKey
            );

            // 3. Obtener senderos de la BD, incluyendo el lugar (para mostrar placeName)
            var trails = await _context.Trail
                .Include(t => t.Place)
                .AsNoTracking()
                .ToListAsync();

            // 4. Proyectar a un JSON más limpio para la IA
            var summary = trails.Select(t => new
            {
                t.Id,
                t.Name,
                t.DistanceKm,
                t.EstimatedTimeMinutes,
                t.Difficulty,
                t.IsLoop,
                PlaceName = t.Place != null ? t.Place.Name : null,
                PlaceCategory = t.Place != null ? t.Place.Category : null,
                PlaceElevation = t.Place != null ? t.Place.ElevationMeters : null
            });

            var jsonData = JsonSerializer.Serialize(summary);

            // 5. Generar el prompt para la IA
            var prompt = Prompts.GenerateTrailsPrompt(jsonData);

            // 6. Llamar a OpenAI
            var result = await client.CompleteChatAsync([
                new UserChatMessage(prompt)
            ]);

            var responseText = result.Value.Content[0].Text?.Trim();

            if (string.Equals(responseText, "error", StringComparison.OrdinalIgnoreCase))
            {
                return Problem("La IA no pudo generar el análisis de senderos.");
            }

            // 7. Regresar el JSON tal cual
            return Content(responseText, "application/json");
        }

    }

}
