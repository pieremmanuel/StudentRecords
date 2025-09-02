using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentRecords;
public class MyList<T> : IEnumerable<T>
{
    private T[] items;
    private int count;

    public MyList(int capacity = 10)
    {
        items = new T[capacity];
        count = 0;
    }

    public void Add(T item)
    {
        if (count == items.Length)
        {
            Resize();
        }
        items[count++] = item;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();
        return items[index];
    }

    public int Count => count;

    private void Resize()
    {
        T[] newItems = new T[items.Length * 2];
        for (int i = 0; i < items.Length; i++)
        {
            newItems[i] = items[i];
        }
        items = newItems;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > count)
            throw new IndexOutOfRangeException();
        if (count == items.Length)
        {
            Resize();
        }
        for (int i = count; i > index; i--)
        {
            items[i] = items[i - 1];
        }
        items[index] = item;
        count++;
    }
    public void DisplayAll()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(items[i]);
        }
    }
    public void Clear()
    {
        items = new T[items.Length];
        count = 0;
        Console.WriteLine("List cleared.");
    }

    public bool Remove(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (this.items[i].Equals(item)) 
            {
                for (int j = i; j < count - 1; j++)
                {
                    this.items[j] = this.items[j + 1];
                }
                this.items[count - 1] = default(T);
                count--;
                Console.WriteLine("Item removed.");
                return true;
            }
        }
        return false;
    }

    public void RemoveAt(int index)
    {
        if (index >= count || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        if (count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }
        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }
        items[count - 1] = default(T);
        count--;
        Console.WriteLine("Item removed at index " + index);
    }


    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return items[i];
        }
    }

    // Explicit non-generic implementation for IEnumerable
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            return items[index];
        }
        set
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            items[index] = value;
        }
    }


    public bool Contains(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[i].Equals(item))
                return true;
        }
        return false;
    }


    public int IndexOf(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[i].Equals(item))
                return i;
        }
        return -1;
    }


}