using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PrisonDataBaseWpfApp
{
    class PrisonerViewModel : INotifyPropertyChanged
    {
        private ApplicationContext app;
        private Prisoner[] prisoners;

        private Prisoner selectedPrisoner;
        public Prisoner[] Prisoners { get; private set; }

        public Prisoner SelectedPrisoner
        {
            get { return selectedPrisoner; }
            set { selectedPrisoner = value; OnPropertyChanged("SelectedPrisoner"); }
        }

        public PrisonerViewModel()
        {
            app = new ApplicationContext();
            Prisoners = app.Prisoners.ToArray();

        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
    }
}
