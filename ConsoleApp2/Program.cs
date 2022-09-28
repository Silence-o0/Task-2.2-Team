abstract class Worker
{
    public string name;
    public string position;
    public string workDay;
    public Worker (string name)
    {
        this.name = name;
    }
    public void call() 
    {
        this.workDay += " call";
    }
    public void writeCode() 
    {
        this.workDay += " writecode";
    }
    public void relax() 
    {
        this.workDay += " relax";
    }
    public abstract void fillWorkDay();
}

class Developer : Worker
{
    public Developer(string name) : base(name) 
    {
        this.position = "Розробник";
    }
    public override void fillWorkDay() 
    {
        this.writeCode();
        this.call();
        this.relax();
        this.writeCode();
    }
}

class Manager : Worker
{
    private Random randomNum = new Random();
    public Manager(string name) : base(name)
    {
        this.position = "Менеджер";
    }
    public override void fillWorkDay()
    {
        int firstRandomValue = randomNum.Next(0,10);
        this.writeCode();
        for (int i = 0; i < firstRandomValue; i++)
        {
            this.call();
        }
        this.relax();
        int secondRandomValue = randomNum.Next(0,5);
        for (int i = 0; i < secondRandomValue; i++)
        {
            this.call();
        }
    }
}

class Team
{
    public string teamName;
    private List<Worker> workerList = new List<Worker>();
    public Team(string teamName)
    {
        this.teamName = teamName;
    }
    public void addWorker ()
    {
        Console.WriteLine("Кого ви хочете додати до команди? (введiть номер).");
        Console.WriteLine("1. Розробник.");
        Console.WriteLine("2. Менеджер.");
        int numAddWorker = Convert.ToInt32(Console.ReadLine());
        if (numAddWorker == 1)
        {
            Console.Write("Введiть ПIБ:");
            string devName = Console.ReadLine();
            workerList.Add(new Developer(devName));
            Console.WriteLine("Розробник доданий до команди.");

        }
        else if (numAddWorker == 2)
        {
            Console.Write("Введiть ПIБ:");
            string managName = Console.ReadLine();
            workerList.Add(new Manager(managName));
            Console.WriteLine("Менеджер доданий до команди.");
        }
        else Console.WriteLine("ERROR");
    }
    public void displayWorkers()
    {
        Console.WriteLine($"Склад команди {this.teamName}:");
        for (int i = 0; i < workerList.Count; i++)
        {
            Console.WriteLine(workerList[i].name);
        }
    }
    public void detailTeamInfo()
    {
        Console.WriteLine($"Команда {this.teamName}:");
        for (int i = 0; i < workerList.Count; i++)
        {
            workerList[i].workDay = null;
            workerList[i].fillWorkDay();
            Console.WriteLine($"{workerList[i].name} - {workerList[i].position} - {workerList[i].workDay}");
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Введiть назву команди:");
        string teamName = Console.ReadLine();
        Team team1 = new Team(teamName);

        while (true)
        {
            Console.WriteLine("Оберiть операцiю, яку хочете здiйснити та введiть її номер:");
            Console.WriteLine("1. Додати");
            Console.WriteLine("2. Вивести список");
            Console.WriteLine("3. Деталi");
            Console.WriteLine("0. Завершити програму.");
            int operationNum = Convert.ToInt32(Console.ReadLine());

            switch (operationNum)
            {
                case 1:
                    team1.addWorker();
                    break;
                case 2:
                    team1.displayWorkers();
                    break;
                case 3:
                    team1.detailTeamInfo();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }

        }

    }
}




