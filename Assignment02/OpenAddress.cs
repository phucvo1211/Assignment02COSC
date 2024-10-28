namespace Assignment02;

public class HashNode
{
    public int key;// Hash node key
    public int value;// Hash node value
    public HashNode(int key, int value) //Hash node constructor
    {
        this.key = key;
        this.value = value;
    }
}

//OpenAddress class contains methods to Add, Delete, and Find a hash node using the linear probe,
// It also contains a method to insert a hash node into the "same hash table" using the quadratic probe
public class OpenAddress : IOpenAddress
{
    static int capacity = 10; //Size of Hash Table (initialize to 10)
    static int size = 0; // Number of occupied slots (initialize to 0)
    public HashNode[] arr = new HashNode[capacity]; //Create a new hash table array
    public HashNode dummy = new HashNode(-1, -1); // Create a new dummy hash node for deleted slots

    //Implements the LinearInsert method of the IOpenAddress interface:
    //Inserts a hash node with a given key and value into the hash table
    public void linearInsert(int key, int value)
    {
        HashNode temp = new HashNode(key, value); // Create new hash node
        int hashIndex = key % capacity; // Get hash index
        //While index is not empty
        while (arr[hashIndex] != null)
        {
            hashIndex++; // increment index by 1 i.e  its the same as (hashIndex + 1)
            hashIndex %= capacity; //hashindex = (hashIndex + 1) % capacity
        }

        if (arr[hashIndex] == null || arr[hashIndex].key == -1) // if index is empty or contains a dummy
        {
            size++; // increment size by 1
        }

        arr[hashIndex] = temp; //insert new hash node into index
    }

    // Implements the LinearDeleteKey method of the IOpenAddress interface: Deletes a given key
    public int linearDeleteKey(int key)
    {
        int hashIndex = key % capacity; //Get the hash index
        while (arr[hashIndex] != null) // While the index is not empty
        {
            if (arr[hashIndex].key == key) // If the index' key = passed key
            {
                arr[hashIndex] = dummy; //Insert a dummy hash node
                size--; // Reduce size by 1
                Console.WriteLine(key + " is Deleted");
                return 1; //Return 1
            }

            hashIndex++; //Increment index by 1 i.e  its the same as (hashIndex + 1)
            hashIndex %= capacity; //hashindex = (hashIndex + 1) % capacity
        }

        Console.WriteLine(key + " Not Found ");
        return 0; // Return 0
    }

    //Implenments the linearFind method of the IOpenAddress interface: Searches for and displays the key, then returns the value if it exists 
    public int linearFind(int key)
    {
        int hashIndex = key % capacity; //Calculate hashindex
        int counter = 0; //Initialize counter to 0; it keeps track of number of visited slots
        while (arr[hashIndex] != null) // While element with index is not empty
        {
            if (counter > capacity) // If counter is > capacity
            {
                Console.WriteLine(key + " Not Found ");
                break; // Break out of loop
            }

            if (arr[hashIndex].key == key) //If the index' key is = the key passed
            {
                Console.WriteLine("Key " + key + ": index is " + hashIndex + " and value is " +
                                  arr[hashIndex].value); //Display index 
                return arr[hashIndex].value; //Return index value

            }

            hashIndex++; // increment index by 1
            hashIndex %= capacity; //hashindex = hashindex % capacity
            counter++; // increment counter  
        }

        Console.WriteLine(key + " Not Found ");
        return -1; // Return -1
    }

    // Implements the insertQuard method of the IOpenAddress interface: Probes the hash table using quardratic open addressing
    public void insertQuard(int key, int value)
    {
        HashNode temp = new HashNode(key, value); // Create a new hash node
        int hashIndex = key % capacity; // Get the hash index with the hash function
        int t = hashIndex;
        int flag = 0; // Flag to test if 

        //While table index is not null and index key <> key passed and hash node has not been
        // inserted in index and index does not contain a dummy node
        while
            (arr[t] != null &&
             flag != t) // (arr[t] != null && arr[hashIndex].key != key && flag != t && arr[hashIndex].key != -1)
        {
            //initialize counter j to 1, while j < capacity, execute statements and increment j by 1
            for (int j = 0; j < capacity; j++)
            {

                // Computing the new hash index value
                t = (key + (j * j)) % capacity;
                if (arr[t] == null) // If the index is empty
                {

                    arr[t] = temp; // inserting the hash node in the table
                    flag = t; //Flag to test if new hash node has been added to hash table, so it terminates at while loop
                    size++; // Increment size by 1
                    Console.WriteLine("index is " + t);
                    Console.WriteLine("Key " + key + ": index is " + t + " and value is " +
                                      arr[t].value); //Display index 
                    // Print out index it was inserted into
                    break; // Break the loop after
                }
            }

        }
    }
       // Implements the quadraticDeleteKey method of the IOpenAddress interface
        public int quadraticDeleteKey(int key)
        {
            int hashIndex = key % capacity; // Initial hash index
            int t = hashIndex;
            int j = 1; // Initialize a counter for quadratic probing
    
            // While the slot at the index is not null (i.e., it could contain our key)
            while (arr[t] != null)
            {
                // Check if the current slot's key matches the key to be deleted
                if (arr[t].key == key)
                {
                    arr[t] = dummy; // Set the slot to dummy to mark it as deleted
                    size--; // Decrement the size counter
                    Console.WriteLine(key + " is Deleted");
                    return 1; // Return 1 to indicate successful deletion
                }
    
                // Use quadratic probing to compute the next index
                t = (hashIndex + (j * j)) % capacity;
                j++; // Increment the counter for quadratic probing
    
                // Break if we have cycled back to the initial hashIndex
                if (t == hashIndex)
                {
                    Console.WriteLine(key + " Not Found ");
                    return 0; // Return 0 if the key was not found
                }
            }
    
            Console.WriteLine(key + " Not Found ");
            return 0; // Return 0 if the key was not found
        }

}