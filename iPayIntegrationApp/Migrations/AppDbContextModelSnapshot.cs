﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentGatewayIntegrationApp;

namespace PaymentGatewayIntegrationApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaymentGatewayIntegrationApp.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount");

                    b.Property<string>("Currency");

                    b.Property<string>("Language");

                    b.Property<string>("OrderNumber");

                    b.Property<string>("Parameter");

                    b.Property<string>("Password");

                    b.Property<string>("ReturnUrl");

                    b.Property<string>("UserName");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PaymentGatewayIntegrationApp.Models.RequestParameter", b =>
                {
                    b.Property<int>("RequestParameterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Parameter");

                    b.HasKey("RequestParameterId");

                    b.ToTable("RequestParameters");
                });
#pragma warning restore 612, 618
        }
    }
}
