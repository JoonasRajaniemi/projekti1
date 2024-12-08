namespace MyHybridApp
{
    public partial class App : Application
    {
        public static ViewModels.ItemListViewModel MainViewModel { get; private set; } 
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            MainViewModel = new();
            MainViewModel.RefreshItem();
        }
    }
}
