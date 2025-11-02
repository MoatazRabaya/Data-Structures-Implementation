

namespace CA_Stack;

public class MyStack<T>
{

    private const int capacity = 10;
    private T[] _array;
    private int _size;

    public int Count => _size;

    public MyStack()
    {
        _array = new T[capacity];
    }

    private void EnsureCapacity()
    {
        if (_size == _array.Length)
        {
            T[] temp = new T[_array.Length * 2];

            for (int i = 0; i < _array.Length; i++)
                temp[i] = _array[i];

            _array = temp;
        }
    }

    public void Push(T ele)
    {
        EnsureCapacity();
        _array[_size] = ele;
        _size++;
    }

    public T Pop()
    {
        if (_size == 0)
            throw new Exception("There is no elements in the stack");
        T ele = _array[_size - 1];
        _size--;
        return ele;

    }

    public T Peek()
    {
        if (_size == 0)
            throw new Exception("There is no elements in the stack");
        return _array[_size - 1];
    }

    public void Clear()
    {
        _size = 0;
    }

    public bool Contains(T ele)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_array[i].Equals(ele))
                return true;
        }
        return false;
    }

}
