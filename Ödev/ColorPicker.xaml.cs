using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace Ödev;

public partial class ColorPicker : ContentPage
{
    public ColorPicker()
    {
        InitializeComponent();
    }

    
    private void OnColorChanged(object sender, ValueChangedEventArgs e)
    {
        
        int red = (int)RedSlider.Value;
        int green = (int)GreenSlider.Value;
        int blue = (int)BlueSlider.Value;

        
        Color color = Color.FromRgb(red, green, blue);
        ColorPreview.Color = color;

        ColorCodeLabel.Text = $"#{red:X2}{green:X2}{blue:X2}";
    }

    
    private async void OnCopyColorCodeClicked(object sender, EventArgs e)
    {
        string colorCode = ColorCodeLabel.Text;

        
        await Clipboard.SetTextAsync(colorCode);
        await DisplayAlert("Başarılı", "Renk kodu kopyalandı!", "Tamam");
    }

    
    private void OnRandomColorClicked(object sender, EventArgs e)
    {
        
        Random random = new Random();
        int red = random.Next(0, 256);
        int green = random.Next(0, 256);
        int blue = random.Next(0, 256);

        
        RedSlider.Value = red;
        GreenSlider.Value = green;
        BlueSlider.Value = blue;

        
        Color color = Color.FromRgb(red, green, blue);
        ColorPreview.Color = color;

        
        ColorCodeLabel.Text = $"#{red:X2}{green:X2}{blue:X2}";
    }
}
