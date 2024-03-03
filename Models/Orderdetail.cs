using System;
using System.Collections.Generic;

namespace sprint_books.Models;

public partial class Orderdetail
{
    public int OrderId { get; set; }

    public int? OrderItemId { get; set; }

    public int? OrderTotal { get; set; }

    public DateTime? OrderPlaced { get; set; }

    public virtual OrderItem? OrderItem { get; set; }

    public List<OrderItem> OrderItems { get; set; }
}
/*Code Attribute
* Source:https://youtu.be/j8XoyxeZgP8?si=LUrve5S1tyovpIZM
* Creater :LearnWithMe #2 Bokhandel Webbshop| Cart +Checkout|ASP.NET core MVC Projekt
*/