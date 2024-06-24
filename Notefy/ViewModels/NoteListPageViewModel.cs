using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Notefy.Models;
using Notefy.Services;
using Notefy.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notefy.ViewModels
{
    public partial class NoteListPageViewModel : ObservableObject

    {
        public ObservableCollection<NoteModel> Note { get; set; } = new ObservableCollection<NoteModel>();

        private readonly INoteService _noteService;

        public NoteListPageViewModel(INoteService noteService)
        {
            _noteService = noteService;
        }

        [ICommand]

        private async void GetNoteList()
        {
            var noteList = await _noteService.GetNoteList();
            if (noteList?.Count >0 )
            {
                Note.Clear();
                foreach(var note in noteList)
                {
                    Note.Add(note);
                }
            }
        }

        [ICommand]
        public async void AddUpdateNote()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateNoteDetail));
        }

        [ICommand]
        public async void DisplayAction(NoteModel noteModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("NoteDetail", noteModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateNoteDetail), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _noteService.DeleteNote(noteModel);
                if (delResponse >0)
                {
                    GetNoteList();
                }

            }
        }

    }

}
