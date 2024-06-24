using Notefy.Views;
namespace Notefy;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddUpdateNoteDetail), typeof(AddUpdateNoteDetail));
	}
}

