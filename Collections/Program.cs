using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1,2 or 3 to check task 1,2 or 3");
            int task;
            int.TryParse(Console.ReadLine(), out int value);
            {
                task = value;
            }

            switch (task)
            {
                case 1:
                    CheckTaskFirst(); 
                    break;
                case 2:
                    CheckTaskSecond(); 
                    break;
                case 3:
                    CheckTaskThird();
                    break;
                default:
                    Console.WriteLine("Wrong task number");
                    break;
            }
        }
        private static void CheckTaskFirst()
        {
            var listTask = new ListTask();
            listTask.TaskLoop();
        }

        private static void CheckTaskSecond()
        {
            var dictionaryTask = new DictionaryTask();
            dictionaryTask.TaskLoop();
        }

        private static void CheckTaskThird()
        {
            var linkedListTask = new LinkedListTask();
            linkedListTask.TaskLoop();
        }

        private class ListTask
        {
            private readonly List<string> _testList = new List<string>() { "Mango", "Pineapple", "Banana" };
            public void TaskLoop()
            {
                string endProgram;
                do
                {
                    Console.WriteLine("Name a tropical fruit");
                    string userInput = Console.ReadLine();
                    _testList.Add(userInput);

                    for (int i = 0; i < _testList.Count; i++)
                    {
                        Console.WriteLine(_testList[i]);
                    }

                    Console.WriteLine("To end the program type \"exit\"");
                    endProgram = Console.ReadLine();
                } while (endProgram != "exit");
            }
        }

        private class DictionaryTask
        {
            private readonly Dictionary<string, float> _students = new Dictionary<string, float>();
            public void TaskLoop()
            {
                string endProgram;
                do
                {
                    Console.WriteLine("Enter the student's name ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the student's grade(from 2 to 5): ");
                    float grade;

                    if (float.TryParse(s: Console.ReadLine(), out float value) == true && value >= 2f && value <= 5f)
                    {
                        grade = value;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect value assigned to grade");
                        return;
                    }

                    _students.Add(name, grade);
                    Console.WriteLine("Write student's name:");
                    string checkName = Console.ReadLine();

                    if (_students.TryGetValue(checkName, out value) == true)
                    {
                        Console.WriteLine("{0} has a grade of {1}", checkName, value);
                    }
                    else
                    {
                        Console.WriteLine("Student does not exist");
                    }

                    Console.WriteLine("To end the program type \"exit\"");
                    endProgram = Console.ReadLine();
                } while (endProgram != "exit");
            }
        }

        private class LinkedListTask
        {
            private readonly LinkedList<string> _testLinkedList = new LinkedList<string>();
            public void TaskLoop() 
            {
                string endProgram;
                do
                {
                    Console.WriteLine("Write 6 of your favorite words");

                    int words = 6;
                    for (int i = 0; i < words; i++)
                    {
                        string word = Console.ReadLine();
                        _testLinkedList.AddLast(word);
                    }

                    var currentValue = _testLinkedList.First;
                    while (currentValue != null)
                    {
                        Console.WriteLine(currentValue.Value);  
                        currentValue = currentValue.Next;
                    }

                    currentValue = _testLinkedList.Last;
                    while (currentValue != null)
                    {
                        Console.WriteLine(currentValue.Value);
                        currentValue = currentValue.Previous;
                    }

                    Console.WriteLine("To end the program type \"exit\"");
                    endProgram = Console.ReadLine();
                } while (endProgram != "exit");
            }
        }
    }
}



