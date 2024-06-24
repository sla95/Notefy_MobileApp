using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notefy.Models;

namespace Notefy.Services
{
	public class NoteService : INoteService
    {
        private SQLite.SQLiteAsyncConnection _dbConn;

        public NoteService()
		{
            SetUpDb();          
		}
        private async void SetUpDb()
        {
            if (_dbConn == null)
            {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Note.db3");
                _dbConn = new SQLite.SQLiteAsyncConnection(dbPath);
                await _dbConn.CreateTableAsync<NoteModel>();
             }
        }

        public Task<int> AddNote(NoteModel noteModel)
        {
            return _dbConn.InsertAsync(noteModel);
        }

        public Task<int> DeleteNote(NoteModel noteModel)
        {
            return _dbConn.DeleteAsync(noteModel);
        }

        public async Task<List<NoteModel>> GetNoteList()
        {
            var noteList = await _dbConn.Table<NoteModel>().ToListAsync();
            return noteList;
        }

        public Task<int> UpdateNote(NoteModel noteModel)
        {
            return _dbConn.UpdateAsync(noteModel);
        }
    }
}

