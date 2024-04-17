if (int.TryParse(Console.ReadLine(), out int a))
{

}
else
{
    Console.WriteLine("Error!");
    return;
}

if (int.TryParse(Console.ReadLine(), out int b))
{

}
else
{
    Console.WriteLine("Error!");
    return;
}

char s;
s = Console.ReadKey().KeyChar;
if (s is not '&' and not '^' and not '|')
{
    Console.WriteLine("Error!");
    return;
}

switch (s)
{
    case '&':
        Console.WriteLine(a & b);
        Console.WriteLine(Convert.ToString(a & b, 2));
        Console.WriteLine(Convert.ToString(a & b, 16));
        break;
    case '^':
        Console.WriteLine(a ^ b);
        int w = (a ^ b);
        Console.WriteLine(Convert.ToString(a ^ b, 2));
        Console.WriteLine(Convert.ToString(a ^ b, 16));
        break;
    case '|':
        Console.WriteLine(a | b);
        Console.WriteLine(Convert.ToString(a | b, 2));
        Console.WriteLine(Convert.ToString(a | b, 16));
        break;
    default:
        Console.WriteLine("Wrong sign!");
        break;
}