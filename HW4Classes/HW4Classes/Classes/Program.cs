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
            //float unitHealth = float.TryParse(Console.ReadLine(), out float result);
            float unitHealth = float.Parse(Console.ReadLine());

            Armor.Helm helm = new("");
            Console.Write("Введите значение брони шлема от 0, до 1: ");
            helm.Armor = float.Parse(Console.ReadLine());

            Armor.Shell shell = new("");
            Console.Write("Введите значение брони кирасы от 0, до 1: ");
            shell.Armor = float.Parse(Console.ReadLine());

            Armor.Boots boots = new("");
            Console.Write("Введите значение брони сапог от 0, до 1: ");
            boots.Armor = float.Parse(Console.ReadLine());

            Console.Write("Укажите минимальный урон оружия (0-20): ");
            float MinDmg = float.Parse(Console.ReadLine());

            Console.Write("Укажите максимальный урон оружия (20-40): ");
            float MaxDmg = float.Parse(Console.ReadLine());

            Weapon weapon = new("", MinDmg, MaxDmg);
            Unit newUnit = new Unit(unitName, unitHealth);

            newUnit.EquipHelm(helm);
            newUnit.EquipShell(shell);
            newUnit.EquipBoots(boots);
            newUnit.EquipWeapon(weapon);

            Console.WriteLine("Общий показатель брони равен:" + newUnit.ArmorValue);

            Console.WriteLine("Фактическое значение здоровья равно: " + newUnit.RealHealth);
        }
    }
}

