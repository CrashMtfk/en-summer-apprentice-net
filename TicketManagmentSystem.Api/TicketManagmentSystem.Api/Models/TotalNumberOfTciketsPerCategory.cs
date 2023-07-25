using System;
using System.Collections.Generic;

namespace TicketManagmentSystem.Api.Models;

public partial class TotalNumberOfTciketsPerCategory
{
    public int? TicketCategoryId { get; set; }

    public int? TotalTickets { get; set; }

    public decimal? Price { get; set; }
}
