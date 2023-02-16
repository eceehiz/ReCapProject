using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }








            //Rental rental = new Rental { RentalId = 1, CarId = 1, CustomerId = 1, };
            //Rental rental2 = new Rental { RentalId = 2, CarId = 3, CustomerId = 3, ReturnDate = new System.DateTime(2023, 01, 25) };
            //Rental rental3 = new Rental { RentalId = 3, CarId = 2, CustomerId = 2, ReturnDate = new System.DateTime(2023, 01, 23) };

            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(rental);
            //rentalManager.Add(rental2);
            //rentalManager.Add(rental3);

            //var result = rentalManager.GetAll();

            //if (result.Success == true)
            //    foreach (var cu in result.Data)
            //    {
            //        Console.WriteLine(cu.RentalId + " Customer= " + cu.CustomerId + " CarId=" + cu.CarId);
            //    }
            //else
            //    Console.WriteLine(result.Message);

        }

    }
}
