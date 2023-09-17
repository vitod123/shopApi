using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace shopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketsService basketsService;

        public BasketsController(IBasketsService basketsService)
        {
            this.basketsService = basketsService;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await basketsService.GetAll());
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await basketsService.GetById(id);
            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpGet("{userName}/User")]
        public async Task<IActionResult> GetUser([FromRoute] string userName)
        {
            var item = await basketsService.GetByUserName(userName);
            if (item == null) return NotFound();

            return Ok(item);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BasketDto basket)
        {
            if (!ModelState.IsValid) return BadRequest();

            await basketsService.Create(basket);

            return Ok();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] BasketDto basket)
        {
            if (!ModelState.IsValid) return BadRequest();

            await basketsService.Edit(basket);

            return Ok();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await basketsService.Delete(id);

            return Ok();
        }
    }
}
