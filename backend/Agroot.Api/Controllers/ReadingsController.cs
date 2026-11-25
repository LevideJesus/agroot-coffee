using Agroot.Api.Models;
using Microsoft.AspNetCore.Mvc;


namespace Agroot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadingsController : ControllerBase
    {
        private static readonly List<Reading> _readings = new();

        [HttpGet]

        public ActionResult<IEnumerable<Reading>> GetReadings()
        {
            return Ok(_readings);
        }

        [HttpGet("{id:int}")]

        public ActionResult<Reading> GetReadingById(int id)
        {
            var reading = _readings.FirstOrDefault(r => r.Id == id);

            if (reading is null)
            {
                return NotFound();
            }

            return Ok(reading);
        }

        [HttpPost]

        public ActionResult<Reading> CreateReading([FromBody] Reading reading)
        {
            lock (_readings)
            {
                reading.Id = _readings.Count + 1;

                _readings.Add(reading);
            }

            return CreatedAtAction(nameof(GetReadingById), new { id = reading.Id }, reading);
        }
    }
}