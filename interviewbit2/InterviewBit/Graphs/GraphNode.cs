using System.Text;

namespace Graphs
{
    public class GraphNode
    {
        public GraphNode(int value) => Val = value;

        public GraphNode[] GraphNodes { get; set; }
        public int Val { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Val);
            sb.Append("{");

            if (GraphNodes == null)
            {
                sb.Append("}");
                return sb.ToString();
            }

            foreach (GraphNode n in GraphNodes)
            {
                sb.Append($"{Val} -> {n}");
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}