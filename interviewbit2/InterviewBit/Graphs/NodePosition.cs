namespace Graphs
{
    public struct NodePosition
    {
        public int Col { get; set; }
        public int Row { get; set; }
        public int Val { get; set; }

        public override string ToString() => $"Row:{Row}, Col:{Col}, Val:{Val}";
    }
}