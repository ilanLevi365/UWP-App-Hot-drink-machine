using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Drinks_Vending_Machine__.Classes
{
     public class Ness_Coffee : Beverage
    {
        public Ness_Coffee(string beverage_Name, float beverage_Price, string image_Source, string[] array_Ingredients)
            : base(beverage_Name, beverage_Price, image_Source, array_Ingredients) { }


        #region Adding Ingredients
        public override string Adding_Ingredients()
        {
            StringBuilder array_Ingredients = new StringBuilder();
            foreach (var Ingredients in Array_Ingredients)
                array_Ingredients.AppendLine(Ingredients);
            return $"{array_Ingredients}";
        }
        #endregion

        #region Adding Hot Water
        public override string Adding_Hot_Water()
        {
            return "";
        }
        #endregion

        #region Stirring
        public override string Stirring()
        {
            return "Stirring...";
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            Ness_Coffee beverage;
            if (obj.GetType() == typeof(Ness_Coffee))
            {
                beverage = (Ness_Coffee)obj;
                return Price_Drink.Equals(beverage.Price_Drink);
            }
            else return false;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return $"Make your Ness Coffee!{base.ToString()}";
        }
        #endregion
    }
}
