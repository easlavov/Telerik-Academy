using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This suffix tree is optimized for searching for whole words and their total occurences in a big text.
// It is filled by adding strings and each of these strings' characters form branches of all occuring substrings(words).
// Each node's Count attribute corresponds to the number of occurences of the word that starts from the root and ends at
// the node.
public class SuffixTrie
{
    private CharNode root;

    public SuffixTrie()
    {
        this.root = new CharNode('$');
    }

    public void Add(string word)
    {
        AddChars(word, 0, this.root);
    }

    public int WordOccurence(string word)
    {
        if (word == string.Empty)
        {
            return 0;
        }
        int count = 0;
        GetWordOccurence(word, 0, this.root, ref count);
        return count;
    }

    private void GetWordOccurence(string word, int index, CharNode currentNode, ref int count)
    {
        char currentChar = word[index];
        bool lastChar = false;
        if (index == word.Length - 1)
        {
            lastChar = true;
        }
        foreach (var node in currentNode.Children)
        {
            if (node.Letter == currentChar)
            {
                if (lastChar)
                {
                    // If this is the last char of the string, set the count
                    count = node.Count;
                    return;
                }
                else
                {
                    // Go to the next level if there already exists a node with this char at the current one
                    this.GetWordOccurence(word, index + 1, node, ref count);
                    return;
                }
            }
        }

        // If no node with the current char exists at this level in the trie, add it:
        return;
    }

    private void AddChars(string word, int index, CharNode currentNode)
    {
        if (word == string.Empty)
        {
            return;
        }
        char currentChar = word[index];
        bool lastChar = false;
        if (index == word.Length - 1)
        {
            lastChar = true;
        }
        
        foreach (var node in currentNode.Children)
        {
            if (node.Letter == currentChar)
            {                
                if (lastChar)
                {
                    // If this is the last char of the string, increase the count of this string occurences
                    node.Count++;
                    return;
                }
                else
                {
                    // Go to the next level if there already exists a node with this char at the current one
                    this.AddChars(word, index + 1, node);
                    return;
                }
            }
        }

        // If no node with the current char exists at this level in the trie, add it:
        CharNode newNode = new CharNode(currentChar);
        currentNode.Children.Add(newNode);
        if (!lastChar)
        {
            // If the word is not finished, continue
            this.AddChars(word, index + 1, newNode);
        }
        else
        {
            newNode.Count++;
        }
    }


}