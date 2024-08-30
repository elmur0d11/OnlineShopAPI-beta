using AutoMapper;
using CommandAPI.Data;
using CommandAPI.Dtos;
using CommandAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IProductAPIRepo _repository;
        private readonly IBuyedProductAPIRepo _buyedRepository;
        private readonly IMapper _mapper;

        public AdminController(IProductAPIRepo repository, IMapper mapper, IBuyedProductAPIRepo buyedRepository)
        {
            _repository = repository;

            _buyedRepository = buyedRepository;

            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreatedDto productCreatedDto)
        {
            var productModel = _mapper.Map<Product>(productCreatedDto);

            await _repository.CreateProduct(productModel);

            await _repository.SaveChangesAsync();

            var productReadDto = _mapper.Map<ProductReadDto>(productModel);

            return Created("", productModel);
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repository.GetAllProducts();

            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }

        [HttpGet("SelledProducts")]
        public async Task<IActionResult> GetSelledProducts()
        {
            var selledProducts = await _buyedRepository.GetAllProducts();

            return Ok(_mapper.Map<IEnumerable<BuyedProductReadDto>>(selledProducts));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _repository.GetProductById(id);

            if(product == null)
                return NotFound();

            return Ok(_mapper.Map<ProductReadDto>(product));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productModelFromRepo = await _repository.GetProductById(id);

            if (productModelFromRepo == null)
                return NotFound();

            _repository.DeleteProduct(productModelFromRepo);

            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto updateDto)
        {
            var productModelFromRepo = await _repository.GetProductById(id);

            if (productModelFromRepo == null)
                return NotFound();

            _mapper.Map(updateDto, productModelFromRepo);

            await _repository.UpdateProduct(productModelFromRepo);

            await _repository.SaveChangesAsync();

            return NoContent();
        }



    }
}
