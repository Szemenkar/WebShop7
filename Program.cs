using e_commerce_project;

string[] title = File.ReadAllLines("data/title.txt");
foreach (var line in title)
{
    Console.WriteLine(line);
}

Console.WriteLine("Press any key to continue...");
Console.ReadKey();
Console.Clear();

Menu.Main();