using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;


namespace Drinks_Vending_Machine__.Classes
{
    public class Manager
    {
        private Vending_Machine _v_M;
        private string          _director_Code = "1234";
        private bool            _paid;
        private int             _num_Clicks;
        private Beverage[]      _beverages;
        private static bool     _sign_Add_Beverage ;
      
        public static int             Num_beverages { get; set; }
        public static bool[]          In_Menu { get; private set; }
        public Button[]               Array_Beverage_Buttons { get; private set; }
        public static List<Component> Component_List { get; set; }
        public static List<int>       Amount_Products_List { get; set; }

       
        public Manager()
        {
            _v_M = new Vending_Machine();
            Component_List = new List<Component>();
            Amount_Products_List = new List<int>();
            List_Products();
            _beverages = new Beverage[6];
            Adding_Beverage();
            Array_Beverage_Buttons = new Button[6];
            In_Menu = new bool[6];
            Adding_Ttue_In_Menu();
            Num_beverages = 6;
        }

     
        #region List Products
        private void List_Products()
        {
            Component_List.Add(Component.Turkish_Coffee);
            Component_List.Add(Component.Sugar);
            Component_List.Add(Component.Chocolate);
            Component_List.Add(Component.Louisa_Tea_Leaves);
            Component_List.Add(Component.Milk);
            Component_List.Add(Component.Grain_Coffee);
            Component_List.Add(Component.Glasses);
            Amount_Products_List.Add(500);
            Amount_Products_List.Add(500);
            Amount_Products_List.Add(500);
            Amount_Products_List.Add(500);
            Amount_Products_List.Add(500);
            Amount_Products_List.Add(500);
            Amount_Products_List.Add(500);
        }
        #endregion

        #region Indexr Add or Information Inventory Quantity 
        public string this[string name_product, int Add_Component = 0]
        {
            get
            {
                //  if(name_product != "")
                for (int i = 0; i < Component_List.Count; i++)
                    if (Component_List[i].ToString() == name_product)
                        return $"You have: {Amount_Products_List[i]} servings of {Component_List[i]} in the machine.";
                return "";
            }
            set
            {
                for (int i = 0; i < Component_List.Count; i++)
                    if (Component_List[i].ToString() == name_product) Amount_Products_List[i] += Add_Component;
            }
        }
        #endregion

        #region Code Keypad
        public void Code_Keypad(Button[] buttons_Code, Button director, Button insert, Button Add_Beverage = null, Button Remuv_Beverage = null)
        {
            if (Add_Beverage != null)
            {
                Add_Beverage.Width = 0;
                Remuv_Beverage.Width = 0;
            }
            insert.IsEnabled = false;
            _v_M.Code_Keypad(buttons_Code, director, insert);
        }
        #endregion
       
        #region Code Change
        public void Code_Change(Button btn_Insert, Button[] _buttons_Code, TextBlock txtBl_Director_Information, Button code_Change, Button Add_Beverage, Button Remuv_Beverage)
        {
            _director_Code = txtBl_Director_Information.Text;
            Insert_Code(btn_Insert, _buttons_Code, txtBl_Director_Information, true, Add_Beverage, Remuv_Beverage, code_Change);
        }
        #endregion
       
        #region Clicking Number
        public void Clicking_Number(object num_Code, Button btn_Insert, Button[] _buttons_Code, TextBlock txtBl_Code_Screen)
        {
            btn_Insert.IsEnabled = false;
            Button button = num_Code as Button;
            if (_num_Clicks == 0) txtBl_Code_Screen.Text = "";
            txtBl_Code_Screen.FontSize = 40;
            txtBl_Code_Screen.Text += button.Content.ToString();
            _num_Clicks++;
            button.IsEnabled = false;
            if (_num_Clicks == 4)
            {
                foreach (var item in _buttons_Code)
                    item.IsEnabled = false;
                btn_Insert.IsEnabled = true;
                _num_Clicks = 0;
            }
        }
        #endregion
       
        #region Insert Code
        public bool Insert_Code(Button btn_Insert, Button[] _buttons_Code, TextBlock txtBl_Code_Screen, bool new_Code = false, Button Add_Beverage = null, Button Remuv_Beverage = null, Button code_Change = null, string num_Code = "")
        {
            txtBl_Code_Screen.FontSize = 17;
            if (new_Code == false)
            {
                if (Code_Verification(txtBl_Code_Screen.Text))
                    return true;
                txtBl_Code_Screen.Text = "Wrong code!\nPlease try again.";
                btn_Insert.IsEnabled = false;
            }
            else
            {
                txtBl_Code_Screen.FontSize = 23;
                txtBl_Code_Screen.Text = "The code has been successfully modified!";
                btn_Insert.Width = 0;
                code_Change.Width = 121;
                foreach (var item in _buttons_Code)
                    item.Width = 0;
                Add_Beverage.Width = 173;
                Remuv_Beverage.Width = 173;
            }
            foreach (var item in _buttons_Code)
                item.IsEnabled = true;
            return false;
        }
        #endregion
        
        #region Code Verification
        private bool Code_Verification(string try_Code)
        {
            if (_director_Code == try_Code) return true;
            return false;
        }
        #endregion

        #region Remuv Beverage Click
        public void Remuv_Beverage_Click(Button[] beverage_Buttons, TextBlock txtBl_Director_Information)
        {
            _sign_Add_Beverage = false;
            txtBl_Director_Information.Text = "";
            bool nothing_On_Menu = false;
            foreach (var beverage in In_Menu)
            {
                if (beverage == true)
                {
                    nothing_On_Menu = false;
                    break;
                }
                nothing_On_Menu = true;
            }
            if (nothing_On_Menu) txtBl_Director_Information.Text = "You have no drink on the menu!";
            else for (int i = 0; i < In_Menu.Length; i++)
                {
                    if (In_Menu[i]) beverage_Buttons[i].Width = 70;
                    else beverage_Buttons[i].Width = 0;
                }
        }
        #endregion

        #region Add Beverage Click
        public void Add_Beverage_Click(Button[] beverage_Buttons, TextBlock txtBl_Director_Information)
        {
            for (int i = 0; i < In_Menu.Length; i++)
            {
                if (In_Menu[i]) beverage_Buttons[i].Width = 0;
                else beverage_Buttons[i].Width = 70;
            }
            _sign_Add_Beverage = true;
            txtBl_Director_Information.Text = "";
            bool all_On_Menu = true;
            foreach (var beverage in In_Menu)
            {
                if (beverage == false)
                {
                    all_On_Menu = false;
                    break;
                }
                all_On_Menu = true;
            }
            if (all_On_Menu) txtBl_Director_Information.Text = "All drinks are already on the menu!";
        }
        #endregion

        #region Add Orr Removing Beverage
        public void Add_Orr_Removing_Beverage(object beverge_Name, TextBlock director_Information)
        {
            Button beverge = beverge_Name as Button;
            beverge.Width = 0;
            if (_sign_Add_Beverage) Add_Beverage(beverge, director_Information);
            else Removing_Beverage(beverge, director_Information);
        }
        #endregion
       
        #region Removing Beverage
        private void Removing_Beverage(Button beverge, TextBlock director_Information)
        {
            _sign_Add_Beverage = false;
            for (int i = 0; i < _beverages.Length; i++)
            {
                if (_beverages[i].Name_Drink.ToString() == beverge.Name.ToString())
                {
                    In_Menu[i] = false;
                    try
                    {
                        director_Information.Text = _v_M.Add_Or_Remove_Beverage(_beverages[i], false);//, Array_Beverage_Buttons);
                    }
                    catch (Not_Exist_In_Machine_Exception n)
                    {
                        director_Information.Text = n.Message;
                    }
                }
            }
        }
        #endregion
       
        #region Add Beverage
        private void Add_Beverage(Button beverge, TextBlock director_Information)
        {
            for (int i = 0; i < _beverages.Length; i++)
            {
                if (_beverages[i].Name_Drink.ToString() == beverge.Name.ToString())
                {
                    In_Menu[i] = true;
                    try
                    {
                        director_Information.Text = _v_M.Add_Or_Remove_Beverage(_beverages[i], true);
                    }
                    catch (Not_Exist_In_Machine_Exception n)
                    {
                        director_Information.Text = n.Message;
                    }
                }
            }
        }
        #endregion
       
        #region Add Inventory Quantity
        public void Add_Inventory_Quantity(object component, TextBlock information_Inventory)
        {
            Button component_Name = component as Button;
            this[component_Name.Name.ToString(), 500] = "";
            information_Inventory.Text = this[component_Name.Name.ToString()];
        }
        #endregion
       
        #region Information Inventory Quantity
        public void Information_Inventory_Quantity(object component, TextBlock information_Inventory)
        {
            Button component_Name = component as Button;
            string new_Component_Name = "";
            switch (component_Name.Name.ToString())
            {
                case "Toorkish_Coffee_I":
                    new_Component_Name = "Turkish_Coffee";
                    break;
                case "Tea_Leaves_I":
                    new_Component_Name = "Louisa_Tea_Leaves";
                    break;
                case "Coco_I":
                    new_Component_Name = "Chocolate";
                    break;
                case "Grain_Coffee_I":
                    new_Component_Name = "Grain_Coffee";
                    break;
                case "Disposable_Cups_I":
                    new_Component_Name = "Glasses";
                    break;
                case "Sugar_I":
                    new_Component_Name = "Sugar";
                    break;
                case "Milk_Carton_I":
                    new_Component_Name = "Milk";
                    break;
            }
            information_Inventory.Text = this[new_Component_Name].ToString();
        }
        #endregion
       
        #region Drinks Menu
        public void Drinks_Menu(TextBlock[] text_Blocks_Details, Image[] images_Buttns)
        {
            _v_M.Drinks_Menu(text_Blocks_Details, images_Buttns);
        }
        #endregion
       
        #region Customer Information
        public void Customer_Information(object beverage_Names, TextBlock txtBl_Customer_Information, Button i_Took_The_Drink, Button[] buttons_Beverage, TextBlock[] text_Blocks_Details)
        {
            Button beverage_Name = beverage_Names as Button;
            string f = beverage_Name.ToString();
            if (_paid == true)
            {
                try
                {
                    txtBl_Customer_Information.Text = _v_M.Selecting_And_Preparing(beverage_Name.Name);
                    i_Took_The_Drink.IsEnabled = true;
                    for (int i = 0; i < buttons_Beverage.Length; i++)
                    {
                        if (buttons_Beverage[i] != beverage_Name)
                        {
                            buttons_Beverage[i].Width = 0; buttons_Beverage[i].Height = 0;
                            text_Blocks_Details[i].Text = "";
                        }
                        else buttons_Beverage[i].IsEnabled = false;
                    }
                }
                catch (Component_Missing_Exception m)
                {
                    txtBl_Customer_Information.Text = "Sorry!\nThe drink is missing.\nPlease select a new drink.";
                }
            }
            else txtBl_Customer_Information.Text = "Please insert money into the machine.";
        }
        #endregion
       
        #region Put Money
        public void Put_Money(TextBlock TxtBl_Payment_Screen, Image Img_Pays, TextBlock txtBl_Customer_Information, Button btn_Money)
        {
            _paid = true;
            btn_Money.IsEnabled = false;
            txtBl_Customer_Information.Text = "";
            Img_Pays.Width = 133; Img_Pays.Height = 140;
            TxtBl_Payment_Screen.Text = "You paid!\nNow choose a drink";
        }
        #endregion
       
        #region I Took The Drink
        public void I_Took_The_Drink(TextBlock TxtBl_Customer_Information, TextBlock TxtBl_Payment_Screen, Image Img_Pays)
        {
            _paid = false;
            Img_Pays.Width = 0; Img_Pays.Height = 0;
            TxtBl_Payment_Screen.Text = "";
            TxtBl_Customer_Information.Text = "";
        }
        #endregion
            
        #region Adding Beverage
        private void Adding_Beverage()
        {
            for (int i = 0; i < _v_M.Array_Beverage.Count; i++)
            {
                _beverages[i] = _v_M.Array_Beverage[i];
            }
        }
        #endregion
       
        #region Adding Ttue In Menu
        private void Adding_Ttue_In_Menu()
        {
            In_Menu[0] = true;
            In_Menu[1] = true;
            In_Menu[2] = true;
            In_Menu[3] = true;
            In_Menu[4] = true;
            In_Menu[5] = true;
        } 
        #endregion
    }
}
