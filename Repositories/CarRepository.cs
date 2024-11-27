using CarRentalServiceAssignment.Data;
using CarRentalServiceAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CarRentalServiceAssignment.Repositories
{
    public class CarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCar(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetCarById(int id) =>
            await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<List<Car>> GetAvailableCars() =>
            await _context.Cars.Where(c => c.IsAvailable).ToListAsync();

        public async Task UpdateCar(int id, Car car)
        {
            if (car == null || car.Id != id)
                throw new ArgumentException("Invalid car object or ID mismatch.");

            var existingCar = await GetCarById(id);
            if (existingCar != null)
            {
                _context.Entry(existingCar).CurrentValues.SetValues(car);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Car not found.");
            }
        }

        public async Task DeleteCar(int id)
        {
            var car = await GetCarById(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }
    }
}
