using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagementSystem.Exceptions
{
    public class ParkingFloorNotFoundException : Exception
    {
        public ParkingFloorNotFoundException()
        {
        }
        public ParkingFloorNotFoundException(string message) : base(message)
        {
        }

        public ParkingFloorNotFoundException(String message, Exception cause) : base(message, cause)
        {
        }


        public ParkingFloorNotFoundException(Exception cause) : base(cause.Message, cause)
        {
        }

    }
}
