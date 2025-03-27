public class View
{
    public void DisplayInFrame(string info)
    {                             //auto-adjustable frame
        int contentLength = info.Length + 2;        // +2 to include whitespaces both at start and end
        string line = new string('═', contentLength);
        string top = "╔" + line + "╗";
        string middle = "║ " + info + " ║";
        string bottom = "╚" + line + "╝";
        string header = $"{top}\n{middle}\n{bottom}";
        Console.WriteLine(header);
    }

    public void DisplayMenu(Dictionary<int, string> menu)
    {
        foreach (var items in menu)
        {
            Console.WriteLine($"{items.Key}. {items.Value}");
        }
        Console.WriteLine("─────────────────────────────");
    }

    public void DisplayPersonalGreeting(string greeting)
    {
        DisplayInFrame(greeting);
    }

    public void DisplayHoroscope(string horoscope)
    {
        DisplayInFrame(horoscope);
    }
}