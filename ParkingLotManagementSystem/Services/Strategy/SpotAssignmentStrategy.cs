using ParkingLotManagementSystem.Models.Enums;
using ParkingLotManagementSystem.Models;

namespace ParkingLotManagementSystem.Services.Strategy
{
    public interface SpotAssignmentStrategy
    {
        ParkingSpot findSpotForVehicle(ParkingLot parkingLot, Vehicle vehicle, ParkingSpotTier parkingSpotTier);
    }
}
