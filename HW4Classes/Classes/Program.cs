using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Unit unitOne = new Unit("", 30f);
            Unit unitTwo = new Unit("", 50f);
            Armor.Helm helmOne = new Armor.Helm("");
            Armor.Shell shellOne = new Armor.Shell("");
            Armor.Boots bootsOne = new Armor.Boots("");
            Armor.Helm helmTwo = new Armor.Helm("");
            Armor.Shell shellTwo = new Armor.Shell("");
            Armor.Boots bootsTwo = new Armor.Boots("");
            Random random = new Random();

            helmOne.Armor = 0.3f;
            shellOne.Armor = 0.5f;
            bootsOne.Armor = 0.1f;
            helmTwo.Armor = 0.6f;
            shellTwo.Armor = 0.2f;
            bootsTwo.Armor = 0.3f;

            float minValueOne = random.Next(10, 30);
            float minValueTwo = random.Next(10, 30);
            float maxValueOne = random.Next(10, 30);
            float maxValueTwo = random.Next(10, 30);

            unitOne.Name = "Figher";
            unitTwo.Name = "Swordsman";

            Weapon weaponOne = new Weapon("", minValueOne, maxValueTwo);
            Weapon weaponTwo = new Weapon("", minValueTwo, maxValueTwo);
            unitOne.EquipWeapon(weaponOne);
            unitTwo.EquipWeapon(weaponTwo);
            unitOne.EquipHelm(helmOne);
            unitOne.EquipBoots(bootsOne);
            unitOne.EquipShell(shellOne);
            unitTwo.EquipHelm (helmTwo);
            unitTwo.EquipBoots(bootsTwo);
            unitTwo.EquipShell(shellTwo);

            Console.WriteLine("Значение здоровья первого бойца {0}, показатель его урона равен {1}", unitOne.RealHealth, unitOne.Damage);

            Console.WriteLine("Значение здоровья второго бойца {0}, показатель его урона равен {1}", unitTwo.RealHealth, unitTwo.Damage);

            Combat combat = new Combat();

            Console.WriteLine("Начало поединка");

            combat.StartCombat(ref unitOne, ref unitTwo);

            Console.WriteLine("Бой завершен");

            combat.ShowResults();


            //Console.WriteLine("Подготовка к бою");

            //Console.Write("Введите имя бойца: ");
            //string unitName = Console.ReadLine();

            //Console.Write("Введите изначальное здоровье бойца (10-100): ");
            //float unitHealth;
            //if (float.TryParse(s: Console.ReadLine(), out float healthValue))
            //{
            //    unitHealth = healthValue;
            //}

            //Armor.Helm helm = new("");
            //Console.Write("Введите значение брони шлема от 0, до 1: ");
            //if (float.TryParse(s: Console.ReadLine(), out float helmValue))
            //{
            //    helm.Armor = helmValue;
            //}

            //Armor.Shell shell = new("");
            //Console.Write("Введите значение брони кирасы от 0, до 1: ");
            //if (float.TryParse(s: Console.ReadLine(), out float shellValue))
            //{
            //    shell.Armor = shellValue;
            //}

            //Armor.Boots boots = new("");
            //Console.Write("Введите значение брони сапог от 0, до 1: ");
            //if (float.TryParse(s: Console.ReadLine(), out float bootsValue))
            //{
            //    boots.Armor = bootsValue;
            //}

            //Console.Write("Укажите минимальный урон оружия (0-20): ");
            //float minDmg;
            //if (float.TryParse(s: Console.ReadLine(), out float minValue))
            //{
            //    minDmg = minValue;
            //}

            //Console.Write("Укажите максимальный урон оружия (20-40): ");
            //float maxDmg;
            //if (float.TryParse(s: Console.ReadLine(), out float maxValue))
            //{
            //    maxDmg = maxValue;
            //}

            //Weapon weapon = new("", minValue, maxValue);
            //Unit newUnit = new Unit(unitName, healthValue);

            //newUnit.EquipHelm(helm);
            //newUnit.EquipShell(shell);
            //newUnit.EquipBoots(boots);
            //newUnit.EquipWeapon(weapon);

            //Console.WriteLine("Общий показатель брони равен:" + newUnit.ArmorValue);

            //Console.WriteLine("Фактическое значение здоровья равно: " + newUnit.RealHealth);

        }
    }
}

