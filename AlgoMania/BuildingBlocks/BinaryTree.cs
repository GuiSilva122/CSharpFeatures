namespace AlgoMania
{
    public class BinaryTree
    {
        public int Value { get; set; }
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }

        public override string ToString() => $"Value = {Value}";
    }

    public class BinaryTreeOps
    {
        public BinaryTree Root { get; set; }

        public bool Add(int value)
        {
            BinaryTree before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Value) //Is new node in left tree? 
                    after = after.Left;
                else if (value > after.Value) //Is new node in right tree?
                    after = after.Right;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            BinaryTree newNode = new BinaryTree();
            newNode.Value = value;

            if (this.Root == null)//Tree ise empty
                this.Root = newNode;
            else
            {
                if (value < before.Value)
                    before.Left = newNode;
                else
                    before.Right = newNode;
            }

            return true;
        }
    }
}
