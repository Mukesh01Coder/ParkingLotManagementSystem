
namespace ParkingLotManagementSystem.Models
{
    public class ParkingTicket
    {
        private int id;
        private ParkingSpot parkingSpot;
        private DateTime entryTime;
        private Vehicle vehicle;
        private ParkingGate gate;
        private Operator operatorDetails;


       
    public string toString()
    {
        return "ParkingTicket{" +
                "ticket Id=" + id +
                "parkingSpot=" + parkingSpot.getParkingSpotNumber() +
                ", entryTime=" + entryTime +
                ", vehicle=" + vehicle.getVehicleNumber() +
                ", gate=" + gate.getGateNumber() +
                ", operator=" + operatorDetails.getName() +
                '}';
    }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public ParkingSpot getParkingSpot()
        {
            return parkingSpot;
        }

        public void setParkingSpot(ParkingSpot parkingSpot)
        {
            this.parkingSpot = parkingSpot;
        }

        public DateTime getEntryTime()
        {
            return entryTime;
        }

        public void setEntryTime(DateTime entryTime)
        {
            this.entryTime = entryTime;
        }

        public Vehicle getVehicle()
        {
            return vehicle;
        }

        public void setVehicle(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        public ParkingGate getGate()
        {
            return gate;
        }

        public void setGate(ParkingGate gate)
        {
            this.gate = gate;
        }

        public Operator getOperator()
        {
            return operatorDetails;
        }

        public void setOperator(Operator operatorDetails)
        {
            this.operatorDetails = operatorDetails;
        }
    }
}
