﻿internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, Recipe> dictionaryRecipe = new Dictionary<string, Recipe>();
        Appmenu menu = new Appmenu(dictionaryRecipe);
        menu.appMenu();
    }

}
class recipeLogger
{
    private Dictionary<string,Recipe> dictionaryRecipe;
    public recipeLogger(Dictionary<string,Recipe>dictionaryRecipe)
    {
        this.dictionaryRecipe = dictionaryRecipe;
    }
    public void logDetails()
    {
        Console.WriteLine("Enter the number of Recipes:");
        int recipeNum;
        if(int.TryParse(Console.ReadLine(),out recipeNum))
        {
            for(int i = 0;i< recipeNum;i++)
            {
                Console.Write("Enter Recipe Name:");
                String recipeNmae = Console.ReadLine();
                Recipe recipe = new Recipe();
                recipe.EnterData();
                dictionaryRecipe.Add(recipeNmae, recipe);
            }
            String ans;
            do
            {
                Console.WriteLine("Display Ingredients and steps?(Y/N)");
                ans = Console.ReadLine();
                switch (ans)
                {
                    case "Y":
                        foreach (var recipeEntry in dictionaryRecipe)
                        {
                            Console.WriteLine($"Recipe Name:{recipeEntry.Key}");
                            recipeEntry.Value.RecipeDisplay();
                        }
                        break;
                    case "N":
                        Appmenu menu = new Appmenu(dictionaryRecipe);
                        menu.appMenu();
                        break;
                        default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                }
            } while (ans != "N");
        }
        else
        {
            Console.WriteLine("Please enter a number");
        }
    }

    public void recipeList()
    {
        foreach(var recipeEntry in dictionaryRecipe)
        {
            Console.WriteLine($"Recipe Name:{recipeEntry.Key}");    
        }
    }
    public void recipeFinder()
    {
        Console.Write("Please enter the name of the Recipe:");
        string recipeName = Console.ReadLine();
        if (dictionaryRecipe.ContainsKey(recipeName))
        {
            Console.WriteLine($"Recipe Name:{recipeName}");
            dictionaryRecipe[recipeName].RecipeDisplay();
        }
        else
        {
            Console.WriteLine("Recipe does not eixst");
        }
    }
}
class ingredientMenu
{
    private Dictionary<string, Recipe> dictionaryRecipe;
    public ingredientMenu(Dictionary<string, Recipe> dictionaryRecipe)
    {
        this.dictionaryRecipe = dictionaryRecipe;
        Recipe recipe = new Recipe();
        while (true)
        {
            Console.WriteLine("=====================");
            Console.WriteLine("Enter 1 to enter recipe details");
            Console.WriteLine("Enter 2 to Dispaly Recipe");
            Console.WriteLine("Enter 3 to Scale Recipe");
            Console.WriteLine("Enter 4 to Reset Quantities");
            Console.WriteLine("Enter 5 to Clear Recipes");
            Console.WriteLine("Enter 6 to go back to main menu");
            Console.WriteLine("===============================");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "1":
                    recipe.EnterData();
                    break;
                case "2":
                    recipe.RecipeDisplay();
                    break;
                case "3":
                    Console.WriteLine("Enter a scale of 0.5 , 2 or 3");
                    double scale1 = Convert.ToDouble(Console.ReadLine());
                    recipe.RecipeScale(scale1);
                    break;
                case "4":
                    recipe.ResetRecipe();
                    break;
                case "5":
                    recipe.ClearRecipe();
                    break;
                case "6":
                    Appmenu appMenu = new Appmenu(dictionaryRecipe);
                    appMenu.appMenu();
                    break;
                default:
                    Console.WriteLine("Wrong value. Please try again");
                    break;






            }

        }

    }

}

class Recipe
{
    private String[] ingredients;
    private double[] amount;
    private String[] units;
    private String[] steps;
    private double[] calories;
    private String[] foodGroup;
    public Recipe()
    {
        ingredients = new String[0];
        amount = new double[0];
        units = new String[0];
        steps = new String[0];
        calories = new double[0];
        foodGroup = new String[0];
    }

    public void EnterData()
    {
        Console.WriteLine("Enter number of Ingredients");
        int ingrNum = Convert.ToInt32(Console.ReadLine());

        ingredients = new string[ingrNum];
        amount = new double[ingrNum];
        units = new String[ingrNum];
        calories = new double[ingrNum];
        foodGroup = new string[ingrNum];

        for (int i = 0; i < ingrNum; i++)
        {
            Console.WriteLine($"Enter ingredient details#{i + 1}:");
            Console.Write("Name:");
            ingredients[i] = Console.ReadLine();
            do
            {
                Console.Write("Quantity:");
            } while (!double.TryParse(Console.ReadLine(), out amount[i]));
            Console.Write("units of measurements");
            units[i] = Console.ReadLine();
            do
            {
                Console.Write("Number of calories:");
            } while (!double.TryParse(Console.ReadLine(), out calories[i]));

            Console.Write("Enter foodGroup:");
            foodGroup[i] = Console.ReadLine();

        }
        //Delegation
        double calExceed = calTotal(calories);
        Console.WriteLine("TOTAL CALORIES:" + calExceed);
        if (calExceed > 300)
        {
            Console.WriteLine("!!!Total calories exceed 300!!!");
            
        }
        int stpNum;
        do
        {
            Console.WriteLine("Enter Number of Steps:");
        } while (!int.TryParse(Console.ReadLine(), out stpNum));
        
        
        steps = new String[stpNum];

        for (int a = 0; a < stpNum; a++)
        {
            Console.Write($"Steps#{a + 1}:");
            steps[a] = Console.ReadLine();
        }
    }

    public double calTotal(double[]calories)
    {
        double result = 0;
        for(int i = 0;i < calories.Length;i++)
        {
            result += calories[i];
        }
        return result;
    }
       
        
    public void RecipeDisplay()
    {
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < ingredients.Length; i++)
        {
            Console.WriteLine($" -{amount[0]}{units[0]} of{ingredients[0]}");
        }
        Console.WriteLine("Steps:");
        for (int a = 0; a < steps.Length; a++)
        {
            Console.WriteLine($" -{steps[0]}");
        }
        double result = 0;
        for (int i = 0; i < calories.Length; i++)
        {
            result += calories[i];
        }

        if (result> 300)
        {
            Console.WriteLine("!!!Total calories exceed 300!!!");

        }


    }
    public void RecipeScale(double scale)
    {
        for (int i = 0; i < amount.Length; i++)
        {
            amount[i] *= scale;
        }
    }
    public void ResetRecipe()
    {
        for (int i = 0; i < amount.Length; i++)
        {
            amount[i] /= 2;
        }
    }
    public void ClearRecipe()
    {
        ingredients = new String[0];
        amount = new double[0];
        units = new String[0];
        steps = new String[0];
    }




}
class Appmenu
{
    private Dictionary<string, Recipe> dictionaryRecipe;
    private recipeLogger repL;
    public Appmenu(Dictionary<string, Recipe> dictionaryRecipe)
    {
        this.dictionaryRecipe = dictionaryRecipe;
        repL= new recipeLogger(dictionaryRecipe);

    }
    public void appMenu()
    {
        while(true)
        {
            Console.WriteLine("===================");
            Console.WriteLine("RECIPE APP");
            Console.WriteLine("===================");
            Console.WriteLine("1) Create Recipe");
            Console.WriteLine("2) Search for Recipe");
            Console.WriteLine("3) Display All Recipe");
            Console.WriteLine("4) Exit Application");
            Console.WriteLine("=====================");
            Console.WriteLine("Please Select an Option:");
            string ans = Console.ReadLine();
            switch(ans)
            {
                case "1":
                    repL.logDetails();
                    break;
                case "2":
                    repL.recipeFinder();
                    break;
                    case "3":
                    repL.recipeList();
                    break; ;
                    case "4":
                    Environment.Exit(0);
                    break;
                    default:
                    Console.WriteLine("Please enter a valid input");
                    break;

            }
        }
         

        
    }
}

