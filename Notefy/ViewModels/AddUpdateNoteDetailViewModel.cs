using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Notefy.Models;
using Notefy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Notefy.ViewModels
{
		[QueryProperty(nameof(NoteDetail), "NoteDetail")]
		public partial class AddUpdateNoteDetailViewModel : ObservableObject
	{
		[ObservableProperty]
		private NoteModel _noteDetail = new NoteModel(); 

		private readonly INoteService _noteService;
		public AddUpdateNoteDetailViewModel(INoteService noteService)
		{
			_noteService = noteService;
		}


		[ICommand]

		public async void AddUpdateNote()
		{
			int response = -1;
			if (NoteDetail.NoteID >0)
			{
				response = await _noteService.UpdateNote(NoteDetail);
			}
			else
			{
				response = await _noteService.AddNote(new Models.NoteModel
				{
					NoteHeading = NoteDetail.NoteHeading,
					NoteDescription = NoteDetail.NoteDescription,
					NoteScheduleDT = NoteDetail.NoteScheduleDT,
					
				}

					);
			}

			if (response >0)
			{
				await Shell.Current.DisplayAlert("Note details added!", "Note saved.", "Ok");
			}
			else
			{
                await Shell.Current.DisplayAlert("Note could not be added!", "Please check it out!", "Ok");
            }
        }
	}	
   
}

