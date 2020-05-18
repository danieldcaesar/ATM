using System;
using System.Collections;

namespace ConsoleApp1
{
    public static class ATM
    {
        private static ArrayList AccountOwners = new ArrayList();
        private static ArrayList PIN = new ArrayList();
        private static ArrayList Balance = new ArrayList();

        // Inserts values into the ArrayLists
        private static void Initialize()
        {
            AccountOwners.Add("Adam");
            AccountOwners.Add("Brenda");
            AccountOwners.Add("Curtis");
            PIN.Add(1234);
            PIN.Add(5678);
            PIN.Add(9101);
            Balance.Add(10000);
            Balance.Add(5000);
            Balance.Add(2500);
        }

        // LogIn method checks the input with the data in the Lists
        private static int LogIn(string user, int pin)
        {
            foreach (string aUser in AccountOwners)
            {
                if(aUser.Equals(user) && (pin == Convert.ToInt32(PIN[AccountOwners.IndexOf(aUser)])))
                    return AccountOwners.IndexOf(aUser);
            }
            return -1;
        }

        // Menu method displays available options to the user
        private static int Menu()
        {
            Console.WriteLine("Please select your transaction");
            Console.WriteLine("1: View Balance");
            Console.WriteLine("2: Deposit");
            Console.WriteLine("3: Withdraw");

            return Convert.ToInt32(Console.ReadLine());
        }


        // Allows user to view their balance
        private static void ViewBalance(int index)
        {
            Console.WriteLine("{0}, your balance is: ${1}", AccountOwners[index], Balance[index]);
        }


        // Allows the user to withdraw cash
        private static void Withdraw(int index, int amt)
        {
            int temp = Convert.ToInt32(Balance[index]);
            if (temp >= amt)
            {
                temp = temp - amt;
                Balance[index] = temp;
                Console.WriteLine("New account balance is: ${0}", temp);
            }
            else Console.WriteLine("Amount requested exceeds available funds.");
        }


        // Allows user to deposit cash
        private static void Deposit(int index, int amt)
        {
            int temp = Convert.ToInt32(Balance[index]);
            temp = temp + amt;
            Balance[index] = temp;
            Console.WriteLine("Deposit Successful. Your new balance is: ${0}", temp);
        }
        



        private static void Main(string[] args)
        {
            // Variable declarations
            int aPin, userIndex = 0, pick = 0, fail = 0;
            string userName;
            bool repeat = true;

            // Initializes the program
            Initialize();
            Console.WriteLine("Welcome to the ATM ****");
            Console.WriteLine("Please log in *********");

            // Ensures the user is only allowed three tries to login
            for(int i =0; i <= 2; i++)
            {
                Console.WriteLine("Enter username: ");
                userName = Console.ReadLine();
                Console.WriteLine("Enter PIN");
                aPin = Convert.ToInt32(Console.ReadLine());

                userIndex = LogIn(userName, aPin);

                if (userIndex < 0)
                {
                    Console.WriteLine("Wrong username or PIN.");
                    fail++;
                }
                else
                {
                    i = 3;
                }
            }
            // End for


            /* Ensures the user is not allowed to continue if their
             * username or password combination is incorrect  */
            if (fail <= 2)
            {

                while (repeat == true)
                {
                    pick = Menu();

                    switch (pick)
                    {
                        case 1:
                            ViewBalance(userIndex);
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("Enter deposit amount: ");
                            int depositAmt = Convert.ToInt32(Console.ReadLine());
                            Deposit(userIndex, depositAmt);
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("Enter withdrawal amount");
                            int withdrawAmt = Convert.ToInt32(Console.ReadLine());
                            Withdraw(userIndex, withdrawAmt);
                            Console.ReadKey();
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            Console.ReadKey();
                            break;
                    }
                    //End switch

                    // Allows user to perform additional transactions
                    Console.WriteLine("Would you like to perform another transaction? (Y/n)");
                    string input = Console.ReadLine();
                    string choice = input.ToUpper();

                    if (choice == "Y")
                    {
                        repeat = true;
                    }
                    else
                    {
                        repeat = false;
                    }
                }
                // End while

            }
            // End if
            Console.WriteLine("Thank you for using our ATM.");
            Console.ReadKey();
        }
        // End Main method
    }
    // End class
}
// End namespace
