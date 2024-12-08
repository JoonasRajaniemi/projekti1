namespace MyHybridApp.Views;

public partial class ItemsListPage : ContentPage
{
	public ItemsListPage()
	{
		InitializeComponent();
	}

	private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		await Navigation.PushAsync(new Views.itemDetailPage());
	}

    private void MenuItem_Clicked(object sender, EventArgs e)
	{
        MenuItem menuItem = (MenuItem)sender;
		ViewModels.ItemViewModel items = (ViewModels.ItemViewModel)menuItem.BindingContext;
        App.MainViewModel.DeleteItem(items);
	}

	private async void Add_Button_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Views.AdditemPage());

    }

    private async void Save_Button_Clicked(object sender, EventArgs e)
    {
		await App.MainViewModel.SaveItems();
    }

    private async void Info_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Info());
    }
}