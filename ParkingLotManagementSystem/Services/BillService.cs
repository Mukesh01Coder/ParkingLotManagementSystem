using ParkingLotManagementSystem.Models.Enums;
using ParkingLotManagementSystem.Models;
using ParkingLotManagementSystem.Repositories;
using ParkingLotManagementSystem.Services.Strategy;

namespace ParkingLotManagementSystem.Services
{
    public class BillService
    {
        private ParkingTicketRepository parkingTicketRepository;
        private BillRepository billRepository;
        private ParkingGateRepository parkingGateRepository;
        private ParkingSpotRepository parkingSpotRepository;
        private ParkingLotRepository parkingLotRepository;

        public BillService(ParkingTicketRepository parkingTicketRepository, BillRepository billRepository,
                           ParkingGateRepository parkingGateRepository, ParkingSpotRepository parkingSpotRepository,
                           ParkingLotRepository parkingLotRepository)
        {
            this.parkingTicketRepository = parkingTicketRepository;
            this.billRepository = billRepository;
            this.parkingGateRepository = parkingGateRepository;
            this.parkingSpotRepository = parkingSpotRepository;
            this.parkingLotRepository = parkingLotRepository;
        }

        public Bill generateBill(ParkingLot parkingLot, int ticketId, int exitGateId)
        {
            ParkingTicket ticket = parkingTicketRepository.findById(ticketId);

            Bill bill = new Bill();
            bill.setExitTime(DateTime.Now);
            bill.setParkingTicket(ticket);
            bill.setExitGate(parkingGateRepository.findById(exitGateId));
            bill.setOperator(parkingGateRepository.findById(exitGateId).getOperator());

            int duration = DateTime.Now.Second - ticket.getEntryTime().Second;

            BillCalculationStrategy strategy = BillCalculationStrategyFactory.getBillCalculationStrategy();
            double amount = strategy.generateOverallBill(duration, ticket.getVehicle().getVehicleType(), ticket.getParkingSpot().getParkingSpotTier());
            bill.setAmount(amount);

            ParkingSpot spot = ticket.getParkingSpot();
            spot.setSpotStatus(ParkingSpotStatus.AVAILABLE);
            spot = parkingSpotRepository.update(spot.getId(), spot);

            parkingLot.setAvailableSlots(parkingLot.getAvailableSlots() + 1);
            parkingLot = parkingLotRepository.update(parkingLot.getId(), parkingLot);

            return billRepository.save(bill);

        }

    }
}
