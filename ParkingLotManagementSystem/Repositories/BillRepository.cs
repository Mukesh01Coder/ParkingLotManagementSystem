using ParkingLotManagementSystem.Exceptions;
using ParkingLotManagementSystem.Models;
namespace ParkingLotManagementSystem.Repositories
{
    public class BillRepository
    {
        private Dictionary<int, Bill> billMap;
        private static int counter = 1;

        public BillRepository()
        {
            this.billMap = new Dictionary<int, Bill>();
        }

        public Bill save(Bill bill)
        {
            bill.setId(counter++);
            billMap.Add(bill.getId(), bill);
            return billMap[bill.getId()];
        }

        public Bill findById(int billId)
        {
            if (billMap.ContainsKey(billId))
            {
                return billMap[billId];
            }
            else
            {
                throw new BillNotFoundException("Bill with given id does not exist : " + billId);
            }
        }

        public Bill update(int billId, Bill newBill)
        {
            if (billMap.ContainsKey(billId))
            {
                Bill oldbill = billMap[billId];

                billMap[billId] = newBill;
                billMap.Add(billId, newBill);

                return oldbill;
            }
            else
            {
                throw new BillNotFoundException("Bill with given id does not exist : " + billId);
            }
        }

        public bool delete(int billId)
        {
            if (billMap.ContainsKey(billId))
            {
                billMap.Remove(billId);
                return true;
            }
            else
            {
                throw new BillNotFoundException("Bill with given id does not exist : " + billId);
            }
        }
    }
}
