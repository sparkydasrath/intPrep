using System.Collections.Generic;
using System.IO;

namespace SystemDesign
{
    /*  To Mat from Quadrature
     *  Given a compressed stream, sort it and return the compressed sorted stream.
     *  Constraints: The entire compressed stream can be stored on the hard drive
     *  Assume single machine
     *
     *
     *  Approach:
     *  Assume that the data is Market Data since it is easier to visualize. Imagine that it is coming in
     *  compressed but the stream is based on timestamp. We want to sort it by Ticker instead.
     *
     *  Ex:
     *  Input:  GOOG-T1, APPL-T2, IBM-T3, GOOG-T4, AMZN-T5, GOOG-T6, AAPL-T7
     *  Output: AMZN-T5, AAPL-T2, APPL-T7, GOOG-T1, GOOG-T4, GOOG-T7, IBM-T3
     *
     *  Approach v1
     *  - Data comes in and assume you can read one data point at a time
     *  - Un-compress it so you can have access to the full market data object
     *  - Use a dictionary of size 26 to store the tickers as they come in [ Dictionary<int, List<string>> ]
     *  - Ex: index 0 will store all the tickers that start with A
     *  - As tickers come in and are added to the list, it will need to get resorted
     *
     * Approach v2
     *  - Instead of using a dictionary to store the uncompressed ticker sorted by name, store each ticker as it's own file
     *  - Ex: you can have something that looks like:
     *      AMZN.txt
     *      AAPL.txt
     *      GOOG.txt
     *      IBM.txt
     *  - The idea is that instead of using 26 dictionary index/list data structure,
     *    take the incoming object, un-compress it to get the ticker, compress it and append it
     *    to the existing (or create a new one) file for that ticker
     *  - The Operating System can sort by filename so you can just read through all the files in order to generate the stream
     *  - Additionally, since we are storing compressed data, we will not exhaust our space constraints
     *
     */

    public class Entity
    {
        public Entity(int id, string symbol)
        {
            Id = id;
            Symbol = symbol;
        }

        public int Id { get; set; }
        public string Symbol { get; set; }
    }

    public class FakeStream
    {
        private int entityCount = -1;

        public List<Entity> Entities => GenerateEntities();

        public Entity GetNext()
        {
            entityCount++;
            if (entityCount < Entities.Count)
            {
                return Entities[entityCount];
            }

            return null;
        }

        private List<Entity> GenerateEntities()
        {
            List<Entity> entities = new List<Entity>
            {
                new Entity(1, "GOOG"),
                new Entity(2, "AMZN"),
                new Entity(3, "IBM"),
                new Entity(4, "GOOG"),
                new Entity(5, "AAPL"),
                new Entity(6, "AAPL"),
                new Entity(7, "IBM"),
                new Entity(8, "AMZN"),
                new Entity(9, "TSLA"),
                new Entity(10, "TSLA"),
                new Entity(11, "MSFT"),
                new Entity(12, "TSLA"),
                new Entity(13, "MSFT"),
                new Entity(14, "MSFT"),
            };

            return entities;
        }
    }

    public class SortStream
    {
        private readonly string baseDir = $"F:\\repos\\intPrep\\systemDesignOutputFiles\\";
        private readonly FakeStream fs;

        public SortStream() => fs = new FakeStream();

        public int EntityCount => fs.Entities.Count;

        public void AppendTickerToFile(Entity entity)
        {
            string path = $"{baseDir}{entity.Symbol}-{entity.Id}.txt";
            if (!File.Exists(path))
                File.Create(path);
        }

        public void CleanDirectory()
        {
            string[] filePaths = Directory.GetFiles(baseDir);
            foreach (string filePath in filePaths)
                File.Delete(filePath);
        }

        public Entity GetCompressedEntityFromStream() => fs.GetNext();

        public Entity UncompressEntity() =>
            /*
            * Nothing need to be done here really, just using this to illustrate the steps
            */

            GetCompressedEntityFromStream();
    }
}