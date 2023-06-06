using System.Collections.Generic;

public class FoodItem
{
    public string Name { get; set; }
    public double Calories { get; set; }
}

public class CaloriesCalculator
{
    public List<FoodItem> FoodItems { get; set; }

    public CaloriesCalculator()
    {
        FoodItems = new List<FoodItem>();
    }

    public void AddFoodItem(FoodItem item)
    {
        FoodItems.Add(item);
    }

    public double CalculateTotalCalories()
    {
        double totalCalories = 0;
        for (int i = 0; i < FoodItems.Count; i++)
        {
            totalCalories += FoodItems[i].Calories;
        }
        return totalCalories;
    }
}