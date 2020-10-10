using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Base
{
    public interface IUnitOfWorkRepository
    {
        void UseContext(DbContext context);
        void RevertToPreviousDbContext();
    }
}
