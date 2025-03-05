using ParkingLotManagementSystem.Exceptions;
using ParkingLotManagementSystem.Models;

namespace ParkingLotManagementSystem.Repositories
{
    public class VehicleRepository
    {
        private Dictionary<int, Vehicle> vehicleMap;
        private static int counter = 1;

        public VehicleRepository()
        {
            this.vehicleMap = new Dictionary<int, Vehicle>();
        }

        public Vehicle save(Vehicle vehicle)
        {
            vehicle.setId(counter++);
            vehicleMap.Add(vehicle.getId(), vehicle);
            return vehicleMap[vehicle.getId()];
        }

        public Vehicle findById(int vehicleId)
        {
            if (vehicleMap.ContainsKey(vehicleId))
            {
                return vehicleMap[vehicleId];
            }
            else
            {
                throw new VehicleNotFoundException("Vehicle with given id does not exist : " + vehicleId);
            }
        }

        public Vehicle update(int vehicleId, Vehicle newVehicle)
        {
            if (vehicleMap.ContainsKey(vehicleId))
            {
                Vehicle oldVehicle = vehicleMap[vehicleId];
                 vehicleMap[vehicleId] = newVehicle;

                return oldVehicle;
            }
            else
            {
                throw new VehicleNotFoundException("Vehicle with given id does not exist : " + vehicleId);
            }
        }

        public bool delete(int vehicleId)
        {
            if (vehicleMap.ContainsKey(vehicleId))
            {
                vehicleMap.Remove(vehicleId);
                return true;
            }
            else
            {
                throw new VehicleNotFoundException("Vehicle with given id does not exist : " + vehicleId);
            }
        }

        public Vehicle getVehicleByNumber(string vehicleNumber)
        {         
            foreach (var entry in vehicleMap)
            {
                if (entry.Value.getVehicleNumber().Equals(vehicleNumber, StringComparison.OrdinalIgnoreCase))
                {
                    return entry.Value;
                }
            }
            throw new VehicleNotFoundException("Vehicle details not found");
        }

    }
}
