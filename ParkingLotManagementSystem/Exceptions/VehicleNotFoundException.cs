using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagementSystem.Exceptions
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException() { }
        public VehicleNotFoundException(string message) : base(message) { }
        public VehicleNotFoundException(String message, Exception cause) : base(message, cause) { }
        public VehicleNotFoundException(Exception cause) : base(cause.Message, cause) { }

    }
}
