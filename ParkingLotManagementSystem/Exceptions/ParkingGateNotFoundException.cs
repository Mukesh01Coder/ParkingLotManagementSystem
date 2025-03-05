using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagementSystem.Exceptions
{
    public class ParkingGateNotFoundException: Exception
    {
        public ParkingGateNotFoundException()
        {
        }
        public ParkingGateNotFoundException(string message) : base(message)
        {
        }
        public ParkingGateNotFoundException(String message, Exception cause) : base(message, cause)
        {
        }

        public ParkingGateNotFoundException(Exception cause) : base(cause.Message, cause)
        {
        }
    }
}
