using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp7._04._2021
{
    internal class VMStudens : INotifyPropertyChanged
    {
        Entities студентыEntities;
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Group> Groups { get; set; }

        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomCommand AddStudents { get; set; }
        public CustomCommand SaveStudents { get; set; }
        public CustomCommand DeleteStudents { get; set; }

        private Student selectedStudent;

        public Student SelectedStudent
        {
            get => selectedStudent;
            set
            {
                selectedStudent = value;
                SignalChanged();
            }
        }

        public VMStudens()
        {
            студентыEntities = DB.GetDB();
            LoadStudents();
            Groups = new ObservableCollection<Group>(студентыEntities.Groups);

            AddStudents = new CustomCommand(() =>
            {
                var student = new Student { Birthday = DateTime.Now }; 
                студентыEntities.Students.Add(student);
                SelectedStudent = student;

            });

            SaveStudents = new CustomCommand(() =>
            {
                try
                {
                    студентыEntities.SaveChanges();
                    LoadStudents();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });

            DeleteStudents = new CustomCommand(() =>
            {

                студентыEntities.Students.Remove(SelectedStudent);
                студентыEntities.SaveChanges();
                LoadStudents();
            });

        }

        private void LoadStudents()
        {
            Students = new ObservableCollection<Student>(студентыEntities.Students);
            SignalChanged("Students");
        }

    }
    
}