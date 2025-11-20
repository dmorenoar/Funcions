using System;
public class Program
{
    //variable global
    const double TaxRate = 0.15; //Una constant és static per defecte
    static double amount = 1000.0; //Definim una variable estàtica global perquè Main és static

    /*Main és static, per això les altres funcions també han de ser static
     * Main és el punt d'entrada de l'aplicació, per això ha de poder ser cridat sense 
     * crear una instància de la classe Program
     * */
    public static void Main()
    {
        const string WelcomeMessage = "Welcome to the ING BANK!";
        const string MessageAmount = "Your amount is: {0}, Final amount: {1}";
        const string MessageInterest = "The interest on your amount is: {0}";
        //variables locals
        int op = 0;
        int creditCardNumber = 123456789;
        double previousAmount = amount, finalAmount;

        do
        {
            op = Menu(ref op);

            switch (op)
            {
                case 1:
                    CheckCreditCard(creditCardNumber, in amount);
                    break;
                case 2:
                    WithdrawCash(100, in previousAmount, out finalAmount);
                    Console.WriteLine(MessageAmount, previousAmount, finalAmount);
                    break;
                case 3:
                    Console.WriteLine(MessageInterest, CalculateInterest(in amount));
                    break;
            }
        }while(op != 0);


    }

    /*
     Mitjançant la paraula reservada out, l'assignació del valor d'aquesta variable farà dins del mètode que s'invoca. 
     No és necessari inicialitzar el valor de la variable, encara que si s'ha d'instanciar.
     out obliga el mètode a assignar un valor abans d'acabar.
     És útil quan necessites retornar més d’un resultat.
     */

    //Un mètode rep un valor que no pot modificar (in) i, alhora, retorna els diners finals del compte (out):
    public static void WithdrawCash(int cash, in double previousAmount, out double finalAmount)
    {
        finalAmount = previousAmount - cash; //Suposem que retirem 100 unitats monetàries
    }

    public static void CheckCreditCard(int creditCardNumber, in double amount)
    {
        const string MessageYourCreditCardIs = "Your credit card number is: {0}, and your amount {1}";
        Console.WriteLine(MessageYourCreditCardIs,creditCardNumber,amount);
    }


    /*
     La paraula reservada in evita que puguem modificar el valor de la variable dins del mètode, 
    per la qual cosa el valor sempre serà el que haguem passat prèviament (la variable és només de lectura).
     */
    public static double CalculateInterest(in double amount)
    {
        //amount = 10;  // Això donarà error perquè amount és només de lectura
        return amount * TaxRate;
    }

    /*
     Quan es passa un paràmetre per referència, l'argument rep l'accés a la variable, 
    de manera que podrà modificar el contingut de la variable (ja que el que es passa és l'adreça de memòria).
    En aquest cas, la variable op és modificada dins de la funció Menu i aquest canvi es reflecteix fora de la funció.
     */
    public static int Menu(ref int op)
    {
        const string MessageChooseAnOption = "Choose an option: \n";
        const string MessageCheckCredit = "1 - Check credit card \n";
        const string MessageWithdrawCash = "2 - Withdraw cash\n";
        const string MessageCheckInterest = "3 - Check interest \n";
        const string MessageExit = "0 - Exit. \n";

        const string PromptMenu = MessageChooseAnOption +
                                  MessageCheckCredit +
                                  MessageWithdrawCash +
                                  MessageCheckInterest +
                                  MessageExit;

        do
        {
            //Console.WriteLine(creditCardNumber); // No podem accedir a aquesta variable aquí perquè és local a Main
            //Console.WriteLine(TaxRate); // Podem accedir a aquesta variable perquè és global
            Console.WriteLine(PromptMenu);

        } while (!int.TryParse(Console.ReadLine(), out op) || (op < -2 || op > 3));

        return op;
    }
}
