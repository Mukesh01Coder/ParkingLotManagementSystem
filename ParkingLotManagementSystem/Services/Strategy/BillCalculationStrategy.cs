using ParkingLotManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagementSystem.Services.Strategy
{
    public interface BillCalculationStrategy
    {
        double generateOverallBill(int duration, VehicleType vehicleType, ParkingSpotTier tier);
    }
}
