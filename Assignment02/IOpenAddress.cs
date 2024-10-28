namespace Assignment02;

public interface IOpenAddress
{
    /// <summary>
    /// Inserts a hash node with a given key and value into the hash table using the linear probe.
    /// </summary>
    /// <param name="key">The key in the key-value pair.</param>
    /// <param name="value">The value in the key-value pair.</param>
    /// <returns>void</returns>
    void linearInsert(int key, int value);

    /// <summary>
    /// Deletes a given key using the linear probe.
    /// </summary>
    /// <param name="key">The key in the key-value pair.</param>
    /// <returns>0 if the key was not found, or 1 if deletion was successful.</returns>
    int linearDeleteKey(int key);

    /// <summary>
    /// Searches for and displays the key, then returns the value if it exists.
    /// </summary>
    /// <param name="key">The key in the key-value pair.</param>
    /// <returns>The value associated with the key if found; otherwise, returns -1.</returns>
    int linearFind(int key);

    /// <summary>
    /// Inserts a hash node with a given key and value into the hash table using the quadratic probe.
    /// </summary>
    /// <param name="key">The key in the key-value pair.</param>
    /// <param name="value">The value in the key-value pair.</param>
    /// <returns>void</returns>
    void insertQuard(int key, int value);

    /// <summary>
    /// Deletes a given key using the quadratic probe.
    /// </summary>
    /// <param name="key">The key in the key-value pair.</param>
    /// <returns>0 if the key was not found, or 1 if deletion was successful.</returns>
    int quadraticDeleteKey(int key); // New method for quadratic deletion
}