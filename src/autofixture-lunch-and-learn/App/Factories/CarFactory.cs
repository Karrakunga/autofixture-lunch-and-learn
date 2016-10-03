using Domain;

namespace App.Factories
{
    public interface ICarFactory
    {
        Car Produce();
    }

    public class CarFactory
    {
        public Car Produce()
        {
            return new Car();
        }
    }
}
