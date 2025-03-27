using System.Text.RegularExpressions;

public class Input{
    public string GetProperInput(){
        string? userInput = Console.ReadLine();
        return userInput switch{
            _ when userInput == null || userInput.Trim() == "" => throw new Exception("Empty input"),
            _ => userInput.Trim()
        };
    }

    public bool TryGetMenuItem(Dictionary<int, string> menu, out int item){
        Console.WriteLine("Select a menu item:");
        if(int.TryParse(GetProperInput(), out int number) && menu.Keys.Any(n => n == number)){
            item = number;
            return true;
        }else{
            item = -1;
            throw new Exception("Invalid number");
        }
    }

    public bool TryGetBirthDate(out DateTime birthDate){
        Console.WriteLine("Enter your birth date:");
        if(DateTime.TryParse(GetProperInput(), out DateTime result)){
            birthDate = result;
            return true;
        }else{
            birthDate = new DateTime();
            throw new Exception("Invalid date format");
        }
    }
    public bool TryGetName(out string name){
        Console.WriteLine("Enter your name:");
        string nameRegex = @"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$"; 
        string Name = GetProperInput();
        if (Regex.IsMatch(Name, nameRegex)){
            name = Name;
            return true;
        }else{
            name = "";
            throw new Exception("Invalid format, try again");
        }
    }
}