using Domain.Entities;
using HotelFinder.DataAcces;
using HotelFinder.DataAcces.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelFinder.DataAcces.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        private readonly dbContext _context;

        public HotelRepository(dbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task DeleteHotel(int id)
        {
            var deleteHotel = await GetHotelById(id);
            if (deleteHotel != null)
            {
                _context.Hotels.Remove(deleteHotel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            return await _context.Hotels
                .FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> UpdateHotelName(int id, string name)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                hotel.Name = name;
                await _context.SaveChangesAsync();
            }
            return hotel;
        }

        public async Task<Hotel> UpdateHotelCity(int id, string city)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                hotel.City = city;
                await _context.SaveChangesAsync();
            }
            return hotel;
        }

        public async Task<Hotel> UpdateHotelCountry(int id, string country)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                hotel.Country = country;
                await _context.SaveChangesAsync();
            }
            return hotel;
        }

        public async Task<List<Hotel>> GetHotelByCity(string city)
        {
            return await _context.Hotels
                .Where(x => x.City.ToLower() == city.ToLower())
                .ToListAsync();
        }


        public async Task<List<Hotel>> GetHotelByCountry(string country)
        {
            return await _context.Hotels
                .Where(x => x.Country.ToLower() == country.ToLower())
                .ToListAsync();
        }
    }

}