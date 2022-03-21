﻿public class Us
{
    public double amount { get; set; }
    public string unitShort { get; set; }
    public string unitLong { get; set; }
}

public class Metric
{
    public double amount { get; set; }
    public string unitShort { get; set; }
    public string unitLong { get; set; }
}

public class Measures
{
    public Us us { get; set; }
    public Metric metric { get; set; }
}

public class ExtendedIngredient
{
    public int? id { get; set; }
    public string aisle { get; set; }
    public string image { get; set; }
    public string consistency { get; set; }
    public string name { get; set; }
    public string nameClean { get; set; }
    public string original { get; set; }
    public string originalName { get; set; }
    public double amount { get; set; }
    public string unit { get; set; }
    public List<string> meta { get; set; }
    public Measures measures { get; set; }
}

public class Ingredient
{
    public int id { get; set; }
    public string name { get; set; }
    public string localizedName { get; set; }
    public string image { get; set; }
}

public class Equipment
{
    public int id { get; set; }
    public string name { get; set; }
    public string localizedName { get; set; }
    public string image { get; set; }
}

public class Length
{
    public int number { get; set; }
    public string unit { get; set; }
}

public class Step
{
    public int number { get; set; }
    public string step { get; set; }
    public List<Ingredient> ingredients { get; set; }
    public List<Equipment> equipment { get; set; }
    public Length length { get; set; }
}

public class AnalyzedInstruction
{
    public string name { get; set; }
    public List<Step> steps { get; set; }
}

public class Recipe
{
    public bool vegetarian { get; set; }
    public bool vegan { get; set; }
    public bool glutenFree { get; set; }
    public bool dairyFree { get; set; }
    public bool veryHealthy { get; set; }
    public bool cheap { get; set; }
    public bool veryPopular { get; set; }
    public bool sustainable { get; set; }
    public int weightWatcherSmartPoints { get; set; }
    public string gaps { get; set; }
    public bool lowFodmap { get; set; }
    public int aggregateLikes { get; set; }
    public double spoonacularScore { get; set; }
    public double healthScore { get; set; }
    public string creditsText { get; set; }
    public string license { get; set; }
    public string sourceName { get; set; }
    public double pricePerServing { get; set; }
    public List<ExtendedIngredient> extendedIngredients { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public int readyInMinutes { get; set; }
    public int servings { get; set; }
    public string sourceUrl { get; set; }
    public string image { get; set; }
    public string imageType { get; set; }
    public string summary { get; set; }
    public List<object> cuisines { get; set; }
    public List<string> dishTypes { get; set; }
    public List<object> diets { get; set; }
    public List<object> occasions { get; set; }
    public string instructions { get; set; }
    public List<AnalyzedInstruction> analyzedInstructions { get; set; }
    public object originalId { get; set; }
    public string spoonacularSourceUrl { get; set; }
}

public class Meal
{
    public List<Recipe> recipes { get; set; }
    public Meal()
    {
        recipes = new List<Recipe>();
    }
}

[Serializable]
public class MealResult
{
    
    public int id { get; set; }   

    public string title { get; set; }

    public string imageType { get; set; }
}



