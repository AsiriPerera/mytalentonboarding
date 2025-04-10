using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using app.server.Models;
using app.server.Dtos;
using app.server.Mappers;

namespace app.server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly MytalentonboardingContext _context;

        public StoreController(MytalentonboardingContext context)
        {
            _context = context;
        }

        // GET: api/Store
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreDto>>> GetStores()
        {
            var _stores = await _context.Stores
                .Select(s => StoreMapper.EntityToDto(s))
                .ToListAsync();
            if ((_stores == null) || (_stores.Count == 0))
            {
                return NotFound("store not found");
            }
            else
            {
                return Ok(_stores);
            }
        }

        // GET: api/Store/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDto>> GetStore(int id)
        {
            var _store = await _context.Stores.FindAsync(id);

            if (_store == null)
            {
                return NotFound("store not found");
            }
            else
            {
                var store = StoreMapper.EntityToDto(_store);
                return Ok(store);
            };
        }

        // PUT: api/Store/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore(int id, StoreDto store)
        {
            if (id != store.Id)
            {
                return BadRequest();
            }

            var _store = StoreMapper.DtoToEntity(store);
            _context.Entry(_store).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
                {
                    return NotFound("store not found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Store
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Store>> PostStore(StoreDto store)
        {
            var _store = StoreMapper.DtoToEntity(store);
            _context.Stores.Add(_store);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStore", new { id = store.Id }, store);
        }

        // DELETE: api/Store/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreExists(int id)
        {
            return _context.Stores.Any(e => e.Id == id);
        }
    }
}
