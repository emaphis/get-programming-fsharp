// Lesson 27  - Exposing F# Types and Functions to C#


using Model;

namespace CSharpApp
{
   class Program
    {
        static void Main(string[] args)
        {
            var car = new Car(4, "Supacars", Tuple.Create(1.5, 3.5));
            var wheels = car.Wheels;
            Console.WriteLine(wheels);
            var brand = car.Brand;
            Console.WriteLine(brand);

            var bike = Vehicle.NewMotorbike("MyBike", 3.5);
            var motorcar = Vehicle.NewMotorcar(car);

            var somewheeledCar = Functions.CreateCar(4, "Supacars", 1.5, 3.5);
            var fourWheeledCar = Functions.CreateFourWheeledCar
                                          .Invoke("Supacars")
                                          .Invoke(1.5)
                                          .Invoke(3.5);
        }
    }
}