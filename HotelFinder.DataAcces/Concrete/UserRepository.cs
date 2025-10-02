using HotelFinder.DataAcces.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces.Concrete
{
    public class UserRepository : IUsersRepository
    {
        private readonly dbContext _context;

        public UserRepository(dbContext context)
        {
            _context = context;
        }

        public async Task<Register> AddNewUser(Register user)
        {
            _context.Registers.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<Register>> GetUsers()
        {
            return await _context.Registers.ToListAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Registers.FindAsync(id);
            if (user != null)
            {
                _context.Registers.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
