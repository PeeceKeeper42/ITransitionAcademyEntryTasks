
using Task2.JsonLogic;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //No exception handler, huh?
            //Don't know how to implement it without ASP.NET Core packages, so...
            char[] stringSeparators = new char[]
            { ' ','.',',','-','=','_','!','?','\"','\'','(',')','/','<','>' };

            var countedWords = new Dictionary<string, uint>();
            try
            {
                var config = Settings.Initialize("appsettings.json");//Is strongly-typed config better?

                foreach (string line in File.ReadLines(config["InputFileName"]))//microsoft docs are the best btw
                {
                    string[] words = line.Split(stringSeparators)//Is != same as "is not" in this case?
                        .Where(x => x is not null)//if there no words
                        .Where(x => x != " ")// if there is spaces
                        .Where(x => x != "")// if "words" themselfs are nulls
                        .ToArray();

                    foreach (var word in words)
                    {
                        if (countedWords.ContainsKey(word))
                        {
                            countedWords[word]++;
                        }      
                        else
                        {
                            countedWords.Add(word, 1);
                        }         
                    }
                }
                countedWords = countedWords.OrderBy(x => x.Value)
                    .Reverse()
                    .ToDictionary(x => x.Key, x => x.Value);

                using (StreamWriter sw = File.CreateText(config["OutputFileName"]))
                {
                    foreach(var dictItem in countedWords)
                    {
                        sw.WriteLine("{0,-30}{1,-10}",dictItem.Key, dictItem.Value);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error has occurred!");
                Console.WriteLine("Exception message: " + ex.Message);
                Console.WriteLine("See StackTrace Here: ");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}