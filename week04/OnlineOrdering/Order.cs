using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineOrdering {
    public class Order {
        private int _orderId;
        private Customer _customer;
        private List<OrderItem> _items = new List<OrderItem>();

        public Order(int orderId, Customer customer) {
            _orderId = orderId;
            _customer = customer;
        }

        public int OrderId => _orderId;
        public Customer Customer => _customer;
        public List<OrderItem> Items => _items;

        public void AddItem(OrderItem item) {
            _items.Add(item);
        }

        public double CalculateTotal() {
            return _items.Sum(i => i.Product.Price * i.Quantity);
        }

        public string GetPackingLabel() {
            return $"Packing Label:\nCustomer: {Customer.Name}\nOrder #{OrderId}\nItems: {string.Join(", ", _items.Select(i => i.Product.Name))}";
        }

        public string GetShippingLabel() {
            return $"Shipping Label:\n{Customer.Name}\n{Customer.Address.Street}, {Customer.Address.City}, {Customer.Address.State} {Customer.Address.ZipCode}";
        }
    }
}