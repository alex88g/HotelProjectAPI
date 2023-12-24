using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HotelProjectAPI.Data;
using HotelProjectAPI.Models;

[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly Context _context;

    public RoomController(Context context)
    {
        _context = context;
    }

    // HTTP GET method to retrieve all rooms
    [HttpGet]
    public ActionResult<IEnumerable<Room>> GetRooms()
    {
        return _context.Rooms.ToList();
    }

    // HTTP POST method to create a new room
    [HttpPost]
    public ActionResult<Room> CreateRoom(string name)
    {
        var room = new Room(name);
        _context.Rooms.Add(room);
        _context.SaveChanges();
        return room;
    }

    // HTTP PUT method to update a room by ID
    [HttpPut("{roomId}")]
    public IActionResult UpdateRoom(int roomId, [FromBody] RoomUpdateModel roomUpdateModel)
    {
        var room = _context.Rooms.Find(roomId);
        if (room != null)
        {
            room.Name = roomUpdateModel.NewName;
            _context.Rooms.Update(room);
            _context.SaveChanges();
            return Ok("Room updated successfully.");
        }
        else
        {
            return NotFound("Room not found.");
        }
    }

    // Model used for updating room name
    public class RoomUpdateModel
    {
        public string NewName { get; set; }
    }

    // HTTP PATCH method to partially update a room by ID
    [HttpPatch("{roomId}")]
    public IActionResult PartialUpdateRoom(int roomId, [FromBody] string name)
    {
        var room = _context.Rooms.Find(roomId);
        if (room != null)
        {
            room.Name = name;
            _context.Rooms.Update(room);
            _context.SaveChanges();
            return Ok("Room partially updated successfully.");
        }
        else
        {
            return NotFound("Room not found.");
        }
    }

    // HTTP DELETE method to delete a room by ID
    [HttpDelete("{roomId}")]
    public IActionResult DeleteRoom(int roomId)
    {
        var room = _context.Rooms.Find(roomId);
        if (room != null)
        {
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return Ok("Room deleted successfully.");
        }
        else
        {
            return NotFound("Room not found.");
        }
    }
}
