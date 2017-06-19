using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using tenorchem.Models;

namespace tenorchem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("tenorchem.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Purity");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("tenorchem.Models.PurchaseRecord", b =>
                {
                    b.Property<int>("PurchaseRecordId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("PaidBackPerTon");

                    b.Property<double>("PricePerTon");

                    b.Property<int>("ProductId");

                    b.Property<DateTime>("PurchaseDate");

                    b.Property<double>("Quantity");

                    b.Property<int>("SupplierId");

                    b.Property<double>("TotalPaidBack");

                    b.Property<double>("TotalPaidPrice");

                    b.Property<string>("comment");

                    b.HasKey("PurchaseRecordId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("PurchaseRecords");
                });

            modelBuilder.Entity("tenorchem.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Comment");

                    b.Property<string>("ContactNumber");

                    b.Property<string>("Contactor");

                    b.Property<string>("SupplierName")
                        .IsRequired();

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("tenorchem.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("isAdmin");

                    b.Property<string>("passWord")
                        .IsRequired();

                    b.Property<string>("userName")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("tenorchem.Models.PurchaseRecord", b =>
                {
                    b.HasOne("tenorchem.Models.Product", "Product")
                        .WithMany("PurchaseRecord")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("tenorchem.Models.Supplier", "Supplier")
                        .WithMany("PurchaseRecord")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
