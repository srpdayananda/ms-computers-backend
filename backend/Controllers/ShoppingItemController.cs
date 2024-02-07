using backend.Data;
using backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingItemController : ControllerBase
    {
        private readonly DataContext _context;

        public ShoppingItemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<ShoppingItem>>> GetShoppingItems()
        {
            return Ok(await _context.shoppingItems.ToListAsync());
        }

        [HttpPost]

        public async Task<ActionResult<List<ShoppingItem>>> CreateShoppingItem(ShoppingItem item)
        {
            _context.shoppingItems.Add(item);
            await _context.SaveChangesAsync();

            return Ok(await _context.shoppingItems.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<ShoppingItem>>> updateShoppingItem(ShoppingItem item)
        {
            var dbShoppingItem = await _context.shoppingItems.FindAsync(item.Id);
            if (dbShoppingItem == null)
                return BadRequest("ShoppingItem not found");

            dbShoppingItem.Name = item.Name;
            dbShoppingItem.Img = item.Img;
            dbShoppingItem.Description = item.Description;
            dbShoppingItem.Quantity = item.Quantity;
            dbShoppingItem.Price = item.Price;

            await _context.SaveChangesAsync();

            return Ok(await _context.shoppingItems.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ShoppingItem>>> deleteShoppingItem(int id)
        {
            var dbShoppingItem = await _context.shoppingItems.FindAsync(id);
            if (dbShoppingItem == null)
                return BadRequest("ShoppingItem not found");

            _context.shoppingItems.Remove(dbShoppingItem);
            await _context.SaveChangesAsync();

            return Ok(await _context.shoppingItems.ToListAsync());
        }
    }
}
