using AutoMapper;
using Craftsmen.Api.DTOs;
using Craftsmen.Domain.Entities;
using Craftsmen.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Craftsmen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery] string? search, int pageSize = 0, int pageNumber = 1)
        {
            var products = await _unitOfWork.ProductRepository.Find(pageSize: pageSize, pageNumber: pageNumber, includeProperties: "Category");
            return Ok(_mapper.Map<List<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetById(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] AddProductDto request)
        {
            var obj = _mapper.Map<Product>(request);
            await _unitOfWork.ProductRepository.Add(obj);
            var res = await _unitOfWork.Complete();
            return Ok(HttpStatusCode.NoContent);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductDto request)
        {
            var obj = _mapper.Map<Product>(request);

            await _unitOfWork.ProductRepository.Update(obj);
            var res = await _unitOfWork.Complete();
            return Ok(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct([FromBody] UpdateProductDto request)
        {
            var obj = _mapper.Map<Product>(request);

            await _unitOfWork.ProductRepository.Remove(obj);
            var res = await _unitOfWork.Complete();
            return Ok(HttpStatusCode.NoContent);
        }
    }
}
