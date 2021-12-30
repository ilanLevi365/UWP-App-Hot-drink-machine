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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Drinks_Vending_Machine__
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Customer_Screen : Page
    {
      private Manager     _m;
      private Button[]    _buttons_Beverage;
      private Image[]     _buttns_Images;
      private TextBlock[] _text_Blocks_Details;

        public Customer_Screen()
        {
            this.InitializeComponent();
            _buttons_Beverage = new Button[6];       
            _buttns_Images = new Image[6];
            Adding_Buttns_Images();
            _text_Blocks_Details = new TextBlock[6];
            Text_Blocks_Details();
            Adding_Buttns_Beverges();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _m = e.Parameter as Manager;
            _m.Drinks_Menu(_text_Blocks_Details, _buttns_Images);
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
            => Frame.Navigate(typeof(Start_Screen), _m);
    
        private void Btn_choice_Click(object sender, RoutedEventArgs e)
            => _m.Customer_Information(sender, TxtBl_Customer_Information, Btn_I_Took_The_Drink, _buttons_Beverage, _text_Blocks_Details);

        private void Btn_Money_Click(object sender, RoutedEventArgs e)
            => _m.Put_Money(TxtBl_Payment_Screen, Img_Pays, TxtBl_Customer_Information, Btn_Money);

        private void Btn_I_Took_The_Drink_Click(object sender, RoutedEventArgs e)
        {
            _m.I_Took_The_Drink(TxtBl_Customer_Information, TxtBl_Payment_Screen, Img_Pays);
            Frame.Navigate(typeof(Start_Screen), _m);
        }
     
        private void Text_Blocks_Details()
        {
            _text_Blocks_Details[0] = TxtBl_Espresso;
            _text_Blocks_Details[1] = TxtBl_Ness_Coffee;
            _text_Blocks_Details[2] = TxtBl_Hot_Milk;
            _text_Blocks_Details[3] = TxtBl_Tea;
            _text_Blocks_Details[4] = TxtBl_Hot_Chocolate;
            _text_Blocks_Details[5] = TxtBl_Coffee;
        }

        private void Adding_Buttns_Images()
        {
            _buttns_Images[0] = Btn_Espresso2;
            _buttns_Images[1] = Btn_Ness_Coffee2;
            _buttns_Images[2] = Btn_Hot_Milk2;
            _buttns_Images[3] = Btn_Tea2;
            _buttns_Images[4] = Btn_Hot_Chocolate2;
            _buttns_Images[5] = Btn_Coffee2;
        }

        private void Adding_Buttns_Beverges()
        {
            _buttons_Beverage[0] = Btn_Espresso1;
            _buttons_Beverage[1] = Btn_Ness_Coffee1;
            _buttons_Beverage[2] = Btn_Hot_Milk1;
            _buttons_Beverage[3] = Btn_Tea1;
            _buttons_Beverage[4] = Btn_Hot_Chocolate1;
            _buttons_Beverage[5] = Btn_Coffee1;
            for (int i = 0; i < _buttons_Beverage.Length; i++)
            {
                if (Manager.In_Menu[i] == false)
                {
                    _buttons_Beverage[i].Width = 0;
                    _text_Blocks_Details[i].Width = 0;
                }
            }
        }
    }
}  