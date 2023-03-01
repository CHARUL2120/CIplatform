using CiPlatform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiPlatform.Repository.Interface
{
    public interface ICiPlatformRepository
    {
        object Users { get; }

        void RegisterUser(User user);

        public int GetUserEmail(User email);
    }
}
