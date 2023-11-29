using System;
using System.IO;
using UnityEngine;

public class SongInfo : MonoBehaviour
{
    /*Just a bunch of classes to call elsewhere*/

    //variables
    static int q = 0;
    static int lncount = 0;

    static string[,] songs = new string[26, 6]; //where songs are stored
    static int[] count = new int[26]; //counts the length of each thing

    /*  Read From Text File  */
    void ReadFile(string file, string[,] array, int[] counter)
    {
        if (File.Exists(file))
        {
            StreamReader textfile = new StreamReader(file);
            string line;
            while ((line = textfile.ReadLine()) != null)
            {
                string sentence = line;
                char separator = '|'; // Space character
                string[] words = sentence.Split(separator);
                //Console.WriteLine(line);
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] != null)
                    {
                        array[q, i] = words[i];
                    }
                }
                counter[lncount] = words.Length;
                q++;
                lncount++;
            }

            textfile.Close();
        }
        else
        {
            Console.WriteLine("No File Found");
        }
    }//end of PrintString()

    /*  Score  */
    void CompareScore(string songTitle, int newScore, string[,] array)
    {
        int currentScore;
        //get current score
        for (int i = 0; i < lncount; i++)
        {
            if (array[i, 0] == songTitle)
            {
                int.TryParse(array[i, 5], out currentScore);
                //compare which is greater
                if (currentScore < newScore)
                {
                    //set new high score
                    array[i, 5] = newScore.ToString();
                    Console.WriteLine($"New High Score Set for {songTitle}: {newScore}");
                }
                else Console.WriteLine($"High Score for {songTitle}: {currentScore}");
                continue;
            }
        }

    }

    /*  Write To File  */
    void SaveProgress(string file, string[,] array)
    {
        if (File.Exists(file))
        {
            //Clear All Text
            File.WriteAllText(file, string.Empty);

            //Write New Information
            using (StreamWriter writer = new StreamWriter(file))
            {
                for (int i = 0; i < lncount; i++)
                {
                    string list = String.Concat(array[i, 0], "|", array[i, 1], "|", array[i, 2], "|", array[i, 3], "|", array[i, 4], "|", array[i, 5]);
                    writer.WriteLine(list);
                }
                Console.WriteLine("Save Complete");
            }
        }
    }

    /*  temp (just to check stuff)  */
    void PrintNewValues(string[,] array, int[] counter)
    {
        if (array.Length != 0)
        {
            for (int i = 0; i < lncount; i++)
            {
                if (counter[i] != -1)
                {
                    for (int j = 0; j < counter[i]; j++)
                    {
                        Console.Write("[");
                        Console.Write(array[i, j]);
                        Console.Write("]");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}//end of class
