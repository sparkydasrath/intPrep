using System.Collections.Generic;

namespace Amazon
{
    public class ValidateTree
    {
        /*
            This was from Rakka's screen where you are given a tree root and two nodes that
            you need to connect.
            Verify after the connection if the tree is still valid ==> no cycles

         */

        public bool IsFound(TreeNodeEx root, TreeNodeEx node)
        {
            // assume we have a search function returns true if the value is already in the tree
            return true;
        }

        public bool IsValid(TreeNodeEx root, TreeNodeEx from, TreeNodeEx to)
        {
            // the idea to to verify that there are no cycles in this tree

            // case 1 - root is null

            if (root == null)
            {
                if (from == null && to == null) return true; // whole tree is null
                if (from == null && to != null)
                {
                    root = to;
                    return true;
                }
                if (from != null && to == null)
                {
                    root = from;
                    return true;
                }
                if (from != null && to != null)
                {
                    root = from;
                    root.Nodes.Add(to);
                    return true; // pick one to be the root
                }
            }

            // case 2 - at this point we have a valid root

            bool isFromNodeInTree = IsFound(root, from);
            bool isToNodeInTree = IsFound(root, to);

            if (isFromNodeInTree == false && isToNodeInTree == false)
            {
                // neither node is in the tree, but the tree is still valid
                return true;
            }

            if (isFromNodeInTree && isToNodeInTree)
            {
                // both nodes are in the tree

                // are they both children of root
                bool isFromAChildOfRoot = root.Nodes.Contains(from);
                bool isToAChildOfRoot = root.Nodes.Contains(to);

                if (isFromAChildOfRoot && isToAChildOfRoot)
                {
                    // if they are both children of root, then that will form a cycle so return false
                    /*
                                           root
                                        /	|	\
                                       / 	| 	 \
                                      /  	|  	  \
                                    from    B       to
                                     |              ^  cycle here
                                     |--------------|
                    */

                    return false;
                }

                if (isFromAChildOfRoot && !isToAChildOfRoot || !isFromAChildOfRoot && isToAChildOfRoot)
                {
                    /*  one is a child of root, the other is somewhere else further down
                        you could potentially form a cycle but if this is a directed graph, then it's not really a cycle,
                        just you now have 2 paths to get to the 'to' node - not sure what to return here
                    */
                    return true; // gonna say it's all good
                }
            }

            return true;
        }

        public class TreeNodeEx
        {
            public TreeNodeEx(string val)
            {
                Nodes = new List<TreeNodeEx>();
            }

            public List<TreeNodeEx> Nodes { get; set; }
            public string Value { get; set; }
        }
    }
}