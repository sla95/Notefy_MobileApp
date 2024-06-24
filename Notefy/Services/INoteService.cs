using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notefy.Models;

namespace Notefy.Services
{
	public interface INoteService
	{
		Task<List<NoteModel>> GetNoteList();
		Task<int> AddNote(NoteModel noteModel);
		Task<int> DeleteNote(NoteModel noteModel);
		Task<int> UpdateNote(NoteModel noteModel);
	}
}

