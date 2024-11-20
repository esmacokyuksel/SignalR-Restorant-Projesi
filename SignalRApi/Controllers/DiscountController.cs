using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntiyLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService,IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
            
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount()
            {
                Title= createDiscountDto.Title,
                Description= createDiscountDto.Description,
                Amount= createDiscountDto.Amount,
                ImageUrl= createDiscountDto.ImageUrl,
                Status= createDiscountDto.Status,

            });
            return Ok("İndirim eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var values=_discountService.TGetByID(id);   
            _discountService.TDelete(values);
            return Ok("İndirim başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
                Title = updateDiscountDto.Title,
                Description = updateDiscountDto.Description,
                Amount = updateDiscountDto.Amount,
                ImageUrl = updateDiscountDto.ImageUrl,
                Status = updateDiscountDto.Status,

            });
            return Ok("İndirim güncellendi");
        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var values = _discountService.TGetByID(id);
            return Ok(values);
        }



    }
}
