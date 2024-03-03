using System;
using System.Collections.Generic;

namespace sprint_books.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? OrderQuantity { get; set; }

    public int? OrderPrice { get; set; }

    public int OrderId { get; set; }
    public int? BookId { get; set; }

    public Orderdetail OrderDetail { get; set; }
    public virtual Book? Book { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}

/*Code Attribute
* Source:https://youtu.be/j8XoyxeZgP8?si=LUrve5S1tyovpIZM
* Creater :LearnWithMe #2 Bokhandel Webbshop| Cart +Checkout|ASP.NET core MVC Projekt
*/