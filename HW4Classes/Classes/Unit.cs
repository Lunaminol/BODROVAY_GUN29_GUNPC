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
        public string name;
        public Unit() { name = "Unknown Unit"; }

        public Unit(string Name, float aHealth)
        { 
            this.name = Name;
            Health = aHealth;
        }

        public float health;
        public float Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value <= 10f)
                {
                    health = 10f;
                    return;
                }
                else if (value >= 100f)
                {
                    health = 100f;
                    return;
                }
                health = value;
            }
        }

        public float realHealth;
        public float ReturnHealth()
        {
            realHealth = health * (1f + ArmorValue);
            return realHealth;
        }

        public bool SetDamage(float value)
        {
            health = Health - value * ArmorValue;
            if (health <= 0)
            {
                return true;
            }
            return false;
        }

        Armor.Helm Helm = new Armor.Helm();
        public static void EquipHelm(Armor.Helm Helm)
        {
            if (Helm != null) 
            {
                new Armor.Helm();

            }
        }

        Armor.Boots Boots = new Armor.Boots();  
        public static void EquipBoots(Armor.Boots Boots)
        {
            if (Boots != null)
            {
                new Armor.Boots();
            }
        }

        Armor.Shell Shell = new Armor.Shell();
        public static void EquipShell(Armor.Shell Shell)
        {
            if (Shell != null)
            {
                new Armor.Shell();
            } 
        }

        Weapon oldWeapon = new Weapon("");
        
        public static void EquipWeapon(Weapon oldWeapon)
        {
            if (oldWeapon != null)  
            {
                Weapon newWeapon = new("", aMinDamage: 0, aMaxDamage: 0);
                oldWeapon = newWeapon;
            }
        }

        private float _baseDamage = 5;
        public float damage;
        public float Damage
        {
            get
            {
                return damage;
            }
            set
            {
                if (oldWeapon.weaponDamage > 0)
                {
                    value = _baseDamage + oldWeapon.weaponDamage;
                }
                else
                {
                    value = _baseDamage;
                }
                damage = value;

            }
        }

        public float ArmorValue;
        public float Armor()
        {
            ArmorValue = Boots.armor + Shell.armor + Helm.armor;
            return ArmorValue;
        }
    }
    }





       
    


           
            

