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
    /// Логика взаимодействия для MainUserPage.xaml
    /// </summary>
    public partial class MainUserPage : Page
    {
        private readonly string userLogin;

        public MainUserPage()
        {
            InitializeComponent();
            if (MainWindow.logInput != default(string))
            {
                userLogin = MainPage.logInput;
            }
            else
            {
                userLogin = AuthPage.logInput;
            }

            HelloUser.Text = "Hello, " + userLogin;

            AddPrisonerButton.animation(0, 510, 2);
            RemovePrisonerButton.animation(0, 510, 2);
            ShowAllPrisonersButton.animation(0, 510, 2);
            LogOutButton.animation(0, 140, 2);
        }
        private void Button_AddPrisoner_Click(object sender, RoutedEventArgs e)
        {
            //AddPrisonerWidow addPrisonerWidow = new AddPrisonerWidow();
            //addPrisonerWidow.Show();
            //Hide();
            NavigationService.Navigate(new AddPrisonerPage());
        }

        private void Button_RemovePrisoner_Click(object sender, RoutedEventArgs e)
        {
            //RemovePrisonerWindow removePrisoner = new RemovePrisonerWindow();
            //removePrisoner.Show();
            //Hide();
            NavigationService.Navigate(new RemovePrisonerPage());
        }

        private void Button_ShowAllPrisoners_Click(object sender, RoutedEventArgs e)
        {
            //ShowAllPrisonersWindow showAllPrisoners = new ShowAllPrisonersWindow();
            //showAllPrisoners.Show();
            //Hide();
            NavigationService.Navigate(new ShowAllPrisonersPage());
        }

        private void Button_LogOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }
    }
}
