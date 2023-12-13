//var internationalPizzaDay23 = new DateTime(2023, 2, 9);

//Console.WriteLine("year is " + internationalPizzaDay23.Year);
//Console.WriteLine("month is " + internationalPizzaDay23.Month);
//Console.WriteLine("day is " + internationalPizzaDay23.Day);
//Console.WriteLine("day of the week is " + internationalPizzaDay23.DayOfWeek);

//var internationalDayPizza24 = internationalPizzaDay23.AddYears(1);


//Console.WriteLine();
//Console.WriteLine("year is " + internationalDayPizza24.Year);
//Console.WriteLine("month is " + internationalDayPizza24.Month);
//Console.WriteLine("day is " + internationalDayPizza24.Day);
//Console.WriteLine("day of the week is " + internationalDayPizza24.DayOfWeek);

//Console.ReadKey();

//var rectangle1 = new Rectangle(5, 10);
//var rectangle2 = new Rectangle(50, 100);

//Console.WriteLine("Count of Rectangle object is " + Rectangle.CountOfInstances);


//Console.WriteLine("Width is " + rectangle1.Width);
//Console.WriteLine("Height is " + rectangle1.GetHeight());
//Console.WriteLine("Area is " + rectangle1.CalculateRectangleCircumference());
//Console.WriteLine("Circumference is " + rectangle1.CalculateRectangleCircumference());


//var calculator = new Calculator();

//Console.WriteLine($"1 + 2 is {Calculator.Add(1, 2)}");
//Console.WriteLine($"1 - 2 is {Calculator.Subtract(1, 2)}");
//Console.WriteLine($"1 * 2 is {Calculator.Multiply(1, 2)}");


//Console.ReadKey();
//class Calculator
//{
//	public static int Add(int a, int b) => a + b;
//	public static int Subtract(int a, int b) => a - b;
//	public static int Multiply(int a, int b) => a * b;
//}


//class Rectangle
//{
//	public readonly int Width;
//	private int _height;

//	public static int CountOfInstances { get; private set; }
//	private static DateTime _firstUsed;

//	static Rectangle()
//	{
//		_firstUsed = DateTime.Now;
//	}


//	public Rectangle(int width, int height)
//	{
//		Width = GetLengthOrDefault(width, nameof(Width));
//		_height = GetLengthOrDefault(height, nameof(_height));
//		++CountOfInstances;
//	}

//	public int GetHeight() => _height;

//	public void SetHeight(int value)
//	{
//		if (value > 0)
//		{
//			_height = value;
//		}
//	}
//	private int GetLengthOrDefault(int length, string name)
//	{
//		const int defaultValueIfPositive = 1;
//		if (length <= 0)
//		{
//			Console.WriteLine($"{name} must be a positive number.");
//			return defaultValueIfPositive;
//		}
//		return length;
//	}
//	public int CalculateRectangleCircumference() => 2 * Width + 2 * _height;

//	public int calculaterectanglearea() => Width * _height;
//}



//var medicalAppointment = new MedicalAppointment(
//    "John Smith", new DateTime(2023, 4, 3));

//simply reschedule
//medicalAppointment.Reschedule(new DateTime(2023, 4, 4));

//overwrite month and day
//medicalAppointment.Reschedule(5, 1);

//add a given number of months and days
//medicalAppointment.Reschedule(1, 2);

//var nameOnly = new MedicalAppointment("Name only");

//Console.ReadKey();

//class MedicalAppointmentPrinter
//{
//    public void Print(MedicalAppointment medicalAppointment)
//    {
//        Console.WriteLine("Appointment will take place on " + medicalAppointment.GetDate());
//    }
//}


//class MedicalAppointment
//{
//    private string _patientName;
//    private DateTime _date;

//    public MedicalAppointment(
//        string patientName, DateTime date)
//    {
//        _patientName = patientName;
//        _date = date;
//    }

//    public DateTime GetDate() => _date;

//    public MedicalAppointment(string patientName) :
//       this(patientName, 7)
//    {
//    }


//    public MedicalAppointment(string patientName = "Unknow", int daysFromNow = 7)
//    {
//        _patientName = patientName;
//        _date = DateTime.Now.AddDays(daysFromNow);
//    }

//    public void Reschedule(DateTime date)
//    {
//        _date = date;
//        var printer = new MedicalAppointmentPrinter();
//        printer.Print(this);
//    }

//    public void OverwriteMonthAndDay(int month, int day)
//    {
//        _date = new DateTime(_date.Year, month, day);
//    }

//    public void MoveByMonthsAndDays(int monthsToAdd, int daysToAdd)
//    {
//        _date = new DateTime(
//            _date.Year,
//            _date.Month + monthsToAdd,
//            _date.Day + daysToAdd);
//    }
//}

//public int CalculateCircumference() => 2 * Width + 2 * Height;

//public int CalculateArea() =>  Width* Height;

//Console.ReadKey();

//var person = new Person()
//{
//	Name = "John"
//};


//class Person
//{
//	public string Name { get; set; }
//	public int YearOfBirth { get; init; }

//public Person(string name, int yearOfBirth)
//{
//	Name = name;
//	YearOfBirth = yearOfBirth;
//}
//}

//var names = new Names();
//var path = names.BuildFilePath();
//if(File.Exists(path))
//{
//    Console.WriteLine("Names file already exists. Loading names.");
//	names.ReadFromTextFile();
//}
//else
//{
//    Console.WriteLine("Names file does not yet exist.");

//	//let's imagine they are given by the user
//	names.AddName("John");
//	names.AddName("not a valid name");
//	names.AddName("Claire");
//	names.AddName("123 definitely not a valid name");

//    Console.WriteLine("Saving names to a file.");

//    names.WriteToTextFile();

//}
//Console.WriteLine(names.Format());

//class Names
//{
//	private List<string> _names = new List<string>();

//	public void AddName(string name)
//	{
//		if (IsValidName(name))
//		{
//			_names.Add(name);
//		}
//	}



//	private bool IsValidName(string name)
//	{
//		return name.Length >= 2 &&
//			name.Length < 25 &&
//			char.IsUpper(name[0]) &&
//			name.All(char.IsLetter);
//	}

//	public void ReadFromTextFile()
//	{
//		var fileContents = File.ReadAllText(BuildFilePath());
//		var namesFromFile = fileContents.Split(Environment.NewLine).ToList();
//		foreach (var name in namesFromFile)
//		{
//			AddName(name);
//		}
//	}

//	public void WriteToTextFile()
//	{
//		File.WriteAllText(BuildFilePath(), Format());

//	}

//	public string BuildFilePath()
//	{
//		//we could imagine this is much more complicated,
//		//for example provided by the user and validated
//		return "names.txt";
//	}

//	public string Format()
//	{
//		return string.Join(Environment.NewLine, _names);
//	}
//}



//using OOP.DataAccess;
//using System.Diagnostics;

//var names = new Names();
//var path = new NamesFilePathBuilder().BuildFilePath();
//var stringsTextualRepository = new StringsTextualRepository();


//if (File.Exists(path))
//{
//	Console.WriteLine("Names file already exists. Loading names.");
//	var stringsFromnFile = stringsTextualRepository.Read(path);
//	names.AddNames(stringsFromnFile);
//}
//else
//{
//	Console.WriteLine("Names file does not yet exist.");

//let's imagine they are given by the user
//	names.AddName("John");
//	names.AddName("not a valid name");
//	names.AddName("Claire");
//	names.AddName("123 definitely not a valid name");

//	Console.WriteLine("Saving names to a file.");

//	stringsTextualRepository.Write(path, names.All);

//}
//Console.WriteLine(new NamesFormatter().Format(names.All));
//Console.ReadKey();



//class NamesFilePathBuilder
//{
//	public string BuildFilePath()
//{
//we could imagine this is much more complicated,
//for example provided by the user and validated
//		return "names.txt";
//	}
//}

//class NamesFormatter
//{
//	public string Format(List<string> names)
//	{
//		return string.Join(Environment.NewLine, names);
//	}
//}

//var pizza = new Pizza();

//pizza.AddIngredient(new Cheddar());
//pizza.AddIngredient(new Mozzarella());
//pizza.AddIngredient(new TomatoSause());

//Console.WriteLine(pizza.ToString());


//var ingredient = new Ingredient();
//ingredient.PublicField = 10;


//var cheddar = new Cheddar();
//cheddar.PublicField = 20;

//Console.WriteLine("Value in ingredient: " + ingredient.PublicField);
//Console.WriteLine("Value in cheddar: " + cheddar.PublicField);

//Console.WriteLine(cheddar.PublicMethod());
//Console.WriteLine(cheddar.ProtectedMethod());
////Console.WriteLine(cheddar.PrivateMethod());


//Console.WriteLine("Variable of type Cheddar");
//Cheddar cheddar = new Cheddar();
//Console.WriteLine(cheddar.Name);


//Console.WriteLine("Variable of type Ingredient");
//Ingredient ingredient = new Cheddar();
//Console.WriteLine(ingredient.Name);

//var ingredients = new List<Ingredient>
//{
//new Cheddar(),
//new Mozzarella(),
//new TomatoSause()
//};

//foreach (Ingredient ingredient in ingredients)
//{
//	Console.WriteLine(ingredient.Name);
//}

//var ingredient = new Ingredient(1);
//var cheddar = new Cheddar(2, 12);
//Console.WriteLine(cheddar);
//Ingredient ingredient = new Cheddar(2, 12);

//Ingredient randomIngredient = GenerateRandomIngredient();
//Console.WriteLine("Random ingredient is " + randomIngredient);

//Console.WriteLine("is object? " + (ingredient is object));
//Console.WriteLine("is ingredient? " + (ingredient is Ingredient));
//Console.WriteLine("is cheaddar? " + (ingredient is Cheddar));
//Console.WriteLine("is mozzarella? " + (ingredient is Mozzarella));
//Console.WriteLine("is tomato sause? " + (ingredient is TomatoSause));


//if (randomIngredient is Cheddar cheddar)
//{
//	Console.WriteLine("cheddar object: " + cheddar);
//}

//var pizza = new Pizza();
//Console.WriteLine(pizza.ingredient);

//Ingredient nullIngredient = null;

//if(nullIngredient != null)
//{

//}

//if (nullIngredient is not null)
//{
//	Console.WriteLine(nullIngredient.Name);
//}

//Ingredient ingredient = GenerateRandomIngredient();
//Console.WriteLine("Ingredient is " + ingredient);

//Cheddar cheddar = ingredient as Cheddar;
//Cheddar cheddar = ingredient as Cheddar;

//if (cheddar is not null)
//{
//	Console.WriteLine(cheddar.Name);
//}
//else
//{
//	Console.WriteLine("Conversion failed");
//}

using OOP.Extensions;
using System.Threading.Channels;

//Ingredient ingredient = new Ingredient(1);

var cheddar = new Cheddar(2, 12);
var tomatoSauce = new TomatoSause(1);
cheddar.Prepare();
tomatoSauce.Prepare();

var ingredients = new List<Ingredient>
{
	new Cheddar(2,10),
	new Mozzarella(2),
	new TomatoSause(2),
};

foreach (var ingredient in ingredients)
{
	ingredient.Prepare();
}


var pizza = RandomPizzaGenerator.Generate(3);

//var multiLineText = @"aaaa
//bbbb
//cccc
//dddd";

//Console.WriteLine("Count of lines is " + multiLineText.CountLines());
//Console.WriteLine("Count of lines is " + StringExtensions.CountLines(multiLineText));

//Console.WriteLine("Next after spring is " + Season.Spring.Next());
//Console.WriteLine("Next after winter is " + Season.Winter.Next());

var bakeAbleDishes = new List<object>
{
new Pizza(),
new Panettone()

};

foreach(var bakeAbleDish in bakeAbleDishes)
{
    Console.WriteLine(bakeAbleDish.GetInstructions());
}

Console.ReadKey();

public abstract class Dessert { }

public abstract class Bakeable
{
	public abstract string GetInstructions();
}

public class Panettone : Dessert
{

}




public static class RandomPizzaGenerator
{
	public static Pizza Generate(int howManyIngredients)
	{
		var pizza = new Pizza();
		for (int i = 0; i < howManyIngredients; ++i)
		{
			var randomIngredient = GenerateRandomIngredient();
			pizza.AddIngredient(randomIngredient);
		}

		return pizza;
	}

	private static Ingredient GenerateRandomIngredient()
	{
		var random = new Random();
		var number = random.Next(1, 4);
		if (number == 1) { return new Cheddar(2, 12); }
		if (number == 2) { return new TomatoSause(1); }
		else return new Mozzarella(2);
	}
}

//public class SpecialRandomPizzaGenerator : RandomPizzaGenerator
//{

//}


public class Pizza
{
	//public Ingredient ingredient;

	private List<Ingredient> _ingredients = new List<Ingredient>();

	public void AddIngredient(Ingredient ingredient) =>
		_ingredients.Add(ingredient);


	public override string ToString() => $"This is a pizza with {string.Join(", ", _ingredients)}";
}

public abstract class Ingredient
{
	public Ingredient(int priceIfExtraTopping)
	{
		Console.WriteLine("Constructor from the Ingredient class");
		PriceIfExtraTopping = priceIfExtraTopping;
	}
	public int PriceIfExtraTopping { get; }
	public override string ToString() => Name;
	public virtual string Name { get; } = "Some ingredient";

	public abstract void Prepare();

	public int PublicField;

	public string PublicMethod() =>
		"This method is PUBLIC in the Ingredient class.";

	protected string ProtectedMethod() =>
		"This method is PROTECTED in the Ingredient class.";

	private string PrivateMethod() =>
		"This method is PRIVATE in the Ingredient class.";
}

public abstract class Cheese : Ingredient
{
	public Cheese(int priceIfExtraTopping) : base(priceIfExtraTopping)
	{
	}
}

public class ItalianFoodItem
{
}


public class Cheddar : Cheese
{
	public Cheddar(int priceIfExtraTopping, int agedForMonths) : base(priceIfExtraTopping)
	{
		AgedForMonths = agedForMonths;
		Console.WriteLine("Constructor from the Cheddar class");
	}
	public override string Name =>
		$"{base.Name}, more specifically, " +
		$"a Cheddar cheese aged for {AgedForMonths} months";
	public int AgedForMonths { get; }

	public override void Prepare() =>
		Console.WriteLine("Grate and sprikle over pizza.");


	public void UseMethodsFromBaseClass()
	{
		Console.WriteLine(PublicMethod());
		Console.WriteLine(ProtectedMethod());
		//Console.WriteLine(PrivateMethod());
	}
}

public class TomatoSause : Ingredient
{
	public TomatoSause(int priceIfExtraTopping) : base(priceIfExtraTopping)
	{
	}

	public override string Name => "Tomato sause";
	public int TomatosIn100Grams { get; }

	public override void Prepare() =>
		Console.WriteLine("Cock tomatoes with basil, garlic and salt." +
			"Spread on pizza.");
}

public class SpecialTomatoSause : TomatoSause
{
	public SpecialTomatoSause(int priceIfExtraTopping) : base(priceIfExtraTopping)
	{
	}

	public override void Prepare() =>

		Console.WriteLine("Special tomato sause");
}

//public class MyBetterString : string
//{

//}



public class Mozzarella : Cheese
{
	public Mozzarella(int priceIfExtraTopping) : base(priceIfExtraTopping)
	{
	}

	public override string Name => "Mozzarella";
	public bool IsLight { get; }

	public override void Prepare() =>

		Console.WriteLine("Slice thinly and place on top of the pizza.");
}

//var numbers = new List<int> { 1, 4, 6, -1, 12, 44, -8, -19 };
//bool shallAddPositiveOnly = true;

//NumbersSumCalculator calculator =
//	shallAddPositiveOnly ?
//	new PositiveNumbersSumCalculator() :
//	new NumbersSumCalculator();

//int sum = calculator.Calculate(numbers);

//Console.WriteLine("Sum is: " + sum);
//Console.ReadKey();

//public class NumbersSumCalculator
//{
//	public int Calculate(List<int> numbers)
//	{
//		int sum = 0;
//		foreach (var number in numbers)
//		{
//			if (ShallBeAdded(number))
//			{
//				sum += number;
//			}
//		}
//		return sum;
//	}

//	protected virtual bool ShallBeAdded(int number)
//	{
//		return true;
//	}
//}

//public class PositiveNumbersSumCalculator : NumbersSumCalculator
//{
//	protected override bool ShallBeAdded(int number)
//	{
//		return number > 0;
//	}
//}

//namespace Coding.Exercise
//{
//	public class Exercise
//	{
//		public List<int> GetCountsOfAnimalsLegs()
//		{
//			var animals = new List<Animal>
//			{
//				new Lion(),
//				new Tiger(),
//				new Duck(),
//				new Spider()
//			};

//			var result = new List<int>();
//			foreach (var animal in animals)
//			{
//				result.Add(animal.NumberOfLegs);
//			}
//			return result;
//		}
//	}



//	public class Animal
//	{
//		public virtual int NumberOfLegs { get; } = 4;
//	}

//	public class Lion : Animal
//	{
//		// Lion has the same number of legs as the base Animal class (4 legs)
//	}

//	public class Tiger : Animal
//	{
//		// Tiger has the same number of legs as the base Animal class (4 legs)
//	}

//	public class Duck : Animal
//	{
//		public override int NumberOfLegs => 2;
//	}

//	public class Spider : Animal
//	{
//		public override int NumberOfLegs => 8;
//	}
//}





//namespace Coding.Exercise
//{
//	public class Exercise
//	{
//		public List<string> ProcessAll(List<string> words)
//		{
//			var stringsProcessors = new List<StringsProcessor>
//				{
//					new StringsTrimmingProcessor(),
//					new StringsUppercaseProcessor()
//				};

//			List<string> result = words;
//			foreach (var stringsProcessor in stringsProcessors)
//			{
//				result = stringsProcessor.Process(result);
//			}
//			return result;
//		}

//		public class StringsProcessor
//		{
//			public virtual List<string> Process(List<string> input)
//			{
//				return input;
//			}
//		}

//		public class StringsTrimmingProcessor : StringsProcessor
//		{
//			public override List<string> Process(List<string> input)
//			{
//				List<string> result = new List<string>();

//				foreach (var str in input)
//				{
//					int length = str.Length / 2;
//					result.Add(str.Substring(0, length));
//				}

//				return result;
//			}
//		}

//		public class StringsUppercaseProcessor : StringsProcessor
//		{
//			public override List<string> Process(List<string> input)
//			{
//				List<string> result = new List<string>();

//				foreach (var str in input)
//				{
//					result.Add(str.ToUpper());
//				}

//				return result;
//			}
//		}
//	}
//}


//int seasonNumber = 0;
//Season spring = (Season)seasonNumber;

////decimal a = 10.01m;

//int integer = 10;
//decimal b = integer;

////decimal c = 100000000000000000000000.01m;
////int d = (int)c;

//int secondSeasonNumber = 11;
//Season summer = (Season)secondSeasonNumber;
//Console.WriteLine(summer);

//Console.ReadKey();

//public enum Season
//{
//	Spring,
//	Summer,
//	Autumn,
//	Winter
//}
