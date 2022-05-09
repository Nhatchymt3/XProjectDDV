using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Contract.Repository.Models
{
	public class TM_DD_MEMBER : Entity
	{
		public string Account { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Pw { get; set; }
		public int ? Permission { get; set; }
		public string ? CompanyName { get; set; }
		public int ? LimmitedDays { get; set; }

		public virtual ICollection<TD_SHARING_INFO> TD_SHARING_INFO { get; set; }

	}
}
