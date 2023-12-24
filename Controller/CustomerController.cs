using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HotelProjectAPI.Data;
using HotelProjectAPI.Models;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly Context _context;

    public CustomerController(Context context)
    {
        _context = context;
    }

    // HTTP GET Method to fetch all customers
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        return _context.Customers.ToList();
    }

    // HTTP POST Method to create a new customer
    [HttpPost]
    public ActionResult<Customer> CreateCustomer(string name) 
    {
        try
        {
            // Find an available room without any customers
            var availableRoom = _context.Rooms.FirstOrDefault(room => room.Customer.Count == 0);
            if (availableRoom == null)
            {
                return BadRequest("No available rooms."); // No rooms available
            }

            // Create a new customer and associate them with the available room
            var customer = new Customer(name);
            customer.Rooms.Add(availableRoom);
            availableRoom.Customer.Add(customer);

            // Update entities in the database
            _context.Rooms.Update(availableRoom);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Ok("Customer created successfully"); // Return success message
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}"); // Handle exceptions
        }
    }

    // HTTP PUT Method to update customer's name by ID
    [HttpPut("{customerId}")]
    public IActionResult UpdateCustomer(int customerId, [FromBody] string Name)
    {
        var customer = _context.Customers.Find(customerId);
        if (customer != null)
        {
            customer.Name = Name;
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return Ok("Customer updated successfully."); // Return success message
        }
        else
        {
            return NotFound("Customer not found."); // Customer not found
        }
    }

    // HTTP PATCH Method to partially update customer's name by ID
    [HttpPatch("{customerId}")]
    public IActionResult PartialUpdateCustomer(int customerId, [FromBody] string name)
    {
        var customer = _context.Customers.Find(customerId);
        if (customer != null)
        {
            customer.Name = name;
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return Ok("Customer partially updated successfully."); // Return success message
        }
        else
        {
            return NotFound("Customer not found."); // Customer not found
        }
    }

    // HTTP DELETE Method to delete a customer by ID
    [HttpDelete("{customerId}")]
    public IActionResult DeleteCustomer(int customerId)
    {
        var customer = _context.Customers.Find(customerId);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok("Customer deleted successfully."); // Return success message
        }
        else
        {
            return NotFound("Customer not found."); // Customer not found
        }
    }
}
