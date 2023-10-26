namespace TestFor302.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double PersonalSale { get; set; }

        public double GetPrice(double price)
        {
            return price * (1 - PersonalSale / 100);
        }
    }
}
