using System;
using System.IO;
using UnityEngine;

public class SongInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int b = 1;

    // Update is called once per frame
    void Update()
    {
        
        if (b > 0) 
        {
            PrintString();
            b = 0;
        }
    }

    void PrintString()
    {
        string file = "Assets/ListTest.txt";
        if (File.Exists(file))
        { 
            StreamReader textfile = new StreamReader(file);
            string line;

            while ((line = textfile.ReadLine()) != null)
            { 
                Console.WriteLine(line);
            }

            textfile.Close();

            Console.ReadKey();
        }
        Console.WriteLine();
    }
}
