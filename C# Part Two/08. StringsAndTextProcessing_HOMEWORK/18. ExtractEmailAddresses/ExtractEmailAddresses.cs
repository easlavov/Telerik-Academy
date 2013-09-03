// Write a program for extracting all email addresses from given text. All substrings that match
// the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Collections.Generic;

class ExtractEmailAddresses
{
    static void Main()
    {
        Console.WriteLine("This program extracts all email addresses from given text.");
        Console.WriteLine();

        // Read input
        string text = "kuma.lisa@yahoo.com went to visit her friend kumcho_valcho@gmail.com. Later came zayo@abv.bg";
        string[] addresses = ExtractEmailAddressesToArray(text);
        foreach (var address in addresses)
        {
            Console.WriteLine(address);
        }

    }

    static string[] ExtractEmailAddressesToArray(string text)
    {
        // Declare an empty list of email addresses
        List<string> addressesList = new List<string>();

        // Find all @ signs
        int atSignIndex = text.IndexOf('@');
        while (atSignIndex != -1)
        {
            // Declare variables for starting and ending indexes of the email address
            int emailAddressFirstIndex = -1, emailAddressLastIndex = -1;

            // Handle border cases
            // Condition: @ has index < 2 or text.length - index < 7
            // Both cases exclude the possibility of a valid email address with @ sign at this index
            if (atSignIndex < 2 || (text.Length - atSignIndex < 7))
            {
                // skip - do nothing
                if ((text.Length - atSignIndex < 7))
                {
                    // no space left for a valid email
                    break;
                }
            }
            // Handle general cases
            else
            {
                // Declare a bool which indicates an invalid email address
                bool validAddress = true;
                // Find first index
                for (int i = atSignIndex - 1; i >= 0; i--)
                {
                    // dots are not allowed before the @ sign
                    if (i == atSignIndex - 1 && text[i] == '.')
                    {
                        // invalid email address
                        validAddress = false;
                        break;
                    }
                    // There may be other cases of forbidden chars for the local part of the email address
                    // These are the general cases
                    if (text[i] == ' ' || text[i] == '!' || text[i] == '"' || text[i] == '#'
                        || text[i] == '$' || text[i] == '%' || text[i] == '(' || text[i] == ')'
                        || text[i] == ',' || text[i] == ':' || text[i] == ';' || text[i] == '<'
                        || text[i] == '>' || text[i] == '<' || text[i] == '@' || text[i] == '['
                        || text[i] == '\\' || text[i] == ']' || text[i] == '`' || text[i] == '|')
                    {
                        emailAddressFirstIndex = i + 1;
                        break;
                    }
                    else if (i == 0)
                    {
                        emailAddressFirstIndex = 0;
                    }
                }
                // Check if double dots appear in the local part
                if (validAddress == true)
                {
                    int doubleDots = text.IndexOf("..", emailAddressFirstIndex, atSignIndex - emailAddressFirstIndex);
                    if (doubleDots != -1)
                    {
                        validAddress = false;
                    }
                }
                if (validAddress == true)
                {
                    // Find last index
                    // There should be at least 6 chars after the @ sign in a valid email address
                    int charsPassed = 0;
                    for (int i = atSignIndex + 1; i < text.Length; i++)
                    {
                        // allowed chars in domain names are letters, digits, dots, dashes
                        if (char.IsLetterOrDigit(text[i]) == false && text[i] != '.' && text[i] != '-')
                        {
                            emailAddressLastIndex = i - 1;
                            break;
                        }
                        charsPassed++;
                        if (i == text.Length - 1)
                        {
                            emailAddressLastIndex = text.Length - 1;
                        }
                    }
                    if (charsPassed < 6)
                    {
                        validAddress = false;
                    }
                }

                // If address is valid, remove a possible invalid char from the end of the address and add address to list
                if (validAddress == true)
                {
                    if (char.IsLetter(text[emailAddressLastIndex]) != true)
                    {
                        if (text.Substring(atSignIndex + 1, emailAddressLastIndex - atSignIndex).Length < 7)
                        {
                            validAddress = false;
                        }
                        else
                        {
                            emailAddressLastIndex--;
                        }
                    }
                    if (validAddress == true)
                    {
                        addressesList.Add(text.Substring(emailAddressFirstIndex, emailAddressLastIndex - emailAddressFirstIndex + 1));
                    }
                }
            }

            atSignIndex = text.IndexOf('@', atSignIndex + 1);

        }
        return addressesList.ToArray();
    }
}