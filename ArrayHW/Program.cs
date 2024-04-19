
int[] array1 = new int[8] {0, 1, 1, 2, 3, 5, 8, 13};

string[] array2 = new string[12] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

int[,] array3 = new int[3, 3]
    {
    {2, 3, 4 },
    {4, 9, 16 },
    {8, 27, 64 }
    };

double[][] jaggedArray = new double[3][];
jaggedArray[0] = [1, 2, 3, 4, 5];
jaggedArray[1] = [Math.E, Math.PI];
jaggedArray[2] = [Math.Log10(1), Math.Log10(10), Math.Log10(100), Math.Log10(1000)];

int[] array4 = { 1, 2, 3, 4, 5 };

int[] array5 = { 7, 8, 9, 10, 11, 12, 13 };

Array.Copy(array4, array5, 3);

Console.WriteLine(array5[3]);

Array.Resize(ref array4, 9);

foreach (var a in array4)
{
    Console.WriteLine(a);
}

