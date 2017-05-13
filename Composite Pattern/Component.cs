using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    public abstract class Component
    {
        public string Name;
        public Composite Parent;
        public static int NextID = 0;
        public int id;

        //operation();
        public abstract int numOfCharacters();

        public Component(string name)
        {
            this.Name = name;
            id = NextID;
            NextID++;
        }
        public string getPath()
        {
            if(Parent != null)
            {
                return Parent.getPath() + "/" + Name; 
            }
            return Name;
        }
        public List<Composite> getLineage()
        {
            List<Composite> output = new List<Composite>();
            Composite toAdd;
            if (this is Composite)
            {
                toAdd = (Composite)this;
                output.Add(toAdd);
                if (this.Parent == null)
                {
                    return output;
                }
            }
            else
            {
                if (this.Parent != null)
                {
                    toAdd = this.Parent;
                    output.Add(toAdd);
                }
                else
                    return output;
            }
            while(toAdd.Parent != null)
            {
                output.Add(toAdd.Parent);
                toAdd = toAdd.Parent;
            }
            return output;
        }
        public abstract int numOfDescendants();
        public abstract int numOfChildren();
        public abstract void add(Component c);
        public abstract Component getChild(int index);
        public abstract Component getChild(string name);
        public abstract IdentifiedTreeNode createTree();
        public abstract string stringify();
    }
    public class Composite : Component
    {
        List<Component> children;
        public Composite(string name) : base(name)
        {
            children = new List<Component>();
        }
        public override int numOfCharacters()
        {
            int output = 0;
            foreach (Component i in children)
                output += i.numOfCharacters();
            return output;
        }
        public override void add(Component c)
        {
            children.Add(c);
            c.Parent = this;
        }
        public void remove(int index)
        {
            children.RemoveAt(index);
        }
        public void remove(Component toRemove)
        {
            children.Remove(toRemove);
        }
        public override Component getChild(int index)
        {
            return children[index];
        }
        public override Component getChild(string name)
        {
            foreach(Component c in children)
            {
                if(c.Name.Equals(name))
                {
                    return c;
                }
            }
            return null;
        }

        public override int numOfDescendants()
        {
            int output = 0;
            foreach(Component c in children)
            {
                output += c.numOfDescendants() + 1;
            }
            return output;
        }
        public override IdentifiedTreeNode createTree()
        {
            if (children.Count == 0)
            {
                return new IdentifiedTreeNode(this.Name + " - Folder, " + numOfCharacters() + " characters", this.id);
            }
            else
            {
                IdentifiedTreeNode[] childTree = new IdentifiedTreeNode[this.children.Count];
                for(int i = 0; i < childTree.Length; i++)
                {
                    childTree[i] = getChild(i).createTree();
                }
                return new IdentifiedTreeNode(this.Name + " - Folder, "+numOfCharacters()+" characters", childTree, this.id);
            }
        }
        public Component getComponentWithID(int goalID)
        {
            if (this.id == goalID)
            {
                return this;
            }
            foreach (Component i in children)
            {
                if (i.id == goalID)
                {
                    return i;
                }
                if (i is Composite)
                {
                    Component temp = ((Composite)i).getComponentWithID(goalID);
                    if (temp != null)
                        return temp;
                }
            }
            return null;
        }
        public override int numOfChildren()
        {
            return children.Count;
        }
        public override string stringify()
        {
            string output = " " + Name + " { ";
            if (this.numOfChildren() == 0)
                return output + " } ";
            output += children[0].stringify();
            for(int i = 1; i < children.Count; i++)
            {
                Component toAdd = children[i];
                output += "," + toAdd.stringify();
            }
            output += " } ";
            return output;
        }

    }
    public class Leaf : Component
    {
        public string Text;
        public Leaf(string name) : base(name)
        {
            Text = "";
        }
        public Leaf(string name, string text) : base(name)
        {
            this.Text = text;
        }
        public override int numOfCharacters()
        {
            return Text.Length;
        }

        public override string stringify()
        {
            return " " + Name + " ";
        }

        public override IdentifiedTreeNode createTree()
        {
            return new IdentifiedTreeNode(this.Name + " - Text File, " + numOfCharacters() + " characters", this.id);
        }


        public override void add(Component c)
        {
            throw new NotImplementedException();
        }
        public override Component getChild(string name)
        {
            throw new NotImplementedException();
        }
        public override Component getChild(int index)
        {
            throw new NotImplementedException();
        }
        public override int numOfDescendants()
        {
            return 0;
        }
        public override int numOfChildren()
        {
            throw new NotImplementedException();
        }
    }
}
