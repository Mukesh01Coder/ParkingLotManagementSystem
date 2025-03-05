using ParkingLotManagementSystem.Models.Enums;

namespace ParkingLotManagementSystem.Models
{
    public class ParkingGate
    {
        private int id;
        private string gateNumber;
        private ParkingGateType gateType;
        private Operator operatorDetails;

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getGateNumber()
        {
            return gateNumber;
        }

        public void setGateNumber(String gateNumber)
        {
            this.gateNumber = gateNumber;
        }

        public ParkingGateType getGateType()
        {
            return gateType;
        }

        public void setGateType(ParkingGateType gateType)
        {
            this.gateType = gateType;
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
