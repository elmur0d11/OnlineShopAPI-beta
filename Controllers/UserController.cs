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
    public class UserController : ControllerBase
    {
        private readonly IProductAPIRepo _repository;
        private readonly IMapper _mapper;
        private readonly ILikedProductAPIRepo _likedRepo;
        private readonly IBuyedProductAPIRepo _buyedRepo;

        public UserController(IProductAPIRepo repository, IMapper mapper, ILikedProductAPIRepo likedRepo, IBuyedProductAPIRepo buyedRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _likedRepo = likedRepo;
            _buyedRepo = buyedRepo;
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repository.GetAllProducts();

            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }

        [HttpGet("LikedProducts")]
        public async Task<IActionResult> GetLikedProducts()
        {
            var likedProducts = await _likedRepo.GetAllProducts();

            return Ok(_mapper.Map<IEnumerable<LikedProductReadDto>>(likedProducts));
        }

        [HttpGet("BuyedProducts")]
        public async Task<IActionResult> GetBuyedProducts()
        {
            var buyedProducts = await _buyedRepo.GetAllProducts();

            return Ok(_mapper.Map<IEnumerable<BuyedProductReadDto>>(buyedProducts));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _repository.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(_mapper.Map<ProductReadDto>(product));
        }

        //POST METHODS
        [HttpPost("Like")]
        public async Task<IActionResult> CreateLikedProduct(LikedProductCreatedDto likedProductCreatedDto)
        {
            var likedProductModel = _mapper.Map<LikedProduct>(likedProductCreatedDto);

            await _likedRepo.CreateProduct(likedProductModel);

            await _likedRepo.SaveChangesAsync();

            var likedProductReadDto = _mapper.Map<LikedProductReadDto>(likedProductModel);

            return Created("", likedProductModel);
        }

        [HttpPost("Buy")]
        public async Task<IActionResult> CreateBuyedProduct(BuyedProductCreatedDto buyedProductCreatedDto)
        {
            var buyedProductModel = _mapper.Map<BuyedProduct>(buyedProductCreatedDto);

            await _buyedRepo.CreateProduct(buyedProductModel);

            await _buyedRepo.SaveChangesAsync();

            var buyedProductReadDto = _mapper.Map<BuyedProductReadDto>(buyedProductModel);

            return Created("", buyedProductModel);

        }
    }
}
