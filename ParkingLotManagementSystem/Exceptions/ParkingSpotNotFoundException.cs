using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagementSystem.Exceptions
{
    public class ParkingSpotNotFoundException : Exception
    {
        public ParkingSpotNotFoundException()
        {
        }
        public ParkingSpotNotFoundException(string message) : base(message)
        {
        }
        public ParkingSpotNotFoundException(String message, Exception cause) : base(message, cause)
        {
        }
        public ParkingSpotNotFoundException(Exception cause) : base(cause.Message, cause)
        {
        }
    }
}
