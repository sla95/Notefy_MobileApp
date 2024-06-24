using Notefy.ViewModels;

namespace Notefy.Views;

public partial class ShoppingListPage : ContentPage
{
	public ShoppingListPage(ShoppingListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
