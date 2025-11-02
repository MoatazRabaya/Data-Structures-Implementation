
using System.Collections;

namespace CA_List;

public class MyList<T> : IEnumerable<T>
{

    private const int defaultCapacity = 10;

    private T[] _array;

    private int _size = 0;
    public int Count => _size;

    public MyList(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity));

        _array = new T[capacity];
    }

    public MyList()
    {

        _array = new T[defaultCapacity];

    }

    private void EnsureCapacity()
    {
        if (_size == _array.Length)
        {
            T[] temp = new T[_array.Length * 2];
            for (int i = 0; i < _size; i++)
                temp[i] = _array[i];
            _array = temp;
        }
    }

    public override string ToString()
    {
        string inf = "[ ";

        for (int i = 0; i < _size; i++)
            inf += _array[i] + " ";
        inf += "]";

        return inf;
    }

    public void Add(T element)
    {
        EnsureCapacity();

        _array[_size] = element;
        _size++;
    }

    public void Insert(int index, T element)
    {

        EnsureCapacity();

        if (index < 0 || index > _size)
            throw new IndexOutOfRangeException();

        if (_size == 0)
            _array[_size] = element;

        else
        {
            for (int i = _size - 1; i >= index; i--)
                _array[i + 1] = _array[i];
            _array[index] = element;
        }
        _size++;

    }

    public T RemoveAt(int index)
    {
        if (_size == 0)
            throw new Exception("The List Has No Elements");

        if (index < 0 || index >= _size)
            throw new IndexOutOfRangeException("Index: " + index + " , " + "Size: " + _size);

        T temp = _array[index];

        for (int i = index; i < _size - 1; i++)
            _array[i] = _array[i + 1];

        _size--;
        return temp;
    }

    public bool Remove(T value)
    {
        int index = IndexOf(value);
        RemoveAt(index);
        return true;
    }

    public void Clear()
    {
        _size = 0;
    }

    public int IndexOf(T element)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_array[i].Equals(element))
                return i;
        }
        return -1;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_array[i].Equals(element))
                return true;
        }
        return false;
    }

    public int LastIndexOf(T element)
    {
        for (int i = _size - 1; i >= 0; i--)
        {
            if (_array[i].Equals(element))
                return i;
        }

        return -1;
    }

    public void TrimExcess()
    {
        T[] temp = new T[_size];
        for (int i = 0; i < _size; i++)
            temp[i] = _array[i];
        _array = temp;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _size; i++)
            yield return _array[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}

