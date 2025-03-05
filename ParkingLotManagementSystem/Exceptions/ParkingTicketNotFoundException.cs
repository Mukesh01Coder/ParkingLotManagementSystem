using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagementSystem.Exceptions
{
    public class ParkingTicketNotFoundException : Exception
    {
        public ParkingTicketNotFoundException()
        {
        }
        public ParkingTicketNotFoundException(string message) : base(message)
        {
        }
        public ParkingTicketNotFoundException(String message, Exception cause) : base(message, cause)
        {
        }
        public ParkingTicketNotFoundException(Exception cause) : base(cause.Message, cause)
        {
        }
    }
}
