//Задание 1
var a = 0;
var b = 1;
var c = 0;
Console.Write("{0} {1}", a,"\n", b);

for (int index = 0; index <= 7; index++)
{
    c = a + b;
    Console.WriteLine("{0}", c);
    a = b;
    b = c;
}

Console.WriteLine("\n");
//Задание 2
for (int i = 2; i <= 20; i += 2)
{
    Console.WriteLine("{0}", i);
}

Console.WriteLine("\n");
//Задание 3
for (int x = 1; x <= 5; x++)
{
    for (int y = 1; y <= 5; y++)
    {
        Console.Write(x * y);
        Console.Write("\t");
    }
    Console.WriteLine("\n");
}

Console.WriteLine("\n");
//Задание 4
string password = "qwerty";
Console.WriteLine("Enter password");
var attempt = "";
do
{
    attempt = Console.ReadLine();
      if (attempt != password)
    {
        Console.WriteLine("Wrong password");
    }
}
while (attempt != password);
Console.WriteLine("Correct password");

