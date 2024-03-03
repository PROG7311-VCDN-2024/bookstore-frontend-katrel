using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace sprint_books.Models;
/*Code Attribute
* Source:https://youtu.be/j8XoyxeZgP8?si=LUrve5S1tyovpIZM
* Creater :LearnWithMe #2 Bokhandel Webbshop| Cart +Checkout|ASP.NET core MVC Projekt
*/
public partial class Cart
{
    private readonly SprintContext _context;

    public Cart(SprintContext context)
    {
        _context = context;
    }
    public string CartId { get; set; } 

    public string? CartItemId { get; set; }

    public string? Username { get; set; }

    public virtual CartItem? CartItem { get; set; }

    public virtual Userdetail? UsernameNavigation { get; set; }

    public List<CartItem> CartItems { get; set; }

    public static Cart GetCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        var context = services.GetService<SprintContext>();
        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

        session.SetString("CartId", cartId);

        return new Cart(context) { CartId = cartId };
    }

    public CartItem GetCartItem(Book book)
    {
        return _context.CartItems.SingleOrDefault(ci =>
        ci.Book.BookId == book.BookId && ci.CartId == CartId);
    }
    public void AddToCart(Book book, int quantity)
    {
        var cartItem = GetCartItem(book);

        if (cartItem!=null)
        {
            cartItem = new CartItem
            {
                Book = book,
                Quantity = quantity,
                CartId = CartId
            };

            _context.CartItems.Add(cartItem);   
        }
        else
        {
            cartItem.Quantity = quantity;
        
        }
        _context.SaveChanges();
    }

    public int ReduceQuantity(Book book)
    {
        var cartItem = GetCartItem(book);
        var remainingQuantity = 0;

        if (cartItem != null)
        {
            if (cartItem.Quantity > 1)
            {
                remainingQuantity = (int)(--cartItem.Quantity);
            }
            else
            {
                _context.CartItems.Remove(cartItem);
            }
        }
        _context.SaveChanges();

        return remainingQuantity;
    }

    public int IncreaseQuantity(Book book)
    {
        var cartItem = GetCartItem(book);
        var remainingQuantity = 0;

        if (cartItem != null)
        {
            if (cartItem.Quantity > 1)
            {
                remainingQuantity = (int)(++cartItem.Quantity);
            }
           
        }
        _context.SaveChanges();

        return remainingQuantity;
    }

    public void RemoveFromCart(Book book)
    {
        var cartItem = GetCartItem(book);

        if (cartItem != null)
        {
            _context.CartItems.Remove(cartItem);
        }
        _context.SaveChanges();
    }

    public void ClearCart()
    {
        var cartItems = _context.CartItems.Where(ci => ci.CartId == CartId);

        _context.CartItems.RemoveRange(cartItems);

        _context.SaveChanges();
    }

    public List<CartItem> GetAllCartItems()
        {
            return CartItems ??
                (CartItems = _context.CartItems.Where(ci => ci.CartId == CartId)
                    .Include(ci => ci.Book)
                    .ToList());
        }


    public int? GetCartTotal()
    {
        return _context.CartItems
            .Where(ci => ci.CartId == CartItemId)
            .Select(ci => ci.Book.Price * ci.Quantity)
            .Sum();
    }

}
