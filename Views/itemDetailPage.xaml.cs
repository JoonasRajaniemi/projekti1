namespace MyHybridApp.Views;

public partial class itemDetailPage : ContentPage
{
	public itemDetailPage()
	{
		InitializeComponent();

		BindingContext = App.MainViewModel.SelectedItem;
	}
}