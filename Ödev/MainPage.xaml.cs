using System.Diagnostics;

namespace Ödev;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnNavigateToVKI(object sender, EventArgs e) 
    {
        await Navigation.PushAsync(new VKI()); 
    }

    private async void OnNavigateToLoanCalculator(object sender, EventArgs e) 
    {
        await Navigation.PushAsync(new KrediHesapla()); 
    }

    private async void OnNavigateToColorPicker(object sender, EventArgs e) 
    {
        await Navigation.PushAsync(new ColorPicker()); 
    }

    private async void OnNavigateToTaskList(object sender, EventArgs e) 
    {
        await Navigation.PushAsync(new TaskList()); 
    }
}
