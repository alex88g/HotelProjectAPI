namespace HotelProjectAPI.Models 
{
    public class Customer
    {
        // Properties of the Customer class
        public int Id { get; set; }     // Represents the unique identifier for a customer
        public string Name { get; set; }  // Represents the name of the customer

        // Represents a collection of rooms associated with the customer
        public ICollection<Room> Rooms { get; set; } = new List<Room>();

        // Constructor for the Customer class
        public Customer(string name)
        {
            Name = name;  // Assigns the provided 'name' parameter to the 'Name' property
        }
    }
}
