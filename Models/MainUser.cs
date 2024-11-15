using System;
using System.Collections.Generic;

namespace WebAPI2.Models;

public partial class MainUser
{
    public int IdUser { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
