using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Classes
{
    public class Unit
    {
        public string Name;
        private float _health;
        private float _baseDamage = 5f;
        private float _damage;
        private float _armorValue;
        private Armor.Helm _helm = new("");
        private Armor.Boots _boots = new("");
        private Armor.Shell _shell = new("");
        private Weapon _weapon = new("");

        public float Health
        {
            get
            {
                return _health;
            }
            private set
            {
                _health = value;
            }
        }

        public float Damage => _damage = _baseDamage + _weapon.GetDamage;

        public float ArmorValue => _armorValue = _helm.Armor + _boots.Armor + _shell.Armor;

        public float RealHealth => Health * (1f + _armorValue);

        public Unit() : this("Unknown Unit", 10)
        { }

        public Unit (string name, float health)
        {
            this.Name = name;
            _health = health;
        }

        public void EquipHelm(Armor.Helm helm)
        {
            _helm = helm;
        }

        public void EquipBoots(Armor.Boots boots)
        {
            _boots = boots;
        }

        public void EquipShell(Armor.Shell shell)
        {
            _shell = shell;
        }

        public void EquipWeapon(Weapon weapon)
        {
            _weapon = weapon;
        }

        public bool SetDamage(float value)
        {
            Health = Math.Clamp(Health - value * ArmorValue, 0, Health);
            return Health <= 0;
        }
    }
}





       
    


           
            

