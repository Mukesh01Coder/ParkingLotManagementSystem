using ParkingLotManagementSystem.Models;
using ParkingLotManagementSystem.Services;
namespace ParkingLotManagementSystem.Controllers
{
    public class BillController
    {
        private BillService billService;

        public BillController(BillService billService)
        {
            this.billService = billService;
        }

        public void displayBillDetails(Bill bill)
        {
            Console.WriteLine(bill);
        }

        public Bill generateBill(ParkingLot parkingLot, int ticketId, int exitGateId)
        {
            return billService.generateBill(parkingLot, ticketId, exitGateId);
        }
    }
}
