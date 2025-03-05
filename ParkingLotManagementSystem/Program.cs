using ParkingLotManagementSystem.Models.Enums;
using ParkingLotManagementSystem.Models;
using ParkingLotManagementSystem.Repositories;
using ParkingLotManagementSystem.Services;
using ParkingLotManagementSystem.Controllers;

BillRepository billRepository = new BillRepository();
ParkingLotRepository parkingLotRepository = new ParkingLotRepository(); // initialised a parkingLotRepo object, available for injection
ParkingGateRepository parkingGateRepository = new ParkingGateRepository();
ParkingFloorRepository parkingFloorRepository = new ParkingFloorRepository();
ParkingSpotRepository parkingSpotRepository = new ParkingSpotRepository();
ParkingTicketRepository parkingTicketRepository = new ParkingTicketRepository();
VehicleRepository vehicleRepository = new VehicleRepository();

ParkingLotService parkingLotService = new ParkingLotService(parkingLotRepository,
        parkingFloorRepository, parkingSpotRepository, parkingGateRepository); // initialising parkingLotService, ie, while object creation the dependency will be injected

TicketService ticketService = new TicketService(parkingGateRepository,
        parkingTicketRepository, parkingSpotRepository, parkingLotRepository, vehicleRepository);

BillService billService = new BillService(parkingTicketRepository,
        billRepository, parkingGateRepository, parkingSpotRepository, parkingLotRepository);

ParkingLotController parkingLotController = new ParkingLotController(parkingLotService);
TicketController ticketController = new TicketController(ticketService);
BillController billController = new BillController(billService);

ParkingLot parkingLot = parkingLotController.initialiseParkingLot(1, 3);
parkingLotController.displayParkingLot(parkingLot);

StreamReader sc = new StreamReader(Console.OpenStandardInput());

Console.WriteLine("Welcome to Parking Lot system");

while (true)
{
    Console.WriteLine("Choose one of the following : ");
    Console.WriteLine("1. Enter new vehicle");
    Console.WriteLine("2. Exit vehicle");
    int option = Convert.ToInt32(sc.ReadLine());
    if (option == 1)
    {
        if (parkingLotController.isSlotAvailable(parkingLot))
        {
            Console.WriteLine("Please enter vehicle number");
            string number = sc.ReadLine();
            ParkingTicket ticket = ticketController.generateTicket(parkingLot, number, ParkingSpotTier.NORMAL, 1);
            ticketController.displayTicketDetails(ticket);
            parkingLotController.displayParkingLot(parkingLot);
        }
        else
        {
           Console.WriteLine("Parking Lot is full, please try again later");
        }
    }
    else
    {
        Console.WriteLine("Please enter your ticketId");
        int ticketId = Convert.ToInt32(sc.ReadLine());
        Bill bill = billController.generateBill(parkingLot, ticketId, 2);
        billController.displayBillDetails(bill);
        parkingLotController.displayParkingLot(parkingLot);
    }
}