using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SurveyinWPF
{
    public class User
    {

        public string Nametxt { get; set; } 
        public string Surname { get; set; }
        public string FatherName { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        public string PhoneNumber { get; set; }

        //public Brush BackColor { get; set; } =
        //new LinearGradientBrush(Colors.White, Colors.Blue, 45); 

        //public DatePicker Birthday { get; set; }

        public RadioButton Gender { get; set; }

        //public ImageBrush BackgroundImage { get; set; } = new ImageBrush(new BitmapImage(new Uri("image/background/city.jpg" , UriKind.Relative)));


        public override string ToString() => $" Name {Nametxt} Surname {Surname} FatherName{FatherName} " +
            $" Country {Country} City{City} PhoneNumber{PhoneNumber}  ";

        


    }


}
