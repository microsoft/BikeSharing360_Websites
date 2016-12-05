using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharing_Private_Web_Site.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
