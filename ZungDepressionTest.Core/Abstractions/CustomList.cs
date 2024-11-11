using System.Collections;
using ZungDepressionTest.Core.Helpers;

namespace ZungDepressionTest.Core.Abstractions;

public abstract class CustomList<T> : IList<T>
{
    protected readonly List<T> Items = [];

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return Items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Items.GetEnumerator();
    }

    void ICollection<T>.Add(T item)
    {
        Items.Add(item);
    }

    void ICollection<T>.Clear()
    {
        Items.Clear();
    }

    bool ICollection<T>.Contains(T item)
    {
        return Items.Contains(item);
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
        Items.CopyTo(array, arrayIndex);
    }

    bool ICollection<T>.Remove(T item)
    {
        return Items.Remove(item);
    }

    int ICollection<T>.Count => Items.Count;

    bool ICollection<T>.IsReadOnly => true;

    int IList<T>.IndexOf(T item)
    {
        return Items.IndexOf(item);
    }

    void IList<T>.Insert(int index, T item)
    {
        Items.Insert(index, item);
    }

    void IList<T>.RemoveAt(int index)
    {
        Items.RemoveAt(index);
    }

    T IList<T>.this[int index]
    {
        get => Items[index];
        set => Items[index] = value;
    }

    public abstract Result<T> Add(T item);
    public abstract Result<T> Remove(T item);
    public abstract Result<T> Find(Func<T, bool> predicate);
    public abstract IReadOnlyList<T> GetItems(Func<T, bool> predicate);
}
