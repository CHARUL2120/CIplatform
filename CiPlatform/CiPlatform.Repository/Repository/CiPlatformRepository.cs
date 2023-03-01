using CiPlatform.Repository.Interface;
using CiPlatform.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiPlatform.Entities.Models;


namespace CiPlatform.Repository.Repository
{
    public class CiPlatformRepository: ICiPlatformRepository
    {
        private readonly CiplatformContext _ciplatformContext;

        object ICiPlatformRepository.Users => throw new NotImplementedException();

        public CiPlatformRepository(CiplatformContext ciplatformContext)
        {
            _ciplatformContext = ciplatformContext;
        }
        public void RegisterUser(User user)
        {
            var data = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Password = user.Password,
                CityId = 2,
                CountryId = 1,
            };

            _ciplatformContext.Users.Add(data);
            _ciplatformContext.SaveChanges();
        }
        public int GetUserEmail(User email)
        {
            var UsersList = _ciplatformContext.Users.Where(X => X.Email == email.Email && X.Password == email.Password).FirstOrDefault();
            if (UsersList != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
