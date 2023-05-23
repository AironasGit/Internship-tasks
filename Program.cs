using System.Text;
class Program
{
     static void Main(string[] args)
    {

        Console.OutputEncoding = Encoding.UTF8; // For lithuanian letters
        int[] numbers = GenerateNumbers(100, 0, 100);
        string text1 = "Programuotojas";
        
        Console.WriteLine();
        Console.WriteLine($"1. '{text1}' reversed is '{ReverseString(text1)}'");
        Console.WriteLine();
        Console.Write($"2. Numbers: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            if(i == numbers.Length - 1)
            {
                Console.Write($"{numbers[i]}.");
                break;
            }
            Console.Write($"{numbers[i]}, ");
        }
        
        Console.WriteLine();
        Console.WriteLine();
        var minMax = FindMinMax(numbers);
        Console.WriteLine($"Minimal value is: {minMax.Item1} | Maximum value is: {minMax.Item2}");
        
        Console.WriteLine();
        var duplicateNumbers = FindDuplicateNumbers(numbers);
        Console.WriteLine($"3. Same numbers as in the second task. Finding the duplicate numbers:");
        foreach (var number in duplicateNumbers)
        {
            Console.WriteLine($"{number.Key} appeared {number.Value} times");
        }

        Console.WriteLine();
        string text2 = "Programuotojo ar tiesiog bet kokio IT specialisto profesija taps vis labiau įprasta.";
        Console.WriteLine($"4. Count vowels and consonants in the following text: {text2}");
        var vowelAndConsonantCount = CountVowelsAndConsonants(text2);
        foreach (var count in vowelAndConsonantCount)
        {
            Console.WriteLine($"{count.Key}|{count.Value}");
        }
    }
    private static int[] GenerateNumbers(int amount, int min, int max)
    {
        Random rng = new Random();
        int[] numbers = new int[amount + 1];
        for (int i = 0; i < amount; i++)
        {
            numbers[i] = rng.Next(min, max);
        }
        return numbers;
    }
    private static string ReverseString(string text) // 1
    {
        string reversedText = "";
        for (int i = text.Length - 1; i >= 0; i--)
        {
            reversedText += text[i];
        }
        return reversedText;
    }
    private static (int, int) FindMinMax(int[] numbers) // 2
    {
        int min, max;
        min = max = numbers[0];
        for (int i = 0; i < numbers.Count(); i++)
        {
            if (min > numbers[i])
            {
                min = numbers[i];
            }
            if (max < numbers[i])
            {
                max = numbers[i];
            }
        }
        return (min, max);
    }
    private static Dictionary<int, int> FindDuplicateNumbers(int[] numbers) // 3
    {
        Dictionary<int, int> duplicateNumbers = new Dictionary<int, int>(); // key = number | value = times the number has appeared in the array
        for (int i = 0; i < numbers.Count(); i++)
        {
            if (duplicateNumbers.ContainsKey(numbers[i]))
            {
                duplicateNumbers[numbers[i]] += 1; 
            }
            else
            {
                duplicateNumbers.Add(numbers[i], 1);
            }
        }
        foreach (var number in duplicateNumbers) // Removing numbers that only appear once
        {
            if (number.Value < 2)
            {
                duplicateNumbers.Remove(number.Key);
            }
        }
        return duplicateNumbers;
    }
    private static Dictionary<string, int> CountVowelsAndConsonants(string text) // 4
    {
        char[] vowels = {'a', 'ą', 'e', 'ę', 'ė', 'i', 'į', 'y', 'o', 'u', 'ų', 'ū'};
        char[] consonants = {'b', 'c', 'č', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'r', 's', 'š', 't', 'v', 'z', 'ž'};
        Dictionary<string, int> vowelAndConsonantCount = new Dictionary<string, int>();
        vowelAndConsonantCount.Add("Vowels", 0);
        vowelAndConsonantCount.Add("Consonants", 0);
        text = text.ToLower();
        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < vowels.Count(); j++)
            {
                if (text[i].Equals(vowels[j]))
                {
                    vowelAndConsonantCount["Vowels"] += 1;
                    break;
                }
            }
            for (int n = 0; n < consonants.Count(); n++)
            {
                if (text[i].Equals(consonants[n]))
                {
                    vowelAndConsonantCount["Consonants"] += 1;
                    break;
                }
            }
        }
        return vowelAndConsonantCount;
    }
}