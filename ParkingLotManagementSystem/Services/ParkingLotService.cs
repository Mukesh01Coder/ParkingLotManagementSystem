using ParkingLotManagementSystem.Models.Enums;
using ParkingLotManagementSystem.Models;
using ParkingLotManagementSystem.Repositories;

namespace ParkingLotManagementSystem.Services
{
    public class ParkingLotService
    {
        private ParkingLotRepository parkingLotRepository; // mentioning the requirement for dependency
        private ParkingFloorRepository parkingFloorRepository;
        private ParkingSpotRepository parkingSpotRepository;
        private ParkingGateRepository parkingGateRepository;

        public ParkingLotService(ParkingLotRepository parkingLotRepository, ParkingFloorRepository parkingFloorRepository,
                                 ParkingSpotRepository parkingSpotRepository, ParkingGateRepository parkingGateRepository)
        {
            this.parkingLotRepository = parkingLotRepository;
            this.parkingFloorRepository = parkingFloorRepository;
            this.parkingSpotRepository = parkingSpotRepository;
            this.parkingGateRepository = parkingGateRepository;
        }

        public ParkingLot initialiseParkingLot(int noOfFloors, int noOfSpotInAFloor)
        {
            Operator operatorDetails = new Operator(1, "Operator", "operator@operate.com");

            ParkingLot parkingLot = new ParkingLot();
            parkingLot.setName("Parking Lot 1");
            parkingLot.setAddress("Street A, Place B, City C - 123456");

            ParkingGate entryGate = new ParkingGate();
            entryGate.setGateNumber("G01");
            entryGate.setGateType(ParkingGateType.ENTRY);
            entryGate.setOperator(operatorDetails);

            ParkingGate exitGate = new ParkingGate();
            exitGate.setGateNumber("G02");
            exitGate.setGateType(ParkingGateType.EXIT);
            exitGate.setOperator(operatorDetails);

            entryGate = parkingGateRepository.save(entryGate);
            exitGate = parkingGateRepository.save(exitGate);

            List<ParkingGate> listOfGates = new List<ParkingGate> { entryGate, exitGate };
            parkingLot.setGates (listOfGates);


            List<ParkingFloor> floors = new List<ParkingFloor>();

            for (int i = 1; i <= noOfFloors; i++)
            {
                ParkingFloor floor = new ParkingFloor();
                floor.setFloorNumber(i);
                List<ParkingSpot> spots = new List<ParkingSpot>();
                for (int j = 1; j <= noOfSpotInAFloor; j++)
                {
                    ParkingSpot spot = new ParkingSpot();
                    spot.setParkingSpotNumber(i + "0" + j);
                    spot.setVehicleTypeSupported(VehicleType.FOUR_WHEELER);
                    spot.setSpotStatus(ParkingSpotStatus.AVAILABLE);
                    spot.setParkingSpotTier(ParkingSpotTier.NORMAL);
                    spot = parkingSpotRepository.save(spot);
                    spots.Add(spot);
                }
                floor.setParkingSpots(spots);
                floor = parkingFloorRepository.save(floor);
                floors.Add(floor);
            }

            parkingLot.setFloors(floors);
            int capacity = noOfFloors * noOfSpotInAFloor;
            parkingLot.setTotalCapacity(capacity);
            parkingLot.setAvailableSlots(capacity);

            return parkingLotRepository.save(parkingLot);
        }

        public void showParkingLot(ParkingLot parkingLot)
        {
            for (int i = 0; i < parkingLot.getFloors().Count; i++)
            {
                ParkingFloor floor = parkingLot.getFloors()[i];
                Console.WriteLine("FLOOR : " + floor.getFloorNumber());
                Console.WriteLine("----------------------------------");
                foreach (ParkingSpot spot in floor.getParkingSpots())
                {
                    Console.Write("|");
                    if (spot.getSpotStatus().Equals(ParkingSpotStatus.OCCUPIED))
                    {
                        Console.Write("X");
                    }
                    else if (spot.getSpotStatus().Equals(ParkingSpotStatus.AVAILABLE))
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                    Console.Write("| ");
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------");
            }
            Console.WriteLine("Available slots - " + parkingLot.getAvailableSlots());
        }
    }
}
