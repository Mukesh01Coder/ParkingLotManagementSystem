using ParkingLotManagementSystem.Exceptions;
using ParkingLotManagementSystem.Models;

namespace ParkingLotManagementSystem.Repositories
{
    public class ParkingSpotRepository
    {
        private Dictionary<int, ParkingSpot> parkingSpotMap;
        private static int counter = 1;

        public ParkingSpotRepository()
        {
            this.parkingSpotMap = new Dictionary<int, ParkingSpot>();
        }

        public ParkingSpot save(ParkingSpot parkingSpot)
        {
            parkingSpot.setId(counter++);
            parkingSpotMap.Add(parkingSpot.getId(), parkingSpot);
            return parkingSpotMap[parkingSpot.getId()];
        }

        public ParkingSpot findById(int parkingSpotId)
        {
            if (parkingSpotMap.ContainsKey(parkingSpotId))
            {
                return parkingSpotMap[parkingSpotId];
            }
            else
            {
                throw new ParkingSpotNotFoundException("Parking spot with given id does not exist : " + parkingSpotId);
            }
        }

        public ParkingSpot update(int parkingSpotId, ParkingSpot newParkingSpot)
        {
            if (parkingSpotMap.ContainsKey(parkingSpotId))
            {
                ParkingSpot oldParkingSpot = parkingSpotMap[parkingSpotId];
                parkingSpotMap[parkingSpotId] = newParkingSpot;

                return oldParkingSpot;
            }
            else
            {
                throw new ParkingSpotNotFoundException("Parking spot with given id does not exist : " + parkingSpotId);
            }
        }

        public bool delete(int parkingSpotId)
        {
            if (parkingSpotMap.ContainsKey(parkingSpotId))
            {
                parkingSpotMap.Remove(parkingSpotId);
                return true;
            }
            else
            {
                throw new ParkingSpotNotFoundException("Parking spot with given id does not exist : " + parkingSpotId);
            }
        }
    }
}
