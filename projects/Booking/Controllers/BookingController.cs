using Booking.DTOs.Bookings;
using Booking.Services.Queue;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [Route("bookings")]
    public class BookingController(IMessagingQueue messagingQueue) : Controller
    {

        private readonly IMessagingQueue _messagingQueue = messagingQueue;

        public static List<Models.Booking> _bookings = [];

        [HttpPost]
        public IActionResult Store([FromBody] CreateBookingRequest body)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var booking = new Models.Booking
            {
                Id = _bookings.Count + 1,
                PassangerName = body.PassangerName,
                PassportNumber = body.PassportNumber,
                From = body.From,
                To = body.To,
                Status = "PROCESSING"
            };
            _bookings.Add(booking);
            _messagingQueue.SendingMessage<Models.Booking>(booking);

            return Created();
        }
    }
}