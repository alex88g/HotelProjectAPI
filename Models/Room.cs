namespace HotelProjectAPI.Models 
{
    public class Room
    {
        // Properties of the Room class
        public int Id { get; set; }     // Represents the unique identifier for a room
        public string Name { get; set; }  // Represents the name of the room

        // Represents the hotel associated with the room (nullable)
        public Hotel? Hotel { get; set; }

        // Represents a collection of customers associated with the room
        public ICollection<Customer> Customer { get; set; } = new List<Customer>();

        // Constructor for the Room class
        public Room(string name)
        {
            Name = name;  // Assigns the provided 'name' parameter to the 'Name' property
        }
    }
}
