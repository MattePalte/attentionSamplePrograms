/*************************************************************************************************/

using System;

class GFG
{

    static void towerOfHanoi(int n, char from_rod, char to_rod, char aux_rod)
    {

        if (n == 0)
        {
            return;
        }

        towerOfHanoi(n-1, from_rod, aux_rod, to_rod);

        Console.WriteLine("Move disk " + n + " from rod " + 
                          from_rod + " to rod " + to_rod);

        towerOfHanoi(n-1, aux_rod, to_rod, from_rod);
    }
     
    public static void Main(String []args)
    {
        int n = 4;
        towerOfHanoi(n, 'A', 'C', 'B');
    }
}

// Questions: How does the algorithm moves disks from the starting rod to the ending rod?
// Answer: 