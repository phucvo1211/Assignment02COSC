namespace Assignment02;

public interface IDoubleHashTable<TKey, TValue>
{
    int GetIndex(TKey key);
    TValue TryGetValue(TKey key);
    bool Remove(TKey key);
    void AddOrUpdate(TKey key, TValue value);
}