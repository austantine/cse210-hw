namespace OnlineOrdering {
    public class Product {
        private int _productId;
        private string _name;
        private double _price;
        private int _stock;

        public Product(int productId, string name, double price, int stock) {
            _productId = productId;
            _name = name;
            _price = price;
            _stock = stock;
        }

        public int ProductId => _productId;
        public string Name => _name;
        public double Price => _price;
        public int Stock => _stock;

        public void UpdateStock(int quantity) {
            _stock -= quantity;
        }
    }
}