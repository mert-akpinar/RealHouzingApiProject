using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.DtoLayer.ProductDtos;
using RealHouzing.EntityLayer.Concrete;

namespace RealHouzing.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetList();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory() 
        {
            var values = _productService.TGetProductsWithCategories();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddProduct(AddProductDto addProductDto)
        {
            Product product = new Product()
            {
                BathCount = addProductDto.BathCount,
                BedRoomCount = addProductDto.BedRoomCount,
                CategoryID = addProductDto.CategoryID,
                CoverImagUrl = addProductDto.CoverImagUrl,
                ProductAddress = addProductDto.ProductAddress,
                ProductPrice = addProductDto.ProductPrice,
                ProductTitle = addProductDto.ProductTitle,
                ProductType = addProductDto.ProductType,
                Square = addProductDto.Square
            };
            _productService.TInsert(product);
            return Ok(product);
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetByID(id);
            _productService.TDelete(values);
            return Ok();
        }
        [HttpGet("id")]
        public IActionResult GetProduct(int id)
        {
            var values = _productService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            Product product = new Product()
            {
                BathCount = updateProductDto.BathCount,
                BedRoomCount = updateProductDto.BedRoomCount,
                CategoryID = updateProductDto.CategoryID,
                CoverImagUrl = updateProductDto.CoverImagUrl,
                ProductAddress = updateProductDto.ProductAddress,
                ProductPrice = updateProductDto.ProductPrice,
                ProductTitle = updateProductDto.ProductTitle,
                ProductType = updateProductDto.ProductType,
                Square = updateProductDto.Square,
                ProductID = updateProductDto.ProductID,
            };
            _productService.TUpdate(product);
            return Ok();
        }

    }
}
