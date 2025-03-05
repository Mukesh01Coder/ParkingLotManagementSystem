using ParkingLotManagementSystem.Models.Enums;
using ParkingLotManagementSystem.Models;
using ParkingLotManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ParkingLotManagementSystem.Controllers
{
    public class ParkingLotController
    {
        private ParkingLotService parkingLotService;

        public ParkingLotController(ParkingLotService parkingLot)
        {
            this.parkingLotService = parkingLot;
        }

        public bool isSlotAvailable(ParkingLot parkingLot)
        {
            return parkingLot.getAvailableSlots() > 0;
        }

        public bool isSlotAvailable(VehicleType vehicleType)
        { // TODO: complete this method
            return true;
        }


        public Bill billPayment(Bill bill)
        {
            return null;
        }


        public ParkingLot initialiseParkingLot(int noOfFloors, int noOfSpotInAFloor)
        {
            //TODO: add validations for practical range of noOfFloors, and noOfSpotInAFloor
            return parkingLotService.initialiseParkingLot(noOfFloors, noOfSpotInAFloor);
        }

        public void displayParkingLot(ParkingLot parkingLot)
        {
            parkingLotService.showParkingLot(parkingLot);
        }
    }
}
