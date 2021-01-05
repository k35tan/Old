//Kelly Tan
//Pig Game - Single player or multiplayer - multiple level types


static void Dice(int dice)
{
if (dice == 1)
{
Console.WriteLine("\n");
Console.WriteLine("-----");
Console.WriteLine("| |");
Console.WriteLine("| o |");
Console.WriteLine("| |");
Console.WriteLine("-----");
}
else if (dice == 2)
{
Console.WriteLine("\n");
Console.WriteLine("-----");
Console.WriteLine("|o |");
Console.WriteLine("| |");
Console.WriteLine("| o|");
Console.WriteLine("-----");
}
else if (dice == 3)
{
Console.WriteLine("\n");
Console.WriteLine("-----");
Console.WriteLine("|o |");
Console.WriteLine("| o |");
Console.WriteLine("| o|");
Console.WriteLine("-----");
}
else if (dice == 4)
{
Console.WriteLine("\n");
Console.WriteLine("-----");
Console.WriteLine("|o o|");
Console.WriteLine("| |");
Console.WriteLine("|o o|");
Console.WriteLine("-----");
}
else if (dice == 5)
{
Console.WriteLine("\n");
Console.WriteLine("-----");
Console.WriteLine("|o o|");
Console.WriteLine("| o |");
Console.WriteLine("|o o|");
Console.WriteLine("-----");
}
else if (dice == 6)
{
Console.WriteLine("\n");
Console.WriteLine("-----");
Console.WriteLine("|o o|");
Console.WriteLine("|o o|");
Console.WriteLine("|o o|");
Console.WriteLine("-----");
}
}
static void Happy()
{
Console.WriteLine(" _____ ");
Console.WriteLine(" .' '. ");
Console.WriteLine(" / o o \\ ");
Console.WriteLine(" | | ");
Console.WriteLine(" | \\ / | ");
Console.WriteLine(" \\ '--' / ");
Console.WriteLine(" '._____.' ");
}
static void Sad()
{
Console.WriteLine(" _____ ");
Console.WriteLine(" .' '. ");
Console.WriteLine(" / o o \\ ");
Console.WriteLine(" | | ");
Console.WriteLine(" | ,--, | ");
Console.WriteLine(" \\ / \\ / ");
Console.WriteLine(" '._____.' ");
}
static void Main(string[] args)
{
string playagain;
int players;
int total1 = 0;
int total2 = 0;
int dice = 0;
int dicetotal = 0;
int a = 0;
int turns = 0;
int turns2 = 0;
int points = 0;
int round = 1;
int difference = 0;
int pointsleft = 0;
int average = 0;
int roundsleft = 0;
string rollagain = "0";
string difficult = "0";
Random rand = new Random();
Console.BackgroundColor = ConsoleColor.White; //white background, black text
Console.Clear();
Console.ForegroundColor = ConsoleColor.Black;
do
{
do
{
Console.Write("\nHow many players are there (1/2): "); //single player or multiplayer
players = int.Parse(Console.ReadLine());
if (players != 1 && players != 2)
{
Console.WriteLine("Please enter a valid option");
}
} while (players != 1 && players != 2); //makes sure input is valid
if (players == 1) //single player
{
do
{
Console.Write("\nWhat difficulty would you like (e/m/h): "); //difficulty
difficult = Console.ReadLine();
if (difficult != "e" && difficult != "m" && difficult != "h")
{
Console.WriteLine("Please enter a valid option");
}
} while (difficult != "e" && difficult != "m" && difficult != "h"); //makes sure input is valid
while (total1 < 100 && total2 < 100)
{
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYour turn"); //player's turn
do
{
dice = rand.Next(1, 7);
System.Threading.Thread.Sleep(2000);
Dice(dice);
if (dice == 1) //ends turn if 1 is rolled, no points are gained
{
Console.WriteLine("You have rolled a 1");
Console.WriteLine("You have gained no points this turn");
Sad();
break;
}
dicetotal += dice;
Console.WriteLine("You have rolled a " + dice);
Console.WriteLine("You have " + dicetotal + " points for this turn");
if (total1 + dicetotal >= 100) //ends turn if total points is equal or greater than 100, add accumulated points to total score
{
total1 += dicetotal;
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYou have gained " + dicetotal + " points this turn");
Happy();
break;
}
System.Threading.Thread.Sleep(2000);
do
{
Console.Write("\nWould you like to roll again (y/n): "); //asks if player wants to roll again
rollagain = Console.ReadLine();
if (rollagain != "y" && rollagain != "n")
{
Console.WriteLine("Please enter a valid option");
}
} while (rollagain != "y" && rollagain != "n"); //makes sure input is valid
if (rollagain == "n") //if player choses to stop rolling, add accumulated points to total score
{
total1 += dicetotal;
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYou have gained " + dicetotal + " points this turn");
Happy();
}
} while (rollagain == "y");
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYou have a total of " + total1 + " points"); //output player's total points
dicetotal = 0;
if (total1 >= 100) //break loop if player has won
{
break;
}
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYour opponents's turn"); //AI's turn
if (difficult == "e") //easy = random number of rolls between 1 and 6
{
turns = rand.Next(1, 7);
a = 1;
for (; a <= turns; a++)
{
dice = rand.Next(1, 7);
System.Threading.Thread.Sleep(2000);
Dice(dice);
if (dice == 1) //ends turn if 1 is rolled, no points are gained
{
Console.WriteLine("Your opponent has rolled a 1");
Console.WriteLine("Your oppenent has gained no points this turn");
break;
}
dicetotal += dice;
Console.WriteLine("Your opponent has rolled a " + dice);
if (total2 + dicetotal >= 100) //ends turn if total points is equal or greater than 100, add accumulated points to total score
{
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYour oppenent has gained " + dicetotal + " points this turn");
total2 += dicetotal;
break;
}
else if (a == turns) //after x rolls, add accumulated points to total score
{
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYour oppenent has chose to stop rolling");
Console.WriteLine("Your oppenent has gained " + dicetotal + " points this turn");
total2 += dicetotal;
}
}
}
else if (difficult == "m") //medium
{
if (total1 >= total2) //if player is ahead, number of rolls between 4 and 6, points between 15 and 20
{
turns = rand.Next(4, 7);
points = rand.Next(15, 21);
}
else if (total1 < total2) //if player behind, number of rolls between 1 and 3, points between 10 and 15
{
turns = rand.Next(1, 4);
points = rand.Next(10, 16);
}
while (turns2 < turns && dicetotal < points) //keep rolling until x rolls or x points is reached
{
dice = rand.Next(1, 7);
System.Threading.Thread.Sleep(2000);
Dice(dice);
if (dice == 1) //ends turn if 1 is rolled, no points are gained
{
Console.WriteLine("Your opponent has rolled a 1");
Console.WriteLine("Your oppenent has gained no points this turn");
break;
}
dicetotal += dice;
Console.WriteLine("Your opponent has rolled a " + dice);
turns2++;
if (total2 + dicetotal >= 100) //ends turn if total points is equal or greater than 100, add accumulated points to total score
{
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYour oppenent has gained " + dicetotal + " points this turn");
total2 += dicetotal;
break;
}
else if (turns2 >= turns || dicetotal >= points) //when x rolls or x points is reached, add accumulated points to total score
{
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYour oppenent has chose to stop rolling");
Console.WriteLine("Your oppenent has gained " + dicetotal + " points this turn");
total2 += dicetotal;
}
}
}
else if (difficult == "h") //hard - calculates - points left from winning, difference of points between player and AI, average points player gets per turn, rounds left
{
if (total1 >= total2)
{
pointsleft = 100 - total1;
difference = total1 - total2;
average = total1 / round;
if (average == 0)
{
average = 1;
}
roundsleft = pointsleft / average;
points = difference / roundsleft + average + 2; //points is the difference of points between the player and AI divided by the rounds left plus the average points player gets per turn plus 2 (to be safe)
}
else if (total1 < total2)
{
pointsleft = 100 - total2;
difference = total2 - total1;
average = total1 / round;
if (average == 0)
{
average = 1;
}
roundsleft = pointsleft / average;
points = average - (difference / roundsleft) + 2; //points is the average points player gets per turn subtract the difference of points between the player and AI divided by the rounds left plus 2 (to be safe)
if (points < 5) //if AI is far ahead, roll until 5 points is reached
{
points = 5;
}
}
if (roundsleft == 0 || roundsleft == 1) //if only one round left, roll until AI wins
{
while (true)
{
dice = rand.Next(1, 7);
System.Threading.Thread.Sleep(2000);
Dice(dice);
if (dice == 1) //ends turn if 1 is rolled, no points are gained
{
Console.WriteLine("Your opponent has rolled a 1");
Console.WriteLine("Your oppenent has gained no points this turn");
break;
}
dicetotal += dice;
Console.WriteLine("Your opponent has rolled a " + dice);
if (total2 + dicetotal >= 100) //ends turn if total points is equal or greater than 100, add accumulated points to total score
{
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYour oppenent has gained " + dicetotal + " points this turn");
total2 += dicetotal;
break;
}
}
}
else
{
while (dicetotal < points) //keep rolling until x points is reached
{
dice = rand.Next(1, 7);
System.Threading.Thread.Sleep(2000);
Dice(dice);
if (dice == 1) //ends turn if 1 is rolled, no points are gained
{
Console.WriteLine("Your opponent has rolled a 1");
Console.WriteLine("Your oppenent has gained no points this turn");
break;
}
dicetotal += dice;
Console.WriteLine("Your opponent has rolled a " + dice);
if (total2 + dicetotal >= 100) //ends turn if total points is equal or greater than 100, add accumulated points to total score
{
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYour oppenent has gained " + dicetotal + " points this turn");
total2 += dicetotal;
break;
}
else if (dicetotal >= points) //when x points is reached, add accumulated points to total score
{
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYour oppenent has chose to stop rolling");
Console.WriteLine("Your oppenent has gained " + dicetotal + " points this turn");
total2 += dicetotal;
}
}
}
}
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\nYour opponent has a total of " + total2 + " points"); //output AI's total points
dicetotal = 0;
turns2 = 0;
round++;
}
System.Threading.Thread.Sleep(2000);
if (total1 >= 100) //output final score
{
Console.WriteLine("\nYou have won with " + total1 + " points");
Console.WriteLine("Your opponent has lost with " + total2 + " points");
}
else
{
Console.WriteLine("\nYour opponent has won with " + total2 + " points");
Console.WriteLine("You have lost with " + total1 + " points");
}
}
else if (players == 2) //multiplayer
{
Console.WriteLine("\nEnter your names");
Console.Write("Player 1: ");
string player1 = Console.ReadLine();
Console.Write("Player 2: ");
string player2 = Console.ReadLine();

while (total1 < 100 && total2 < 100)
{
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\n" + player1 + "'s turn");
do
{
dice = rand.Next(1, 7);
System.Threading.Thread.Sleep(2000);
Dice(dice);
if (dice == 1) //ends turn if 1 is rolled, no points are gained
{
Console.WriteLine(player1 + " has rolled a 1");
Console.WriteLine(player1 + " has gained no points this turn");
Sad();
break;
}
dicetotal += dice;
Console.WriteLine(player1 + " has rolled a " + dice);
Console.WriteLine(player1 + " has " + dicetotal + " points for this turn");
if (total1 + dicetotal >= 100) //ends turn if total points is equal or greater than 100, add accumulated points to total score
{
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\n" + player1 + " has gained " + dicetotal + " points this turn");
Happy();
total1 += dicetotal;
break;
}
System.Threading.Thread.Sleep(2000);
do
{
Console.Write("\nWould you like to roll again " + player1 + " (y/n): "); //asks if player wants to roll again
rollagain = Console.ReadLine();
if (rollagain != "y" && rollagain != "n")
{
Console.WriteLine("Please enter a valid option");
}
} while (rollagain != "y" && rollagain != "n"); //makes sure input is valid
if (rollagain == "n") //if player choses to stop rolling, add accumulated points to total score
{
total1 += dicetotal;
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\n" + player1 + " has gained " + dicetotal + " points this turn");
Happy();
}
} while (rollagain == "y");
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\n" + player1 + " has a total of " + total1 + " points"); //output player's total points
dicetotal = 0;
if (total1 >= 100) //break loop if player has won
{
break;
}
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\n" + player2 + "'s turn");
do
{
dice = rand.Next(1, 7);
System.Threading.Thread.Sleep(2000);
Dice(dice);
if (dice == 1) //ends turn if 1 is rolled, no points are gained
{
Console.WriteLine(player2 + " has rolled a 1");
Console.WriteLine(player2 + " has gained no points this turn");
Sad();
break;
}
dicetotal += dice;
Console.WriteLine(player2 + " has rolled a " + dice);
Console.WriteLine(player2 + " has " + dicetotal + " points for this turn");
if (total2 + dicetotal >= 100) //ends turn if total points is equal or greater than 100, add accumulated points to total score
{
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\n" + player2 + " has gained " + dicetotal + " points this turn");
Happy();
total2 += dicetotal;
break;
}
System.Threading.Thread.Sleep(2000);
do
{
Console.Write("\nWould you like to roll again " + player2 + " (y/n): "); //asks if player wants to roll again
rollagain = Console.ReadLine();
if (rollagain != "y" && rollagain != "n")
{
Console.WriteLine("Please enter a valid option");
}
} while (rollagain != "y" && rollagain != "n"); //makes sure input is valid
if (rollagain == "n") //if player choses to stop rolling, add accumulated points to total score
{
total2 += dicetotal;
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\n" + player2 + " has gained " + dicetotal + " points this turn");
Happy();
}
} while (rollagain == "y");
System.Threading.Thread.Sleep(2000);
Console.WriteLine("\n" + player2 + " has a total of " + total2 + " points"); //output player's total points
dicetotal = 0;
}
System.Threading.Thread.Sleep(2000);
if (total1 >= 100) //output final score
{
Console.WriteLine("\n" + player1 + " has won with " + total1 + " points");
Console.WriteLine(player2 + " lost with " + total2 + " points");
}
else
{
Console.WriteLine("\n" + player2 + " has won with " + total2 + " points");
Console.WriteLine(player1 + " lost with " + total1 + " points");
}
}
do
{
Console.Write("\nWould you like to play again (y/n): "); //asks player if they want to play again
playagain = Console.ReadLine();
if (playagain != "y" && playagain != "n")
{
Console.WriteLine("Please enter a valid option");
}
} while (playagain != "y" && playagain != "n"); //makes sure input is valid
} while (playagain == "y");
}
