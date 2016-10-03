using App.Factories;
using Domain;

namespace App
{
    public class CarCreator
    {
        private readonly ICarFactory _carFactory;

        public CarCreator(ICarFactory carFactory)
        {
            _carFactory = carFactory;
        }

        public Car Create()
        {
            return _carFactory.Produce();
        }
    }
}
