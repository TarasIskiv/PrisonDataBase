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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ApplicationContext db;
        public MainPage()
        {
            InitializeComponent();
            db = new ApplicationContext();
            SignUpButton.animation(0, 315, 2);
            LoginButton.animation(0, 315, 2);
            registerButton.animation(0, 630, 2);
        }
        public static string logInput { get; private set; }
        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            string login = Userlogin.Text;
            string email = UserEmail.Text;
            string password = UserPassword.Password;
            string confirmedPassword = UserConfirmedPassword.Password;

            bool isBadInput = false;

            var result = login.checkLogin();
            if (result.isBad)
            {
                Userlogin.BorderBrush = Brushes.DarkRed;
                Userlogin.BorderThickness = new Thickness(5);
                Userlogin.Background = Brushes.Red;
                Userlogin.ToolTip = result.TypeError;
                isBadInput = true;
            }
            else
            {
                Userlogin.BorderBrush = Brushes.DarkGreen;
                Userlogin.BorderThickness = new Thickness(5);
                Userlogin.Background = Brushes.Green;
                Userlogin.ToolTip = result.TypeError;
                logInput = login;
            }


            result = password.checkPassword();

            if (result.isBad)
            {
                isBadInput = true;
                UserPassword.BorderBrush = Brushes.DarkRed;
                UserPassword.BorderThickness = new Thickness(5);
                UserPassword.Background = Brushes.Red;
                UserPassword.ToolTip = result.TypeError;
            }
            else
            {
                UserPassword.BorderBrush = Brushes.DarkGreen;
                UserPassword.BorderThickness = new Thickness(5);
                UserPassword.Background = Brushes.Green;
                UserPassword.ToolTip = result.TypeError;
            }

            result = confirmedPassword.checkConfirmedPassword(password);

            if (result.isBad)
            {
                isBadInput = true;
                UserConfirmedPassword.BorderBrush = Brushes.DarkRed;
                UserConfirmedPassword.BorderThickness = new Thickness(5);
                UserConfirmedPassword.Background = Brushes.Red;
                UserConfirmedPassword.ToolTip = result.TypeError;
            }
            else
            {
                UserConfirmedPassword.BorderBrush = Brushes.DarkGreen;
                UserConfirmedPassword.BorderThickness = new Thickness(5);
                UserConfirmedPassword.Background = Brushes.Green;
                UserConfirmedPassword.ToolTip = result.TypeError;
            }

            result = email.checkEmail();

            if (result.isBad)
            {
                isBadInput = true;

                UserEmail.BorderBrush = Brushes.DarkRed;
                UserEmail.BorderThickness = new Thickness(5);
                UserEmail.Background = Brushes.Red;
                UserEmail.ToolTip = result.TypeError;
            }
            else
            {
                UserEmail.BorderBrush = Brushes.DarkGreen;
                UserEmail.BorderThickness = new Thickness(5);
                UserEmail.Background = Brushes.Green;
                UserEmail.ToolTip = result.TypeError;
            }

            if (!isBadInput)
            {
                IsRegisteredContorol.Background = Brushes.Green;
                User user = new User(login, password, email);
                db.Users.Add(user);
                db.SaveChanges();
                NavigationService.Navigate(new MainUserPage());
            }
            else
            {
                IsRegisteredContorol.Background = Brushes.Red;
            }


        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AuthPage());
        }
    }
}
