using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Classes
{
    public struct Interval
    {
        private float _minValue;
        private float _maxValue;
        private Random _random = new Random();
        
        public int GetDamageRandom
        {  
            get
            {
                return _random.Next((int)_minValue, (int)_maxValue); 
            }
        }

        public float Min => _minValue;
        public float Max => _maxValue;
        public float Average => (Min + Max) / 2;  

        public Interval(int minValue, int maxValue) : this ((float)minValue, (float)maxValue)
        { 
            this._minValue = minValue;
            this._maxValue = maxValue;
            CheckInput(minValue, maxValue);
        }

        public Interval(float minValue, float maxValue) 
        { 
            this._minValue = minValue;
            this._maxValue = maxValue;
            CheckInput(minValue, maxValue);
        }

        public Interval(float value) : this ((float) value, (float) value)
        { 
            this._minValue = value;  
            this._maxValue = value;
        }

        public void CheckInput(float minValue, float maxValue)
        {
            if (minValue > maxValue)
            {
                Console.WriteLine("Некорректные данные");
                _minValue = _maxValue;
            }
        }
    }

    public struct Rate
    {
        private Unit _attackingUnit;
        private float _health;
        private float _damage;

        public float Health => (float)Math.Round(_health, 2);
        public float Damage => _damage;
        public string Name => _attackingUnit.Name;
            
        public Rate(ref Unit _attackingUnit, float damage, float health)
        {
            this._attackingUnit = _attackingUnit;
            _damage = damage;
            _health = health;
        }
    }

    public class Combat
    {
        private Random _random = new Random();

        List<Rate> Rate = new List<Rate>();

        public Combat() { List<Rate> Rate; }

        public void StartCombat(ref Unit unitOne, ref Unit unitTwo)
        {
            do
            {
                int attack = _random.Next(1, 10);
                if (attack % 2 == 0)
                {
                    unitOne.SetDamage(unitTwo.Damage);
                    Rate.Add(new Rate(ref unitTwo, unitTwo.Damage, unitOne.Health));
                }
                else
                {
                    unitTwo.SetDamage(unitOne.Damage);
                    Rate.Add(new Rate(ref unitOne, unitOne.Damage, unitTwo.Health));
                }
            } while (!unitOne.SetDamage(unitTwo.Damage) || !unitTwo.SetDamage(unitOne.Damage));
        }

        public void ShowResults()
        {
            foreach (Rate rate in Rate)
            {
                Console.WriteLine("Боец {0} нанёс урон {1} и оставил {2} здоровья.", rate.Name, rate.Damage, rate.Health);
            }
        }
    }
}
