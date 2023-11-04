using Microsoft.AspNetCore.Mvc;
using TestExersize.Models;
using MediatR;

namespace TestExersize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly MaterialExampleDataStore _context;
        private readonly IMediator _mediator;

        public SellerController(MaterialExampleDataStore context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        //получение списка всех продавцов
        [HttpGet(Name = "GetAllSellers")]
        public async Task<ActionResult> GetSellers()
        {
        var sellers = await _mediator.Send(new GetSellersQuery());
        return Ok(sellers);
        }

        //добавление продавца
        [HttpPost(Name = "AddSeller")]
        public async Task<ActionResult> AddSeller([FromBody]Seller seller)
        {
        var sellerToReturn = await _mediator.Send(new AddSellerCommand(seller));
        return CreatedAtRoute("GetSellerById", new { id = sellerToReturn.Id}, sellerToReturn);
        }

        //получение информации об продавце по его айди
        [HttpGet("{id:int}", Name = "GetSellerById")]
        public async Task<ActionResult> GetSellerById(int id)
        {
        var seller = await _mediator.Send(new GetSellerByIdQuery(id));

        return Ok(seller);
        }

        //удаление продавца
        [HttpDelete(Name = "DeleteSeller")]
        public async Task<ActionResult> DeleteSeller(int id){
            var seller = await _mediator.Send(new DeleteSellerQuery(id));
            return Ok(seller);
        }

        //обновление информации о продавце
        [HttpPost("{id:int}",Name = "UpdateSeller")]
        public async Task<ActionResult> UpdateSeller(int id, [FromBody]Seller seller)
        {
        var sellerToReturn = await _mediator.Send(new UpdateSellerCommand(id,seller));
        return CreatedAtRoute("GetSellerById", new { id = sellerToReturn.Id}, sellerToReturn);
        }
    }
}
