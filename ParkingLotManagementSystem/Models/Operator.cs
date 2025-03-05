namespace ParkingLotManagementSystem.Models
{
    public class Operator
    {
        private int id;
        private string name;
        private string email;

        public Operator(int id, string name, string email)
        {
            this.id = id;
            this.name = name;
            this.email = email;
        }
        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public string getEmail()
        {
            return email;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }
    }
}
