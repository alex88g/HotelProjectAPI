using Microsoft.AspNetCore.Mvc;
using HotelProjectAPI.Data;
using HotelProjectAPI.Models;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class HotelController : ControllerBase
{
    private readonly Context _context;

    public HotelController(Context context)
    {
        _context = context;
    }

    // HTTP GET method to retrieve all hotels
    [HttpGet]
    public ActionResult<IEnumerable<Hotel>> GetHotels()
    {
        return _context.Hotels.ToList();
    }

    // HTTP POST method to create a new hotel
    [HttpPost]
    public ActionResult<Hotel> CreateHotel(string name)
    {
        var hotel = new Hotel(name);
        _context.Hotels.Add(hotel);
        _context.SaveChanges();
        return hotel;
    }

    // HTTP PUT method to update a hotel by ID
    [HttpPut("{hotelId}")]
    public IActionResult UpdateHotel(int hotelId, [FromBody] HotelUpdateModel hotelUpdateModel)
    {
        var hotel = _context.Hotels.Find(hotelId);
        if (hotel != null)
        {
            hotel.Name = hotelUpdateModel.Name;
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
            return Ok("Hotel updated successfully.");
        }
        else
        {
            return NotFound("Hotel not found.");
        }
    }

    // Model used for updating hotel name
    public class HotelUpdateModel
    {
        public string Name { get; set; }
    }

    // HTTP PATCH method to partially update a hotel by ID
    [HttpPatch("{hotelId}")]
    public IActionResult PartialUpdateHotel(int hotelId, [FromBody] string name)
    {
        var hotel = _context.Hotels.Find(hotelId);
        if (hotel != null)
        {
            hotel.Name = name;
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
            return Ok("Hotel partially updated successfully.");
        }
        else
        {
            return NotFound("Hotel not found.");
        }
    }

    // HTTP DELETE method to delete a hotel by ID
    [HttpDelete("{hotelId}")]
    public IActionResult DeleteHotel(int hotelId)
    {
        var hotel = _context.Hotels.Find(hotelId);
        if (hotel != null)
        {
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
            return Ok("Hotel deleted successfully.");
        }
        else
        {
            return NotFound("Hotel not found.");
        }
    }
}
