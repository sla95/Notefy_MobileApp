using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notefy.Models
{
	public class NoteModel
	{
		[PrimaryKey, AutoIncrement]
		public int NoteID { get; set; }
		public string NoteHeading { get; set; }
		public string NoteDescription { get; set; }
		public DateTime NoteCreatedDT { get; set; }
		public DateTime NoteScheduleDT { get; set; }

		
        public NoteModel()
		{
			
		}
	}
}

