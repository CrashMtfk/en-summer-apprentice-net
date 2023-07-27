namespace TicketManagmentSystem.Api.Models.Dto
{
    public class OrderPatchDto
    {
        public int OrderId { get; set; }
        public int? NumberOfTickets { get; set; }
        public int? TicketCategoryID { get; set; } 
    }
}
