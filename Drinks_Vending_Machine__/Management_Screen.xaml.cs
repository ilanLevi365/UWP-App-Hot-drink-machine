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
    public sealed partial class Management_Screen : Page
    {
       private Manager  _m;
       private Button[] _buttons_Code;
       private Button[] _beverage_Buttons;
       
        public Management_Screen()
        {
            this.InitializeComponent();
            _buttons_Code = new Button[9];
            Adding_Buttons_Code();
            _beverage_Buttons = new Button[6];
            Adding_beverags_Buttons();
            TxtBl_Director_Information.Text = $"You have \"{Manager.Num_beverages}\" types of drinks in the machine.";
        }
      
        protected override void OnNavigatedTo(NavigationEventArgs e)     
           => _m = e.Parameter as Manager;
     
        private void Btn_Add_Inventorys(object sender, RoutedEventArgs e)
           => _m.Add_Inventory_Quantity(sender, TxtBl_Director_Information);
     
        private void Btn_Information_Inventory(object sender, RoutedEventArgs e)   
           => _m.Information_Inventory_Quantity(sender, TxtBl_Director_Information);

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)     
           => Frame.Navigate(typeof(Start_Screen), _m);

        private void Btns_Cods_Click(object sender, RoutedEventArgs e) 
           => _m.Clicking_Number(sender, Btn_Insert, _buttons_Code, TxtBl_Director_Information);
      
        private void Btn_Insert_Click(object sender, RoutedEventArgs e)  
           => _m.Code_Change(Btn_Insert, _buttons_Code, TxtBl_Director_Information, Btn_Code_Change, Btn_Add_Beverage, Btn_Remuv_Beverage);
     
        private void Btn_Code_Change_Click(object sender, RoutedEventArgs e)
           => _m.Code_Keypad(_buttons_Code, Btn_Code_Change, Btn_Insert, Btn_Add_Beverage, Btn_Remuv_Beverage);

        private void Bnt_Machine_Program_Reset_Click(object sender, RoutedEventArgs e)
           => Frame.Navigate(typeof(MainPage));

        private void Btn_choice_Click(object sender, RoutedEventArgs e)          
           => _m.Add_Orr_Removing_Beverage(sender, TxtBl_Director_Information);
       
        private void Btn_Remuv_Beverage_Click(object sender, RoutedEventArgs e)
           => _m.Remuv_Beverage_Click(_beverage_Buttons, TxtBl_Director_Information);
     
        private void Btn_Add_Beverage_Click(object sender, RoutedEventArgs e) 
           => _m.Add_Beverage_Click(_beverage_Buttons, TxtBl_Director_Information);

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

        public void Adding_beverags_Buttons()
        {
            _beverage_Buttons[0] = Espresso;
            _beverage_Buttons[1] = Ness_Coffee;
            _beverage_Buttons[2] = Hot_Milk;
            _beverage_Buttons[3] = Tea;
            _beverage_Buttons[4] = Hot_Chocolate;
            _beverage_Buttons[5] = Coffee;
        }
    }

}
