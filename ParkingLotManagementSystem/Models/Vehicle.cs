using ParkingLotManagementSystem.Models.Enums;

namespace ParkingLotManagementSystem.Models
{
    public class Vehicle
    {
        private int id;
        private string vehicleNumber;
        private string vehicleInfo;
        private VehicleType vehicleType;

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getVehicleNumber()
        {
            return vehicleNumber;
        }

        public void setVehicleNumber(String vehicleNumber)
        {
            this.vehicleNumber = vehicleNumber;
        }

        public string getVehicleInfo()
        {
            return vehicleInfo;
        }

        public void setVehicleInfo(String vehicleInfo)
        {
            this.vehicleInfo = vehicleInfo;
        }

        public VehicleType getVehicleType()
        {
            return vehicleType;
        }

        public void setVehicleType(VehicleType vehicleType)
        {
            this.vehicleType = vehicleType;
        }
    }
}
