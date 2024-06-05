using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Lection_1;

namespace Program
{
    internal class Program
    {
        static private decimal personalIdCounter = 1;
        static private decimal accountNumber = 1;
        static private decimal globalTransactionID = 1;
        static public decimal PersonalIdCounter
        {
            get => personalIdCounter;
            set => personalIdCounter = value;
        }

        static public decimal AccountNumber
        {
            get => accountNumber;
            set => accountNumber = value;
        }

        static public decimal GlobalTransactionID
        {
            get => globalTransactionID;
            set => globalTransactionID = value;
        }

        static public void Main(string[] args)
        {
            BankSystem bank = new BankSystem();
            Console.WriteLine("Online banking offers you it is services!");
            Console.WriteLine("Please, enter a command: ");
            Admin admin = new Admin(0, "ADMIN", "ADMIN");
            string command = Convert.ToString(Console.ReadLine());
            switch (command)
            {
                case "-help":
                    Commands();
                    break;

                case "-admin_admin":
                    AdminCommands();
                    break;

                case "-create_person":
                    Console.WriteLine("Please enter your name: ");
                    string createName = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Please enter your address: ");
                    string createAddress = Convert.ToString(Console.ReadLine());
                    if (createName != null)
                    {
                        Person person = new Person(PersonalIdCounter, createName, AccountNumber);
                        person.Address = createAddress;
                        admin.add_client(bank, person);
                        PersonalIdCounter++;
                        AccountNumber++;
                    }
                    else
                    {
                        Console.WriteLine("Filed's can't be empty string");
                    }
                    break;

                case "-get_balance":
                    Console.WriteLine("Please enter your name: ");
                    string BalanceAccount = Convert.ToString(Console.ReadLine());
                    foreach (Person client in bank.Clients)
                    {
                        if (client.Name == BalanceAccount)
                        {
                            Console.WriteLine(client.get_balance());
                            break;
                        }
                    }
                    Console.WriteLine("Account with this username doesn't exist");
                    break;

                case "-transaction":
                    int checker = 0;
                    Person senderAccount = null;
                    Person recipientAccount = null;
                    Console.WriteLine("Please enter your name: ");
                    string sender = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Please enter recipient name: ");
                    string recipient = Convert.ToString(Console.ReadLine());
                    foreach (Person client in bank.Clients)
                    {
                        if (client.Name == sender)
                        {
                            checker++;
                            senderAccount = client;
                        }
                        if (client.Name == recipient)
                        {
                            checker++;
                            recipientAccount = client;
                        }
                    }
                    if (checker == 2)
                    {
                        Transaction transaction = new Transaction();
                        Console.WriteLine("Please enter the amount for the transaction: ");
                        decimal amountForTransaction = Convert.ToDecimal(Console.ReadLine());
                        transaction.record_transaction(amountForTransaction, GlobalTransactionID);
                        bank.add_transaction(transaction);
                        GlobalTransactionID++;
                        recipientAccount.deposit(amountForTransaction);
                        senderAccount.deposit(senderAccount.get_balance() - amountForTransaction);
                        Console.WriteLine("The transaction was successful");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Account with this username doesn't exist");
                        break;
                    }

                case "-deposite":
                    Console.WriteLine("Please enter your name: ");
                    string createNameForDeposit = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Please enter the amount for the deposit: ");
                    decimal amountForDeposite = Convert.ToDecimal(Console.ReadLine());
                    foreach (Person client in bank.Clients)
                    {
                        if (client.Name == createNameForDeposit)
                        {
                            client.deposit(amountForDeposite);
                            Console.WriteLine("Success! Your deposit has been updated");
                            break;
                        }
                    }
                    Console.WriteLine("Account with this username doesn't exist");
                    break;

                case "-generate_report":
                    Console.WriteLine("Please enter the transaction id: ");
                    decimal transactionID = Convert.ToDecimal(Console.ReadLine());
                    var transactForReport = bank.view_transactions();
                    foreach (Transaction transaction in transactForReport)
                    {
                        if (transaction.get_transaction_details().id == transactionID)
                        {
                            Console.WriteLine(admin.generate_report(bank, transaction));
                            break;
                        }
                    }
                    Console.WriteLine("A transaction with this ID doesn't exist");
                    break;


                case "-view_transactions":
                    var allTransact = bank.view_transactions();
                    foreach (Transaction transaction in allTransact)
                    {
                        Console.WriteLine();
                    }
                    break;

                case "-remove_client":
                    Console.WriteLine("Enter username to delete from system: ");
                    string deleteUser = Convert.ToString(Console.ReadLine());
                    foreach (Person client in bank.Clients)
                    {
                        if (client.Name == deleteUser)
                        {
                            Console.WriteLine("User with entered name finded");
                            admin.remove_client(bank, client);
                            break;
                        }
                    }
                    Console.WriteLine("Account with this username doesn't exist");
                    break;

                default:
                    Console.WriteLine("It is a wrong command, please, use \"-help\"");
                    break;
            }
        }

        static public void Commands()
        {
            Console.WriteLine("View all commands: -help");
            Console.WriteLine("Create a new account: -create_person");
            Console.WriteLine("View account balance: -get_balance");
            Console.WriteLine("Create a new transaction: -transaction");
            Console.WriteLine("To put money on balance: -deposit");
        }

        static public void AdminCommands()
        {
            Console.WriteLine("Create a new account: -remove_client");
            Console.WriteLine("View account balance: -view_transactions");
            Console.WriteLine("Create a new transaction: -generate_report");
        }
    }
}
