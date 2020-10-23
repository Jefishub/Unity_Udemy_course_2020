using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hacker : MonoBehaviour
{
    //game state
    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    { 
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to Terminal Hacker\nPlease choose the level of difficulty");
        Terminal.WriteLine("Press 1 for Easy, press 2 for Hard");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        //we can always go direct to main menu
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Application.Quit();
        }
        else if (input == "hint")
        {
            if (level == 1 || level == 2)
            {
                Terminal.WriteLine(password.Anagram());
            }
            else
            {
                Terminal.WriteLine("Do you really need a hint ?");
            }
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = house[Random.Range(0, house.Length)];
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = science[Random.Range(0, science.Length)];
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    int limit = 3; // 3 tries per password
    string[] house = { "window", "table", "room", "door", "bed" }; //level 1
    string[] science = {"climatologist", "entanglement", "observatory", "electricity", "astrophysics"}; //level 2

    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Correct password entered");
        Terminal.WriteLine("You have now access to everything! ");
        ShowLevelReward();
        Terminal.WriteLine("write 'menu' if you want to go back to Main Menu");
        limit = 3;
        level = 0;
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    ______
   /     //
  /     //
 /     //
(_____(/
"
                );
                break;

            case 2:
                Terminal.WriteLine("Have a scroll...");
                Terminal.WriteLine(@"
 ________
(_______()
|        |
| E=mc2  |
|________|"
                );
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (level == 1)
        {
            if (input == password)
            {
                WinScreen();
            }
            else
            {
                NotCorrect();
            }
        }
        else if (level == 2)
        {
            if (input == password)

            {
                WinScreen();
            }
            else
            {
                NotCorrect();
            }
        }
    }

    void NotCorrect()
    {
        limit -= 1;

        Terminal.WriteLine("Incorrect password");
        if (limit == 0)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("SHUTTING DOWN");
            Terminal.WriteLine("Type 'menu' to go back to Main Menu");
            limit = 3;
            level = 0;
        }
        else
        {
            Terminal.WriteLine("You have " + limit + " tries left");
            Terminal.WriteLine("Try again:");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password:");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
