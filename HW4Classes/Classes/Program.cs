using System;
using System.ComponentModel.Design;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Подготовка к бою");

            Console.Write("Введите имя бойца: ");
            string unitName = Console.ReadLine();

            Console.Write("Введите изначальное здоровье бойца (10-100): ");
            float unitHealth = float.Parse(Console.ReadLine());

            Console.Write("Введите значение брони шлема от 0, до 1: ");
            float helmArmor = float.Parse(Console.ReadLine());
            Armor.Helm Helm = new();
            Helm.Armor = helmArmor;

            Console.Write("Введите значение брони кирасы от 0, до 1: ");
            float shellArmor = float.Parse(Console.ReadLine());
            Armor.Shell Shell = new();
            Shell.Armor = shellArmor;

            Console.Write("Введите значение брони сапог от 0, до 1: ");
            float bootsArmor = float.Parse(Console.ReadLine());
            Armor.Boots Boots = new();
            Boots.Armor = bootsArmor;

            Console.Write("Укажите минимальный урон оружия (0-20): ");
            float minDmg = float.Parse(Console.ReadLine());

            Console.Write("Укажите максимальный урон оружия (20-40): ");
            float maxDmg = float.Parse(Console.ReadLine());
            Weapon oldWeapon = new("", minDmg, maxDmg);

            Unit newUnit = new Unit(unitName, unitHealth);

            Console.WriteLine("Общий показатель брони равен:" + newUnit.ArmorValue);

            Console.WriteLine("Фактическое значение здоровья равно: " + newUnit.realHealth);
        }
    }
}

