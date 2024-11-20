using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntiyLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;   
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll(); 
            return Ok(values);
        }
        [HttpPost]   
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
               Mail=createBookingDto.Mail,
               Date=createBookingDto.Date,
               Name=createBookingDto.Name,
               PersonCount=createBookingDto.PersonCount,
               Phone=createBookingDto.Phone, 
               Description=createBookingDto.Description,
            };
            _bookingService.TAdd(booking);  
            return Ok("Rezervasyon yapıldı");
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var value= _bookingService.TGetByID(id);
            _bookingService.TDelete(value);    
            return Ok("Rezervasyon silindi");  
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                Name=updateBookingDto.Name,
                BookingID=updateBookingDto.BookingID,
                Mail=updateBookingDto.Mail,
                Date = updateBookingDto.Date,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
                Description = updateBookingDto.Description,

            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon Güncellendi");
        }
        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var value=_bookingService.TGetByID(id);
            return Ok(value);   
        }
    }
}
