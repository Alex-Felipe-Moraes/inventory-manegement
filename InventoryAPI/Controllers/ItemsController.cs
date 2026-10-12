using InventoyAPI.Data;
using InventoyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Controllers{

    [ApiController]
    [Route("api/[controller]")]

    public class ItemsController : ControllerBase {
        private readonly InventoryContext _context;

        public ItemsController(InventoryContext context){

            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems(){

            return await _context.items.ToListAsync();

        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<Item>> GetItem(int Id){

            var item = await _context.items.FindAsync(Id);
            if(item == null)
            {
                return NotFound();
            }
            return item;

        } 


        // ADD
        [HttpPost]
        public async Task<ActionResult<Item>> AddItem(Item item){

            _context.items.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item);
            
        }


        // UPDATE
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateItem(int id, Item item){

            if (id == item.Id){
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else{
                return BadRequest();
            }

        }


        //DELETE
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id){

            var item = await _context.items.FindAsync(Id);
            
            if(item == null){
                return NotFound();
               
            }

            _context.items.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();

        }


    }
}