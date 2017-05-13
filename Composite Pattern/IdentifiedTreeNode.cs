using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    public class IdentifiedTreeNode : System.Windows.Forms.TreeNode
    {
        private int id;
        public IdentifiedTreeNode(string name, IdentifiedTreeNode[] children, int id) : base(name, children)
        {
            this.id = id;
        }
        public IdentifiedTreeNode(string name, int id) : base(name)
        {
            this.id = id;
        }
        public int getID()
        {
            return id;
        }
        public IdentifiedTreeNode getNodeWithID(int goalID)
        {
            if (this.id == goalID)
            {
                return this;
            }
            foreach (IdentifiedTreeNode i in Nodes)
            {
                IdentifiedTreeNode temp = i.getNodeWithID(goalID);
                if (temp != null)
                    return temp;
            }
            return null;
        }
        public List<int> getExpandedNodes()
        {
            List<int> output = new List<int>();
            if(this.IsExpanded)
            {
                output.Add(this.id);
            }

            foreach(IdentifiedTreeNode i in Nodes)
            {
                foreach (int j in i.getExpandedNodes())
                {
                    output.Add(j);
                }
            }
            return output;
        }
    }
}
