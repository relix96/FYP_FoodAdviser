using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdviserModels.Models
{
    public class Filter
    {
        public enum Diet
        {
            GlutenFree,
            Ketogenic,
            Vegetarian,
            LactoVegetarian,
            OvoVegetarian,
            Vegan,
            Pescetarian,
            Paleo,
            Primal,
            LowFODMAP,
            Whole30
        }

        public enum Intolerance
        {
            Dairy,
            Peanut,
            Soy,
            Egg,
            Seafood,
            Sulfite,
            Gluten,
            Sesame,
            TreeNut,
            Grain,
            Shellfish,
            Wheat
        }

        public enum Cuisine
        {
            African,
            American,
            British,
            Cajun,
            Caribbean,
            Chinese,
            EasternEuropean,
            European,
            French,
            German,
            Greek,
            Indian,
            Irish,
            Italian,
            Japanese,
            Jewish,
            Korean,
            LatinAmerican,
            Mediterranean,
            Mexican,
            MiddleEastern,
            Nordic,
            Southern,
            Spanish,
            Thai,
            Vietnamese
        }

        public enum Type
        {
            MainCourse,
            SideDish,
            Dessert,
            Appetizer,
            Salad,
            Bread,
            Breakfast,
            Soup,
            Beverage,
            Sauce,
            Marinade,
            Fingerfood,
            Snack,
            Drink
        }
    }
}
