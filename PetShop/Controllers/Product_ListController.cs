using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_ListController : ControllerBase
    {
        private readonly PetShopDbContext _context;

        public Product_ListController(PetShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Product_List
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_List>>> GetProduct_Lists()
        {
            return await _context.Product_Lists.ToListAsync();
        }

        // GET: api/Product_List/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_List>> GetProduct_List(int id)
        {
            var product_List = await _context.Product_Lists.FindAsync(id);

            if (product_List == null)
            {
                return NotFound();
            }

            return product_List;
        }

        // PUT: api/Product_List/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct_List(int id, Product_List product_List)
        {
            if (id != product_List.Id)
            {
                return BadRequest();
            }

            _context.Entry(product_List).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_ListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product_List
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product_List>> PostProduct_List(Product_List product_List)
        {
            _context.Product_Lists.Add(product_List);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct_List", new { id = product_List.Id }, product_List);
        }

        // DELETE: api/Product_List/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct_List(int id)
        {
            var product_List = await _context.Product_Lists.FindAsync(id);
            if (product_List == null)
            {
                return NotFound();
            }

            _context.Product_Lists.Remove(product_List);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Product_ListExists(int id)
        {
            return _context.Product_Lists.Any(e => e.Id == id);
        }
    }
}
