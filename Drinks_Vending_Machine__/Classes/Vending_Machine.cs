using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Drinks_Vending_Machine__.Classes
{
    public enum Component { Turkish_Coffee, Sugar, Chocolate, Louisa_Tea_Leaves, Milk, Grain_Coffee, Glasses }
   
    public  class Vending_Machine
    {
        public  List<Beverage> Array_Beverage { get; private set; }
       
        public  Vending_Machine()
        {
            Array_Beverage = new List<Beverage>();
            Creating_Drinks();        
        }

        #region Code Keypad
        public void Code_Keypad(Button[] buttons_Code, Button Change_Code, Button insert)
        {
            foreach (var button in buttons_Code)
            {
                button.Width = 50; button.Height = 50;
            }
            Change_Code.Width = 0;
            insert.Width = 80;
        }
        #endregion

        #region Creating Drinks
        public void Creating_Drinks()
        {
            Array_Beverage.Add(new Espresso("Espresso", 1.5f, "/Assets/Img_Espresso.jpg", new string[2] { "Turkish coffee: 7 g", "Sugar: 14 g" }));
            Array_Beverage.Add(new Ness_Coffee("Ness_Coffee", 2.5f, "/Assets/Img_Ness_Coffee.jpg", new string[3] { "Milk: 180 ml, 90 c'", "Grain coffee: 10 g", "Sugar: 14 g" }));
            Array_Beverage.Add(new Hot_Milk("Hot_Milk", 2.0f, "/Assets/Img_Hot_Milk.jpg", new string[1] { "Milk: 180 ml, 90 c" }));
            Array_Beverage.Add(new Tea("Tea", 1.0f, "/Assets/Img_Tea.jpg", new string[2] { "Louisa tea leaves: 5 g", "Sugar: 14 g" }));
            Array_Beverage.Add(new Hot_Chocolate("Hot_Chocolate", 3.0f, "/Assets/Img_Hot_Chocolate.jpg", new string[2] { "Milk: 180 ml, 90 c", "Chocolate: 20 g" }));
            Array_Beverage.Add(new Coffee("Coffee", 2.0f, "/Assets/Img_Coffee.jpg", new string[2] { "Turkish coffee: 14 g", "Sugar: 14 g" }));
        } 
        #endregion

        #region Drinks Menu
        public void Drinks_Menu(TextBlock[] text_Blocks_Details, Image[] images_Buttns)
        {
            for (int i = 0; i < images_Buttns.Length; i++)
            {
                images_Buttns[i].Source = new BitmapImage(new Uri($"ms-appx://{Array_Beverage[i].New_Image_Btten}"));
                text_Blocks_Details[i].Text = $"{Array_Beverage[i].Name_Drink}\n{Array_Beverage[i].Price_Drink:C}";
            }
        }
        #endregion

        #region Checking Beverage Components In Stock
        private bool Components_Hot_Milk()
        {
            if (In_Stock(Component.Glasses) && In_Stock(Component.Milk))
                return true;
            else return false;
        }
        private bool Components_Coffee()
        {
            if (In_Stock(Component.Glasses) && In_Stock(Component.Turkish_Coffee) && In_Stock(Component.Sugar))
                return true;
            else return false;
        }
        private bool Components_Hot_Chocolate()
        {
            if (In_Stock(Component.Glasses) && In_Stock(Component.Milk) && In_Stock(Component.Chocolate))
                return true;
            else return false;
        }
        private bool Components_Ness_Coffee()
        {
            if (In_Stock(Component.Glasses) && In_Stock(Component.Grain_Coffee) && In_Stock(Component.Sugar))
                return true;
            else return false;
        }
        private bool Components_Tea()
        {
            if (In_Stock(Component.Glasses) && In_Stock(Component.Louisa_Tea_Leaves) && In_Stock(Component.Sugar))
                return true;
            else return false;
        }
        private bool In_Stock(Component name_Component)
        {
            for (int i = 0; i < Manager.Component_List.Count; i++)
            {
                if (Manager.Component_List[i] == name_Component)
                {
                    if (Manager.Amount_Products_List[i] != 0)
                    {
                        Manager.Amount_Products_List[i]--;
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Selecting And Preparing
        public string Selecting_And_Preparing(string beverage_Name)
        {
            bool sign_Components = false;
            int new_beverage_Num = 0 ;
                switch (beverage_Name)
                {
                    case "Btn_Espresso1":
                    new_beverage_Num = 0;
                    sign_Components = Components_Coffee();
                    break;
                case "Btn_Ness_Coffee1":
                    new_beverage_Num = 1;
                    sign_Components = Components_Ness_Coffee();
                    break;
                case "Btn_Hot_Milk1":
                    new_beverage_Num = 2;
                    sign_Components = Components_Hot_Milk();
                    break;
                case "Btn_Tea1":
                    new_beverage_Num = 3;
                    sign_Components = Components_Tea();
                    break;
                case "Btn_Hot_Chocolate1":
                    new_beverage_Num = 4;
                    sign_Components = Components_Hot_Chocolate();
                    break;
                case "Btn_Coffee1":
                    new_beverage_Num = 5;
                    sign_Components = Components_Coffee();
                        break;                
                    default:
                        sign_Components = false;
                        break;
                }
         
            if (sign_Components == true) return Array_Beverage[new_beverage_Num].ToString();
            else throw new Component_Missing_Exception($"One of the ingredients of the drink {beverage_Name} is missing.");
            return "";
        }
        #endregion

        #region Remove Beverage
        public string Add_Or_Remove_Beverage(Beverage beverage, bool add_Beverage)
        {
            for (int i = 0; i < Array_Beverage.Count; i++)
            {
                if (Array_Beverage[i].Name_Drink.ToString() == beverage.Name_Drink.ToString())
                {
                    if (add_Beverage == true)
                    {
                       Manager.Num_beverages++;
                       return $"The drink \"{beverage.Name_Drink}\" was Adding\nYou now have {Manager.Num_beverages} types of drinks in the machine!";
                    }
                    if(add_Beverage == false)
                    {
                        Manager.Num_beverages--;
                        return $"The drink \"{beverage.Name_Drink}\" was removed\nYou now have {Manager.Num_beverages} types of drinks in the machine!";
                    }
                }
            }
            throw new Not_Exist_In_Machine_Exception($" The \"{beverage.Name_Drink}\" drink is not on the customer's menu.");
            return "";
        }
        #endregion

        #region Add Beverage
        public void Add_Beverage(Beverage beverage)
        {        
            beverage.Beverage_Sign = true;
            Manager.Num_beverages++;
            beverage.Beverage_Sign = false;
        }
        #endregion
    }
}
