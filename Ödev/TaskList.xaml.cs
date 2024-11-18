using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace Ödev
{
    public partial class TaskList : ContentPage
    {
        
        public ObservableCollection<Gorev> Gorevler { get; set; }

        public TaskList()
        {
            InitializeComponent();
            Gorevler = new ObservableCollection<Gorev>();
            GorevlerCollectionView.ItemsSource = Gorevler;
        }

        
        private void GorevEkleClicked(object sender, EventArgs e)
        {
            GorevEkleKutu.IsVisible = true;
        }

        
        private void GorevKaydet(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(YeniGorevEntry.Text))
            {
                
                Gorevler.Add(new Gorev { GorevAdı = YeniGorevEntry.Text, Tamamlandi = false });
                YeniGorevEntry.Text = string.Empty;  
                GorevEkleKutu.IsVisible = false;  
            }
        }

        
        private async void GorevSil(object sender, EventArgs e)
        {
            var gorev = (Gorev)((Button)sender).CommandParameter;
            bool sil = await DisplayAlert("Sil", $"'{gorev.GorevAdı}' görevini silmek istediğinize emin misiniz?", "Evet", "Hayır");

            if (sil)
            {
                Gorevler.Remove(gorev); 
            }
        }

        private async void GorevDuzenle(object sender, EventArgs e)
        {
            var gorev = (Gorev)((Button)sender).CommandParameter;
            var yeniGorevAdı = await DisplayPromptAsync("Görev Düzenle", "Görevi Düzenle",
                                                        initialValue: gorev.GorevAdı);

            if (!string.IsNullOrWhiteSpace(yeniGorevAdı))
            {
                gorev.GorevAdı = yeniGorevAdı;  
            }
        }

       
        public class Gorev : INotifyPropertyChanged
        {
            private string _gorevAdı;

            public string GorevAdı
            {
                get => _gorevAdı;
                set
                {
                    if (_gorevAdı != value)
                    {
                        _gorevAdı = value;
                        OnPropertyChanged(nameof(GorevAdı)); 
                    }
                }
            }

            public bool Tamamlandi { get; set; }

            
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

