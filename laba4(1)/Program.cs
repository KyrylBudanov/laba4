using System;
using System.Collections.Generic;

// Базовий клас "Живий організм"
class Organism
{
    public double Energy { get; set; }
    public int Age { get; set; }
    public double Size { get; set; }

    public Organism(double energy, int age, double size)
    {
        Energy = energy;
        Age = age;
        Size = size;
    }
}

// Спадкоємні класи
class Animal : Organism, IReproducible, IPredator
{
    public string Species { get; set; }
    public int ReproductionRate { get; set; }
    public double PreyPreference { get; set; }

    public Animal(double energy, int age, double size, string species, int reproductionRate, double preyPreference)
        : base(energy, age, size)
    {
        Species = species;
        ReproductionRate = reproductionRate;
        PreyPreference = preyPreference;
    }

    public void Reproduce()
    {
        // Логіка розмноження для тварин
    }

    public void Hunt()
    {
        // Логіка полювання для тварин
    }
}

class Plant : Organism, IReproducible
{
    public string Type { get; set; }

    public Plant(double energy, int age, double size, string type)
        : base(energy, age, size)
    {
        Type = type;
    }

    public void Reproduce()
    {
        // Логіка розмноження для рослин
    }
}

class Microorganism : Organism, IReproducible
{
    public string MicroType { get; set; }

    public Microorganism(double energy, int age, double size, string microType)
        : base(energy, age, size)
    {
        MicroType = microType;
    }

    public void Reproduce()
    {
        // Логіка розмноження для мікроорганізмів
    }
}

// Інтерфейси
interface IReproducible
{
    void Reproduce();
}

interface IPredator
{
    void Hunt();
}

// Клас "Екосистема"
class Ecosystem
{
    private List<Organism> organisms = new List<Organism>();

    public void AddOrganism(Organism organism)
    {
        organisms.Add(organism);
    }

    public void SimulateEcology()
    {
        // Логіка взаємодії організмів в екосистемі: харчування, розмноження, конкуренція
    }
}

class Program
{
    static void Main()
    {
        Ecosystem ecosystem = new Ecosystem();

        // Створіть об'єкти тварин, рослин, мікроорганізмів і додайте їх до екосистеми
        Animal lion = new Animal(100, 5, 1.5, "Lion", 3, 0.7);
        Animal zebra = new Animal(80, 4, 1.2, "Zebra", 4, 0.5);
        Plant grass = new Plant(50, 2, 0.1, "Grass");
        Microorganism bacteria = new Microorganism(10, 1, 0.01, "Bacteria");

        ecosystem.AddOrganism(lion);
        ecosystem.AddOrganism(zebra);
        ecosystem.AddOrganism(grass);
        ecosystem.AddOrganism(bacteria);

        // Симулюйте взаємодію організмів у екосистемі
        ecosystem.SimulateEcology();
    }
}
