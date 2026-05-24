using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sealHkthon.Services.MinhMN
{
    public interface ISystemUserAccountService
    {
        Task<Entities.MinhMN.Models.SystemUserAccount> GetUserAccountAsync(string userName, string password);
    }
}
