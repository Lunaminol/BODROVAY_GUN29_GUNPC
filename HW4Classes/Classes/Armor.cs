using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Armor
    {
        public class Helm
        {
            private string _name = "Helm";
            public string Name { get { return _name; } }
            public float armor;

            public  float Armor
            {
                get
                {
                    return armor;
                }
                set
                {
                    if (value < 0f)
                    {
                        armor = 0f;
                        Console.WriteLine("Некорректно заданное свойство");
                        return;
                    }
                    else if (value > 1f)
                    {
                        armor = 1f;
                        Console.WriteLine("Некорректно заданное свойство");
                        return;
                    }
                    armor = value;
                }
            }
        }

        public class Shell
        {
            private string _name = "Shell";
            public string Name { get { return _name; } }
            public float armor;
            public float Armor
            {
                get
                {
                    return armor;
                }
                set
                {
                    if (value < 0f)
                    {
                        armor = 0f;
                        Console.WriteLine("Некорректно заданное свойство");
                        return;
                    }
                    else if (value > 1f)
                    {
                        armor = 1f;
                        Console.WriteLine("Некорректно заданное свойство");
                        return;
                    }
                    armor = value;
                }

        }
        }

        public class Boots
        {
            private string _name = "Boots";
            public string Name { get { return _name; } }
            public float armor;
            public float Armor
            {
                get
                {
                    return armor;
                }
                set
                {
                    if (value < 0f)
                    {
                        armor = 0f;
                        Console.WriteLine("Некорректно заданное свойство");
                        return;
                    }
                    else if (value > 1f)
                    {
                        armor = 1f;
                        Console.WriteLine("Некорректно заданное свойство");
                        return;
                    }
                    armor = value;
                }
            }
        }
    }
}