using System;
using System.Collections.Generic;

namespace OnlineOrdering {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(":::::: Welcome to the Online Ordering System! :::::::");
            Console.WriteLine();

            // ============================
            // Step 1: Create Customers
            // ============================
            Address addr1 = new Address("123 Main St", "Benin City", "Edo", "300001");
            Customer cust1 = new Customer(1, "Austine", "austine@example.com", "+2348012345678", addr1);

            Address addr2 = new Address("456 Market Rd", "Lagos", "Lagos", "100001");
            Customer cust2 = new Customer(2, "Mary", "mary@example.com", "+2348098765432", addr2);

            // ============================
            // Step 2: Create Products
            // ============================
            Product laptop = new Product(101, "Laptop", 500.00, 10);
            Product mouse = new Product(102, "Mouse", 20.00, 50);
            Product phone = new Product(103, "Phone", 300.00, 15);
            Product keyboard = new Product(104, "Keyboard", 40.00, 25);

            // ============================
            // Step 3: Create Orders
            // ============================
            // First order for Austine
            Order order1 = new Order(1001, cust1);
            order1.AddItem(new OrderItem(laptop, 1));
            order1.AddItem(new OrderItem(mouse, 2));

            // Second order for Mary
            Order order2 = new Order(1002, cust2);
            order2.AddItem(new OrderItem(phone, 1));
            order2.AddItem(new OrderItem(keyboard, 1));

            // Store orders in a list
            List<Order> orders = new List<Order> { order1, order2 };

            // ============================
            // Step 4: Display Order Summaries
            // ============================
            foreach (var order in orders) {
                Console.WriteLine($"Order #{order.OrderId} for {order.Customer.Name}");
                Console.WriteLine($"Phone: {order.Customer.PhoneNumber}");
                Console.WriteLine($"Total: {order.CalculateTotal():C}");
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine();
            }

            Console.WriteLine("::::::::===Thank you for your orders!==::::::::");
        }
    }
}