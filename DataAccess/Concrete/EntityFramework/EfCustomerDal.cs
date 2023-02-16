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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cu in context.Customers
                             join us in context.Users
                             on cu.UserId equals us.UserId
                             select new CustomerDetailDto { CustomerFirstName = us.FirstName, 
                                 CustomerLastName = us.LastName, CustomerEmail = us.Email, CompanyName = cu.CompanyName };

                return result.ToList();
            }
        }
    }
}
