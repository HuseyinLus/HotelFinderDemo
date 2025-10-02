using Domain;
using HotelFinder.DataAcces.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces.Concrete
{
    public class LoginRepository : ILoginRepository
    {
        private readonly dbContext _context;

        public LoginRepository(dbContext context)
        {
            _context = context;
        }

        public async Task<Register> Login(string userName, string password)
        {
            var response = await _context.Registers
                .FirstOrDefaultAsync(x => x.Username == userName && x.Password == password);

            if (response?.Username != userName)
            {
                return null;
            }

            return response;
        }

        public async Task<Register> GetUserInfo(string userName)
        {
            var response = await _context.Registers
                .FirstOrDefaultAsync(x => x.Username == userName);

            if (response?.Username != userName)
            {
                return null;
            }

            return response;
        }
    }
}
