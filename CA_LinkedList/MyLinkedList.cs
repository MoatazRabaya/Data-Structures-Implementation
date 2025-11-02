namespace CA_LinkedList;

public class MyLinkedList<T>
{

    private Node<T> _head { get; set; }
    private Node<T> _tail { get; set; }

    private int _size;

    public int Count => _size;

    public MyLinkedList()
    {
    }

    public override String ToString()
    {
        String inf = "[ ";
        Node<T> curr = _head;

        while (curr != null)
        {
            inf += curr.Data + " ";
            curr = curr.Next;
        }
        inf += "]";
        return inf;
    }

    public void Clear()
    {
        _head = _tail = null;
    }

    public void AddFirst(T ele)
    {
        Node<T> temp = new(ele);

        if (_head is null)
        {
            _head = _tail = temp;
        }
        else
        {
            temp.Next = _head;
            _head.Prev = temp;
            _head = temp;
        }
        _size++;
    }

    public void AddLast(T ele)
    {
        Node<T> temp = new(ele);
        if (_size == 0)
            _head = _tail = temp;
        else
        {
            _tail.Next = temp;
            temp.Prev = _tail;
            _tail = temp;
        }
        _size++;
    }

    public void AddAfter(Node<T> node, T value)
    {
        Node<T> newNode = new Node<T>(value);

        Node<T> curr = _head;

        while (curr != null)
        {
            if (curr == node)
            {
                newNode.Prev = curr;
                newNode.Next = curr.Next;
                if (curr.Next != null)
                    curr.Next.Prev = newNode;
                curr.Next = newNode;
                if (curr == _tail)
                    _tail = newNode;
            }
            curr = curr.Next;
        }
        if (curr is null)
            throw new Exception($"There is no node similar to the node {node}");
    }

    public void AddBefore(Node<T> node, T value)
    {
        Node<T> newNode = new Node<T>(value);

        Node<T> curr = _head;

        while (curr != null)
        {
            if (curr == node)
            {
                newNode.Next = curr;
                newNode.Prev = curr.Prev;
                if (curr.Prev != null)
                    curr.Prev.Next = newNode;
                curr.Prev = newNode;
                if (curr == _head)
                    _head = newNode;
            }
            curr = curr.Next;
        }
        if (curr is null)
            throw new Exception($"There is no node similar to the node {node}");
    }

    public T RemoveFirst()
    {
        T temp = _head.Data;

        if (_size == 0)
            throw new Exception("No Data");
        if (_size == 1)
            _head = _tail = null;
        else
        {
            _head = _head.Next;
            _head.Prev = null;
        }
        _size--;
        return temp;
    }

    public T RemoveLast()
    {
        T temp = _tail.Data;

        if (_size == 0)
            throw new Exception("No Data");

        if (_size == 1)
            _head = _tail = null;
        else
        {
            _tail = _tail.Prev;
            _tail.Next = null;
        }
        _size--;
        return temp;
    }


    public void Remove(T ele)
    {

        if (_size == 0)
            throw new Exception("No Data");

        Node<T> curr = _head;

        while (curr != null)
        {
            if (curr.Data.Equals(ele))
            {
                if (curr == _tail)
                {
                    curr.Prev.Next = null;
                    _tail = curr.Prev;
                }
                else if (curr == _head)
                {
                    curr.Next.Prev = null;
                    _head = curr.Next;
                }
                else
                {
                    curr.Next.Prev = curr.Prev;
                    curr.Prev.Next = curr.Next;
                }
            }
            curr = curr.Next;
        }
    }

    public void RotateRight(int rotateBy)
    {
        if (_size == 0 || rotateBy % _size == 0)
            return;

        rotateBy = rotateBy % _size;

        _tail.Next = _head;
        _head.Prev = _tail;

        for (int i = 0; i < rotateBy; i++)
        {
            _head = _head.Prev;
            _tail = _tail.Prev;
        }
        _tail.Next = null;
        _head.Prev = null;
    }

    public void RotateLeft(int rotateBy)
    {

        if (_size == 0 || rotateBy % _size == 0)
            return;
        rotateBy = rotateBy % _size;
        _tail.Next = _head;
        _head.Prev = _tail;

        for (int i = 0; i < rotateBy; i++)
        {
            _head = _head.Next;
            _tail = _tail.Next;
        }
        _tail.Next = null;
        _head.Prev = null;
    }

    public void Reverse()
    {

        if (_size == 0)
            return;
        Node<T> first = _head.Next;
        Node<T> last = _head;

        _tail = _head;

        while (first != null)
        {
            last = first;
            first = first.Next;
            last.Next = _head;
            _head.Prev = last;
            _head = last;
        }

        _tail.Next = null;
        _head.Prev = null;
    }

    public Node<T> MiddleElement()
    {

        if (_size == 0)
            throw new Exception("No Data");

        Node<T> first = _head;
        Node<T> end = _tail;

        while (first != end && end.Next != first)
        {
            first = first.Next;
            end = end.Prev;
        }

        return end;
    }

}
