using Assessment;
Competition comp = new Competition();

comp.LoadFromFile();
int userInput;
do
{
    Console.WriteLine(" ");
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1. Add a new competitor");
    Console.WriteLine("2. Remove a competitor");
    Console.WriteLine("3. Clear competition details");
    Console.WriteLine("4. Display Event Details");
    Console.WriteLine("5. Save all details to file");
    Console.WriteLine("6. Sort competitors by their age");
    Console.WriteLine("7. Display competitors with a certain number of career wins");
    Console.WriteLine("8. Display all competition qualifiers");
    Console.WriteLine("9. Exit");
    Console.WriteLine(" ");
    Console.WriteLine("Select an option");
    userInput = Convert.ToInt32(Console.ReadLine());
    switch (userInput)
    {
        case 1:
            comp.AddCompetitor(new Competitor());
            break;

        case 2:
            comp.RemoveCompetitor();
            break;
        
        case 3:
            comp.ClearAll();
            break;

        case 4:
            comp.GetAllByEvent();
            break;

        case 5:
            comp.SaveToFile();
            break;

        case 6:
            comp.SortCompetitorsByAge();
            break;

        case 7:
            comp.Winners();
            break;

        case 8:
            comp.GetQualifiers();
            break;

        case 9:
            comp.SaveToFile();
            Console.WriteLine("Goodbye");
            break;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (userInput != 9);




