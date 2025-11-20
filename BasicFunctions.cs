using System;

public class BasicFunctions
{
	public satic void Main()
	{
        const string WelcomeMessage = "Welcome to the Champion Utility Program!";
        const string ChampionRole = "The role of the champion is: ";
        const string CriticalChanceMessage = "The champion has a critical hit chance: ";
        const string AttachBonusMessage = "The total attack of the champion is: ";

        int op = 0;

        ShowMessage(WelcomeMessage);

        do
        {
            op = Menu();

            switch (op)
            {
                case -1:
                    AdminModeEnabled();
                    break;
                case 1:
                    Console.WriteLine(AttachBonusMessage + CalcAttackChampion(10, 5));
                    break;
                case 2:
                    Console.WriteLine(ChampionRole + GetChampionRole("Lux"));
                    break;
                case 3:
                    Console.WriteLine(CriticalChanceMessage + GetRandomCriticalChance());
                    break;
            }
        } while (op != 0);


    }


    //Rep arguments però no retorna
    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    const string MessageAdmin = "Admin mode enabled.";

    //Ni rep arguments ni retorna
    public static void AdminModeEnabled()
    {
        Console.WriteLine(MessageAdmin);
    }

    //Retorna però no rep arguments
    public static bool GetRandomCriticalChance()
    {
        Random rand = new Random();
        int chance = rand.Next(1, 101); // Generates a number between 1 and 100
        return chance <= 25; // 25% chance for critical hit
        int chance = rand.Next(1, 101);
        return chance <= 25;
    }


    //Retorna i rep arguments
    public static string GetChampionRole(string champion)
    {
        const string MessageUnknownChampion = "Unknown champion.";
        const string MessageMarksman = "Marksman";
        const string MessageFighter = "Fighter";
        const string MessageMage = "Mage";

        string role = "";

        switch (champion)
        {
            case "Ashe":
            case "Caitlyn":
            case "Jinx":
                role = MessageMarksman;
                break;
            case "Garen":
            case "Darius":
            case "Mordekaiser":
                role = MessageFighter;
                break;
            case "Lux":
            case "Annie":
            case "Veigar":
                role = MessageMage;
                break;
            default:
                role = MessageUnknownChampion;
                break;
        }

        return role;
    }

    public static int CalcAttackChampion(int attack, int bonus)
    {
        int totalAttack = attack + bonus;

        return totalAttack;
    }
    public static int Menu()
    {
        const string MessageChooseAnOption = "Choose an option: \n";
        const string MessageCalcAttack = "1 - Calc Attack Champion \n";
        const string MessageGetRole = "2 - Get Champion Role \n";
        const string MessageGetCritical = "3 - Get Random Critical \n";
        const string MessageExit = "0 - Exit. \n";

        const string PromptMenu = MessageChooseAnOption +
                                  MessageCalcAttack +
                                  MessageGetRole +
                                  MessageGetCritical +
                                  MessageExit;

        int op = 0;

        do
        {
            Console.WriteLine(PromptMenu);

        } while (!int.TryParse(Console.ReadLine(), out op) || (op < -2 || op > 3));

        return op;
    }
}
