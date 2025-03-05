namespace ParkingLotManagementSystem.Services.Strategy
{
    public class BillCalculationStrategyFactory
    {
        public static BillCalculationStrategy getBillCalculationStrategy()
        {
            return new LinearBillCalculationStrategy();
        }
    }
}
