using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Drinks_Vending_Machine__.Classes
{
    public abstract class Beverage
    {
        public string[] Array_Ingredients { get; private set; }
        public String   Name_Drink { get; private set; }
        public float    Price_Drink { get; private set; }
        public string   New_Image_Btten { get; private set; }
        public bool     Beverage_Sign { get; set; }
        
        public Beverage(string name_Drink, float price_Drink, string uri_Image, string[] array_Ingredients)
        {
            Name_Drink = name_Drink;
            Price_Drink = price_Drink;
            New_Image_Btten = uri_Image;
            Array_Ingredients = array_Ingredients;
        }

        private void Preparation()
        {
            Adding_Ingredients();
            Adding_Hot_Water();
            Stirring();
        }

        public abstract string Adding_Ingredients();

        public abstract string Adding_Hot_Water();

        public abstract string Stirring();


        public override string ToString()
        {
            return $"\n\nPut in a glass of ingredients:\n{Adding_Ingredients()}{Adding_Hot_Water()}\n\n{Stirring()}";
        }
    }
}
