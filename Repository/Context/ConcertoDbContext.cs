using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.DBConstraint;
using Model.DTO;
using Model.DTO.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class ConcertoDbContext : DbContext
    {
		public ConcertoDbContext(DbContextOptions<ConcertoDbContext> options) : base(options)
		{
		}
		public DbSet<AdminDTO> adminDTOs{ get; set; }
		public DbSet<ConcertDTO> concertDTOs{ get; set; }
		public DbSet<ConcertMerchandiseDTO> concertMerchandiseDTOs{ get; set; }
		public DbSet<ConcertStatisticDTO> concertStatisticDTOs{ get; set; }
		public DbSet<RoleDTO> roleDTOs{ get; set; }
		public DbSet<SessionDTO> sessionDTOs{ get; set; }
		public DbSet<TicketDTO> ticketDTOs{ get; set; }
		public DbSet<UserDTO> userDTOs{ get; set; }
		

		public override int SaveChanges()
		{
			OnBeforeSave();
			return base.SaveChanges();
		}

		public int SaveDeletion()
		{
			OnBeforeDelete();
			return base.SaveChanges();
		}

		public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
		{
			Entry(entity).State = EntityState.Deleted;
			return base.Update(entity);
		}

		private void OnBeforeSave()
		{
			IEnumerable<EntityEntry> entries = ChangeTracker.Entries();
			foreach (var entry in entries)
			{
				if (entry.Entity is BaseModel model)
				{
					switch (entry.State)
					{
						case EntityState.Added:
							model.SetUserIn("SuperAdmin");
							model.SetDateIn(DateTime.Now);
							model.SetUserUp(null);
							model.SetDateUp(null);
							model.SetStr(BaseConstraint.StrSC.Active);
							break;
						case EntityState.Modified:
							model.SetUserUp("SuperAdmin");
							model.SetDateUp(DateTime.Now);
							model.SetStr(BaseConstraint.StrSC.Active);
							break;
						case EntityState.Deleted:
							model.SetUserUp("SuperAdmin");
							model.SetDateUp(DateTime.Now);
							model.SetStr(BaseConstraint.StrSC.Active);
							break;
					}
				}
			}
		}

		private void OnBeforeDelete()
		{
			IEnumerable<EntityEntry> entries = ChangeTracker.Entries();
			foreach (var entry in entries)
			{
				if (entry.Entity is BaseModel model)
				{
					model.SetUserUp("SuperAdmin");
					model.SetDateUp(DateTime.Now);
					model.SetStr(BaseConstraint.StrSC.Deactive);
				}
			}
		}
	}
}
