using System;
using System.Collections.Generic;
using System.IO;

namespace SystemDesign
{
    public class SortStream
    {
        private readonly string inputFilePath = $"F:\\repos\\intPrep\\systemDesignFilesInput\\input.txt";
        private readonly string outputDirectory = $"F:\\repos\\intPrep\\systemDesignFilesOutput\\";
        private readonly string outputFilePath = $"F:\\repos\\intPrep\\systemDesignFilesOutput\\output.txt";
        private readonly Dictionary<string, StreamWriter> writers;

        public SortStream()
        {
            writers = new Dictionary<string, StreamWriter>();
            CleanDirectory();
        }

        public void CleanDirectory()
        {
            string[] filePaths = Directory.GetFiles(outputDirectory);
            foreach (string filePath in filePaths)
                File.Delete(filePath);
        }

        public void PerformStreamSorting()
        {
            ProcessInputStream();
            CloseAllWriters();
            ProcessOutputStream();
        }

        private void CloseAllWriters()
        {
            // close all the open writer streams
            foreach (StreamWriter stream in writers.Values)
                stream.Close();
        }

        private string[] GetPairFromLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            string[] split = line.Split(',');
            return split;
        }

        private StreamWriter GetStreamWriterFromCache(string key)
        {
            if (writers.ContainsKey(key)) return writers[key];

            StreamWriter sw = File.CreateText(outputDirectory + key + ".txt");
            writers[key] = sw;
            return sw;
        }

        private void ProcessInputStream()
        {
            Console.WriteLine("Start processing input stream\n");
            using (StreamReader sr = new StreamReader(inputFilePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] idSymbolPair = GetPairFromLine(line);
                    if (idSymbolPair != null) SendToOutputStream(idSymbolPair);
                }
            }

            Console.WriteLine("Done processing input stream\n");
        }

        private void ProcessOutputStream()
        {
            Console.WriteLine("Start processing output stream\n");

            string[] files = Directory.GetFiles(outputDirectory);

            // sort the files
            Array.Sort(files);

            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                foreach (string path in files)
                {
                    // read each file's content and add it to the output list
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (!sr.EndOfStream)
                        {
                            sw.WriteLine(sr.ReadLine());
                        }
                    }
                }
            }

            Console.WriteLine("Done processing output stream\n");
        }

        private void SendToOutputStream(string[] idSymbolPair)
        {
            StreamWriter output = GetStreamWriterFromCache(idSymbolPair[1]);
            output.WriteLine(idSymbolPair[1] + "," + idSymbolPair[0]);
        }
    }
}