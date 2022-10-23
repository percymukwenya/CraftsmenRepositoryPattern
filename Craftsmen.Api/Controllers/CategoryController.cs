using AutoMapper;
using Craftsmen.Api.DTOs;
using Craftsmen.Domain.Entities;
using Craftsmen.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Craftsmen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAll();
            return Ok(_mapper.Map<List<CategoryDto>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory([Required]int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(id);
            return Ok(_mapper.Map<CategoryDetailDto>(category));
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] AddCategoryDto request)
        {
            var obj = _mapper.Map<Category>(request);
            await _unitOfWork.CategoryRepository.Add(obj);
            var res = await _unitOfWork.Complete();
            return Ok(HttpStatusCode.NoContent);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryDto request)
        {
            var obj = _mapper.Map<Category>(request);

            await _unitOfWork.CategoryRepository.Update(obj);
            var res = await _unitOfWork.Complete();
            return Ok(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory([FromBody] UpdateCategoryDto request)
        {
            var obj = _mapper.Map<Category>(request);

            await _unitOfWork.CategoryRepository.Remove(obj);
            var res = await _unitOfWork.Complete();
            return Ok(HttpStatusCode.NoContent);
        }
    }
}
