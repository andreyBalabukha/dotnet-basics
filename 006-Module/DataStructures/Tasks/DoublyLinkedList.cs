using System;
using System.Collections;
using Tasks.DoNotChange;

namespace Tasks
{
    public class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
        }
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int length;
    
        public int Length => length;

        public void Add(T e)
        {
            Node<T> node = new Node<T>(e);

            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }

            length = length + 1;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> node = new Node<T>(e);

            if (index == 0)
            {
                node.Next = head;
                head.Previous = node;
                head = node;
            }
            else if (index == length)
            {
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                node.Next = current.Next;
                node.Previous = current;
                current.Next.Previous = node;
                current.Next = node;
            }

            length = length + 1;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public void Remove(T item)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (current == head)
                    {
                        head = current.Next;
                        head.Previous = null;
                    }
                    else if (current == tail)
                    {
                        tail = current.Previous;
                        tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }

                    length = length - 1;
                    return;
                }

                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current == head)
            {
                head = current.Next;
                head.Previous = null;
            }
            else if (current == tail)
            {
                tail = current.Previous;
                tail.Next = null;
            }
            else
            {
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
            }

            length = length - 1;
            return current.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class DoublyLinkedListNode<T>
    {
        public T Value { get; }
        public DoublyLinkedListNode<T> Next { get; internal set; }
        public DoublyLinkedListNode<T> Previous { get; internal set; }

        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
    }
}
