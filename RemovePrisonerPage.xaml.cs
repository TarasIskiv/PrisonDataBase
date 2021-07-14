using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrisonDataBaseWpfApp
{
    /// <summary>
    /// Логика взаимодействия для RemovePrisonerPage.xaml
    /// </summary>
    public partial class RemovePrisonerPage : Page
    {
        ApplicationContext app;

        public RemovePrisonerPage()
        {
            InitializeComponent();
            DataContext = new RemovePrisonerViewModel();
            app = new ApplicationContext();
            RemovePrisonerButton.animation(0, 300, 2);
            HomeButton.animation(0, 250, 2);
        }

        private void Button_RemovePrisoner_Clicked(object sender, RoutedEventArgs e)
        {
            if (CurrentPrisoner.Items.Count != 0)
            {
                Prisoner prisoner = null;
                for (int i = 0; i < CurrentPrisoner.Items.Count; i++)
                {

                    prisoner = CurrentPrisoner.Items[i] as Prisoner;
                }
                var removePrisoner = (from x in app.Prisoners where x.prisonerId == prisoner.prisonerId select x).First();
                app.Prisoners.Remove(removePrisoner);
                app.SaveChanges();
                FoundedPrisonerField.BorderBrush = Brushes.DarkGreen;
                FoundedPrisonerField.BorderThickness = new Thickness(5);
                FoundedPrisonerField.ToolTip = "Prisoner removed";
            }
            else
            {
                FoundedPrisonerField.BorderBrush = Brushes.DarkRed;
                FoundedPrisonerField.BorderThickness = new Thickness(5);
                FoundedPrisonerField.ToolTip = "You don't choose prisoner";

            }
        }


        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainUserPage());
        }
    }
}
