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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        ApplicationContext application;
        public AuthPage()
        {
            InitializeComponent();
            application = new ApplicationContext();
            LoginButton.animation(0, 320, 2);
            SignUpButton.animation(0, 320, 2);
            LargestLoginButton.animation(0, 640, 2);
        }
        public static string logInput { get; private set; }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            string login = Userlogin.Text;
            string password = UserPassword.Password;
            bool isBadInput = false;

            var users = application.Users.ToList();
            if (users.Where(x => x.Login == login && x.Password == password).Count() == 1)
            {
                Userlogin.BorderBrush = Brushes.DarkGreen;
                Userlogin.BorderThickness = new Thickness(5);
                Userlogin.Background = Brushes.Green;
                logInput = login;

                UserPassword.BorderBrush = Brushes.DarkGreen;
                UserPassword.BorderThickness = new Thickness(5);
                UserPassword.Background = Brushes.Green;
            }
            else
            {
                Userlogin.BorderBrush = Brushes.DarkRed;
                Userlogin.BorderThickness = new Thickness(5);
                Userlogin.Background = Brushes.Red;
                Userlogin.ToolTip = "Login/Password isn't correct";
                isBadInput = true;
                UserPassword.BorderBrush = Brushes.DarkRed;
                UserPassword.BorderThickness = new Thickness(5);
                UserPassword.Background = Brushes.Red;
                UserPassword.ToolTip = "Login/Password isn't correct";
            }

            if (!isBadInput)
            {
                IsRegisteredContorol.Background = Brushes.Green;
                NavigationService.Navigate(new MainUserPage());
            }
            else
            {
                IsRegisteredContorol.Background = Brushes.Red;
            }
        }

        private void Button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
