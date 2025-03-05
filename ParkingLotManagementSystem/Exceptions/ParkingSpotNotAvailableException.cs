using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagementSystem.Exceptions
{
    public class ParkingSpotNotAvailableException : Exception
    {
        public ParkingSpotNotAvailableException()
        {
        }
        public ParkingSpotNotAvailableException(string message) : base(message)
        {
        }
        public ParkingSpotNotAvailableException(String message, Exception cause) : base(message, cause)
        {
        }
        public ParkingSpotNotAvailableException(Exception cause) : base(cause.Message, cause)
        {
        }
    }
}
