using Notefy.ViewModels;

namespace Notefy.Views;

public partial class NoteListPage : ContentPage
{
    private NoteListPageViewModel _viewMode;
    public NoteListPage(NoteListPageViewModel viewModel)
	{
		InitializeComponent();
        _viewMode = viewModel;

		this.BindingContext = viewModel;

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetNoteListCommand.Execute(null);
    }


}
