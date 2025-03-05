using ParkingLotManagementSystem.Models.Enums;
using ParkingLotManagementSystem.Models;
using ParkingLotManagementSystem.Services;
namespace ParkingLotManagementSystem.Controllers
{
    public class TicketController
    {
        private TicketService ticketService;

        public TicketController(TicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public void displayTicketDetails(ParkingTicket parkingTicket)
        {
            Console.WriteLine(parkingTicket);
        }

        public ParkingTicket generateTicket(ParkingLot parkingLot, string vehicleNumber, ParkingSpotTier parkingSpotTier, int entryGateId)
        {
            return ticketService.generateTicket(vehicleNumber, parkingLot, parkingSpotTier, entryGateId);
        }
    }
}
