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
    public class ParkingTicketRepository
    {
        private Dictionary<int, ParkingTicket> parkingParkingTicketMap;
        private static int counter = 1;

        public ParkingTicketRepository()
        {
            this.parkingParkingTicketMap = new Dictionary<int, ParkingTicket>();
        }

        public ParkingTicket save(ParkingTicket parkingParkingTicket)
        {
            parkingParkingTicket.setId(counter++);
            parkingParkingTicketMap.Add(parkingParkingTicket.getId(), parkingParkingTicket);
            return parkingParkingTicketMap[parkingParkingTicket.getId()];
        }

        public ParkingTicket findById(int parkingParkingTicketId)
        {
            if (parkingParkingTicketMap.ContainsKey(parkingParkingTicketId))
            {
                return parkingParkingTicketMap[parkingParkingTicketId];
            }
            else
            {
                throw new ParkingTicketNotFoundException("Parking floor with given id does not exist : " + parkingParkingTicketId);
            }
        }

        public ParkingTicket update(int parkingParkingTicketId, ParkingTicket newParkingTicket)
        {
            if (parkingParkingTicketMap.ContainsKey(parkingParkingTicketId))
            {
                ParkingTicket oldParkingTicket = parkingParkingTicketMap[parkingParkingTicketId];
                parkingParkingTicketMap[parkingParkingTicketId] = newParkingTicket;

                return oldParkingTicket;
            }
            else
            {
                throw new ParkingTicketNotFoundException("Parking floor with given id does not exist : " + parkingParkingTicketId);
            }
        }

        public bool delete(int parkingParkingTicketId)
        {
            if (parkingParkingTicketMap.ContainsKey(parkingParkingTicketId))
            {
                parkingParkingTicketMap.Remove(parkingParkingTicketId);
                return true;
            }
            else
            {
                throw new ParkingTicketNotFoundException("Parking floor with given id does not exist : " + parkingParkingTicketId);
            }
        }
    }
}
