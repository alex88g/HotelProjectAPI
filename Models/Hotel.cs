namespace HotelProjectAPI.Models 
{
    public class Hotel
    {
        // Properties of the Hotel class
        public int Id { get; set; }     // Represents the unique identifier for a hotel
        public string Name { get; set; }  // Represents the name of the hotel

        // Represents a collection of rooms associated with the hotel
        public ICollection<Room> Rooms { get; set; } = new List<Room>();

        // Constructor for the Hotel class
        public Hotel(string name)
        {
            Name = name;  // Assigns the provided 'name' parameter to the 'Name' property
        }
    }
}
