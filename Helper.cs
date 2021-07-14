using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PrisonDataBaseWpfApp
{
    public static class Helper
    {
        public static (bool isBad, string TypeError) checkLogin(this string login)
        {
            return login.Length < 5 ? (true, "Minimum length = 5 symbols") : (false, string.Empty);
        }

        public static (bool isBad, string TypeError) checkPassword(this string password)
        {
            return password.Length < 8 || !(new Regex(@"\d+").Match(password).Success) ?
                (true, "Minimum length = 8 symbols Or You haven't numbers in your password") : 
                (false, string.Empty);
        }

        public static (bool isBad, string TypeError) checkConfirmedPassword(this string confirmedPassword, string password)
        {
            return confirmedPassword.Length < 8 || !confirmedPassword.Equals(password) ?
                (true, "Minimum length = 8 symbols Or You entered different passwords") :
                (false, string.Empty);
        }

        public static (bool isBad, string TypeError) checkEmail(this string email)
        {
            return !email.Contains('@') || !email.Contains('.') ?
                 (true, "Incorrect email address") :
                 (false, string.Empty);
        }

        public static (bool isBad, string TypeError) checkAddingPrisonerAge(this string age)
        {
            int ageInteger = -1;
             
            if (age.Equals(string.Empty))
            {
                return (true, "This field cannot be empty");
            }
            else if (!Int32.TryParse(age, out ageInteger))
            {
                return (true, "This field cannot contains letters");
            }
            else
            {
                if (Int32.TryParse(age, out ageInteger))
                {
                    if (ageInteger < 18 || ageInteger > 120)
                    {
                        return (true, "Prisoner is too young or too old");
                        
                    }
                    else
                    {
                        return (false, string.Empty);
                    }
                }
            }
            return (false, string.Empty);
        }

        public static (bool isBad, string TypeError) checkAddingPrisonerName(this string fullName)
        {
            if (fullName.Equals(string.Empty))
            {
                return (true, "This field cannot be empty");
            }
            else if (new Regex(@"\d+").Match(fullName).Success)
            {
                return (true, "Prisoner's name cannot contains numbers");
            }

            return (false, string.Empty);
            
        }

        public static void animation(this Button button, int from, int to, int timeInSeconds)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = from;
            doubleAnimation.To = to;
            doubleAnimation.Duration = TimeSpan.FromSeconds(timeInSeconds);
            button.BeginAnimation(Button.WidthProperty, doubleAnimation);
        }
    }
}
