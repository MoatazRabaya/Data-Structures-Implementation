public class MyQueue<T>
{
    // Circular Manner
    private int _front, _rear;
    private int _capacity;
    T[] _array;
    private int _size;

    public int Count => _size;

    public MyQueue(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be positive");

        this._capacity = capacity;
        _front = 0;
        _size = 0;
        _rear = 0;
        _array = new T[this._capacity];
    }

    public void EnQueue(T ele)
    {
        if (_size == _capacity)
        {
            T[] arr = new T[2 * _capacity];
            for (int i = 0; i < _size; i++)
                arr[i] = _array[i];
            _array = arr;
            _capacity *= 2;
            _front = 0;
            _rear = _size;
        }

        _array[_rear] = ele;
        _rear = (_rear + 1) % _capacity;
        _size++;
    }

    public T DeQueue()
    {
        if (_size == 0)
            throw new Exception("The Queue is Empty");

        T ret = _array[_front];
        _front = (_front + 1) % _capacity;
        _size--;
        return ret;
    }

    public T Peek()
    {
        if (_size == 0)
            throw new Exception("The Queue is Empty");
        return _array[_front];
    }

    public void Clear()
    {
        _front = 0;
        _rear = 0;
        _size = 0;
    }

    public bool Contains(T ele)
    {
        for (int i = 0; i < _size; i++)
        {
            int index = (_front + i) % _capacity;
            if (ele.Equals(_array[index]))
                return true;
        }
        return false;
    }

}