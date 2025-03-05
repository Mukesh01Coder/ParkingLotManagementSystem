using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagementSystem.Exceptions
{
    public class ParkingLotNotFoundException : Exception
    {
        public ParkingLotNotFoundException()
        {
        }
        public ParkingLotNotFoundException(string message) : base(message)
        {
        }
        public ParkingLotNotFoundException(String message, Exception cause) : base(message, cause)
        {
        }
        public ParkingLotNotFoundException(Exception cause) : base(cause.Message, cause)
        {
        }
    }
}
