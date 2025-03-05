namespace ParkingLotManagementSystem.Exceptions
{
    public class BillNotFoundException : Exception
    {
        public BillNotFoundException()
        {
        }

        public BillNotFoundException(string message) : base(message) { }
       

        public BillNotFoundException(string message, Exception innerException) : base(message, innerException) { }


        public BillNotFoundException(Exception cause) : base(cause.Message, cause) { }
    }
}
