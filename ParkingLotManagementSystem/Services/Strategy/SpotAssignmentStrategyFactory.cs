
namespace ParkingLotManagementSystem.Services.Strategy
{
    public class SpotAssignmentStrategyFactory
    {
        public static SpotAssignmentStrategy getSpotAssignmentStrategy()
        {
            return new LinearSpotAssignmentStrategy();
        }
    }
}
