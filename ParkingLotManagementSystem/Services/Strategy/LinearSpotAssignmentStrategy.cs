using ParkingLotManagementSystem.Exceptions;
using ParkingLotManagementSystem.Models.Enums;
using ParkingLotManagementSystem.Models;

namespace ParkingLotManagementSystem.Services.Strategy
{
    public class LinearSpotAssignmentStrategy: SpotAssignmentStrategy
    {
        public LinearSpotAssignmentStrategy() { }
        public ParkingSpot findSpotForVehicle(ParkingLot parkingLot, Vehicle vehicle, ParkingSpotTier parkingSpotTier)
        {
            foreach (ParkingFloor floor in parkingLot.getFloors())
            {
                foreach (ParkingSpot spot in floor.getParkingSpots())
                {
                    if (spot.getSpotStatus().Equals(ParkingSpotStatus.AVAILABLE)
                    && spot.getVehicleTypeSupported().Equals(vehicle.getVehicleType())
                    && spot.getParkingSpotTier().Equals(parkingSpotTier))
                    {
                        return spot;
                    }
                }
            }
            throw new ParkingSpotNotAvailableException("No parking spot found");
        }
    }
}
