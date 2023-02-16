using Core.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars
                             on re.CarId equals ca.CarId

                             join cu in context.Customers
                             on re.CustomerId equals cu.UserId

                             join us in context.Users
                             on re.CustomerId equals us.UserId

                             join br in context.Brands
                             on ca.BrandId equals br.BrandId

                             join co in context.Colors
                             on ca.ColorId equals co.ColorId

                             select new RentalDetailDto { CustomerFirstName = us.FirstName, 
                                 CustomerLastName = us.LastName, Description = ca.Description, ModelYear = ca.ModelYear.ToString(), 
                                 RentDate = re.RentDate, ReturnDate = re.ReturnDate, CarBrandName = br.BrandName, CarColorName = co.ColorName };
                return result.ToList();
            }
        }
    }
}
