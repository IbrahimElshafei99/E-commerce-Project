using DataAccess.Data;
using DataAccess.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                // Customer
                if (!context.customers.Any())
                {
                    context.customers.AddRange(new List<Customer>()
                            {
                                new Customer()
                                {
                                    Name = "Ahmed",
                                    City = "Cairo",
                                    Email = "123@gmail.com",
                                    PaymentInfo= "Visa"
                                },
                                new Customer()
                                {
                                    Name = "Mohamed",
                                    City = "Giza",
                                    Email = "abc@gmail.com",
                                    PaymentInfo= "Visa"
                                },
                                new Customer()
                                {
                                    Name = "Ibrahim",
                                    City = "Cairo",
                                    Email = "ab1@gmail.com",
                                    PaymentInfo= "Debit Card"
                                },
                                new Customer()
                                {
                                    Name = "Mohamed",
                                    City = "October",
                                    Email = "bc2@gmail.com",
                                    PaymentInfo= "Debit Card"
                                },
                                new Customer()
                                {
                                    Name = "Maha",
                                    City = "Fisal",
                                    Email = "ac3@gmail.com",
                                    PaymentInfo= "Visa"
                                },
                                new Customer()
                                {
                                    Name = "Ali",
                                    City = "Alex",
                                    Email = "ac4@gmail.com",
                                    PaymentInfo= "Visa"
                                }
                            });
                    context.SaveChanges();
                }

                // Category
                if (!context.categories.Any())
                {
                    context.categories.AddRange(new List<Category>()
                            {
                                new Category()
                                {
                                    Name = "Shoes",
                                    Description = "This category is about different shoes brands"
                                },
                                new Category()
                                {
                                    Name = "Mobiles",
                                    Description = "This category is about different mobile brands"
                                },
                                new Category()
                                {
                                    Name = "Clothes",
                                    Description = "This category is about different clothes brands"
                                },
                                new Category()
                                {
                                    Name = "Watches",
                                    Description = "This category is about different watches brands"
                                }

                            });
                    context.SaveChanges();
                }

                
                // Product
                if (!context.products.Any())
                {
                    context.products.AddRange(new List<Product>()
                            {
                                new Product()
                                {
                                    Name = "Air Jordan",
                                    Description = "The new Air Jordan has released",
                                    Price = 1500,
                                    Quantity = 20,
                                    CategoryId = 1
                                },
                                new Product()
                                {
                                    Name = "Air Force",
                                    Description = "The new Air Force has released",
                                    Price = 1999,
                                    Quantity = 11,
                                    CategoryId = 1
                                },
                                new Product()
                                {
                                    Name = "IPhone 12",
                                    Description = "The IPhone 12 with discount is here",
                                    Price = 10000,
                                    Quantity = 5,
                                    CategoryId = 2
                                },
                                new Product()
                                {
                                    Name = "Honor 50 Lite",
                                    Description = "The newest Honor product released",
                                    Price = 6000,
                                    Quantity = 12,
                                    CategoryId = 2
                                },
                                new Product()
                                {
                                    Name = "Hoody",
                                    Description = "The new American Eagle product released",
                                    Price = 600,
                                    Quantity = 30,
                                    CategoryId = 3
                                },
                                new Product()
                                {
                                    Name = "Jacket",
                                    Description = "The new Town Team product released",
                                    Price = 900,
                                    Quantity = 22,
                                    CategoryId = 3
                                },
                                new Product()
                                {
                                    Name = "Casio",
                                    Description = "The new Casio product released",
                                    Price = 600,
                                    Quantity = 7,
                                    CategoryId = 4
                                }
                            });
                    context.SaveChanges();
                }

                // Order
                if (!context.orders.Any()) 
                {
                    context.orders.AddRange(new List<Order>()
                            {
                                new Order()
                                {
                                    Date = DateTime.Today,
                                    Amount = 2,
                                    CustomerId = 3,
                                },
                                new Order()
                                {
                                    Date = DateTime.Today,
                                    Amount = 1,
                                    CustomerId = 4,
                                },
                                new Order()
                                {
                                    Date = DateTime.Today,
                                    Amount = 1,
                                    CustomerId = 5,
                                }

                            });
                    context.SaveChanges();

                }

                // Order Items
                if (!context.ordersItems.Any())
                {
                    context.ordersItems.AddRange(new List<OrderItems>()
                            {
                                new OrderItems()
                                {
                                    Price = 1500,
                                    Quantity = 1,
                                    ProductId = 1,
                                    Order_Id = 4,
                                },
                                new OrderItems()
                                { 
                                    Price = 600,
                                    Quantity = 1,
                                    ProductId = 5,
                                    Order_Id = 4,
                                },
                                new OrderItems()
                                {
                                    Price = 10000,
                                    Quantity = 1,
                                    ProductId = 3,
                                    Order_Id = 5,
                                },
                                new OrderItems()
                                {
                                    Price = 1800,
                                    Quantity = 3,
                                    ProductId = 5,
                                    Order_Id = 6,
                                }
                            });
                    context.SaveChanges();

                }

            }
            }

    }
}
