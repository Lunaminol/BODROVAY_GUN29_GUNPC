using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private Interval _interval;

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

        public float GetDamage => _interval.Average;

        public Weapon(string name) { this.Name = name; }

        public Weapon(string name, float minDamage, float maxDamage) 
        {
            this.Name = name;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            SetDamageParams(minDamage, maxDamage);
            Interval SetDamage = new Interval(minDamage, maxDamage); 
        }

        public void SetDamageParams(float minDamage, float maxDamage)
        {
            if (minDamage > maxDamage)
            {
                Console.WriteLine("Некорректные данные " + Name);
                MinDamage = MaxDamage;
            }
        }
    }
}
