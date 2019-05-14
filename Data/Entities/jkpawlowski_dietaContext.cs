using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data
{
    public partial class jkpawlowski_dietaContext : DbContext
    {
        public jkpawlowski_dietaContext()
        {
        }

        public jkpawlowski_dietaContext(DbContextOptions<jkpawlowski_dietaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Limits> Limits { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Shops> Shops { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=sql.jkpawlowski.nazwa.pl;user=jkpawlowski_jakub;password=mGjRD9hDT5X6GMR;database=jkpawlowski_dieta");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History", "jkpawlowski_dieta");

                entity.HasIndex(e => e.IngredientId)
                    .HasName("IngredientID");

                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductID");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount).HasColumnType("int(11)");

                entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IngredientId)
                    .HasColumnName("IngredientID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ingredient");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user");
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.ToTable("Ingredients", "jkpawlowski_dieta");

                entity.HasIndex(e => e.Id)
                    .HasName("ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Gluten).HasColumnType("tinyint(1)");

                entity.Property(e => e.Lactose).HasColumnType("tinyint(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Vege).HasColumnType("tinyint(1)");
            });

            modelBuilder.Entity<Limits>(entity =>
            {
                entity.ToTable("Limits", "jkpawlowski_dieta");

                entity.HasIndex(e => e.IngredientId)
                    .HasName("IngredientsID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Daily).HasColumnType("int(11)");

                entity.Property(e => e.IngredientId)
                    .HasColumnName("IngredientID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.Limits)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("new_limit");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("Products", "jkpawlowski_dieta");

                entity.HasIndex(e => e.IngridientId)
                    .HasName("IngridientID");

                entity.HasIndex(e => e.ShopId)
                    .HasName("ShopID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IngridientId)
                    .HasColumnName("IngridientID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShopId)
                    .HasColumnName("ShopID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Weight).HasColumnType("int(11)");

                entity.HasOne(d => d.Ingridient)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IngridientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("add_product");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("shop_ref");
            });

            modelBuilder.Entity<Shops>(entity =>
            {
                entity.ToTable("Shops", "jkpawlowski_dieta");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "jkpawlowski_dieta");

                entity.HasIndex(e => e.Id)
                    .HasName("ID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Kcals).HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .IsUnicode(false);
            });
        }
    }
}
