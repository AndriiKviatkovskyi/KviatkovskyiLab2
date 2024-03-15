using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace KviatkovskyiLab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        PersonViewModel _person = new PersonViewModel();

        public ICommand ProceedCommand { get; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ProceedCommand = new RelayCommand(Proceed, CanProceed);
        }

        private bool CanProceed(object parameter)
        {

            return !string.IsNullOrWhiteSpace(EnterFirstName.Text) &&
                   !string.IsNullOrWhiteSpace(EnterLastName.Text) &&
                   !string.IsNullOrWhiteSpace(EnterEmail.Text) &&
                   PickedBirthday.SelectedDate.HasValue;
        }

        private async void Proceed(object parameter)
        {
            await ProcessAsync();
        }

       

        private async Task ProcessAsync()
        {
            try
            {
                NameBlock.Text = "";
                SurnameBlock.Text = "";
                EmailBlock.Text = "";
                BirthdateBlock.Text = "";
                AgeBlock.Text = "";
                IsAdultBlock.Text = "";
                ZodiacWesternBlock.Text = "";
                ZodiacChineseBlock.Text = "";
                BirthdayBlock.Text = "";
                foreach (UIElement element in MainGrid.Children)
                {
                    element.IsEnabled = false;
                }
                MainWindowName.IsEnabled = false;
                string tempName = EnterFirstName.Text;
                string tempSurname = EnterLastName.Text;
                string tempEmail = EnterEmail.Text;
                DateTime tempDate = DateTime.Now;
                if (PickedBirthday.SelectedDate.HasValue)
                {
                    tempDate = PickedBirthday.SelectedDate.Value;
                }
                await Task.Run(() =>
                {
                    _person.Person = new PersonModel(tempName, tempSurname, tempEmail, tempDate);           
                });
                int age = _person.Age;
                if (age < 0 || age > 135)
                {
                    MessageBox.Show("Your age must be between 0 and 135", "INVALID AGE");
                }
                else
                {
                    NameBlock.Text = _person.FirstName;
                    SurnameBlock.Text = _person.LastName;
                    EmailBlock.Text = _person.Email;
                    BirthdateBlock.Text = _person.Birthdate.ToShortDateString();
                    AgeBlock.Text = age + "";
                    IsAdultBlock.Text = _person.IsAdult ? "Adult" : "Child";
                    ZodiacWesternBlock.Text = _person.ZodiacWestern;
                    ZodiacChineseBlock.Text = _person.ZodiacChinese;
                    if (_person.IsBirthday) BirthdayBlock.Text = "HAPPY BIRTHDAY!";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                foreach (UIElement element in MainGrid.Children)
                {
                    element.IsEnabled = true;
                }
                MainWindowName.IsEnabled = true;
            }
        }

      
    }
}
