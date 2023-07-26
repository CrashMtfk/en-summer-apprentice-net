namespace TicketManagmentSystem.Api.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public DateTime? OrderedAt { get; set; }

        public int? NumberOfTickets { get; set; }

        public decimal? TotalPrice { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual TicketCategory? TicketCategory { get; set; }
    }
}
