// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using BootCamp25;

Console.WriteLine("Welcome to the 2025 UITS Bootcamp\n-------Software Dev Track--------\n\n\n");

//string firstName = "John";
//string lastName = "Doeo";

//Console.WriteLine(firstName + " " +  lastName);

//Console.WriteLine($"{firstName} {lastName}");

//int age = 29;
//double height  = 30.82;


//Console.WriteLine($"Hello {firstName}, you're {age} years old and your height is " +
//    $"{height} cm");

//int numOfPens  = (int)10.9323;

//Console.WriteLine($"{ numOfPens } Pens");


//Taking Inputs

/*
Console.WriteLine("What is your name?");
string name = Console.ReadLine();
Console.WriteLine($"Good Morning {name}, how''re you doing today??");


Console.WriteLine("What is your age?");
//string ageString = Console.ReadLine();
int age = int.Parse( Console.ReadLine() );
Console.WriteLine($"I see, you'll be {age + 10} years next 10 years ");

*/

/*

Console.WriteLine("What is the first number");

int firstNum = int.Parse(Console.ReadLine());

Console.WriteLine("What is the second number");

int secondNum = int.Parse(Console.ReadLine());

int sum = firstNum  + secondNum;
int sub = firstNum - secondNum;
int mul = firstNum  * secondNum;

Console.WriteLine($"Num 1 is {firstNum}\nNum 2 is {secondNum}");

Console.WriteLine($"Sum is {sum}\n" +
    $"Difference is {sub}\n" +
    $"Product is {mul}");

*/

/*
int age = 31;

string nationality = "Ghanaian";

bool isGhanaian = nationality == "Ghanaian";

if (isGhanaian && age >= 18)
{
    Console.WriteLine("Happy Voting");
} else
{
    Console.WriteLine("Arrest HIM");
}
*/
/*
double CWA = 39.2;
if (CWA >= 70)
{
    Console.WriteLine("First Class.Congrats");
} else if (CWA >= 60)
{
    Console.WriteLine("Second Class Upper");
} else if (CWA >= 50)
{
    Console.WriteLine("Third Class");
}  else
{
    Console.WriteLine("GO HOME!!");
}*/

/*

int num1 = 10;
int num2 = 20;
int num3 = 30;
int num4 = 12;
int num5 = 13;


int number = num1;

if (number % 2 == 0)
{
    Console.WriteLine($"{number} is an Even number");
} else
{
    Console.WriteLine($"{number} is an Odd number");
}
*/


//LOOPS

//First 10 even numbers
/*
int count = 0;
int number = 1;

while (count < 10)
{
    if (number % 2 == 0)
    {
        Console.WriteLine(number);
        count++;
    }
    number++;
}
*/

// For loop for the first 10 odd numbers
/*
for (int i = 1; i <= 20; i++)
{
    if (i % 2 != 0)
    {
        Console.WriteLine(i);
    }
}
*/
/*
 string[] names = ["John", "Doe", "Jane", "Smith"];

//Console.WriteLine(names[names.Length - 1]);

int index = names.Length - 1;
while (index >= 0)
{
    Console.WriteLine(names[index]);
    index--;

}
*/

//MEthod to multiply two numbers
/*
int multiply(int num1, int num2)
{
    return num1 * num2;
}

Console.WriteLine(multiply(10, 20));
*/
//Method to check the maximum of three numbers

/*
int maximum(int num1, int num2, int num3)
{
    int max = num1;
    if (num2 > max)
    {
        max = num2;
    }
    if (num3 > max)
    {
        max = num3;
    }
    return max;
}

Console.WriteLine(maximum(70, 20, 30));

*/


//int[] nums = { 10, 20, 30,  50, 7 };


// Method to add the numbers in an array
/*
int sumArrayNumbers(int[] numbers)
{
    int sum = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        sum += numbers[i];
    }
    return sum;
}


Console.WriteLine(sumArrayNumbers(nums));
*/

//Method that accepts an integer and displays one to that number
/*
void displayOneToN(int n)
{
    for (int i = 1; i <= n; i++)
    {
        Console.WriteLine(i);
    }
}



displayOneToN(10);

*/


//Method that accepts an integer and displays that number down to zero
/*
void displayNtoZero(int n)
{
    for (int i = n; i >= 0; i--)
    {
        Console.WriteLine(i);
    }
}

displayNtoZero(100);
*/

/*
int[] numbers = { 10, 20, 30, 40, 50 };

int findMinimum(int[] nums)
{
    int min = nums[0];
    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i] < min)
        {
            min = nums[i];
        }
    }
    return min;
}

Console.WriteLine(findMinimum(numbers));

*/

/*

void recPerimeter(int lenght, int breadth)
{
    int perimeter = 2 *(lenght * breadth);

    Console.WriteLine($"The perimeter of a rectangle with lenght: {lenght} and breadth: {breadth} is {perimeter}");
}


recPerimeter(284, 62);


void factorial(int n)
{
    int prod = 1;

    if (n == 0)
    {
        prod = 1;
        
    }
    else
    {
        for (int i = 1; i <= n; i++)
        {
            prod *= i;
        }

    }


    Console.WriteLine(prod);


 }

factorial(0);

*/
/*
void reverseString (string letters)
{
    for (int i = letters.Length-1; i >= 0; i--)
    {
        Console.Write(letters[i]);
    }
}

reverseString("I was born a sinner");

*/

/*
//CLASSES
Square square = new Square(4);
square.Draw();



class Shape
{
    public int noOfSides;

    public Shape(int x)
    {
        noOfSides = x;
    }

    public virtual void Draw()
    {
        Console.WriteLine($"I am drawing a shape of {noOfSides} sides");
    }
}


class Square : Shape
{
    public Square(int x) : base(x) // pass sides to Shape constructor
    {
    }

    public override void Draw()
    {
        Console.WriteLine("I am drawing a Square");
    }
}
*/
DatabaseService dbService = new DatabaseService();

// 1. Add a Student
//int rows = dbService.AddStudent("Ava", "Zieglar", 21);
//Console.WriteLine(rows == 1 ? "✅ Student added successfully!" : "❌ Failed to add student.");
/*
// 2. Add a Course
dbService.AddCourse("Object-Oriented Programming", 3);

// 3. Add a Teacher
dbService.AddTeacher("John", "Doe", "Computer Science");

// 4. Add a Class (Course + Teacher)
// 👉 Make sure you know which CourseID and TeacherID were generated
// For now, we assume first records got ID=1
dbService.AddClass(1, 1, "Mon-Wed 10:00-11:30 AM");

// 5. Enroll the Student in the Course
// Again assuming first StudentID=1, CourseID=1
dbService.EnrollStudent(1, 1);

Console.WriteLine("✅ Sample records added successfully!");
*/

//dbService.GetAllStudents();

//Console.WriteLine("\n Students retrieved successfully!");

var enrollments = dbService.GetAllEnrollmentsDetailed();

foreach (var record in enrollments)
{
    Console.WriteLine(record);
}