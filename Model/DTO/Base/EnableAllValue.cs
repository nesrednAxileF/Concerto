using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTO.Base
{
    public interface EnableAllValue<TEntity> where TEntity : BaseModel
    {
        TEntity GetAllValuedEntity();
    }
}
