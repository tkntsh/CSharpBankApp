using System;

namespace NtshangaseName_4123601_VRA704_Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //username: philWalter47
            //password: trebleWinner23'
            bankingApp acc = new bankingApp("Phil Foden", "philWalter47", "trebleWinner23'", "Who won the Ballon d'Or in 2014?", "Cristiano Ronaldo", 1234, 1000.00, 0, false);
            acc.loginDetails();

            while (true)
            {
                acc.menu();
            }
        }
    }

    //class to handle all the functionalities of the application
    class bankingApp
    {
        private string nameSurname;
        private string username;
        private string password;
        private string securityQ;
        private string securityA;
        private int pin;
        private double availableBalance;
        private int attemptCounter;
        private bool logIn;

        //constructor method to initialize the objects in the bankingApp class
        public bankingApp(string nameSurname, string username, string password, string securityQ, string securityA, int pin, double availableBalance, int attemptCounter, bool logIn)
        {
            this.nameSurname = nameSurname;
            this.username = username;
            this.password = password;
            this.securityQ = securityQ;
            this.securityA = securityA;
            this.pin = 1234;
            this.availableBalance = 1000.00;
            this.attemptCounter = 0;
            this.logIn = false;
        }

        //void method to check the details entered by the user
        public void loginDetails()
        {
            //loop for three attemps for the user
            while(attemptCounter < 3)
            {
                //first login attempt
                attemptCounter++;
                Console.WriteLine("Welcome to the Banking app. Enter Q to exit.\nPlease enter your username (username is case sensitive): ");
                string userName = Console.ReadLine();
                Console.WriteLine("Please enter your password. Enter 'F' for forgotten password  (password is case sensitive): ");
                string passWord = Console.ReadLine();

                //giving user option to quit program if they want to exit
                if(userName == "Q" || passWord == "Q" || userName == "q" || passWord == "q")
                {
                    Console.WriteLine("Goodbye.");
                    System.Environment.Exit(0);
                }
                //if user forgot password they will be redirected to the forgotPassword() method to recover it
                if(userName == "F" || userName == "f" || passWord == "F" || passWord == "f")
                {
                    forgotPassword();
                    break;
                }
                //if details are correct, code will break out
                if (userName == username && passWord == password)
                {
                    logIn = true;
                    Console.WriteLine("\nWelcome " + nameSurname);
                    break;
                }
                //if detials are incorrect the user has two attempts left to login
                else
                {
                    //2nd login attempt
                    attemptCounter++;
                    if(attemptCounter == 2)
                    {
                        //this time we ask for the username, password and the security question
                        Console.WriteLine("Incorrect username or password!" +
                            "\nPlease answer the following security question." +
                            "\n" + securityQ + ": ");
                        string securityAns = Console.ReadLine();
                        Console.WriteLine("Please re-enter your username: ");
                        userName = Console.ReadLine();
                        Console.WriteLine("Please re-enter your password: ");
                        passWord = Console.ReadLine();

                        //check if the details are correct to break out of loop
                        if(userName == username && passWord == password && securityAns == securityA)
                        {
                            Console.WriteLine("\nWelcome " + nameSurname);
                            break;
                        }
                        //else notify the user their account will lock and update the attempt counter
                        else
                        {
                            Console.WriteLine("Incorrect! You have 1 attempt remaining before locking your account.");
                            attemptCounter++;
                        }
                    }
                    //3rd login attempt
                    else if(attemptCounter == 3)
                    {
                        //ask user for username, password and security question one last time
                        Console.WriteLine("Please answer the following security question." +
                            "\n" + securityQ + ": ");
                        string securityAns = Console.ReadLine();
                        Console.WriteLine("Please re-enter your username: ");
                        userName = Console.ReadLine();
                        Console.WriteLine("Please re-enter your password: ");
                        passWord = Console.ReadLine();

                        //check if details entered by user are correct to break out of loop
                        if(userName == username && passWord == password && securityAns == securityA)
                        {
                            Console.WriteLine("\nWelcome " + nameSurname);
                            break;
                        }
                        //if details are still incorrect lock user account
                        else
                        {
                            Console.WriteLine("Incorrect! You have 0 attempts remaining.");
                            lockAcc();
                            break;
                        }
                    }
                }

            }
        }

        public void languageSelection()
        {
            while(true)
            {
                Console.WriteLine("Welcome. Please select a language (using 1, 2 or 3):\n1. English\n2. French\n3. Portugues");

                string userInput = Console.ReadLine();
                int userChoice;
                if (int.TryParse(userInput, out userChoice))
                {
                    switch(userChoice)
                    {
                        case 1:
                            menu();
                            break;
                        case 2:
                            menuFrench();
                            break;
                        case 3:
                            menuPortugues();
                            break;
                        default:
                            Console.WriteLine("Invalid input entered! Please try again (enter a number from 1 to 3).");
                            break;
                        }
                    }
                }

            }

            //portugues menu
            void menuPortugues()
            {
                while(true)
                {
                    Console.WriteLine("\nBem-vindo ao aplicativo bancário" +
                    "\n1. Consultar saldo disponível" +
                    "\n2. Retirar dinheiro" +
                    "\n3. Transferir dinheiro" +
                    "\n4. Alterar nome e PIN" +
                    "\n5. Ver detalhes da conta" +
                    "\n6. Sair" +
                    "\nInsira a opção: ");

                    string userInput = Console.ReadLine();
                    int userChoice;
                    if(int.TryParse(userInput, out userChoice))
                    {
                        switch (userChoice)
                        {
                            case 1:
                                checkAvailableBalance();
                                break;
                            case 2:
                                withdrawMoney();
                                break;
                            case 3:
                                eftMoney();
                                break;
                            case 4:
                                changeDetails();
                                break;
                            case 5:
                                viewDetailsOfAccount();
                                break;
                            case 6:
                                loginDetails();
                                break;
                            default:
                                Console.WriteLine("Escolha inválida selecionada! Por favor, tente novamente. (Digite um número de 1 a 6)");
                                break;
                        }
                    }
                }
            }

            //french menu
            void menuFrench()
            {
                while (true)
                {
                    Console.WriteLine("\nBienvenue sur l'application Bancaire" +
                    "\n1. Vérifier le solde disponible" +
                    "\n2. Retirer de l'argent" +
                    "\n3. Transférer de l'argent" +
                    "\n4. Changer le nom et le code PIN" +
                    "\n5. Afficher les détails du compte" +
                    "\n6. Se déconnecter" +
                    "\nEntrer une option: ");

                    string userInput = Console.ReadLine();
                    int userChoice;
                    if(int.TryParse(userInput, out userChoice))
                    {
                        switch(userChoice)
                        {
                            case 1:
                                checkAvailableBalance();
                                break;
                            case 2:
                                withdrawMoney();
                                break;
                            case 3:
                                eftMoney();
                                break;
                            case 4:
                                changeDetails();
                                break;
                            case 5:
                                viewDetailsOfAccount();
                                break;
                            case 6:
                                loginDetails();
                                break;
                            default:
                                Console.WriteLine("Choix sélectionné non valide! Veuillez réessayer. (Entrez un nombre de 1 à 6)");
                                break;
                        }
                    }
                }
            }

            //void method to display the menu (english) entered by the user
            void menu()
            {
                //loop to keep user in the menu until they enter a valid option
                while (true)
                {
                    Console.WriteLine("\nWelcome to  the Banking App" +
                    "\n1. Check Available Balance" +
                    "\n2. Withdraw Money" +
                    "\n3. Transfer Money (EFT)" +
                    "\n4. Change Name and PIN" +
                    "\n5. View Account Details" +
                    "\n6. Logout" +
                    "\nEnter option: ");

                    //checking what option the user entered to valid and verify what should be displayed next
                    string userInput = Console.ReadLine();
                    int userChoice;
                    if(int.TryParse(userInput, out userChoice))
                    {
                        switch(userChoice)
                        {
                            case 1:
                                checkAvailableBalance();
                                break;
                            case 2:
                                withdrawMoney();
                                break;
                            case 3:
                                eftMoney();
                                break;
                            case 4:
                                changeDetails();
                                break;
                            case 5:
                                viewDetailsOfAccount();
                                break;
                            case 6:
                                loginDetails();
                                break;
                            default:
                                Console.WriteLine("Invalid choice selected! Please try again. (Enter a number from 1-6)");
                                break;
                        }
                    }
                }
            }

            //method to check the available bank
            void checkAvailableBalance()
            {
                Console.WriteLine("Your available balance is: R" + availableBalance + ".00");
            }

            //method to withdraw money
            void withdrawMoney()
            {
                //loop for the user until they enter a valid input
                while(true)
                {
                    //ask the user how much they would like to withdraw
                    Console.WriteLine("Please enter how much money you would like to withdraw: ");
                    string enteredValue = Console.ReadLine();
                    double amountEntered;

                    //check if it is possible to withdraw the amount entered by the user
                    if(double.TryParse(enteredValue, out amountEntered))
                    {
                        if(amountEntered < availableBalance)
                        {
                            //updating the available balance
                            availableBalance -= amountEntered;
                            Console.WriteLine("Your withdrawal was successful.\nUpdated available balance is: R" + availableBalance + ".00");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Could not complete transaction! Insufficient funds.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number. (e.g. 540)\n");
                    }
                }
            }

            //method that transfers money to beneficiaries for the user
            void eftMoney()
            {
                //loop for the user until a valid value has been entered
                while(true)
                {
                    //asking the user how much they would like to transfer
                    Console.WriteLine("Please enter an amount to transfer: ");
                    string enteredValue = Console.ReadLine();
                    double amountEntered;
                    int beneficiaryNum;

                    //check if it is possible to transfer the amount entered by the user
                    if(double.TryParse(enteredValue, out amountEntered))
                    {
                        //telling the user to select a beneficiary to send to
                        Console.WriteLine("Select which beneficiary you'd like to transfer to:" +
                            "\n1. Wife - 89273983" +
                            "\n2.Mom - 23798292" +
                            "\n3. Dad - 19811348" +
                            "\nEnter choice: ");
                        string beneNum = Console.ReadLine();

                        //checking if varaible entered by the user is a valid input
                        if (int.TryParse(beneNum, out beneficiaryNum))
                        {
                            if(beneficiaryNum == 1)
                            {
                                Console.WriteLine("Wife selected.");
                            }
                            else if(beneficiaryNum == 2)
                            {
                                Console.WriteLine("Mom selected.");
                            }
                            else if(beneficiaryNum == 3)
                            {
                                Console.WriteLine("Dad selected.");
                            }
                            //checking if there is enough money to send what the user wants to send
                            if(amountEntered < availableBalance)
                            {
                                //updating the available balance
                                availableBalance -= amountEntered;
                                Console.WriteLine("Your transfer was successful.\nUpdated available balance is: R" + availableBalance + ".00");
                                break;
                            }
                            //telling user if transaction was unsuccessful
                            else
                            {
                                Console.WriteLine("Could not complete transaction! Insufficient funds.");
                            }
                        }
                        //if user inputs an invalid option this will be displayed
                        else
                        {
                            Console.WriteLine("Invalid option selected! Try again.");
                        }

                    }
                    //if user inputs an invalid option this will be displayed
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number. (e.g. 540)\n");
                    }
                }
            }

            //method to change details for the user
            void changeDetails()
            {
                //loop method until a valid name, surname and pin has been entered
                while(true)
                {
                    Console.WriteLine("Please enter new name: ");

                    //checking if name isn't null
                    if(!string.IsNullOrWhiteSpace(nameSurname))
                    {
                        nameSurname = Console.ReadLine();
                        Console.WriteLine("Please enter a new pin (4-digit number): ");
                        string newPin = Console.ReadLine();

                        //checking if int entered is valid
                        if (int.TryParse(newPin, out pin) && pin >= 1000 && pin <= 9999)
                        {
                            //pin = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Name and PIN change was successful!");

                            //exit loop once valid data has been entered
                            break;
                        }
                        //display error for user
                        else
                        {
                            Console.WriteLine("Invalid PIN! Please enter a valid 4-digit PIN. (e.g. 1234)");
                        }
                    }
                    //display error for user
                    else
                    {
                        Console.WriteLine("Invalid name! Please enter a valid name. (e.g. Reece James)");
                    }
                }
            }

            //method to view the details of the users account
            void viewDetailsOfAccount()
            {
                Console.WriteLine("Account Details:" +
                    "\nName: " + nameSurname + "" +
                    "\nPIN: " + pin + "" +
                    "\nAvailable Balance: " + availableBalance + ".00");
            }

            //method to lock the users account after too many failed attempts to log in
            void lockAcc()
            {
                //set login varaible to false since user account has been locked
                logIn = false;
                Console.WriteLine("Your account has been locked after 3 failed attempts to log in.\nTry unlocking your account in the next menu.");
                //redirecting user into unlocking account menu
                unlockAcc();
            }

            //method to unlock the users account after it has been locked
            void unlockAcc()
            {
                //asking user to input username and answer the security question
                Console.WriteLine("Enter your username to unlock your account: ");
                string userInput = Console.ReadLine();
                Console.WriteLine("Answer the following security question to unlock your account:\n" + securityQ);
                string securityAnswer = Console.ReadLine();

                //if answers are correct user will be able to log in again
                if(userInput == username && securityAnswer == securityA)
                {
                    logIn = true;
                    Console.WriteLine("Account successfully unlocked!\n");
                    loginDetails();
                }
                //closing program if unlocking is unsuccessful
                else
                {
                    Console.WriteLine("Account unlocking unsuccessful.\nGoodbye!");
                    System.Environment.Exit(0);
                }
            }

            //method for the user to access their password if forgotten
            void forgotPassword()
            {
                //giving the user a security question to answer before they're shown their password
                Console.WriteLine("Please answer the question below to recover password (You only get one attempt to recover your password).");
                Console.WriteLine(securityQ);
                string userInput = Console.ReadLine();

                //if the answer is correct the user will be shown their password
                if (userInput == securityA)
                {
                    Console.WriteLine("Password recovery successful.\nYour password is: " + password + "\nYou will be redirected to the login screen");
                    loginDetails();
                }
                //if incorrect the user is told the recovery was unsuccessful and the program closes
                else
                {
                    Console.WriteLine("Password recovery failed.\nExiting banking app.");
                    System.Environment.exit(0);
                }
            }
    }
}
