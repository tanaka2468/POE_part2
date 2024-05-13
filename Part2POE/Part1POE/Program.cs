internal class Program
{
    private static void Main(string[] args)
    {
       Recipe recipe = new Recipe();
        while (true)
        {
            Console.WriteLine("=====================");
            Console.WriteLine("Enter 1 to enter recipe details");
            Console.WriteLine("Enter 2 to Dispaly Recipe");
            Console.WriteLine("Enter 3 to Scale Recipe");
            Console.WriteLine("Enter 4 to Reset Quantities");
            Console.WriteLine("Enter 5 to Clear Recipes");
            Console.WriteLine("Enter 6 to Exit ");
            Console.WriteLine("===============================");
            string ans = Console.ReadLine();
            switch(ans)
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
                    Environment.Exit(1);
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

    public Recipe()
    {
        ingredients = new String[0];
        amount = new double[0];
        units = new String[0];
        steps = new String[0];
    }

    public void EnterData()
    {
        Console.WriteLine("Enter number of Ingredients");
        int ingrNum = Convert.ToInt32(Console.ReadLine());

        ingredients = new string[ingrNum];
        amount = new double[ingrNum];
        units = new String[ingrNum];

        for (int i = 0; i < ingrNum; i++)
        {
            Console.WriteLine($"Enter ingredient details#{i + 1}:");
            Console.Write("Name:");
            ingredients[i] = Console.ReadLine();
            Console.Write("Quantiy");
            amount[i] = Convert.ToDouble(Console.ReadLine());
            Console.Write("units of measurements");
            units[i] = Console.ReadLine();
        }

        Console.WriteLine("Enter Number of Steps:");
        int stpNum = Convert.ToInt32(Console.ReadLine());
        steps = new String[stpNum];

        for (int a = 0; a < stpNum; a++)
        {
            Console.Write($"Steps#{a + 1}:");
            steps[a] = Console.ReadLine();
        }
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
    }
    public void RecipeScale(double scale)
    {
        for (int i = 0; i < amount.Length; i++)
        {
            amount[i]*=scale;
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
