using System.Text.RegularExpressions;
using TextBasedAdventureGame.Classes;

Console.WriteLine("You went exploring to the bottom of the ocean. Unfortunately your sub has broken down,\nand you need to send a distress call. The system was built by a madman who wanted to\nensure no false distresses could be sent. You’re running out of air and time.");

//Instantiating Objects
PlayerClass user = new();
Puzzle radioPuzzle = new("Radio puzzle","Map");
Puzzle deskPuzzle = new("Button Puzzle", "Riddle Letter");
Puzzle bookcasePuzzle = new("Bookcase puzzle", "morse code book");
Puzzle computerPuzzle = new("Computer puzzle", "Headset");

//Entering player name to be used in letter below
Console.WriteLine("\nWelcome to Escape the Sub. Please enter your name:");
string name = Console.ReadLine();
if (name != null)
    user.name = name;

Console.WriteLine("\nYou find a letter from Dr. X:");
Console.WriteLine($"\n     Dear {user.name},\n     I have devised a distress system to get you out of tough situations.\n     However you must find the 4 pieces of the distress beacon and assemble it.\n     Please respond to this letter via carrier pigeon if you have any questions.\n     Sincerely,\n     Dr. X");

//Main game loop, seeing if player has all 4 pieces (win condition)
while (user.beaconPieces != 4)
{
    //Player choice to navigate the room
    Console.WriteLine("\nYou have " + user.beaconPieces + " piece(s) of the distress beacon.");
    Console.WriteLine("\nPlease choose a object in the room:\n1) Radio with complicated looking maps on the wall\n2) Desk with a lot of buttons on it\n3) A computer and a radio with a headset\n4) Bookcase with a safe at the bottom\n5) Quit");

    string objectChoice = Console.ReadLine();
    int objectValue;

    //Checking input to make sure its a valid number
    if (int.TryParse(objectChoice, out objectValue) && objectValue >= 1 && objectValue <= 5)
    {
        //Puzzle 1, Radio Puzzle
        if (objectValue == 1)
        {
            //If puzzle is solved, dont need to be here
            if (radioPuzzle.solved)
                Console.WriteLine("\nYou've solved this puzzle already.");

            //Radio Interaction Loop, main 3 choices
            while (radioPuzzle.solved == false)
            {
                Console.WriteLine("\nYou're sitting at the radio, there's a map on the wall");
                Console.WriteLine("1) Change Radio Dials\n2) Inspect Map\n3) Back");

                string radioInput = Console.ReadLine();
                int radioValue;

                //Radio Interaction
                if (int.TryParse(radioInput, out radioValue) && radioValue >= 1 && radioValue <= 3)
                {
                    //Choosing change radio dials
                    if (radioValue == 1)
                    {
                        //Inputting the first dial setting
                        Console.WriteLine("Please enter the first dial setting (A-Z), or 0 to go back");
                        string dialInput1 = Console.ReadLine();
                        int dialValue1;

                        if (dialInput1.Length == 1 && char.IsLetter(dialInput1[0]))
                        {
                            //Inputting second dial setting
                            Console.WriteLine("Please enter the second dial setting (1-20), or 0 to go back");
                            string dialInput2 = Console.ReadLine();
                            int dialValue2;

                            if (int.TryParse(dialInput2, out dialValue2) && dialValue2 >= 0 && dialValue2 <= 20)
                                //Checking if player inputs are correct settings.
                                if (dialInput1 == "F" && dialValue2 == 3)
                                {
                                    Console.WriteLine("\nYou found a piece of the distress beacon!");
                                    radioPuzzle.solved = true;
                                    user.beaconPieces++;
                                }
                                //Break option
                                else if (dialValue2 == 0)
                                    break;
                                else
                                {
                                    Console.WriteLine("Nothing happens.");
                                }
                            else
                                Console.WriteLine("Please enter a valid input.");
                        }
                        else if (int.TryParse(dialInput1, out dialValue1) && dialValue1 == 0)
                            break;
                        else
                            Console.WriteLine("Please enter a valid input.");
                    }
                    //Looking at the Map
                    else if (radioValue == 2)
                    {
                        Console.WriteLine("\nYou look at the map on the wall.");
                        Console.WriteLine("\nJohnny the Pirate's Treasure Map\n      A      B      C      D      E      F      G      H      I      J      K      L\r\n --+------+------+------+------+------+------+------+------+------+------+------+------+\r\n 1 |      |      |      |      |      |      |      |      |      |      |      |      |\r\n   |      |      |      |      |      |      |      |      |      |      |      |      |\r\n --+------+------+------+------+------+------+------+------+------+------+------+------+\r\n 2 |      |  @@  |      |      |      |      |      |      |      |      |      |      |\r\n   |      |  @@  |      |      |      |      |      |      |      |      |      |      |\r\n --+------+------+------+------+------+------+------+------+------+------+------+------+\r\n 3 |      |      |      |      |      |  \\/  |      |      |      |  $$  |      |      |\r\n   |      |      |      |      |      |  /\\  |      |      |      |  $$  |      |      |\r\n --+------+------+------+------+------+------+------+------+------+------+------+------+\r\n 4 |      |      |      |      |      |      |      |      |      |      |      |      |\r\n   |      |      |      |      |      |      |      |      |      |      |      |      |\r\n --+------+------+------+------+------+------+------+------+------+------+------+------+\r\n 5 |      |      |  /\\  |      |      |      |      |      |      |      | -->  |      |\r\n   |      |      |  \\/  |      |      |      |      |      |      |      | -->  |      |\r\n --+------+------+------+------+------+------+------+------+------+------+------+------+\r\n 6 |      |      |      |      |      |      |      |  ┌┐  |      |      |      |      |\r\n   |      |      |      |      |      |      |      |  └┘  |      |      |      |      |\r\n --+------+------+------+------+------+------+------+------+------+------+------+------+\r\n 7 |      |      |  %%  |      |      |      |      |      |      |      |      |      |\r\n   |      |      |  %%  |      |      |      |      |      |      |      |      |      |\r\n --+------+------+------+------+------+------+------+------+------+------+------+------+\r\n 8 |      |      |      |      |      |      |      |      |      |      |      |      |\r\n   |      |      |      |      |      |      |      |      |      |      |      |      |\r\n --+------+------+------+------+------+------+------+------+------+------+------+------+\nX marks the spot!");
                    }
                    //Going back
                    else if (radioValue == 3)
                        break;
                    else
                        Console.WriteLine("\nPlease enter a valid choice:\n");
                }
                else
                    Console.WriteLine("\nPlease enter a valid Choice");
            }

        }
        //Puzzle 2, Button Puzzle
        else if (objectValue == 2)
        {
            if (deskPuzzle.solved)
            {
                Console.WriteLine("\nYou've solved this puzzle already.");
            }
            while (deskPuzzle.solved == false)
            {
                Console.WriteLine("\nYou walk up to the desk.");
                Console.WriteLine("The desk is filled with red buttons");
                Console.WriteLine("You count them and find there are 26 in total");
                Console.WriteLine("The buttons are each labeled with a number, 1-26");
                Console.WriteLine("On the desk you find a handwritten note");
                Console.WriteLine("\n1) Start pressing buttons \n2) Inspect note \n3) Back");
                string deskInput = Console.ReadLine();
                int deskValue;

                if (int.TryParse(deskInput, out deskValue) && deskValue >= 1 && deskValue <= 3)
                {
                    if (deskValue == 1)
                    {
                        Console.WriteLine("\nPress a button!: ");
                        string buttonInput1 = Console.ReadLine();
                        int buttonValue1;
                        if (int.TryParse(buttonInput1, out buttonValue1) && buttonValue1 >= 0 && buttonValue1 <= 26)
                        {
                            Console.WriteLine("\nPress another!: ");
                            string buttonInput2 = Console.ReadLine();
                            int buttonValue2;
                            if (int.TryParse(buttonInput2, out buttonValue2) && buttonValue2 >= 0 && buttonValue2 <= 26)
                            {
                                Console.WriteLine("\nWhy not one more!: ");
                                string buttonInput3 = Console.ReadLine();
                                int buttonValue3;
                                if (int.TryParse(buttonInput3, out buttonValue3) && buttonValue3 >= 0 && buttonValue3 <= 26)
                                {
                                    if (buttonValue1 == 4 && buttonValue2 == 18 && buttonValue3 == 24)
                                    {
                                        Console.WriteLine("You hear a thud at your feet");
                                        Console.WriteLine("Its a piece of the distress beacon!");
                                        deskPuzzle.solved = true;
                                        user.beaconPieces++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nThe desk doesnt do anything, but it was pretty fun pushing the buttons.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nPlease enter a valid input.");
                                }
                            }
                        }
                    }
                    else if (deskValue == 2)
                    {
                        Console.WriteLine("\nYou pick up the note and read it");
                        Console.WriteLine("\n      Greetings! The brilliant DR.X hopes you enjoy this desk of buttons.");
                        Console.WriteLine("      This is merely a recreational activity, press as many buttons as you like.");
                        Console.WriteLine("      P.S. There is absolutley NO SECRET CODE hidden in this note that you input with the buttons!");
                        Console.WriteLine("      P.P.S SERIOUSLY!!! NO CODE!!!");
                        Console.WriteLine("\nThe letter obviously has a secret code as DR.X is printed in red");
                        Console.WriteLine("How could this be put into the desk?");
                    }
                    else if (deskValue == 3)
                    {
                        break;
                    }
                }
            }
        }
        //Puzzle 3, Computer Puzzle
        else if (objectValue == 3)
        {
            //If puzzle is solved, dont need to be here
            if (computerPuzzle.solved)
                Console.WriteLine("\nYou've solved this puzzle already.");

            //Computer Interaction Loop, main 3 choices
            while (computerPuzzle.solved == false)
            {
                Console.WriteLine("\nYou're sitting at the computer, there's a headset laying next to it.");
                Console.WriteLine("The computer screen blank, with a prompt for \"Activation Key\".");
                Console.WriteLine($"1) Input Code\n2) Put on {computerPuzzle.item}\n3) Back");

                string computerInput = Console.ReadLine();
                int computerValue;

                //Computer Interaction
                if (int.TryParse(computerInput, out computerValue) && computerValue >= 1 && computerValue <= 3)
                {
                    //Choosing Input Code
                    if (computerValue == 1)
                    {
                        //Inputting Code
                        Console.WriteLine("Please enter the activation key in all caps, or 0 to go back");
                        string keyInput = Console.ReadLine();
                        int keyValue;

                        //Checking if Code is A-Z
                        if (Regex.IsMatch(keyInput, @"^[A-Z]+$"))
                        {
                            //Checking if code is correct
                            if ((keyInput == "REDOCTOBER"))
                            {
                                Console.WriteLine("\nYou found a piece of the distress beacon!");
                                computerPuzzle.solved = true;
                                user.beaconPieces++;
                            }
                            else
                            {
                                Console.WriteLine("\nNothing happens.");
                            }
                        }
                        else if (int.TryParse(keyInput, out keyValue) && keyValue == 0)
                            break;
                        else
                            Console.WriteLine("\nPlease enter a valid input.");
                    }
                    //Listening to the headset
                    else if (computerValue == 2)
                    {
                        Console.WriteLine("\nYou put the headset on and hear Morse Code.");
                        if (user.items.Contains("morse code book"))
                            Console.WriteLine("REDOCTOBER");
                        else
                            Console.WriteLine("\n.-.  .  -..  ---  -.-.  -  ---  -...  .  .-.\n**There might be something to help you translate**");
                    }
                    //Going back
                    else if (computerValue == 3)
                        break;
                    else
                        Console.WriteLine("\nPlease enter a valid choice:\n");
                }
                else
                    Console.WriteLine("\nPlease enter a valid Choice");
            }
        }
        //Puzzle 4, Bookcase Puzzle
        else if (objectValue == 4)
        {

            if (bookcasePuzzle.solved)
                Console.WriteLine("\nYou've solved this puzzle already.");

            while (bookcasePuzzle.solved == false)
            {
                Console.WriteLine("\nYou walk up to the intimidating bookshelf, the books are arranged in a mix of brown books and on the middle shelf, you notice bright red and blue books.");
                Console.WriteLine("You find a morse code translation book on the top shelf.");
                user.items.Add(bookcasePuzzle.item);
                Console.WriteLine("\n*added morse code book to inventory*");
                Console.WriteLine("\nNext to it you notice a safe with a 3 digit code");
                Console.WriteLine("The books dont seem to have been just thrown on the shelf, someone put them where they are with a purpose.");
                Console.WriteLine("How could this give me a number?");
                Console.WriteLine("\n1) Inspect bookshelf\n2) Inspect safe\n3) Back");

                string bookcaseInput = Console.ReadLine();
                int bookcaseValue;

                if (int.TryParse(bookcaseInput, out bookcaseValue) && bookcaseValue >= 1 && bookcaseValue <= 3)
                {
                    if (bookcaseValue == 1)
                    {
                        Console.WriteLine("\nYou look at the colored books in order");
                        Console.WriteLine("<<red, blue, red, red, blue, red, red, red>>");
                    }

                    else if (bookcaseValue == 2)
                    {
                        Console.WriteLine("You walk over to the safe and look at the dial");
                        Console.WriteLine("Above the dial you see a faint scratch");
                        Console.WriteLine("The numbers 1 and 0 are scratched into the safe");
                        Console.WriteLine("Enter the code here");
                        string safeInput = Console.ReadLine();
                        int safeValue;

                        if (int.TryParse(safeInput, out safeValue) && safeValue >= 0 && safeValue <= 999)
                            if (safeValue == 183)
                            {
                                Console.WriteLine("The safe swings open");
                                Console.WriteLine("You found a piece of the distress beacon!");
                                bookcasePuzzle.solved = true;
                                user.beaconPieces++;
                            }
                            else
                            {
                                Console.WriteLine("\nThe safe lies dormant");
                            }
                        else
                        {
                            Console.WriteLine("\n Please enter a valid input");
                        }
                    }
                    else if (bookcaseValue == 3)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valid input");
                }
            }
        }

        //Quit
        else if (objectValue == 5)
            break;
        else
            Console.WriteLine("\nPlease enter a valid choice:\n");
    }
    else
        Console.WriteLine("\nPlease enter a valid choice:\n");

}

if (user.beaconPieces == 4)
    Console.WriteLine("\nYou frantically put all the pieces together, assembling the distress beacon. Pushing the large \"SOS\" button on the front, you breathe a sigh of relief as you know you're saved.. eventually that is. You swear you're going to wring Dr. X's neck next time you see him.");

Console.WriteLine("\nThank you for playing :)\nPress enter to quit");
Console.ReadLine();

//Copy paste for integer input validation
//if (int.TryParse(var1, out var2) && var2 >= 1 && var2 <= 3)
//{ }
//else
//Console.WriteLine("\nPlease enter a valid choice:\n");