using ParkingLotManagementSystem.Models;
using ParkingLotManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagementSystem.Services
{
    public class VehicleService
    {
        private VehicleRepository vehicleRepository;

        public VehicleService(VehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public Vehicle getVehicleDetails(String number)
        {
            return vehicleRepository.getVehicleByNumber(number);
        }
    }
}
