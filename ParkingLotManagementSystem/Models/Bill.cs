namespace ParkingLotManagementSystem.Models
{
    public class Bill
    {
        private int id;
        private DateTime exitTime;
        private ParkingTicket parkingTicket;
        private double amount;
        private Payment payment;
        private ParkingGate exitGate;
        private Operator operatorDetails;

        public string toString()
        {
            return "Bill{" +
                    "id=" + id +
                    ", exitTime=" + exitTime +
                    ", parkingTicket=" + parkingTicket +
                    ", amount=" + amount +
                    ", payment=" + payment +
                    ", exitGate=" + exitGate +
                    ", operator=" + operatorDetails +
                    '}';
        }
        public ParkingGate getExitGate()
        {
            return exitGate;
        }

        public void setExitGate(ParkingGate exitGate)
        {
            this.exitGate = exitGate;
        }

        public Operator getOperator()
        {
            return operatorDetails;
        }

        public void setOperator(Operator operatorDetails)
        {
            this.operatorDetails = operatorDetails;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public DateTime getExitTime()
        {
            return exitTime;
        }

        public void setExitTime(DateTime exitTime)
        {
            this.exitTime = exitTime;
        }

        public ParkingTicket getParkingTicket()
        {
            return parkingTicket;
        }

        public void setParkingTicket(ParkingTicket parkingTicket)
        {
            this.parkingTicket = parkingTicket;
        }

        public double getAmount()
        {
            return amount;
        }

        public void setAmount(double amount)
        {
            this.amount = amount;
        }

        public Payment getPayment()
        {
            return payment;
        }

        public void setPayment(Payment payment)
        {
            this.payment = payment;
        }
    }
}
