using Drinks_Vending_Machine__.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Drinks_Vending_Machine__
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Start_Screen : Page
    {
       private Manager  _m;
       private Button[] _buttons_Code;
     
        public Start_Screen()
        {
            this.InitializeComponent();

            _buttons_Code = new Button[9];
            Adding_Buttons_Code();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
            => _m = e.Parameter as Manager;

        private void Btn_Menu_Click(object sender, RoutedEventArgs e)
            => Frame.Navigate(typeof(Customer_Screen), _m);

        private void Btn_Management__Click_1(object sender, RoutedEventArgs e)
            => _m.Code_Keypad(_buttons_Code, Btn_Management_, Btn_Insert);
     
        private void Btns_Cods_Click(object sender, RoutedEventArgs e)
            => _m.Clicking_Number(sender, Btn_Insert, _buttons_Code, TxtBl_Code_Screen);

        private void Btn_Insert_Click(object sender, RoutedEventArgs e)
        { if (_m.Insert_Code(Btn_Insert, _buttons_Code, TxtBl_Code_Screen)) Frame.Navigate(typeof(Management_Screen), _m); }

        public void Adding_Buttons_Code()
        {
            _buttons_Code[0] = Btn_1;
            _buttons_Code[1] = Btn_2;
            _buttons_Code[2] = Btn_3;
            _buttons_Code[3] = Btn_4;
            _buttons_Code[4] = Btn_5;
            _buttons_Code[5] = Btn_6;
            _buttons_Code[6] = Btn_7;
            _buttons_Code[7] = Btn_8;
            _buttons_Code[8] = Btn_9;
        }
    }
}
