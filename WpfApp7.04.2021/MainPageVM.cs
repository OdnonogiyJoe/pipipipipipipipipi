using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;
namespace WpfApp7._04._2021

{
    internal class MainPageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Entities студентыEntities;

        private Special selectedSpecial;
        private Group selectedGroup;

        public ObservableCollection<Special> Specials { get; set; }
        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Student> Students { get; set; }

        public MainPageVM()
        {
           
            студентыEntities = DB.GetDB();//экземпляр будет создан один раз.
                                          //делаем ссылку на класс с данными 
            Specials = new ObservableCollection<Special>(студентыEntities.Specials);
        }

        public Special SelectedSpecial
        {
            get => selectedSpecial;
            set
            {
                selectedSpecial = value;
                if (selectedSpecial != null)
                    Groups = new ObservableCollection<Group>(selectedSpecial.Groups);
                else
                    Groups = new ObservableCollection<Group>();
                SignalChanged("Groups");
            }
        } //чтобы добавить метод...с параметром Grops- перепрочитался список групп

        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                if (selectedGroup != null)
                    Students = new ObservableCollection<Student>(selectedGroup.Students);
                else
                    Students = new ObservableCollection<Student>();
                SignalChanged("Students");
            }

        }

    }

}
