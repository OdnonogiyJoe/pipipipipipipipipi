using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WpfApp7._04._2021
{
    internal class VM : INotifyPropertyChanged
    {
        public Page CurrentPage { get; set; }

        /*СтудентыEntities студентыEntities;
        private Specials selectedSpecial;
        private Groups selectedGroup;*/

        public ObservableCollection<Special> Specials { get; set; }
        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Student> Students { get; set; }

        public CustomCommand OpenGroups { get; set; }
        public CustomCommand OpenStudents { get; set; }
        public CustomCommand OpenSpecials { get; set; }
        public CustomCommand OpenMainPage { get; set; }

        public VM()
        {
            //Specials = new ObservableCollection<Specials>(студентыEntities.Specials);
            OpenSpecials = new CustomCommand(() => { CurrentPage = new PageSpecials(); SignalChanged("CurrentPage"); });
            OpenGroups = new CustomCommand(() => { CurrentPage = new PageGroups(); SignalChanged("CurrentPage"); });
            OpenStudents = new CustomCommand(() => { CurrentPage = new PageStudents(); SignalChanged("CurrentPage"); });
            OpenMainPage =  new CustomCommand(() => { CurrentPage = new MainPage(); SignalChanged("CurrentPage"); });
        }

        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public event PropertyChangedEventHandler PropertyChanged;
    }

}