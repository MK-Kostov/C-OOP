using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;
using System.Security.Cryptography.X509Certificates;

var ingredientsRegister = new IngredientsRegister();

var cookiesRecipesApp = new CookiesRecipesApp(
	new RecipesRepository(
		new StringsTextualRepository(),
		ingredientsRegister),
	new RecipesConsoleUserInteraction(
		ingredientsRegister));

cookiesRecipesApp.Run("recipes.txt");

public class CookiesRecipesApp
{

	private readonly IRecipesRepository _recipesRepository;
	private readonly IRecipesUserInteraction _recipesUserInteraction;
	public CookiesRecipesApp(
		IRecipesRepository recipesRepository,
		IRecipesUserInteraction recipesUserInteraction)
	{
		_recipesRepository = recipesRepository;
		_recipesUserInteraction = recipesUserInteraction;
	}
	public void Run(string filePath)
	{
		var allRecipes = _recipesRepository.Read(filePath);
		_recipesUserInteraction.PrintExistingRecipes(allRecipes);

		_recipesUserInteraction.PromptToCreateRecipe();

		var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

		if (ingredients.Count() > 0)
		{
			var recipe = new Recipe(ingredients);
			allRecipes.Add(recipe);
			_recipesRepository.Write(filePath, allRecipes);

			_recipesUserInteraction.ShowMessage("Recipe added: ");
			_recipesUserInteraction.ShowMessage(recipe.ToString());
		}
		else
		{
			_recipesUserInteraction.ShowMessage("No ingredients have been selected. " + "Recipe will not be saved.");
		}

		_recipesUserInteraction.Exit();

	}
}

public interface IRecipesUserInteraction
{
	void ShowMessage(string message);
	void Exit();
	void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
	void PromptToCreateRecipe();
	IEnumerable<Ingredient> ReadIngredientsFromUser();
}

public interface IIngredientsRegister
{
	IEnumerable<Ingredient> All { get; }

	Ingredient GetById(int id);
}

public class IngredientsRegister : IIngredientsRegister
{
	public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
	{
		new WheatFlour(),
		new SpeltFlour(),
		new Butter(),
		new Chocolate(),
		new Sugar(),
		new Cardamom(),
		new Cinnamon(),
		new CocoaPowder()
	};

	public Ingredient GetById(int id)
	{
		foreach (var ingredient in All)
		{
			if (ingredient.Id == id)

			{
				return ingredient;
			}
		}
		return null;
	}
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
	private readonly IIngredientsRegister _ingredientsRegister;

	public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
	{
		_ingredientsRegister = ingredientsRegister;
	}

	public void ShowMessage(string message)
	{
		Console.WriteLine(message); ;
	}
	public void Exit()
	{
		Console.WriteLine("Press any key to close.");
		Console.ReadKey();
	}

	public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
	{
		if (allRecipes.Count() > 0)
		{
			Console.WriteLine("Existing recipes are:" + Environment.NewLine);

			var counter = 1;
			foreach (var recipe in allRecipes)
			{
				Console.WriteLine($"*****{counter}*****");
				Console.WriteLine(recipe);
				Console.WriteLine();
				counter++;
			}
		}
	}

	public void PromptToCreateRecipe()
	{
		Console.WriteLine("Create a new cookie recipe! " +
			"Available ingredients are: ");

		foreach (var ingredient in _ingredientsRegister.All)
		{
			Console.WriteLine(ingredient);
		}
	}

	public IEnumerable<Ingredient> ReadIngredientsFromUser()
	{
		bool shallStop = false;
		var ingredients = new List<Ingredient>();

		while (!shallStop)
		{
			Console.WriteLine("Add an ingredient by its ID, " +
				"or type anything else if finished.");

			var userInput = Console.ReadLine();

			if (int.TryParse(userInput, out int id))
			{
				var selectedIngredient = _ingredientsRegister.GetById(id);
				if (selectedIngredient is not null)
				{
					ingredients.Add(selectedIngredient);
				}
			}
			else
			{
				shallStop = true;
			}

		}

		return ingredients;
	}
}

public interface IRecipesRepository
{
	List<Recipe> Read(string filePath);
	void Write(string filePath, List<Recipe> allRecipes);
}
public class RecipesRepository : IRecipesRepository
{
	private readonly IStringsRepository _stringsRepository;
	private readonly IIngredientsRegister _ingredientsRegister;
	private const string Separator = ", ";

	public RecipesRepository(
		IStringsRepository stringsRepository,
		IIngredientsRegister ingredientsRegister)
	{
		_stringsRepository = stringsRepository;
		_ingredientsRegister = ingredientsRegister;
	}

	public List<Recipe> Read(string filePath)
	{
		List<string> recipesFromFile = _stringsRepository.Read(filePath);
		var recipes = new List<Recipe>();

		foreach (var recipeFromFile in recipesFromFile)
		{
			var recipe = RecipeFromString(recipeFromFile);
			recipes.Add(recipe);
		}
		return recipes;
	}

	private Recipe RecipeFromString(string recipeFromFile)
	{
		var ingredients = recipeFromFile.Split(Separator)
			.Select(int.Parse)
			.Select(_ingredientsRegister.GetById);

		return new Recipe(ingredients);

	}

	public void Write(string filePath, List<Recipe> allRecipes)
	{
		var recipesAsStrings = allRecipes.Select(recipe =>
		{
			var allIds = recipe.Ingredients.Select(ingredient => ingredient.Id);
			return string.Join(Separator, allIds);
		});

		_stringsRepository.Write(filePath, recipesAsStrings.ToList());
	}
}

public interface IStringsRepository
{
	List<string> Read(string filePath);
	void Write(string filePath, List<string> strings);
}

public class StringsTextualRepository : IStringsRepository
{
	private static readonly string Seperator = Environment.NewLine;

	public List<string> Read(string filePath)
	{
		if (File.Exists(filePath))
		{
			var fileContents = File.ReadAllText(filePath);
			return fileContents.Split(Seperator).ToList();
		}
		return new List<string>();
	}

	public void Write(string filePath, List<string> strings)
	{
		File.WriteAllText(filePath, string.Join(Seperator, strings));
	}
}
