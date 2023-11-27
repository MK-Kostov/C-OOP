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

var rectangle1 = new Rectangle(5, 10);
var rectangle2 = new Rectangle(50, 100);

Console.WriteLine("Count of Rectangle object is " + Rectangle.CountOfInstances);


Console.WriteLine("Width is " + rectangle1.Width);
Console.WriteLine("Height is " + rectangle1.GetHeight());
Console.WriteLine("Area is " + rectangle1.CalculateRectangleCircumference());
Console.WriteLine("Circumference is " + rectangle1.CalculateRectangleCircumference());


var calculator = new Calculator();

Console.WriteLine($"1 + 2 is {Calculator.Add(1, 2)}");
Console.WriteLine($"1 - 2 is {Calculator.Subtract(1, 2)}");
Console.WriteLine($"1 * 2 is {Calculator.Multiply(1, 2)}");


Console.ReadKey();
class Calculator
{
	public static int Add(int a, int b) => a + b;
	public static int Subtract(int a, int b) => a - b;
	public static int Multiply(int a, int b) => a * b;
}


class Rectangle
{
	public readonly int Width;
	private int _height;

	public static int CountOfInstances { get; private set; }
	public Rectangle(int width, int height)
	{
		Width = GetLengthOrDefault(width, nameof(Width));
		_height = GetLengthOrDefault(height, nameof(_height));
		++CountOfInstances;
	}

	public int GetHeight() => _height;

	public void SetHeight(int value)
	{
		if (value > 0)
		{
			_height = value;
		}
	}
	private int GetLengthOrDefault(int length, string name)
	{
		const int defaultValueIfPositive = 1;
		if (length <= 0)
		{
			Console.WriteLine($"{name} must be a positive number.");
			return defaultValueIfPositive;
		}
		return length;
	}
	public int CalculateRectangleCircumference() => 2 * Width + 2 * _height;

	public int calculaterectanglearea() => Width * _height;
}



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



