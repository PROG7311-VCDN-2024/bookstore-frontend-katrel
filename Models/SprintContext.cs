using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sprint_books.Models;

public partial class SprintContext : DbContext
{
    public SprintContext()
    {
    }

    public SprintContext(DbContextOptions<SprintContext> options)
        : base(options)
    {
    }

    public  DbSet<Book> Books { get; set; }

    public DbSet<Cart> Carts { get; set; }

    public DbSet<CartItem> CartItems { get; set; }

    public  DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Orderdetail> Orderdetails { get; set; }

    public  DbSet<Userdetail> Userdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=sprint; Encrypt=False;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__8BE5A10D89FF2877");

            entity.ToTable("Book");

            entity.Property(e => e.BookId)
                .ValueGeneratedNever()
                .HasColumnName("bookId");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("author");
            entity.Property(e => e.DatePublished).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imageUrl");
            entity.Property(e => e.Isbn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Language)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("language");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__cart__415B03B8D3FF6A26");

            entity.ToTable("cart");

            entity.Property(e => e.CartId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cartId");
            entity.Property(e => e.CartItemId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cartItemId");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.CartItem).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CartItemId)
                .HasConstraintName("FK__cart__cartItemId__5070F446");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK__cart__username__5165187F");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__cartItem__283983B64EC96FAF");

            entity.ToTable("cartItem");

            entity.Property(e => e.CartItemId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cartItemId");
            entity.Property(e => e.BookId).HasColumnName("bookId");

            
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__orderIte__57ED0681D99D4751");

            entity.ToTable("orderItem");

            entity.Property(e => e.OrderItemId).ValueGeneratedNever();
            entity.Property(e => e.BookId).HasColumnName("bookId");
            entity.Property(e => e.OrderPrice).HasColumnName("orderPrice");
            entity.Property(e => e.OrderQuantity).HasColumnName("orderQuantity");

            
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orderdet__0809335D2FDDFC5B");

            entity.ToTable("orderdetails");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("orderId");
            entity.Property(e => e.OrderPlaced)
                .HasColumnType("datetime")
                .HasColumnName("orderPlaced");
            entity.Property(e => e.OrderTotal).HasColumnName("orderTotal");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.OrderItemId)
                .HasConstraintName("FK__orderdeta__Order__571DF1D5");
        });

        modelBuilder.Entity<Userdetail>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__Userdeta__F3DBC573CC2678A2");

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
