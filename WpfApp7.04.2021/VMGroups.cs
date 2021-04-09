using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace WpfApp7._04._2021
{
    internal class VMGroups : INotifyPropertyChanged
    {
        Entities студентыEntities;
        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Special> Specials { get; set; }

        private Group selectedGroup;

        public Group SelectedGroup
        {
            get => selectedGroup;
            set {
                selectedGroup = value;
                SignalChanged();
            }
        }

        public CustomCommand AddGroups { get; set; }
        public CustomCommand SaveGroups { get; set; }

        public VMGroups()
        {
            студентыEntities = DB.GetDB();
            LoadGroups();
            Specials = new ObservableCollection<Special>(студентыEntities.Specials);

            AddGroups = new CustomCommand(() =>
            {
                var group = new Group { Number = "Номер группы" };
                студентыEntities.Groups.Add(group);
                SelectedGroup = group;
            });

            SaveGroups = new CustomCommand(() =>
            {
                try
                {
                    студентыEntities.SaveChanges();
                    LoadGroups();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });
        }

        private void LoadGroups()
        {
            Groups = new ObservableCollection<Group>(студентыEntities.Groups);
            SignalChanged("Groups");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}