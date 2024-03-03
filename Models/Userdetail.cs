using System;
using System.Collections.Generic;

namespace sprint_books.Models;

public partial class Userdetail
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
