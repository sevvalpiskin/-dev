using System;
using System.Collections.ObjectModel;

namespace Ödev;

public partial class KrediHesapla : ContentPage
{
    public ObservableCollection<string> LoanTerms { get; set; }
    public ObservableCollection<string> KrediTürleri { get; set; }

    public KrediHesapla()
    {
        InitializeComponent();

       
        LoanTerms = new ObservableCollection<string>
        {
            "6 Ay", "12 Ay", "18 Ay", "24 Ay", "36 Ay", "48 Ay", "60 Ay", "72 Ay"
        };

        
        KrediTürleri = new ObservableCollection<string>
        {
            "İhtiyaç Kredisi", "Konut Kredisi", "Taşıt Kredisi", "Ticari Kredi"
        };

        BindingContext = this; 
    }

    
    private void OnCalculateClicked(object sender, EventArgs e)
    {
        try
        {
         
            double krediTutarı = double.Parse(LoanAmountEntry.Text);
            double faizOranı = double.Parse(InterestRateEntry.Text) / 100;

            
            string selectedTerm = LoanTermPicker.SelectedItem.ToString();
            int vadeSüresi = int.Parse(selectedTerm.Split(' ')[0]); 

            
            double kdv = 0, bsmv = 0;

           
            string selectedKrediTürü = KrediTürüPicker.SelectedItem.ToString();
            if (selectedKrediTürü == "İhtiyaç Kredisi")
            {
                kdv = 0.15;
                bsmv = 0.10;
            }
            else if (selectedKrediTürü == "Konut Kredisi")
            {
                kdv = 0;
                bsmv = 0;
            }
            else if (selectedKrediTürü == "Taşıt Kredisi")
            {
                kdv = 0.15;
                bsmv = 0.05;
            }
            else if (selectedKrediTürü == "Ticari Kredi")
            {
                kdv = 0;
                bsmv = 0.05;
            }

          
            double brutFaiz = ((faizOranı + (faizOranı * bsmv) + (faizOranı * kdv)) / 100);
            double taksit = ((Math.Pow(1 + brutFaiz, vadeSüresi) * brutFaiz) / (Math.Pow(1 + brutFaiz, vadeSüresi) - 1)) * krediTutarı;
            double toplamÖdeme = taksit * vadeSüresi;
            double toplamFaiz = toplamÖdeme - krediTutarı;

            
            MonthlyPaymentLabel.Text = $"{taksit:F2} TL";
            TotalPaymentLabel.Text = $"{toplamÖdeme:F2} TL";
            TotalInterestLabel.Text = $"{toplamFaiz:F2} TL";
        }
        catch (Exception)
        {
            DisplayAlert("Hata","doğru doldurunuz", "Tamam");
        }
    }
}
