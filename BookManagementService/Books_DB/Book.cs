﻿using System;
using System.Collections.Generic;

namespace InventoryManagementService;

public partial class Book
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Year { get; set; }

    public string? Author { get; set; }

    public string? Genre { get; set; }
}
