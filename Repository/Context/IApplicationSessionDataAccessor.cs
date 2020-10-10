using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public interface IApplicationSessionDataAccessor
    {
        int GetLoginUserName();
    }
}
