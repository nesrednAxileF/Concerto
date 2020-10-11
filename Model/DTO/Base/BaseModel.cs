using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.DTO.Base
{
	public class BaseModel
	{
		[Column("Id")]
		public int ID { get; set; }
		[Column("UserIn")]
		public string UserIn { get; private set; }
		[Column("DateIn")]
		public DateTime DateIn { get; private set; }
		[Column("UserUp")]
		public string UserUp { get; private set; }
		[Column("DateUp")]
		public DateTime? DateUp { get; private set; }
		[Column("StrSc")]
		public char StrSc { get; private set; }

		public void SetDateIn(DateTime DateIn)
		{
			this.DateIn = DateIn;
		}

		public void SetStr(char StrSc)
		{
			this.StrSc = StrSc;
		}
		public void SetUserIn(string UserIn)
		{
			this.UserIn = UserIn;
		}
		public void SetDateUp(DateTime? DateUp)
		{
			this.DateUp = DateUp;
		}
		public void SetUserUp(string UserUp)
		{
			this.UserUp = UserUp;
		}
	}
}
