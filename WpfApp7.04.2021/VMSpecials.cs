using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp7._04._2021
{
    internal class VMSpecials : INotifyPropertyChanged
    {
        Entities студентыEntities;
        private Special selectedSpecials;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Special> Specials { get; set; }

        public Special SelectedSpecial
        {
            get => selectedSpecials;
            set { selectedSpecials = value; SignalChanged(); }
        }


        public CustomCommand AddSpecials { get; set; }
        public CustomCommand SaveSpecials { get; set; }


        public VMSpecials()
        {
            студентыEntities = DB.GetDB();
            LoadSpecials();
            AddSpecials = new CustomCommand(() =>
            {
                SelectedSpecial = new Special { Title = "Название" };
                студентыEntities.Specials.Add(new Special { Title = "название" });
                LoadSpecials();
            });
            SaveSpecials = new CustomCommand(() => //студентыEntities.SaveChanges());
            {
                try
                {
                    студентыEntities.SaveChanges();
                    LoadSpecials();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });
        }
        private void LoadSpecials()
        {
            Specials = new ObservableCollection<Special>(студентыEntities.Specials);
            SignalChanged("Specials");
        }
        void SignalChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}