namespace OnlineOrdering {
    public class Payment {
        private int _paymentId;
        private double _amount;
        private string _status;

        public Payment(int paymentId, double amount) {
            _paymentId = paymentId;
            _amount = amount;
            _status = "Pending";
        }

        public int PaymentId => _paymentId;
        public double Amount => _amount;
        public string Status => _status;

        public void ProcessPayment() {
            _status = "Completed";
            Console.WriteLine($"Payment {_paymentId} completed.");
        }
    }
}