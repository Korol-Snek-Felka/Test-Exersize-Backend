using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestExersize.Models;

namespace TestExersize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly TestExersizeContext _context;

        public SellerController(TestExersizeContext context)
        {
            _context = context;
        }

        // GET: api/Seller
        //получение списка всех продавцов
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetSellerItems()
        {
          if (_context.SellerItems == null)
          {
              return NotFound();
          }
            return await _context.SellerItems.ToListAsync();
        }

        // GET: api/Seller/5
        //получение информации о продавце по его Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Seller>> GetSeller(int id)
        {
          if (_context.SellerItems == null)
          {
              return NotFound();
          }
            var seller = await _context.SellerItems.FindAsync(id);

            if (seller == null)
            {
                return NotFound();
            }

            return seller;
        }
        
        // POST: api/Seller
        // создание нового продавца
        [HttpPost]
        public async Task<ActionResult<Seller>> PostSeller(Seller seller)
        {
          if (_context.SellerItems == null)
          {
              return Problem("Entity set 'TestExersizeContext.SellerItems'  is null.");
          }
            _context.SellerItems.Add(seller);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeller), new { id = seller.Id, name = seller.Name }, seller);
        }

        // POST: api/Seller
        // обновление информации о продавце
        [HttpPost("{id}")]
        public async Task<ActionResult<Seller>> UpdateSeller(int id, Seller seller){
            if (_context.SellerItems == null)
          {
              return NotFound();
          }
            var updatingSeller = await _context.SellerItems.FindAsync(id);

            if (updatingSeller == null)
            {
                return NotFound();
            }
             _context.SellerItems.Remove(updatingSeller);//удаление старого продавца
             _context.SellerItems.Add(seller);//добавление нового продавца
             
             await _context.SaveChangesAsync();
             return CreatedAtAction(nameof(GetSeller), new { id = seller.Id, name = seller.Name }, seller);
        }
        // DELETE: api/Seller/5
        //удаление продавца
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeller(int id)
        {
            if (_context.SellerItems == null)
            {
                return NotFound();
            }
            var seller = await _context.SellerItems.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }

            _context.SellerItems.Remove(seller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SellerExists(int id)
        {
            return (_context.SellerItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
