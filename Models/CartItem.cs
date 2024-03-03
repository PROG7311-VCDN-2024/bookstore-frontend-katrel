using System;
using System.Collections.Generic;

namespace sprint_books.Models;

public  class CartItem
{
    public string CartItemId { get; set; } = null!;

    public int? BookId { get; set; }

    public int? Quantity { get; set; }

    public  Book? Book { get; set; }
    public string CartId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
/*Code Attribute
* Source:https://youtu.be/j8XoyxeZgP8?si=LUrve5S1tyovpIZM
* Creater :LearnWithMe #2 Bokhandel Webbshop| Cart +Checkout|ASP.NET core MVC Projekt
*/