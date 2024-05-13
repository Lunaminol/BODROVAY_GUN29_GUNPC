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
            public Helm (string name) { name = "Helm"; }
            private float _armor;

            public  float Armor
            {
                get
                {
                    return _armor;
                }
                set
                {
                    if (value < 0f)
                    {
                        _armor = 0f;
                        Console.WriteLine("Некорректно заданное свойство");
                        return;
                    }
                    else if (value > 1f)
                    {
                        _armor = 1f;
                        Console.WriteLine("Некорректно заданное свойство");
                        return;
                    }
                    _armor = value;
                }
            }
        }

        public class Shell
        {
            public Shell (string name) { name = "Shell"; } 
            private float _armor;
            public float Armor
            {
                get
                {
                    return _armor;
                }
                set
                {
                    if (value < 0f)
                    {
                        _armor = 0f;
                        Console.WriteLine("Некорректно заданное свойство");
                        return;
                    }
                    else if (value > 1f)
                    {
                        _armor = 1f;
                        Console.WriteLine("Некорректно заданное свойство");
                        return;
                    }
                    _armor = value;
                }

        }
        }

        public class Boots
        {
            public Boots (string name) { name = "Boots"; }
            private float _armor;
            public float Armor
            {
                get
                {
                    return _armor;
                }
                set
                {
                    if (value < 0f)
                    {
                        _armor = 0f;
                        Console.WriteLine("Некорректно заданное свойство");
                        return;
                    }
                    else if (value > 1f)
                    {
                        _armor = 1f;
                        Console.WriteLine("Некорректно заданное свойство");
                        return;
                    }
                    _armor = value;
                }
            }
        }
    }
}