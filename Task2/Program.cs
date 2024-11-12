
EngFrenchDic dictionary = new EngFrenchDic();

dictionary.AddWord("hello", new string[] { "bonjour", "salut" });
dictionary.AddWord("apple", new string[] { "pomme" });

Console.WriteLine("Translations for 'hello':");
dictionary.SearchTranslation("hello");

dictionary.ChangeWord("hello", "greetings");

Console.WriteLine("\nAfter changing 'hello' to 'greetings':");
dictionary.SearchTranslation("greetings");

dictionary.ChangeTranslation("greetings", new string[] { "salutations", "bonjour" });

Console.WriteLine("\nAfter changing translations of 'greetings':");
dictionary.SearchTranslation("greetings");

dictionary.RemoveTranslation("greetings", "salutations");

Console.WriteLine("\nAfter removing 'salutations' from 'greetings':");
dictionary.SearchTranslation("greetings");

dictionary.RemoveWord("apple");

Console.WriteLine("\nAfter removing 'apple':");
try
{
    dictionary.SearchTranslation("apple");
}
catch (KeyNotFoundException)
{
    Console.WriteLine("'apple' not found in dictionary.");
}

public class EngFrenchDic
{
    private Dictionary<string, string[]> dic = new Dictionary<string, string[]>();

    public EngFrenchDic() { }
    public void AddWord(string word, string[] translations) => dic.Add(word, translations);

    public void RemoveWord(string word) => dic.Remove(word);
    public void RemoveTranslation(string word, string translation)
    {
        string[] newtranslations = new string[dic[word].Length];

        for (int i = 0; i < dic[word].Length; i++)
            if (dic[word][i] != translation)
                newtranslations.Append(dic[word][i]);

        dic[word] = newtranslations;
    }

    public void ChangeWord(string word, string newword)
    {
        string[] translations = dic[word];
        dic.Remove(word);
        dic.Add(newword, translations);
    }

    public void ChangeTranslation(string word, string[] newtranslations) => dic[word] = newtranslations;

    public void SearchTranslation(string word)
    {
        for (int i = 0; i < dic[word].Length; i++)
        {
            Console.Write($"{dic[word][i]}, ");
        }
        Console.WriteLine();
    }
}