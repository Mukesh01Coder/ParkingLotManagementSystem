using ParkingLotManagementSystem.Exceptions;
using ParkingLotManagementSystem.Models.Enums;
using ParkingLotManagementSystem.Models;
using ParkingLotManagementSystem.Repositories;
using ParkingLotManagementSystem.Services.Strategy;

namespace ParkingLotManagementSystem.Services
{
    public class TicketService
    {
        private ParkingGateRepository parkingGateRepository;
        private ParkingTicketRepository parkingTicketRepository;
        private ParkingSpotRepository parkingSpotRepository;
        private ParkingLotRepository parkingLotRepository;
        private VehicleRepository vehicleRepository;

        public TicketService(ParkingGateRepository parkingGateRepository, ParkingTicketRepository parkingTicketRepository,
                             ParkingSpotRepository parkingSpotRepository, ParkingLotRepository parkingLotRepository,
                             VehicleRepository vehicleRepository)
        {
            this.parkingGateRepository = parkingGateRepository;
            this.parkingTicketRepository = parkingTicketRepository;
            this.parkingSpotRepository = parkingSpotRepository;
            this.parkingLotRepository = parkingLotRepository;
            this.vehicleRepository = vehicleRepository;
        }

        public ParkingTicket generateTicket(string vehicleNumber, ParkingLot parkingLot, ParkingSpotTier parkingSpotTier, int entryGate)
        {
            Vehicle vehicle = null;
            try
            {
                vehicle = vehicleRepository.getVehicleByNumber(vehicleNumber);
            }
            catch (VehicleNotFoundException ve)
            {
                StreamReader sc = new StreamReader(Console.OpenStandardInput());
                Console.WriteLine("Vehicle does not exist with this number, please enter the details");

                Console.WriteLine("Please enter the vehicle type - 1. 2 Wheeler, 2. 3 Wheeler, 4. 4 Wheeler");
                int vehicleType = Convert.ToInt32(sc.ReadLine());

                Console.WriteLine("Please enter the vehicle info");
                string vehicleInfo = sc.ReadLine();

                vehicle = new Vehicle();
                vehicle.setVehicleNumber(vehicleNumber);
                vehicle.setVehicleInfo(vehicleInfo);
                //TODO: change vehicleType based on the user input

                switch(vehicleType)
                {
                    case 4:
                        vehicle.setVehicleType(VehicleType.FOUR_WHEELER);
                        break;
                    case 1:
                        vehicle.setVehicleType(VehicleType.TWO_WHEELER);
                        break;
                    case 2:
                        vehicle.setVehicleType(VehicleType.THREE_WHEELER);
                        break;
                    default:
                        throw new VehicleNotFoundException("Vehicle Type Exits!");                      
                }
                     
                //vehicle.setVehicleType(VehicleType.FOUR_WHEELER);
                vehicle = vehicleRepository.save(vehicle);
            }
            return generateTicket(parkingLot, vehicle, parkingSpotTier, entryGate);
        }

        private ParkingTicket generateTicket(ParkingLot parkingLot, Vehicle vehicle, ParkingSpotTier parkingSpotTier, int entryGateId)
        {
            SpotAssignmentStrategy spotAssignmentStrategy = SpotAssignmentStrategyFactory.getSpotAssignmentStrategy();
            ParkingSpot spot = spotAssignmentStrategy.findSpotForVehicle(parkingLot, vehicle, parkingSpotTier);

            ParkingTicket ticket = new ParkingTicket();
            ticket.setEntryTime(DateTime.Now);
            ticket.setParkingSpot(spot);
            ticket.setVehicle(vehicle);
            ticket.setGate(parkingGateRepository.findById(entryGateId));
            ticket.setOperator(parkingGateRepository.findById(entryGateId).getOperator());

            ticket = parkingTicketRepository.save(ticket);

            spot.setSpotStatus(ParkingSpotStatus.OCCUPIED);
            spot = parkingSpotRepository.update(spot.getId(), spot);

            parkingLot.setAvailableSlots(parkingLot.getAvailableSlots() - 1);
            parkingLot = parkingLotRepository.update(parkingLot.getId(), parkingLot);

            return ticket;
        }
    }
}
