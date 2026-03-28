using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(":::::: Welcome to the Online Ordering System! :::::::");
            Console.WriteLine();
            // ============================
            // Step 1: Collect Customer Info
            // ============================
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter your phone number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter your street address:");
            string street = Console.ReadLine();

            Console.WriteLine("Enter your city:");
            string city = Console.ReadLine();

            Console.WriteLine("Enter your state:");
            string state = Console.ReadLine();

            Console.WriteLine("Enter your zip code:");
            string zipCode = Console.ReadLine();

            // Create Address and Customer objects using user input
            Address addr = new Address(street, city, state, zipCode);
            Customer cust = new Customer(1, name, email, phoneNumber, addr);

            // ============================
            // Step 2: Display Product List
            // ============================
            List<Product> products = new List<Product> {
                new Product(101, "Laptop", 500.00, 10),
                new Product(102, "Mouse", 20.00, 50),
                new Product(103, "Phone", 300.00, 15),
                new Product(104, "Keyboard", 40.00, 25),
                new Product(101, "Pen", 10.00, 10),
                new Product(102, "USB drivee", 200.00, 10),
                new Product(103, "Phone Pouch", 100.00, 10),
                new Product(104, "Keyboard Light", 20.00, 10)
            };

            Console.WriteLine("\nAvailable Products:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Price:C} (Stock: {products[i].Stock})");
            }

            // ============================
            // Step 3: Create Order
            // ============================
            Order order = new Order(1001, cust);

            Console.WriteLine("\nEnter the number of items you want to add to your order:");
            int itemCount = int.Parse(Console.ReadLine());

            // Loop through user selections
            for (int i = 0; i < itemCount; i++)
            {
                Console.WriteLine("\nSelect product by number:");
                int productChoice = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("Enter quantity:");
                int quantity = int.Parse(Console.ReadLine());

                // Validate product choice
                if (productChoice >= 0 && productChoice < products.Count)
                {
                    Product chosenProduct = products[productChoice];
                    order.AddItem(new OrderItem(chosenProduct, quantity));
                    chosenProduct.UpdateStock(quantity); // Reduce stock
                }
                else
                {
                    Console.WriteLine("Invalid choice. Skipping...");
                }
            }

            // ============================
            // Step 4: Display Order Summary
            // ============================
            Console.WriteLine($"\nOrder #{order.OrderId} for {order.Customer.Name}");
            Console.WriteLine($"Phone: {order.Customer.PhoneNumber}");
            Console.WriteLine($"Total: {order.CalculateTotal():C}");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine("::::::::===Thank you for your order!==::::::::");
        }
    }
}