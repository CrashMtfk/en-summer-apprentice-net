﻿using System;
using System.Collections.Generic;

namespace TicketManagmentSystem.Api.Models;

public partial class TicketCategory
{
    public int TicketCategoryId { get; set; }

    public int? EventId { get; set; }

    public string? TicketDescription { get; set; }

    public decimal? Price { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
