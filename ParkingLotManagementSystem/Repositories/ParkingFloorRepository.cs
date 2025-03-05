using ParkingLotManagementSystem.Exceptions;
using ParkingLotManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ParkingLotManagementSystem.Repositories
{
    public class ParkingFloorRepository
    {
        private Dictionary<int, ParkingFloor> parkingFloorMap;
        private static int counter = 1;

        public ParkingFloorRepository()
        {
            this.parkingFloorMap = new Dictionary<int, ParkingFloor>();
        }

        public ParkingFloor save(ParkingFloor parkingFloor)
        {
            parkingFloor.setId(counter++);
            parkingFloorMap.Add(parkingFloor.getId(), parkingFloor);
            return parkingFloorMap[parkingFloor.getId()];
        }

        public ParkingFloor findById(int parkingFloorId)
        {
            if (parkingFloorMap.ContainsKey(parkingFloorId))
            {
                return parkingFloorMap[parkingFloorId];
            }
            else
            {
                throw new ParkingFloorNotFoundException("Parking floor with given id does not exist : " + parkingFloorId);
            }
        }

        public ParkingFloor update(int parkingFloorId, ParkingFloor newParkingFloor)
        {
            if (parkingFloorMap.ContainsKey(parkingFloorId))
            {
                 ParkingFloor oldParkingFloor = parkingFloorMap[parkingFloorId];
                parkingFloorMap[parkingFloorId] = newParkingFloor;
                return oldParkingFloor;
            }
            else
            {
                throw new ParkingFloorNotFoundException("Parking floor with given id does not exist : " + parkingFloorId);
            }
        }

        public bool delete(int parkingFloorId)
        {
            if (parkingFloorMap.ContainsKey(parkingFloorId))
            {
                parkingFloorMap.Remove(parkingFloorId);
                return true;
            }
            else
            {
                throw new ParkingFloorNotFoundException("Parking floor with given id does not exist : " + parkingFloorId);
            }
        }

    }
}
