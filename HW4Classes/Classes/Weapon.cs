using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Classes
{
    public class Weapon
    {
        public string name;
        public float minDamage;
        public float maxDamage;

        public Weapon (string Name) { name = Name; }
        public Weapon(string Name, float aMinDamage, float aMaxDamage)
        {
            this.name = Name;
            minDamage = aMinDamage;
            maxDamage = aMaxDamage;
            SetDamageParams(minDamage, maxDamage);
        }

        public float MinDamage
        {
            get
            {
                return minDamage;
            }
            private set
            {
                if (value < 1f)
                {
                    minDamage = 1f;
                    Console.WriteLine("Минимальный урон установлен на 1");
                    return;
                }
                minDamage = value;
            }
        }
        
        public float MaxDamage
        {
            get
            {  
                return maxDamage;
            }
            private set
            {
                if (value <= 1f)
                {
                    maxDamage = 10f;
                    Console.WriteLine("Максимальный урон установлен на 10");
                    return;
                }
                maxDamage = value;
            }
        }

        public void SetDamageParams(float minDamage, float maxDamage)
        {
            if (minDamage > maxDamage)
            {
                Console.WriteLine("Некорректные данные " + name);
                MinDamage = MaxDamage;
            }
        }

        public float weaponDamage;
        public float GetDamage()
        {
            float weaponDamage = (minDamage + maxDamage) / 2;
            return weaponDamage;
        }
    }
}
