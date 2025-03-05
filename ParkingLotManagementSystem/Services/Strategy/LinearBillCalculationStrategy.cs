using ParkingLotManagementSystem.Models.Enums;

namespace ParkingLotManagementSystem.Services.Strategy
{
    public class LinearBillCalculationStrategy: BillCalculationStrategy
    {
        public double generateOverallBill(int duration, VehicleType vehicleType, ParkingSpotTier tier)
        {
            return 10 * duration;
        }
    }
}
