using CarRentalServiceAssignment.Models;
using CarRentalServiceAssignment.Repositories;
namespace CarRentalServiceAssignment.Services
{
    public class CarRentalService
    {
        private readonly CarRepository _carRepository;

        public CarRentalService(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<Car>> GetAvailableCars() => await _carRepository.GetAvailableCars();

        public async Task AddCar(Car car) => await _carRepository.AddCar(car);

        public async Task DeleteCar(int id) => await _carRepository.DeleteCar(id);

        public async Task UpdateCar(int id, Car car)
        {
          await _carRepository.UpdateCar(id,car);
           
        }
    }
}
