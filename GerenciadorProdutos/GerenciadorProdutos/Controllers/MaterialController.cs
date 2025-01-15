using Azure;
using GerenciadorMaterial.Api.Service;
using GerenciadorMaterial.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorMaterial.Api.Controllers
{
    [Route("api/material")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        public readonly IMaterialService _materialService;
        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet("getall")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var retorno = await _materialService.MaterialObterTodos();
            return Ok(retorno);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var material = await _materialService.MaterialObter(new Material {Id = id });
            if (material == null)
                return NotFound();
            return Ok(material);
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] Material material)
        {
            await _materialService.MaterialInserir(material);
            return Ok(material);
        }

        [HttpPut("update")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] Material updatedMaterial)
        {
            await _materialService.MaterialAtualizar(updatedMaterial);
            return Ok(true);
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _materialService.MaterialDeletar(new Material { Id = id });
            return Ok(true);
        }
    }
}
