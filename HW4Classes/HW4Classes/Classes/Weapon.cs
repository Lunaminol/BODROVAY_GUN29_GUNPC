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
        public string Name;
        private float _minDamage;
        private float _maxDamage;

        public Weapon(string name) { this.Name = name; }
        public Weapon(string name, float minDamage, float maxDamage)
        {
            this.Name = name;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            SetDamageParams(MinDamage, MaxDamage);
        }

        public float MinDamage
        {
            get
            {
                return _minDamage;
            }
            private set
            {
                if (value < 1f)
                {
                    _minDamage = 1f;
                    Console.WriteLine("Минимальный урон установлен на 1");
                    return;
                }
                _minDamage = value;
            }
        }
        
        public float MaxDamage
        {
            get
            {  
                return _maxDamage;
            }
            private set
            {
                if (value <= 1f)
                {
                    _maxDamage = 10f;
                    Console.WriteLine("Максимальный урон установлен на 10");
                    return;
                }
                _maxDamage = value;
            }
        }

        public void SetDamageParams(float minDamage, float maxDamage)
        {
            if (minDamage > maxDamage)
            {
                Console.WriteLine("Некорректные данные " + Name);
                MinDamage = MaxDamage;
            }
        }

        private float _weaponDamage;
        public float GetDamage => _weaponDamage = (MinDamage + MaxDamage) / 2;
    }
}
