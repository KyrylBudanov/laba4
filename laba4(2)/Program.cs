using System;
using System.Collections.Generic;

// Базовий клас "Комп'ютер"
class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OperatingSystem { get; set; }

    public Computer(string ipAddress, int power, string os)
    {
        IPAddress = ipAddress;
        Power = power;
        OperatingSystem = os;
    }
}

// Спадкоємні класи
class Server : Computer, IConnectable
{
    public List<Computer> ConnectedComputers { get; private set; }

    public Server(string ipAddress, int power, string os)
        : base(ipAddress, power, os)
    {
        ConnectedComputers = new List<Computer>();
    }

    public void Connect(Computer computer)
    {
        ConnectedComputers.Add(computer);
        Console.WriteLine($"Сервер {IPAddress} підключився до комп'ютера {computer.IPAddress}");
    }

    public void Disconnect(Computer computer)
    {
        ConnectedComputers.Remove(computer);
        Console.WriteLine($"Сервер {IPAddress} відключився від комп'ютера {computer.IPAddress}");
    }

    public void TransferData(Computer computer, string data)
    {
        Console.WriteLine($"Сервер {IPAddress} передав дані до комп'ютера {computer.IPAddress}: {data}");
    }
}

class Workstation : Computer, IConnectable
{
    public List<Computer> ConnectedComputers { get; private set; }

    public Workstation(string ipAddress, int power, string os)
        : base(ipAddress, power, os)
    {
        ConnectedComputers = new List<Computer>();
    }

    public void Connect(Computer computer)
    {
        ConnectedComputers.Add(computer);
        Console.WriteLine($"Робоча станція {IPAddress} підключилась до комп'ютера {computer.IPAddress}");
    }

    public void Disconnect(Computer computer)
    {
        ConnectedComputers.Remove(computer);
        Console.WriteLine($"Робоча станція {IPAddress} відключилась від комп'ютера {computer.IPAddress}");
    }

    public void TransferData(Computer computer, string data)
    {
        Console.WriteLine($"Робоча станція {IPAddress} передала дані до комп'ютера {computer.IPAddress}: {data}");
    }
}

class Router : Computer, IConnectable
{
    public List<Computer> ConnectedComputers { get; private set; }

    public Router(string ipAddress, int power, string os)
        : base(ipAddress, power, os)
    {
        ConnectedComputers = new List<Computer>();
    }

    public void Connect(Computer computer)
    {
        ConnectedComputers.Add(computer);
        Console.WriteLine($"Маршрутизатор {IPAddress} підключився до комп'ютера {computer.IPAddress}");
    }

    public void Disconnect(Computer computer)
    {
        ConnectedComputers.Remove(computer);
        Console.WriteLine($"Маршрутизатор {IPAddress} відключився від комп'ютера {computer.IPAddress}");
    }

    public void TransferData(Computer computer, string data)
    {
        Console.WriteLine($"Маршрутизатор {IPAddress} передав дані до комп'ютера {computer.IPAddress}: {data}");
    }
}

// Інтерфейс "IConnectable"
interface IConnectable
{
    void Connect(Computer computer);
    void Disconnect(Computer computer);
    void TransferData(Computer computer, string data);
}

// Клас "Мережа"
class Network
{
    public List<Computer> AllComputers { get; private set; }

    public Network()
    {
        AllComputers = new List<Computer>();
    }
}

class Program
{
    static void Main()
    {
        Network network = new Network();

        Server server1 = new Server("192.168.1.1", 1000, "Windows Server");
        Server server2 = new Server("192.168.1.2", 1200, "Linux");
        Workstation workstation1 = new Workstation("192.168.1.3", 800, "Windows 10");
        Workstation workstation2 = new Workstation("192.168.1.4", 900, "macOS");
        Router router = new Router("192.168.1.5", 500, "RouterOS");

        network.AllComputers.Add(server1);
        network.AllComputers.Add(server2);
        network.AllComputers.Add(workstation1);
        network.AllComputers.Add(workstation2);
        network.AllComputers.Add(router);

        server1.Connect(workstation1);
        server2.Connect(workstation2);
        router.Connect(server1);
        router.Connect(server2);

        workstation1.TransferData(server1, "Дані від робочої станції до сервера 1");
        server1.TransferData(workstation1, "Відповідь від сервера 1 до робочої станції");

        router.Disconnect(server1);
        server2.Disconnect(workstation2);

        Console.ReadKey();
    }
}
