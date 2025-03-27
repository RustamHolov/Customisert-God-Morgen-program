public class Controller
{
    private Greeting Greeting { get; set; }
    private View View { get; set; }
    private Input Input { get; set; }
    public Controller(Greeting greeting, View view, Input input)
    {
        Greeting = greeting;
        View = view;
        Input = input;
    }

    public Dictionary<int, string> MainMenuItems = new(){
        {1, "Get personal greetign"},
        {2, "Get horoscope"},
        {0, "Exit"}
    };

    public Dictionary<int, string> InternalMenuItems = new(){
        {9,"Previous menu"},
        {0, "Exit"}
    };

    public DateTime GetBirthDate()
    {
        try
        {
            Input.TryGetBirthDate(out DateTime birthDate);
            return birthDate;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return GetBirthDate();
        }
    }
    public string GetName()
    {
        try
        {
            Input.TryGetName(out string name);
            return name;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return GetName();
        }
    }
    public int GetMenuItem(Dictionary<int,string> menu)
    {
        try
        {
            Input.TryGetMenuItem(menu, out int item);
            return item;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return GetMenuItem(menu);
        }
    }

    public void PersonalGreeting()
    {
        string name = GetName();
        Console.Clear();
        View.DisplayPersonalGreeting(Greeting.GetPersonalGreeting(name));

    }
    public void Horoscope()
    {
        DateTime birthDate = GetBirthDate();
        Console.Clear();
        View.DisplayHoroscope(Greeting.GetHoroscope(birthDate));
    }
    public void InternalMenu(){
        View.DisplayMenu(InternalMenuItems);
        switch(GetMenuItem(InternalMenuItems)){
            case 9: MainMenu(); break;
            case 0: break;
        }
    }

    public void MainMenu()
    {
        Console.Clear();
        View.DisplayInFrame(Greeting.GetHeader());
        View.DisplayMenu(MainMenuItems);
        switch (GetMenuItem(MainMenuItems))
        {
            case 1: PersonalGreeting(); InternalMenu(); break;
            case 2: Horoscope(); InternalMenu(); break;
            case 0: break;
        }
    }
    public void MainFlow()
    {
        while (true)
        {
            MainMenu();
            break;
        }
    }
}