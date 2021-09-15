using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PetShop.Models
{
    public class PetShopDbContext:DbContext
    {
        public PetShopDbContext(){ }
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options):base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Discounts> Discounts { get; set; }
        public virtual DbSet<Product_List> Product_Lists { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Providers> Providers { get; set; }
        public virtual DbSet<Receipts> Receipts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.name).HasColumnName("Name").IsRequired();
                x.HasIndex(x => x.name).IsUnique();
            });
            modelBuilder.Entity<Providers>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.name).HasColumnName("Name").IsRequired();
                x.Property(x => x.surname).HasColumnName("Surname").IsRequired();
                x.Property(x => x.phone).HasColumnName("Phone").IsRequired();
                x.Property(x => x.info).HasColumnName("Info");
                x.HasIndex(x => x.phone).IsUnique();

            });
            modelBuilder.Entity<Products>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.name).HasColumnName("Name").IsRequired();
                x.Property(x => x.info).HasColumnName("Info").IsRequired();
                x.Property(x => x.price).HasColumnName("Price").IsRequired();
                x.HasOne(x => x.Provider).WithMany(x => x.Products).HasForeignKey(x => x.ProvidersId);
                x.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoriesId);
            });
            modelBuilder.Entity<Product_List>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Product).WithMany(x => x.Product_Lists).HasForeignKey(x => x.ProductsId);
                x.HasOne(x => x.Receipts).WithMany(x => x.Product_Lists).HasForeignKey(x => x.ReceiptsId);
                x.Property(x => x.amount).HasColumnName("Amount").IsRequired();
            });
            modelBuilder.Entity<Receipts>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Discount).WithMany(x => x.Receipts).HasForeignKey(x => x.DiscountsId);
                x.HasOne(x => x.Client).WithMany(x => x.Receipts).HasForeignKey(x => x.ClientsId);
                x.Property(x => x.date).HasColumnName("Date").IsRequired();
            });
            modelBuilder.Entity<Clients>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.name).HasColumnName("Name").IsRequired();
                x.Property(x => x.surname).HasColumnName("Surname").IsRequired();
                x.Property(x => x.phone).HasColumnName("Phone").IsRequired();
                x.HasIndex(x => x.phone).IsUnique();
            });
            modelBuilder.Entity<Discounts>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.amout_of_discount).HasColumnName("AmountOfDiscount").IsRequired();
                x.Property(x => x.info).HasColumnName("Info").IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
