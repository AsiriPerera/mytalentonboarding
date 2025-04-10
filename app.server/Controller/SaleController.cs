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
    public class SaleController : ControllerBase
    {
        private readonly MytalentonboardingContext _context;

        public SaleController(MytalentonboardingContext context)
        {
            _context = context;
        }

        // GET: api/Sale
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleDto>>> GetSales()
        {
            var _sales = await _context.Sales
                .Select(s => SaleMapper.EntityToDto(s))
                .ToListAsync();
            if ((_sales == null) || (_sales.Count == 0))
            {
                return NotFound("sale not found");
            }
            else
            {
                return Ok(_sales);
            }
        }

        // GET: api/Sale/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDto>> GetSale(int id)
        {
            var _sale = await _context.Sales.FindAsync(id);

            if (_sale == null)
            {
                return NotFound("sale not found");
            }
            else
            {
                var sale = SaleMapper.EntityToDto(_sale);
                return Ok(sale);
            };
        }

        // PUT: api/Sale/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, SaleDto sale)
        {
            if (id != sale.Id)
            {
                return BadRequest();
            }

            var _sale = SaleMapper.DtoToEntity(sale);
            _context.Entry(_sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
                {
                    return NotFound("sale not found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sale
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(SaleDto sale)
        {
            var _sale = SaleMapper.DtoToEntity(sale);
            _context.Sales.Add(_sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }

        // DELETE: api/Sale/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }
    }
}
