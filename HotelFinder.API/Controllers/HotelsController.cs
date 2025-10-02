using Domain.Entities;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HotelController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("CreateHotel")]
    public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDTO dto)
    {
        var hotel = new Hotel
        {
            Name = dto.Name,
            City = dto.City,
            Country = dto.Country
        };
        var result = await _hotelService.CreateHotel(hotel);
        return Ok(new HotelResponseDTO { Id = result.Id, Name = result.Name, City = result.City, Country = result.Country });
    }

    [HttpGet("GetALlHotels")]
    public async Task<IActionResult> GetHotels()
    {
        var hotels = await _hotelService.GetHotels();
        var response = hotels.Select(h => new HotelResponseDTO { Id = h.Id, Name = h.Name, City = h.City, Country = h.Country }).ToList();
        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("HotelById/{id}")]
    public async Task<IActionResult> GetHotelById(int id)
    {
        var hotel = await _hotelService.GetHotelById(id);
        if (hotel == null) return NotFound();
        return Ok(new HotelResponseDTO
        {
            Id = hotel.Id,
            Name = hotel.Name,
            City = hotel.City,
            Country = hotel.Country
        });
    }

    // GET hotel by Name
    [HttpGet("GetHotelByName/{name}")]
    public async Task<IActionResult> GetHotelByName(string name)
    {
        var hotel = await _hotelService.GetHotelByName(name);
        if (hotel == null) return NotFound();
        return Ok(new HotelResponseDTO
        {
            Id = hotel.Id,
            Name = hotel.Name,
            City = hotel.City,
            Country = hotel.Country
        });
    }

    // GET hotel by City
    [HttpGet("GetHotelbyCity/{city}")]
    public async Task<IActionResult> GetHotelByCity(string city)
    {
        var hotel = await _hotelService.GetHotelByCity(city);
        if (hotel == null || !hotel.Any())
            return NotFound();
        var response = hotel.Select(hotel => new HotelResponseDTO
        {
            Id = hotel.Id,
            Name = hotel.Name,
            City = hotel.City,
            Country = hotel.Country
        }).ToList();
        return Ok(response);
    }

    // GET hotel by Country
    [HttpGet("GetHotelbyCountry/{country}")]
    public async Task<IActionResult> GetHotelByCountry(string country)
    {
        var hotel = await _hotelService.GetHotelByCountry(country);
        if (hotel == null || !hotel.Any())
            return NotFound();
        var response = hotel.Select(hotel => new HotelResponseDTO
        {
            Id = hotel.Id,
            Name = hotel.Name,
            City = hotel.City,
            Country = hotel.Country
        }).ToList();
        return Ok(response);    
    }

    // UPDATE hotel Name
    [Authorize(Roles = "Admin")]
    [HttpPatch("{id}/UpdateHotelsName")]
    public async Task<IActionResult> UpdateHotelName(int id, [FromBody] string name)
    {
        var updated = await _hotelService.UpdateHotelName(id, name);
        if (updated == null) return NotFound();
        return Ok(new HotelResponseDTO
        {
            Id = updated.Id,
            Name = updated.Name,
            City = updated.City,
            Country = updated.Country
        });
    }

    // UPDATE hotel City
    [Authorize(Roles = "Admin")]
    [HttpPatch("{id}/UpdateHotelsCity")]
    public async Task<IActionResult> UpdateHotelCity(int id, [FromBody] string city)
    {
        var updated = await _hotelService.UpdateHotelCity(id, city);
        if (updated == null) return NotFound();
        return Ok(new HotelResponseDTO
        {
            Id = updated.Id,
            Name = updated.Name,
            City = updated.City,
            Country = updated.Country
        });
    }

    // UPDATE hotel Country
    [Authorize(Roles = "Admin")]
    [HttpPatch("{id}/UpdateHotelsCountry")]
    public async Task<IActionResult> UpdateHotelCountry(int id, [FromBody] string country)
    {
        var updated = await _hotelService.UpdateHotelCountry(id, country);
        if (updated == null) return NotFound();
        return Ok(new HotelResponseDTO
        {
            Id = updated.Id,
            Name = updated.Name,
            City = updated.City,
            Country = updated.Country
        });
    }

    // DELETE hotel
    [Authorize(Roles = "Admin")]
    [HttpDelete("DeleteHotel/{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        await _hotelService.DeleteHotel(id);
        return NoContent();
    }
}

