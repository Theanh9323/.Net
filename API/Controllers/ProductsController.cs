using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interface;
using Core.Specifications;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductType> productGeType;
        private readonly IGenericRepository<ProductBrand> productGeBrand;
        private readonly IMapper mapper;

        /*private readonly IProductRepository repository;*/

        public ProductsController(/*IProductRepository repository,*/IGenericRepository<Product> ProductRepo,IGenericRepository<ProductType> ProductGeType,IGenericRepository<ProductBrand>ProductGeBrand, IMapper mapper)
        {
            productRepo = ProductRepo;
            productGeType = ProductGeType;
            productGeBrand = ProductGeBrand;
            this.mapper = mapper;

            /*this.repository = repository;*/
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductWithTypesAndBrandsSpecification();
            var products = await productRepo.ListAsync(spec);
            return Ok(mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);

            var product = await productRepo.GetEntityWithSpec(spec);
            return mapper.Map<Product,ProductToReturnDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await productGeBrand.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            return Ok(await productGeType.ListAllAsync());
        }
    }
}
