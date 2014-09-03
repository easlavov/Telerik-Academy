using System;
using System.IO;

class TestProgram
{
    // http://pastebin.com/Tmv3gstw
    static string filePath = @"C:\Temp\BigText.txt";
    static SuffixTrie trie = new SuffixTrie();

    static void Main()
    {
        Console.WriteLine("When you press any key the application will create a new text file with 105 MB size and random words in the project directory.");
        //Console.ReadKey();
        //CreateBigTextFile();
        Console.WriteLine("Now press any key to read text file and extract words in a trie.");
        Console.ReadKey();
        FillTrie();
        Console.WriteLine("Finally, press a key to count the occurence of the word 'mumu' and display result.");
        Console.ReadKey();
        FindWord("mumu");
    }

    private static void FindWord(string word)
    {
        Console.WriteLine(trie.WordOccurence("mama"));
        Console.WriteLine(trie.WordOccurence("mamo"));
        Console.WriteLine(trie.WordOccurence("kolan"));
        Console.WriteLine(trie.WordOccurence("meso"));
    }

    private static void FillTrie()
    {        
        StreamReader reader = new StreamReader(filePath);
        using (reader)
        {
            //string[] words = reader.ReadToEnd().Split(' ');
            string[] words = { "koko", "kola", "mama", "kolan", "meso", "kolar", "merak", "kino", "kinoman", "m" };
            foreach (var word in words)
            {
                trie.Add(word);
            }
        }
        Console.WriteLine("Trie filled successfully.");       
    }

    private static void CreateBigTextFile()
    {
        string[] words =
        {
            "kaka", "mama","lili","anko","sisi","mimi","koko","boko","haho","hihi","mumu","zuno","kumo","lisa","zayo","bayo","bebe","drvo","veso","lele",
        };
        int totalWords = 1050000;
        StreamWriter writer = new StreamWriter(filePath);
        using (writer)
        {
            for (int i = 0; i < totalWords; i++)
            {
                for (int b = 0; b < words.Length; b++)
                {
                    writer.Write(words[b] + " ");
                }
            }
        }
        Console.WriteLine("File created successfully!");
    }
}