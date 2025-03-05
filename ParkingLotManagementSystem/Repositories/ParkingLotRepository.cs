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
    public class ParkingLotRepository
    {
        private Dictionary<int, ParkingLot> parkingLotMap;
        private static int counter = 1;

        public ParkingLotRepository()
        {
            this.parkingLotMap = new Dictionary<int, ParkingLot>();
        }

        public ParkingLot save(ParkingLot parkingLot)
        {
            parkingLot.setId(counter++);
            parkingLotMap.Add(parkingLot.getId(), parkingLot);
            return parkingLotMap[parkingLot.getId()];
        }

        public ParkingLot findById(int parkingLotId)
        {
            if (parkingLotMap.ContainsKey(parkingLotId))
            {
                return parkingLotMap[parkingLotId];
            }
            else
            {
                throw new ParkingLotNotFoundException("Parking lot with given id does not exist : " + parkingLotId);
            }
        }

        public ParkingLot update(int parkingLotId, ParkingLot newParkingLot)
        {
            if (parkingLotMap.ContainsKey(parkingLotId))
            {
                ParkingLot oldParkingLot = parkingLotMap[parkingLotId];
                parkingLotMap[parkingLotId] = newParkingLot;
                return oldParkingLot;
            }
            else
            {
                throw new ParkingLotNotFoundException("Parking lot with given id does not exist : " + parkingLotId);
            }
        }

        public bool delete(int parkingLotId)
        {
            if (parkingLotMap.ContainsKey(parkingLotId))
            {
                parkingLotMap.Remove(parkingLotId);
                return true;
            }
            else
            {
                throw new ParkingLotNotFoundException("Parking lot with given id does not exist : " + parkingLotId);
            }
        }

    }
}
