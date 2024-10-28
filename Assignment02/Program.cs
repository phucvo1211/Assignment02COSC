// See https://aka.ms/new-console-template for more information

using Assignment02;

class Program
{
    static void Main()
    {
        // Create a hash table instance with int keys and int values, with size 7
        DoubleHashTable<int, int> hashTable = new DoubleHashTable<int, int>(7);

        Console.WriteLine("Adding key-value pairs to the hash table:");
        hashTable.AddOrUpdate(10, 100);
        hashTable.AddOrUpdate(20, 200);
        hashTable.AddOrUpdate(5, 50);
        hashTable.AddOrUpdate(15, 150);

        Console.WriteLine("Finding values by keys:");
        Console.WriteLine($"Value for key 10: {hashTable.TryGetValue(10)}");
        Console.WriteLine($"Value for key 20: {hashTable.TryGetValue(20)}");
        Console.WriteLine($"Value for key 5: {hashTable.TryGetValue(5)}");
        Console.WriteLine($"Value for key 15: {hashTable.TryGetValue(15)}");

        Console.WriteLine("Removing key 5...");
        hashTable.Remove(5);

        Console.WriteLine("Trying to find removed key 5:");
        var value = hashTable.TryGetValue(5);
        if (value == default(int))
        {
            Console.WriteLine("Key not found");
        }
        else
        {
            Console.WriteLine($"Value for key 5: {value}");
        }

        Console.WriteLine("Testing update on existing key:");
        hashTable.AddOrUpdate(10, 300);
        Console.WriteLine($"Updated value for key 10: {hashTable.TryGetValue(10)}");
    }
}