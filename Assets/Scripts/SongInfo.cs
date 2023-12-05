using System;
using System.IO;
using UnityEngine;

/* 
    * CREDITS FOR EVERYTHING *
    //Reading
    Read String Base code: https://c-sharpcorner.com/UploadFile/mahesh/how-to-read-a-text-file-in-C-Sharp/
    Split String to words: https://ironpdf.com/blog/net-help/csharp-split-string-guide/#:~:text=Imagine%20you%20have%20a%20sentence,based%20on%20a%20given%20separator.
          
    //Writing
    Write File Base Code: https://www.c-sharpcorner.com/article/c-sharp-write-to-file/
    Clear Information from File: https://www.techiedelight.com/clear-contents-of-file-csharp/
*/

/* NOTE FOR LIST TEXT STRUCTURE: Song Title|Artist|BPM|Image|MP3 File|Score  */

namespace Symphony
{
    public class SongInfo : MonoBehaviour
    {
        /*Just a bunch of methods to call elsewhere*/

        /*  Read From Text File  */
        public static void ReadFile(string file, string[,] array, int[] counter, int q, int lncount)
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
                Debug.Log("File Read Successfully");
            }
            else
            {
                Debug.Log("No File Found");
            }
        }//end of ReadFile()

        /*  Score  */
        public static void CompareScore(string songTitle, int newScore, string[,] array, int lncount)
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
                        Debug.Log($"New High Score Set for {songTitle}: {newScore}");
                    }
                    else Debug.Log($"High Score for {songTitle}: {currentScore}");
                    continue;
                }
            }

        }

        /*  Write To File  */
        public static void SaveProgress(string file, string[,] array, int lncount)
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
                    Debug.Log("Save Complete");
                }
            }
        }

        /*  temp (just to check stuff)  */
        //void PrintNewValues(string[,] array, int[] counter)
        //{
        //    if (array.Length != 0)
        //    {
        //        for (int i = 0; i < lncount; i++)
        //        {
        //            if (counter[i] != -1)
        //            {
        //                for (int j = 0; j < counter[i]; j++)
        //                {
        //                    Console.Write("[");
        //                    Console.Write(array[i, j]);
        //                    Console.Write("]");
        //                }
        //                Console.WriteLine();
        //            }
        //        }
        //    }
        //}
    }//end of class
}

