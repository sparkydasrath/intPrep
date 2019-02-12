namespace SystemDesign
{
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
}