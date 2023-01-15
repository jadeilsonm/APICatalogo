using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context;

public class ApiCatalogoDbContext : DbContext
{
    public ApiCatalogoDbContext(DbContextOptions<ApiCatalogoDbContext> options) : base(options)
    { }
    
    public DbSet<Category>? Categories { get; set; }
    public  DbSet<Product>? Products { get; set; }
}