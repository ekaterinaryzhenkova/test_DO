public class Program
{
    public static void Main(String[] args)
    {
        string[] str_money = new string[6];
        int[] int_money = new int[6];

        Console.WriteLine("Введите стоимость товара:");

        Console.Write("Фунты: ");
        str_money[0] = Console.ReadLine();

        Console.Write("Шиллинги: ");
        str_money[1] = Console.ReadLine();

        Console.Write("Пенсы: ");
        str_money[2] = Console.ReadLine();

        Console.WriteLine("Введите внесенную покупателем сумму:");
        Console.Write("Фунты: ");
        str_money[3] = Console.ReadLine();

        Console.Write("Шиллинги: ");
        str_money[4] = Console.ReadLine();

        Console.Write("Пенсы: ");
        str_money[5] = Console.ReadLine();

        for (int i = 0; i < 6; i++)
        {
            if (Validate(str_money[i]))
            {
                int_money[i] = int.Parse(str_money[i]);
            }
            else
            {
                Console.WriteLine("Некорректный формат ввода данных");
                return;
            }
        }

        Console.WriteLine(Calculate(int_money[0], int_money[1], int_money[2], int_money[3], int_money[4], int_money[5]));
    }

    public static string Calculate(int pounds, int shillings, int pennies,
                                   int buyers_pounds, int buyers_shillings, int buyers_pennies)
    {
        int cost = pennies + shillings * 12 + pounds * 240;
        int buyers_fee = buyers_pennies + buyers_shillings * 12 + buyers_pounds * 240;
        int difference = buyers_fee - cost;

        if (difference == 0)
        {
            return "Нет сдачи";
        }
        else if (difference > 0)
        {
            int remaining_pounds = difference / 240;
            int remaining_shillings = (difference - remaining_pounds * 240) / 12;
            int remaining_pennies = difference % 12;
            return $"Сдача: Фунты: {remaining_pounds}, шиллинги: {remaining_shillings}, пенсы: {remaining_pennies}";
        }
        else
        {
            return "Ошибка";
        }
    }

    public static bool Validate(string money)
    {
        if (int.TryParse(money, out int num))
        {
            return true;
        }

        return false;
    }
}