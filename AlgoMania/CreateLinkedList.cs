namespace AlgoMania
{
    public class Node
    {
        public string Value { get; set; }
        public Node Next { get; set; }

        public Node(string value)
        {
            this.Value = value;
            this.Next = null;
        }
    }
    
    public class MyLinkedList
    {
        private Node _head;
        public MyLinkedList() => _head = new Node(null);

        public void insert_node_to_tail(Node node) => tail().Next = node;

        public void insert_node_to_head(Node node)
        {
            if (this._head.Next is not null)
            {
                var head_element = _head;
                node.Next = head_element.Next;
                head_element.Next = node;
            }
            else
                _head.Next = node;
        }

        public bool is_empty() => this._head.Next is null;

        public Node head() => this._head.Next;

        public Node tail()
        {
            var node = _head;
            while(node.Next is not null)
                node = node.Next;

            return node;
        }
    }
}