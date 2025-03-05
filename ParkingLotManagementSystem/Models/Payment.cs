namespace ParkingLotManagementSystem.Models
{
    public class Payment
    {
        private int id;
        private double amount;
        private string transactionReferenceNumber;
        private PaymentStatus paymentStatus;
        private PaymentMode paymentMode;

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public double getAmount()
        {
            return amount;
        }

        public void setAmount(double amount)
        {
            this.amount = amount;
        }

        public String getTransactionReferenceNumber()
        {
            return transactionReferenceNumber;
        }

        public void setTransactionReferenceNumber(String transactionReferenceNumber)
        {
            this.transactionReferenceNumber = transactionReferenceNumber;
        }

        public PaymentStatus getPaymentStatus()
        {
            return paymentStatus;
        }

        public void setPaymentStatus(PaymentStatus paymentStatus)
        {
            this.paymentStatus = paymentStatus;
        }

        public PaymentMode getPaymentMode()
        {
            return paymentMode;
        }

        public void setPaymentMode(PaymentMode paymentMode)
        {
            this.paymentMode = paymentMode;
        }
    }
}
