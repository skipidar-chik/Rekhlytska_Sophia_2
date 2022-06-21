using System.Text.Json;

Console.WriteLine("Холм");
TerrainProfile holm = new();
holm.altitudes = new List<double>() { 210.5, 220, 215.5, 216, 230.2, 219 };
holm.Laing = 10;
holm.PrintAll();
Console.WriteLine("---------------------------------------");
holm.Compare(new List<double>() { 350.1, 315, 380.5, 385, 364, 360.2 });
Serealizer();

async void Serealizer()
{
    using FileStream fs = new FileStream("TerrainProfile.json", FileMode.OpenOrCreate);
        await JsonSerializer.SerializeAsync<TerrainProfile>(fs, holm);
}