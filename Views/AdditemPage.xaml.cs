namespace MyHybridApp.Views;

public partial class AdditemPage : ContentPage
{

    string entereName;

	public AdditemPage()
	{
		InitializeComponent();
	}

    private void entry_Completed(object sender, EventArgs e)
    {
        entereName = ((Entry)sender).Text;
    }

    private void entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        entereName = ((Entry)sender).Text;
    }

    private async void Add_Button_Clicked(object sender, EventArgs e)
    {
        Models.Item newItem = new Models.Item(App.MainViewModel.Items.Count+1, entereName, "nounok.png");
        App.MainViewModel.AddItem(new ViewModels.ItemViewModel(newItem));
        await Navigation.PopAsync();

    }
}