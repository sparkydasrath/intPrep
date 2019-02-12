using System.Collections.Generic;

namespace SystemDesign
{
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
}