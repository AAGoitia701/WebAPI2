﻿using System;
using System.Collections.Generic;

namespace WebAPI2.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? Name { get; set; }

    public string? Brand { get; set; }

    public decimal? Price { get; set; }
}
