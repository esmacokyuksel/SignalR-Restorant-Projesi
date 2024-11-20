using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;
using SignalR.EntiyLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestoimonialService _testoimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestoimonialService testoimonialService, IMapper mapper)
        {
            _testoimonialService = testoimonialService;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testoimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testoimonialService.TAdd(new Testimonial()
            {
                Name = createTestimonialDto.Name,   
                Title = createTestimonialDto.Title, 
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,   
                Status = createTestimonialDto.Status    
                

            });
            return Ok("Referans eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testoimonialService.TGetByID(id);
            _testoimonialService.TDelete(values);
            return Ok("Referans başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testoimonialService.TUpdate(new Testimonial()
            {
                Name = updateTestimonialDto.Name,   
                Title = updateTestimonialDto.Title, 
                Comment = updateTestimonialDto.Comment, 
                ImageUrl = updateTestimonialDto.ImageUrl,   
                Status = updateTestimonialDto.Status,   
               

            });
            return Ok("Referans güncellendi");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testoimonialService.TGetByID(id);
            return Ok(values);
        }


    }
}
