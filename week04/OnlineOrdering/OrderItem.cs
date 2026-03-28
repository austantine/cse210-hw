namespace OnlineOrdering {
    public class OrderItem {
        private Product _product;
        private int _quantity;

        public OrderItem(Product product, int quantity) {
            _product = product;
            _quantity = quantity;
        }

        public Product Product => _product;
        public int Quantity => _quantity;
    }
}