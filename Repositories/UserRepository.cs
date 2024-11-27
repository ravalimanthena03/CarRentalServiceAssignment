using CarRentalServiceAssignment.Data;
using CarRentalServiceAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace CarRentalServiceAssignment.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmail(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> GetUserById(int id) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
}
