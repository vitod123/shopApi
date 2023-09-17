using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace shopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesService favoritesService;

        public FavoritesController(IFavoritesService favoritesService)
        {
            this.favoritesService = favoritesService;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await favoritesService.GetAll());
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await favoritesService.GetById(id);
            if (item == null) return NotFound();

            return Ok(item);
        }
        [HttpGet("{userName}/User")]
        public async Task<IActionResult> GetUser([FromRoute] string userName)
        {
            var item = await favoritesService.GetByUserName(userName);
            if (item == null) return NotFound();

            return Ok(item);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FavoriteDto favorite)
        {
            if (!ModelState.IsValid) return BadRequest();

            await favoritesService.Create(favorite);

            return Ok();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] FavoriteDto favorite)
        {
            if (!ModelState.IsValid) return BadRequest();

            await favoritesService.Edit(favorite);

            return Ok();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await favoritesService.Delete(id);

            return Ok();
        }
    }
}
