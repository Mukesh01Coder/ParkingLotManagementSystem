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
    public class ParkingGateRepository
    {
        private Dictionary<int, ParkingGate> parkingGateMap;
        private static int counter = 1;

        public ParkingGateRepository()
        {
            this.parkingGateMap = new Dictionary<int, ParkingGate>();
        }

        public ParkingGate save(ParkingGate parkingGate)
        {
            parkingGate.setId(counter++);
            parkingGateMap.Add(parkingGate.getId(), parkingGate);
            return parkingGateMap[parkingGate.getId()];
        }

        public ParkingGate findById(int parkingGateId)
        {
            if (parkingGateMap.ContainsKey(parkingGateId))
            {
                return parkingGateMap[parkingGateId];
            }
            else
            {
                throw new ParkingGateNotFoundException("Parking gate with given id does not exist : " + parkingGateId);
            }
        }

        public ParkingGate update(int parkingGateId, ParkingGate newParkingGate)
        {
            if (parkingGateMap.ContainsKey(parkingGateId))
            {
                 ParkingGate oldParkingGate = parkingGateMap[parkingGateId];
                parkingGateMap[parkingGateId] = newParkingGate;

                return oldParkingGate;
            }
            else
            {
                throw new ParkingGateNotFoundException("Parking gate with given id does not exist : " + parkingGateId);
            }
        }

        public bool delete(int parkingGateId)
        {
            if (parkingGateMap.ContainsKey(parkingGateId))
            {
                parkingGateMap.Remove(parkingGateId);
                return true;
            }
            else
            {
                throw new ParkingGateNotFoundException("Parking gate with given id does not exist : " + parkingGateId);
            }
        }

    }
}
