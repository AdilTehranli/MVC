using Microsoft.EntityFrameworkCore;
using ProniaMvc.Models;

namespace ProniaMvc.DataAccess;

public class ProniaDbContext : DbContext
{
	public ProniaDbContext(DbContextOptions options ) : base( options )
	{

	}
    public DbSet<Slider> Sliders { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<ProductImage> ProductImages { get; set; }
}
