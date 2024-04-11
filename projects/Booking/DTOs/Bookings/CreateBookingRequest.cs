namespace Booking.DTOs.Bookings
{
    public class CreateBookingRequest
    {
        public string PassangerName { get; set; } = string.Empty;

        public string PassportNumber { get; set; } = string.Empty;

        public string From { get; set; } = string.Empty;

        public string To { get; set; } = string.Empty;
    }
}