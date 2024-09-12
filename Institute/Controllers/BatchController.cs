using Institute.Data;
using Institute.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Institute.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BatchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BatchController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Batch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetBatches()
        {
            // Fetches all batches from the database
            return await _context.Batches.ToListAsync();
        }

        // GET: api/Batch/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Batch>> GetBatch(int id)
        {
            // Finds a batch by its ID
            var batch = await _context.Batches.FindAsync(id);

            if (batch == null)
            {
                return NotFound(); // Returns 404 if the batch is not found
            }

            return batch;
        }

        // POST: api/Batch
        [HttpPost]
        public async Task<ActionResult<Batch>> PostBatch(Batch batch)
        {
            // Adds a new batch to the database
            _context.Batches.Add(batch);
            await _context.SaveChangesAsync();

            // Returns a 201 Created response with the location of the new batch
            return CreatedAtAction(nameof(GetBatch), new { id = batch.Id }, batch);
        }

        // PUT: api/Batch/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatch(int id, Batch batch)
        {
            if (id != batch.Id)
            {
                return BadRequest(); // Returns 400 Bad Request if the ID doesn't match
            }

            _context.Entry(batch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); // Updates the batch in the database
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatchExists(id))
                {
                    return NotFound(); // Returns 404 if the batch is not found
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Returns 204 No Content if the update is successful
        }

        // DELETE: api/Batch/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            // Finds and removes the batch from the database
            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound(); // Returns 404 if the batch is not found
            }

            _context.Batches.Remove(batch);
            await _context.SaveChangesAsync();

            return NoContent(); // Returns 204 No Content if the deletion is successful
        }

        private bool BatchExists(int id)
        {
            // Checks if a batch exists in the database
            return _context.Batches.Any(e => e.Id == id);
        }
    }
}