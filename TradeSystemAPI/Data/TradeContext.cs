using Microsoft.EntityFrameworkCore;
using TradeSystemAPI.Models;

namespace TradeSystemAPI.Data
{
    public class TradeContext : DbContext
    {

        public TradeContext(DbContextOptions<TradeContext> options) : base(options) {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<orderWare> OrderWares { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ImageUpload> ImageUploads { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var products = new List<Product>() {
                new Product() {
                    ProductId = Guid.Parse("d048f7ab-5b75-4d37-8f4e-ad939e8dba0a"),
                    ProductName = "Mickey Mouse",
                    ProductCategory = "Electric",
                    ProductPrice = 500,
                    Distributor = 12,
                    ProductDescription = "Good for your night sleep with coziness and comfort",
                    ProductImgUrl = "https://tamhome.vn/wp-content/uploads/2017/07/IMG_4969.jpg"

                },
                new Product() {
                    ProductId = Guid.Parse("53dc9e8c-c3dd-4b5a-8ef0-80535bf66bbb"),
                    ProductName = "Banana Milk",
                    ProductCategory = "Detox",
                    ProductPrice = 20,
                    Distributor = 22,
                    ProductDescription = "Healthy with a rich source of vitamins C",
                    ProductImgUrl = "https://drivemehungry.com/wp-content/uploads/2022/08/korean-banana-milk-5.jpg"

                },
                new Product() {
                    ProductId = Guid.Parse("569289df-6346-4e75-a15d-923f97cac8ac"),
                    ProductName = "Panna Cotta",
                    ProductCategory = "Dessert",
                    Distributor = 25,
                    ProductPrice = 30,
                    ProductDescription = "Perfect for ending your meal with some sweet treats",
                    ProductImgUrl = "https://leitesculinaria.com/wp-content/uploads/2020/01/panna-cotta.jpg"

                }
            };
            modelBuilder.Entity<Product>().HasData(products);
            var warehouses = new List<Warehouse>()
            {
                new Warehouse()
                {
                    WarehouseId = Guid.Parse("b7f822ef-493b-4f15-802a-5c75de666e8d"),
                    WareName = "Felix",
                    License = "2012",
                    CentralDistance = "21",
                    EstimatedTime = 3
                },
                new Warehouse()
                {
                    WarehouseId = Guid.Parse("e5e31796-666d-4d99-9805-c25ab4343098"),
                    WareName = "FedX",
                    License = "2005",
                    CentralDistance = "15",
                    EstimatedTime = 2
                },
                new Warehouse()
                {
                    WarehouseId = Guid.Parse("a64608dc-8140-47f2-b886-e3948926ff1a"),
                    WareName = "AUPost",
                    License = "2014",
                    CentralDistance = "12",
                    EstimatedTime = 4
                }
            };
            modelBuilder.Entity<Warehouse>().HasData(warehouses);
        }

    }
}
