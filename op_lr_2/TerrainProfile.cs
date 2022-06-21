internal class TerrainProfile
{
    public List<double> altitudes = new();//список висот
    public double Laing { get; set; }//закладення
    public double st = 0; //найбільша крутизна
    public double MaxAltitude() => altitudes.Max();
    public double MinAltitude() => altitudes.Min();
    public void AltitudeDifference(out double maxAltDif, out double sumAltDif)
    {
        maxAltDif = 0;//максимальний перепад висот
        sumAltDif = 0;//cумарний перепад висот

        for (int i = 0; i <= altitudes.Count - 2; i++)
        {
            if (Math.Abs(altitudes[i] - altitudes[i + 1]) > maxAltDif)
                maxAltDif = Math.Abs(altitudes[i] - altitudes[i + 1]);
            sumAltDif += Math.Abs(altitudes[i] - altitudes[i + 1]);
        }
    }
    public void Steepness(out double maxSteepness, out double averageSteepness)
    {
        double[] stepness = new double[altitudes.Count-1];
        for (int i = 0; i <= altitudes.Count - 2; i++)
        {
            if (i< stepness.Length)
            {
                if (altitudes[i] < altitudes[i + 1])
                    stepness[i] = Math.Atan(Math.Abs((altitudes[i + 1] - altitudes[i])) / Laing);
                else if (altitudes[i] > altitudes[i + 1])
                    stepness[i] = Math.Atan((altitudes[i] - altitudes[i + 1]) / Laing);
                else if (altitudes[i] == altitudes[i + 1])
                    stepness[i] = 0;
            }            
        }

        averageSteepness = stepness.Average();
        maxSteepness = stepness.Max();
    }
    public void Compare(List<double> al)
    {
        AltitudeDifference(out double maxAltDif, out double sumAltDif);
        Steepness(out double maxSteepness, out double avSteepness);
        if (al.Count == altitudes.Count)
        {
            double maxAltDif2 = 0;//максимальний перепад висот
            double sumAltDif2 = 0;//мінімальний перепад висот

            for (int i = 0; i <= altitudes.Count - 2; i++)
            {
                if (Math.Abs(al[i] - al[i + 1]) > maxAltDif2)
                    maxAltDif2 = Math.Abs(al[i] - al[i + 1]);
                sumAltDif2 += Math.Abs(al[i] - al[i + 1]);
            }

            double[] stepness = new double[al.Count - 1];
            for (int i = 0; i <= al.Count - 2; i++)
            {
                if (i < stepness.Length)
                {
                    if (altitudes[i] < al[i + 1])
                        stepness[i] = Math.Atan(Math.Abs((al[i + 1] - al[i])) / Laing);
                    else if (al[i] > al[i + 1])
                        stepness[i] = Math.Atan((al[i] - al[i + 1]) / Laing);
                    else if (al[i] == al[i + 1])
                        stepness[i] = 0;
                }
            }
            double averageSteepness2 = stepness.Average();
            double maxSteepness2 = stepness.Max();

            Console.WriteLine($"Max altitude difference of the first profile - {Math.Round(maxAltDif, 3)}," +
                $" the second - {Math.Round(maxAltDif2, 3)}," +
                $" difference - { Math.Round(Math.Abs(maxAltDif2- maxAltDif), 3)} m");
            Console.WriteLine($"Summary altitude difference of the first profile - {Math.Round(sumAltDif, 3)}, " +
                $"the second - {Math.Round(sumAltDif2, 3)}, " +
                $"difference - {Math.Round(Math.Abs(sumAltDif2 - sumAltDif), 3)} m");
            Console.WriteLine($"Max steepnes of the first profile - {Math.Round(maxSteepness, 3)}, " +
                $"the second - {Math.Round(maxSteepness2, 3)}, " +
                $"difference - {Math.Round(Math.Abs(maxSteepness - maxSteepness2), 3)} m");
            Console.WriteLine($"Averege steepnes of the first profile - {Math.Round(avSteepness, 3)}, " +
                $"the second - {Math.Round(averageSteepness2, 3)}, " +
                $"difference - {Math.Round(Math.Abs(averageSteepness2 - avSteepness), 3)} m");
        }
        else Console.WriteLine("Different number of altitudes!");
    }
    public void PrintAll() 
    {
        AltitudeDifference(out double maxAltDif, out double sumAltDif) ;
        Steepness(out double maxSteepness, out double avSteepness);
        //Steepness();
        Console.WriteLine($"Min altitude: {MinAltitude()} m");
        Console.WriteLine($"Max altitude: {MaxAltitude()} m");
        Console.WriteLine($"Max altitude difference: {Math.Round(maxAltDif, 3)} m");
        Console.WriteLine($"Summary altitude difference: {Math.Round(sumAltDif, 3)} m");
        Console.WriteLine($"Max steepnes: {Math.Round(maxSteepness, 3)}");
        Console.WriteLine($"Averege steepnes: {Math.Round(avSteepness, 3)}");
    }

}

