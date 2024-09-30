// Controllers/ItemsController.cs
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebAPIMethods.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebAPIMethods.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private static List<Item> _items = new List<Item>
        {
            new Item { Id = 1, Name = "Item1" },
            new Item { Id = 2, Name = "Item2" }
        };

        [HttpGet]
        public ActionResult<List<Item>> GetItems() => Ok(_items);

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<Item> CreateItem([FromBody] Item newItem)
        {
            newItem.Id = _items.Max(i => i.Id) + 1; // Simple ID generation
            _items.Add(newItem);
            return CreatedAtAction(nameof(GetItem), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, [FromBody] Item updatedItem)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            item.Name = updatedItem.Name; // Update the item
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PatchItem(int id, [FromBody] JsonPatchDocument<Item> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest("Invalid patch document.");
            }

            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            _items.Remove(item);
            return NoContent();
        }

        [HttpHead("{id}")]
        public IActionResult HeadItem(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            return NoContent();
        }

        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, PATCH, DELETE, HEAD, OPTIONS");
            return Ok();
        }
    }
}
