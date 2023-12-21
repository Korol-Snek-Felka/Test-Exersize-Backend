using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestExersize.Models;

namespace TestExersize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MaterialExampleDataStore _context;

        public MaterialController(MaterialExampleDataStore context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }

        //получение списка всех материалов
        [HttpGet(Name = "GetAllMaterials")]
        public async Task<ActionResult> GetMaterials()
        {
        var materials = await _mediator.Send(new GetMaterialsQuery());
        return Ok(materials);
        }

        //добавление материала
        [HttpPost(Name = "AddMAterial")]
        public async Task<ActionResult> AddMaterial([FromBody]Material material)
        {
        var materialToReturn = await _mediator.Send(new AddMaterialCommand(material));
        return CreatedAtRoute("GetMaterialById", new { id = materialToReturn.Id}, materialToReturn);
        }

        //получение информации об материале по его айди
        [HttpGet("{id:int}", Name = "GetMaterialById")]
        public async Task<ActionResult> GetMaterialById(int id)
        {
        var material = await _mediator.Send(new GetMaterialByIdQuery(id));

        return Ok(material);
        }

        //удаление материала
        [HttpDelete(Name = "DeleteMaterial")]
        public async Task<ActionResult> DeleteMaterial(int id){
            var material = await _mediator.Send(new DeleteMaterialQuery(id));
            return Ok(material);
        }

        //обновление информации о материале
        [HttpPost("{id:int}",Name = "UpdateMaterial")]
        public async Task<ActionResult> UpdateMaterial(int id, [FromBody]Material material)
        {
        var materialToReturn = await _mediator.Send(new UpdateMaterialCommand(id,material));
        return CreatedAtRoute("GetMaterialById", new { id = materialToReturn.Id}, materialToReturn);
        }
    }
}
