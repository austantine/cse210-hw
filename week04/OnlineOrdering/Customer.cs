namespace OnlineOrdering {
    public class Customer {
        private int _customerId;
        private string _name;
        private string _email;
        private string _phoneNumber;
        private Address _address;

        public Customer(int customerId, string name, string email, string phoneNumber, Address address) {
            _customerId = customerId;
            _name = name;
            _email = email;
            _phoneNumber = phoneNumber;
            _address = address;
        }

        public int CustomerId => _customerId;
        public string Name => _name;
        public string Email => _email;
        public string PhoneNumber => _phoneNumber;
        public Address Address => _address;
    }
}