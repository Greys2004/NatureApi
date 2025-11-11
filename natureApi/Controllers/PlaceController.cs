using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NatureApi.Models.DTOs;
using StoreApi.Models.Entities;

namespace NatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlaceController : ControllerBase
    {
        private readonly NatureDbContext _context;

        public PlaceController(NatureDbContext context)
        {
            _context = context;
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
    }
    
    
    [Route("api/[controller]")]
    [ApiController]
    public class TrailsController : ControllerBase
    {
        private readonly NatureDbContext _context;

        public TrailsController(NatureDbContext context)
        {
            _context = context;
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
    }
}
