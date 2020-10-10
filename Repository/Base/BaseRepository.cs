﻿using Microsoft.EntityFrameworkCore;
using Model.DTO.Base;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Model.DBConstraint.BaseConstraint;

namespace Repository.Base
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected ConcertoDbContext Context;
        private ConcertoDbContext PrevDbContext;

        // For EntityFrameworkCore, extend from this ctor
        public BaseRepository(IDbContextFactory dbContextFactory)
        {
            Context = (ConcertoDbContext)dbContextFactory.GetContext();
        }

        public void UseContext(DbContext context)
        {
            PrevDbContext = this.Context;
            this.Context = (ConcertoDbContext)context;
        }

        public void RevertToPreviousDbContext()
        {
            this.Context = PrevDbContext;
            PrevDbContext = null;
        }
       
        public IEnumerable<TEntity> FindAll()
        {
            IEnumerable<TEntity> entities = Context.Set<TEntity>().Where(x => !x.StrSc.Equals(StrSC.Deactive));
            return entities;
        }
        //public TEntity Find(int ID,string ColoumnIDName)
        // {
        //    if (ID == -1 && typeof(EnableAllValue<TEntity>).IsAssignableFrom(typeof(TEntity)))
        //    {
        //        var entityType = typeof(TEntity);
        //        EnableAllValue<TEntity> allValuedEntity = (EnableAllValue<TEntity>)Activator.CreateInstance(entityType);
        //        return allValuedEntity.GetAllValuedEntity();
        //    }
        //    return Context.Set<TEntity>()
        //        .Where(x => x.ID.Equals(ID))
        //        .Where(x => !x.StrSc.Equals(StrSC.Deactive))
        //        .FirstOrDefault();
        //}

        public TEntity Insert(TEntity entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
            Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public IEnumerable<TEntity> InsertMultiple(List<TEntity> entities)
        {
            for (int i = 0; i < entities.Count; i++)
                Context.Add(entities[i]);
            Context.SaveChanges();
            //entities.ForEach(x => Context.Entry(x).State = EntityState.Detached);
            return entities;
        }
        public TEntity Update(TEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
            Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                Context.Remove(entity);
                Context.SaveDeletion();
            }
        }
        //public void DeleteMultiple(List<int> IDs)
        //{
        //    bool Recorded = false;
        //    IDs.ForEach(id =>
        //    {
        //        TEntity entity = this.Find(id);
        //        if (entity != null)
        //        {
        //            Context.Remove(entity);
        //            Recorded = true;
        //        }
        //    });
        //    if (Recorded)
        //        Context.SaveDeletion();
        //}

    }
}
