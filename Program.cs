namespace Customisert_God_Morgen_program;

class Program
{
    static void Main(string[] args)
    {
        Controller controller = new Controller(new Greeting(), new View(), new Input());
        controller.MainFlow();
    }
}
