using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddPrisonerPage.xaml
    /// </summary>
    public partial class AddPrisonerPage : Page
    {
        ApplicationContext db;
        byte[] photoBlob = null;
        public AddPrisonerPage()
        {
            InitializeComponent();
            db = new ApplicationContext();
            AddButton.animation(0, 200, 2);
            HomeButton.animation(0, 200, 2);
        }
        private void Button_AddNewPrisoner_Click(object sender, RoutedEventArgs e)
        {
            string age = PrisonerAge.Text;
            string fullName = PrisonerFullName.Text;
            int ageInteger = -1;

            bool photoResult = false;
            var AgeResult = age.checkAddingPrisonerAge();

            if (AgeResult.isBad)
            {
                PrisonerAge.ToolTip = AgeResult.TypeError;
                PrisonerAge.BorderBrush = Brushes.DarkRed;
                PrisonerAge.Background = Brushes.Red;
            }
            else
            {
                PrisonerAge.ToolTip = AgeResult.TypeError;
                ageInteger = Convert.ToInt32(age);
                PrisonerAge.BorderBrush = Brushes.DarkGreen;
                PrisonerAge.Background = Brushes.Green;
            }

            var FullNameResult = fullName.checkAddingPrisonerName();


            if (FullNameResult.isBad)
            {
                PrisonerFullName.ToolTip = FullNameResult.TypeError;
                PrisonerFullName.BorderBrush = Brushes.DarkRed;
                PrisonerFullName.Background = Brushes.Red;
            }
            else
            {
                PrisonerFullName.ToolTip = FullNameResult.TypeError;
                PrisonerFullName.BorderBrush = Brushes.DarkGreen;
                PrisonerFullName.Background = Brushes.Green;
            }

            if(photoBlob != null)
            {
                photoResult = true;
            }else
            {
                BorderImage.BorderBrush = Brushes.DarkRed;
            }

            if (!AgeResult.isBad && !FullNameResult.isBad && photoResult)
            {
                var prisoners = db.Prisoners.ToList();
                int id;
                if (prisoners.Count == 0)
                {
                    id = 0;
                }else
                {
                    id = prisoners.OrderByDescending(x => x.prisonerId).FirstOrDefault().prisonerId + 1;
                }
                
                string fileName ="prisoner_" + id.ToString() + ".jpg";
                string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
                File.WriteAllBytes(fileName, photoBlob);
                Prisoner prisoner = new Prisoner(ageInteger, fullName, path);
                db.Prisoners.Add(prisoner);
                db.SaveChanges();
            }
        }


       


        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainUserPage());
        }

        private void UploadPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if ((Boolean)dialog.ShowDialog())
            {
                var photo = new BitmapImage(new Uri(dialog.FileName));
                PrisonerPhoto.Source = photo;

                var bitmapSource = PrisonerPhoto.Source as BitmapSource;

                if (bitmapSource != null)
                {
                    BitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

                    using (var stream = new MemoryStream())
                    {
                        encoder.Save(stream);
                        photoBlob = stream.ToArray();
                    }
                }

            }
            else
            {
                MessageBox.Show("You didn't choose photo");
            }

           
            
        }
    }
}
