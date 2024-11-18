using Microsoft.Maui;

namespace Ödev;

public partial class VKI: ContentPage
{
    public VKI()
    {
        InitializeComponent();
    }

    private void VkiHesapla(object sender, EventArgs e)
    {
        if (double.TryParse(KiloGirdisi.Text, out double kilo) && double.TryParse(BoyGirdisi.Text, out double boy))
        {
            boy = boy / 100;

           
            double vki = kilo / (boy * boy);
            VkiLabel.Text = vki.ToString("F2"); 

            string cinsiyet = CinsiyetErkek.IsChecked ? "Erkek" : (CinsiyetKadin.IsChecked ? "Kadın" : "Seçilmeyen");

            
            string vkiKategorisi = VkiKategorisiniGetir(vki);

          
            KategoriLabel.Text = $"Kategoriniz: {vkiKategorisi} ({cinsiyet})";
        }
        else
        {
           
            VkiLabel.Text = "Hatalı Giriş!";
            KategoriLabel.Text = "Lütfen geçerli bir kilo ve boy giriniz.";
        }
    }

    private string VkiKategorisiniGetir(double vki)
    {
        
        if (vki < 16)
            return "İleri düzeyde zayıf";
        else if (vki >= 16 && vki < 16.99)
            return "Orta düzeyde zayıf";
        else if (vki >= 17 && vki < 18.49)
            return "Hafif düzeyde zayıf";
        else if (vki >= 18.50 && vki < 24.99)
            return "Normal kilolu";
        else if (vki >= 25 && vki < 29.99)
            return "Hafif şişman, fazla kilolu";
        else if (vki >= 30 && vki < 34.99)
            return "1. derece obez";
        else if (vki >= 35 && vki < 39.99)
            return "2. derece obez";
        else
            return "3. derece obez";
    }
}
