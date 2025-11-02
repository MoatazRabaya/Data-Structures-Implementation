
namespace CA_List;

class Program
{
    static void Main(string[] args)
    {
        MyList<int> list = new();

        list.Add(1);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}

