using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Drinks_Vending_Machine__.Classes
{
     public  class Tea : Beverage
    {
        public Tea(string beverage_Name, float beverage_Price, string image_Source, string[] array_Ingredients)
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
            return "Water: 180 ml, 90 c";
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
            Tea beverage;
            if (obj.GetType() == typeof(Tea))
            {
                beverage = (Tea)obj;
                return Price_Drink.Equals(beverage.Price_Drink);
            }
            else return false;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return $"Make your Tea!{base.ToString()}";
        }
        #endregion
    }
}
