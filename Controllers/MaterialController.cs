using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestExersize.Models;

namespace TestExersize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly TestExersizeContext _context;

        public MaterialController(TestExersizeContext context)
        {
            _context = context;
        }

        // GET
        // получение списка всех материалов
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterialItems()
        {
          if (_context.MaterialItems == null)
          {
              return NotFound();
          }
            return await _context.MaterialItems.ToListAsync();
        }

        // GET
        // получение информации об материале по его id
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
          if (_context.MaterialItems == null)
          {
              return NotFound();
          }
            var material = await _context.MaterialItems.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        // POST: api/Material
        // создание нового материала с указанием продавца
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(Material material)
        {
          if (_context.MaterialItems == null)
          {
              return Problem("Entity set 'TestExersizeContext.MaterialItems'  is null.");
          }

          //проверка на сущестование продавца
          int sellerId=material.SellerId;
          var seller = await _context.SellerItems.FindAsync(sellerId);

            if (seller == null)
            {
                return Problem("This seller does not exist! Enter seller before material!");
            }

            _context.MaterialItems.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMaterial), new { id = material.Id, name=material.Name, price=material.Price,
            sellerId=material.SellerId }, material);
        }

        // POST: api/Material
        // обновление информации о материале
        [HttpPost("{id}")]
        public async Task<ActionResult<Material>> UpdateMaterial(int id, Material material){
            if (_context.MaterialItems == null)
          {
              return NotFound();
          }
            var updatingMaterial = await _context.MaterialItems.FindAsync(id);

            if (updatingMaterial == null)
            {
                return NotFound();
            }
             _context.MaterialItems.Remove(updatingMaterial);//удаление старого материала
             _context.MaterialItems.Add(material);//добавление нового материала
             
             await _context.SaveChangesAsync();
             return CreatedAtAction(nameof(GetMaterial), new { id = material.Id, name=material.Name, price=material.Price,
            sellerId=material.SellerId }, material);

        }

        // DELETE: api/Material/5
        //удаление материала
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            if (_context.MaterialItems == null)
            {
                return NotFound();
            }
            var material = await _context.MaterialItems.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.MaterialItems.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialExists(int id)
        {
            return (_context.MaterialItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
