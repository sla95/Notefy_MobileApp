namespace Notefy.Views;

public partial class AddUpdateNoteDetail : ContentPage
{
	public AddUpdateNoteDetail(ViewModels.AddUpdateNoteDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
    }
}
