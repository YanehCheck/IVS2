using Math = MathLib.Math;


/// <summary>
/// Class for profiling
/// Calculates sample standard deviation of numbers from standard input
/// result print to standard output
/// </summary>
class Deviation
{
    static void Main()
    {
        // Read numbers from input
        /*List<double> numbers = new List<double>();
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            string[] tokens = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double number))
                {
                    numbers.Add(number);
                }
            }
        }*/

        // Generate random numbers for profiling
        List<double> numbers = new List<double>();
        Random random = new Random();
        for (uint i = 0; i < 10; i++)
        {
            numbers.Add(random.NextDouble());
        }

        // Calculate average value of numbers
        double average = 0;
        foreach (double number in numbers)
        {
            average = Math.Add(average, number);
        }
        average = Math.Divide(average, numbers.Count);

        // average^2 * count of numbers
        double valueBuff = Math.Pow(average, 2);
        valueBuff = Math.Multiply(valueBuff, numbers.Count);

        // Calculate sum of numbers^2
        double sumOfSquaredDifferences = 0;
        double x2; //number^2
        foreach (double number in numbers)
        {
            x2 = Math.Pow(number, 2);
            sumOfSquaredDifferences = Math.Add(sumOfSquaredDifferences, x2);
        }

        // (sum of numbers^2) - valueBuff 
        sumOfSquaredDifferences = Math.Subtract(sumOfSquaredDifferences, valueBuff);


        //N-1
        double new_number_count = Math.Subtract(numbers.Count, 1);

        // calculate sample standart deviation
        double sampleStandardDeviation = Math.Divide(sumOfSquaredDifferences, new_number_count);
        sampleStandardDeviation = Math.Root(2, sampleStandardDeviation);

        // Write output
        Console.WriteLine(sampleStandardDeviation);
    }
}