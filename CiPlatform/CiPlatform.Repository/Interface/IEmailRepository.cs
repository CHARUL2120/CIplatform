using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiPlatform.Repository.Interface
{
    public interface IEmailRepository
    {
        public void SendEmail(string recipient, string subject, string body);

    }
}
