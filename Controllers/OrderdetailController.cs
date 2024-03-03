using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sprint_books.Models;

namespace sprint_books.Controllers
{
    /*Code Attribute
* Source:https://youtu.be/j8XoyxeZgP8?si=LUrve5S1tyovpIZM
* Creater :LearnWithMe #2 Bokhandel Webbshop| Cart +Checkout|ASP.NET core MVC Projekt
*/
    public class OrderdetailController : Controller
    {
        private readonly SprintContext _context;
        private readonly Cart _cart;

        public OrderdetailController(SprintContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Orderdetail order)
        {
            var cartItems = _cart.GetAllCartItems();
            _cart.CartItems = cartItems;

            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Cart is empty, please add a book first.");
            }

            if (ModelState.IsValid)
            {
                CreateOrder(order);
                _cart.ClearCart();
                return View("CheckoutComplete", order);
            }

            return View(order);
        }

        public IActionResult CheckoutComplete(Orderdetail order)
        {
            return View(order);
        }

        public void CreateOrder(Orderdetail order)
        {
            order.OrderPlaced = DateTime.Now;

            var cartItems = _cart.CartItems;

            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem()
                {
                    OrderQuantity = item.Quantity,
                    BookId = item.Book.BookId,
                    OrderId = order.OrderId,
                    OrderPrice = item.Book.Price * item.Quantity
                };
                order.OrderItems.Add(orderItem);
                order.OrderTotal += orderItem.OrderPrice;
            }
            _context.Orderdetails.Add(order);
            _context.SaveChanges();
        }


        // GET: Orderdetail
        public async Task<IActionResult> Index()
        {
            var sprintContext = _context.Orderdetails.Include(o => o.OrderItem);
            return View(await sprintContext.ToListAsync());
        }

        // GET: Orderdetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.Orderdetails
                .Include(o => o.OrderItem)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderdetail == null)
            {
                return NotFound();
            }

            return View(orderdetail);
        }

        // GET: Orderdetail/Create
        public IActionResult Create()
        {
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId");
            return View();
        }

        // POST: Orderdetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderItemId,OrderTotal,OrderPlaced")] Orderdetail orderdetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderdetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", orderdetail.OrderItemId);
            return View(orderdetail);
        }

        // GET: Orderdetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.Orderdetails.FindAsync(id);
            if (orderdetail == null)
            {
                return NotFound();
            }
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", orderdetail.OrderItemId);
            return View(orderdetail);
        }

        // POST: Orderdetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderItemId,OrderTotal,OrderPlaced")] Orderdetail orderdetail)
        {
            if (id != orderdetail.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderdetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderdetailExists(orderdetail.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", orderdetail.OrderItemId);
            return View(orderdetail);
        }

        // GET: Orderdetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.Orderdetails
                .Include(o => o.OrderItem)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderdetail == null)
            {
                return NotFound();
            }

            return View(orderdetail);
        }

        // POST: Orderdetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderdetail = await _context.Orderdetails.FindAsync(id);
            if (orderdetail != null)
            {
                _context.Orderdetails.Remove(orderdetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderdetailExists(int id)
        {
            return _context.Orderdetails.Any(e => e.OrderId == id);
        }
    }
}
