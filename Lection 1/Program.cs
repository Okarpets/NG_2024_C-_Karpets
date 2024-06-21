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
        static public decimal PersonalIdCounter = 1;
        static public decimal AccountNumber = 1;
        static public decimal GlobalTransactionID = 1;

        static public void Main(string[] args)
        {
            BankSystem Bank = new BankSystem();
            Console.WriteLine("Online banking offers you it is services!");
            Console.WriteLine("Please, enter a command: ");
            Admin Admin = new Admin(0, "ADMIN", "ADMIN");
            string Command = Convert.ToString(Console.ReadLine());
            switch (Command)
            {
                case "-help":
                    Commands();
                    break;

                case "-admin_admin":
                    AdminCommands();
                    break;

                case "-create_person":
                    Console.WriteLine("Please enter your name: ");
                    string CreateName = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Please enter your address: ");
                    string CreateAddress = Convert.ToString(Console.ReadLine());
                    if (CreateName != null)
                    {
                        Client Person = new Client(PersonalIdCounter, CreateName, AccountNumber);
                        Person.Address = CreateAddress;
                        Admin.AddClient(Bank, Person);
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
                    foreach (Client Client in Bank.Clients)
                    {
                        if (Client.Name == BalanceAccount)
                        {
                            Console.WriteLine(Client.GetBalance());
                            break;
                        }
                    }
                    Console.WriteLine("Account with this username doesn't exist");
                    break;

                case "-transaction":
                    int Checker = 0;
                    Client SenderAccount = null;
                    Client RecipientAccount = null;
                    Console.WriteLine("Please enter your name: ");
                    string Sender = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Please enter recipient name: ");
                    string Recipient = Convert.ToString(Console.ReadLine());
                    foreach (Client Client in Bank.Clients)
                    {
                        if (Client.Name == Sender)
                        {
                            Checker++;
                            SenderAccount = Client;
                        }
                        if (Client.Name == Recipient)
                        {
                            Checker++;
                            RecipientAccount = Client;
                        }
                    }
                    if (Checker == 2)
                    {
                        Transaction Transaction = new Transaction();
                        Console.WriteLine("Please enter the amount for the transaction: ");
                        decimal AmountForTransaction = Convert.ToDecimal(Console.ReadLine());
                        Transaction.RecordTransaction(AmountForTransaction, GlobalTransactionID);
                        Bank.AddTransaction(Transaction);
                        GlobalTransactionID++;
                        RecipientAccount.Deposit(AmountForTransaction);
                        SenderAccount.Deposit(SenderAccount.GetBalance() - AmountForTransaction);
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
                    string CreateNameForDeposit = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Please enter the amount for the deposit: ");
                    decimal AmountForDeposite = Convert.ToDecimal(Console.ReadLine());
                    foreach (Client Client in Bank.Clients)
                    {
                        if (Client.Name == CreateNameForDeposit)
                        {
                            Client.Deposit(AmountForDeposite);
                            Console.WriteLine("Success! Your deposit has been updated");
                            break;
                        }
                    }
                    Console.WriteLine("Account with this username doesn't exist");
                    break;

                case "-generate_report":
                    Console.WriteLine("Please enter the transaction id: ");
                    decimal TransactionID = Convert.ToDecimal(Console.ReadLine());
                    var TransactForReport = Bank.ViewTransactions();
                    foreach (Transaction Transaction in TransactForReport)
                    {
                        if (Transaction.GetTransactionDetails().Id == TransactionID)
                        {
                            Console.WriteLine(Admin.GenerateReport(Bank, Transaction));
                            break;
                        }
                    }
                    Console.WriteLine("A transaction with this ID doesn't exist");
                    break;


                case "-view_transactions":
                    var AllTransact = Bank.ViewTransactions();
                    foreach (Transaction Transaction in AllTransact)
                    {
                        Console.WriteLine();
                    }
                    break;

                case "-remove_client":
                    Console.WriteLine("Enter username to delete from system: ");
                    string DeleteUser = Convert.ToString(Console.ReadLine());
                    foreach (Client Client in Bank.Clients)
                    {
                        if (Client.Name == DeleteUser)
                        {
                            Console.WriteLine("User with entered name found");
                            Admin.RemoveClient(Bank, Client);
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
