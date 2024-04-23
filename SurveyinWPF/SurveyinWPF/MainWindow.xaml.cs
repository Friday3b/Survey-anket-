using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.DirectoryServices.ActiveDirectory;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;



namespace SurveyinWPF
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //bunu burada yaratmaqin meqsedi local variable olmaqdan cixartmaq idi 
        //eger initialize icersiinde yazsaydiq scope biten kimi buda bitecekdi ve ene ashaqida ishledemmiecekdik 

        private User user;
        
        public MainWindow()
        {

            InitializeComponent();

            user = new User();
            user.Nametxt = "Taleh"; 
            DataContext = user;


            

        }

        private void ConverttoJson_Click_Button(object sender, RoutedEventArgs e)
        {
            var filename = $"{user.Nametxt}";
            var json = JsonSerializer.Serialize(user);
            File.WriteAllText(filename, json);
            MessageBox.Show("Json file already saved");
        }


        private void fromJson_ConvertFiletoScreen_button_click(object sender, RoutedEventArgs e)
        {
            var filename = $"{searchinpanel.Text}";

            if (File.Exists(filename))
            {
                try
                {
                    var json = File.ReadAllText(filename);
                    var loadedUser = JsonSerializer.Deserialize<User>(json);

                    user.Nametxt = loadedUser.Nametxt;
                    user.Surname = loadedUser.Surname;
                    user.FatherName = loadedUser.FatherName;
                    user.Country = loadedUser.Country;
                    user.City = loadedUser.City;
                    user.PhoneNumber = loadedUser.PhoneNumber;



                    loadedUser.Nametxt = Namesection.Text;
                    loadedUser.Surname=Surnamesection.Text;
                    loadedUser.FatherName=FatherNameSection.Text;
                    loadedUser.Country=Countrysection.Text;
                    loadedUser.City=Citysection.Text;
                    loadedUser.PhoneNumber=PhoneNumbersection.Text;




                    //MessageBox.Show($"Name: {user.Nametxt}\n" +
                    //                $"Surname: {user.Surname}\n" +
                    //                $"FatherName: {user.FatherName}\n" +
                    //                $"Country: {user.Country}\n" +
                    //                $"City: {user.City}\n" +
                    //                $"PhoneNumber: {user.PhoneNumber}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading json file: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Json file not found.");
            }
        }



        //public class GenderConverter : IValueConverter
        //{
        //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        string genderValue = value as string;
        //        string radioButtonContent = parameter as string;

        //        return genderValue == radioButtonContent;
        //    }

        //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        bool isChecked = (bool)value;
        //        string radioButtonContent = parameter as string;

        //        if (isChecked)
        //            return radioButtonContent;
        //        else
        //            return null;
        //    }
        //}



    }
}
