using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace shopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await productsService.GetAll());
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await productsService.GetById(id);
            if (item == null) return NotFound();

            return Ok(item);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{order}/Order")]
        public async Task<IActionResult> Order([FromRoute] string order)
        {
            if (order.Split(' ').Length > 1)
            {
                string[] orderByStr = order.Split(' ');
                order = "";
                for (int i = 0; i < orderByStr.Length; i++)
                {
                    order += orderByStr[i];
                }
            }
            var item = await productsService.Order(order.ToLower());
            if (item == null) return NotFound();

            return Ok(item);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{search}/Search")]
        public async Task<IActionResult> Search([FromRoute] string search)
        {
            var item = await productsService.Search(search.ToLower());
            if (item == null) return NotFound();

            return Ok(item);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid) return BadRequest();

            await productsService.Create(product);

            return Ok();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid) return BadRequest();

            await productsService.Edit(product);

            return Ok();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await productsService.Delete(id);

            return Ok();
        }
    }
}
