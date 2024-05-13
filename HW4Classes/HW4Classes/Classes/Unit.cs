using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Classes
{
    class Unit
    {
        public string Name;
        private float _health;

        public Unit() : this("Unknown Unit", 10)
        { }

        public Unit (string name, float health)
        {
            this.Name = name;
            _health = health;
        }

        public float Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value <= 10f)
                {
                    _health = 10f;
                    return;
                }
                else if (value >= 100f)
                {
                    _health = 100f;
                    return;
                }
                _health = value;
            }
        }

        private Armor.Helm _helm = new("");
        private Armor.Boots _boots = new("");
        private Armor.Shell _shell = new("");
        private Weapon _weapon = new("", 0, 0);

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

        private float _armorValue;
        public float ArmorValue => _armorValue = _helm.Armor + _boots.Armor + _shell.Armor;

        private float _realHealth;
        public float RealHealth => _realHealth = Health * (1f + _armorValue);

        public bool SetDamage(float value)
        {
            Health = Health - value * ArmorValue;
            if (Health <= 0)
            {
                return true;
            }
            return false;
        }

        private float _baseDamage = 5;
        private float _damage;
        public float Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                if (_weapon.GetDamage > 0)
                {
                    value = _baseDamage + _weapon.GetDamage;
                }
                else
                {
                    value = _baseDamage;
                }
                _damage = value;

            }
        }
    }
    }





       
    


           
            

