﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SuperConsole;

/*
Theory & Facts
*/

/*
 Q1:
 Explain the relationship between the Stack and the Heap in C#.

 A:
 The Stack is an runtime in-memory data address storage space where certain data 
 types accessed by value are allocated;
 (e.g. data types such as Integers, Doubles, Floats, Booleans, Methods et.al).

 The Stack is always accessed sequentially (hence the name), 
 thus blocking usage of underlying blocks until the uppermost has been utilized.
 A block is automatically disposed of once it has been accessed, meaning the Stack 
 governs its own memory cleanup procedures.

 The Heap is another runtime in-memory data address storage space where data types
  accessed by reference are placed.
 They don't carry an inherent value to access, and as such cannot be stored 
 directly on the Stack (they can however be accessed through variables 
 that *are* stored on the Stack).

 The Heap has a flat structure and thus, in contrast from the Stack, 
 allows for all it's stored objects to be accessed at any time, irrespective of 
 any allocation order. 
 
 The Heap can also contain Value types, depending on how they are declared.

 Unlike the Stack, objects in the heap are not automatically disposed of once 
 utilized, and thus have to be handled manually in order to be removed from the 
 memory storage. This procedure is called Garbage Collection (GC for short).

 To illustrate this, we can take the following examples:

 the Value type is declared by itself and as such is stored on the Stack:
***  
int myInt; 
***  

The Valye type is stored on the *Heap*, 
as it is has an inherent relationship to it's owning class:
***  
class myClass {
    public int myInt;
} 
*** 

---

Q2: 
Explain the difference between Value and Reference types of data.

A:
As detailed in the previous answer, the main difference between Value and Reference types, is how they are handled
by the runtime in-memory storages-spaces. Value types are placed directly on the Stack 
while Reference types of data are allocated on the Heap.

---

Q3:
The two methods illustrated in this example return different resluts. 
The first one returns an integer of 3, while the second returns an integer of 4.
Why?

A:
In the first method, the variables "x" and "y" are declared as Value types of Integer.
This means that they are accessed by value, and as such, in the operation of "y = x", "y"
is assigned the value of "x", meaning it's assigned the value 3.
"y" is then directly assigned the value of 4, but since it was only assigned the value of "x" and not the reference
(since Value types carry no inherent reference), "x" remains unchanged and is thus returned as 3.

In the second method, both "x" and "y" are declared as Reference Class types of MyInt. since Classes are Reference types,
they are thus accessed by refernce and thus an operation like "y = x" in this case, means y now carries the Class object reference
of x. Fundamentally, "x" and "y" are now variables that have a reference to the same underlying object on the heap.
This is why changing the MyValue Property of "y", also changes the same Property of "x", since it is the same object that is being accessed.
Thus, returning "x.MyValue" results in an Integer of 4. 

*/

namespace SkalProj_Datastrukturer_Minne
{

    class Program
    {
        readonly static IO io = new();

        /// <summary>
        /// The main method, vill handle the menus for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /*
        Assignment 1 (Examine List)
        */

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menu.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            io.ClearAll();
            bool running = true;
            List<string> theList = [];
            io.WriteEncoded($"Increment string list with [green]+<Word>.[green]{Environment.NewLine}" +
                            $"decrement list with [red]-<Word>[red].{Environment.NewLine}" +
                            $"[red](Exit with any other key).[red]{Environment.NewLine}");

            do
            {
                io.Write("input a string to add or remove:", newline: true, foreground: "green");

                string input = Console.ReadLine()!;
                char nav = input[0];
                string value = input[1..];

                switch (nav.ToString())
                {
                    case "+":
                        theList.Add(value);
                        io.WriteEncoded($"[green]List Count:[green] {theList.Count}\n" +
                                        $"[green]List Capacity:[green] {theList.Capacity}\n");
                        break;
                    case "-":
                        theList.Remove(value);
                        io.WriteEncoded($"[red]List Count:[red] {theList.Count}\n" +
                                        $"[red]List Capacity:[red] {theList.Capacity}\n");
                        break;
                    default:
                        running = false;
                        Main();
                        break;
                }
            } while (running);
        }

        /*
        Q1: 
        Complete the above method to make the examination possible

        A:
        See implemenation above.

        Q2:
        When does the capacity of the list increase?

        A:
        The capacity increases when the set capacity is exceeded.

        Q3:
        By how much does the capcity increase?
        
        A:
        The increase is exponential. I.e. a new List initialized with default 
        settings have an element capacity of 4. When this is exceeded, 
        the capacity is increased by 2 * capacity N => [4, 8, 16, 32, 64, 128]..

        Q4:
        Why does the capacity not increase in size according to the count?

        A:
        Because the List uses an Array internally, and Arrays or of a fixed size,
        a new Array has to be created and assigned the elements as the limit is 
        exceeded. As this is a relatively memory expensive task in itself, 
        the List Capacity increases exponentially in order to reduce 
        the amount of times a new Array has to created.

        Q5:
        Is the Capacity reduced when elements are removed?

        A:
        No, the Capacity is not reduced inherently by removing elements, 
        by the same token of avoiding creating a new Array (since Arrays are 
        *always* of a fixed size).

        Q6:
        With this in mind, when is it preferential to 
        utilize an Array instead of a List?

        A:
        If one can be sure of the capacity in advance of a colletion operation, 
        it is always preferential to stick with a predetermined size.
        This reduces the amount of times new array objects have to be created 
        and thus leads to less overhead in memory storage.

        */

        /*
        Assignment 2
        */

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menu.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing 
             * to see how it behaves
            */

            io.ClearAll();
            bool running = true;
            Queue<string> customerQueue = new();

            io.WriteEncoded($"Enqueue customer to queue with [green]+<CustomerName>.[green]{Environment.NewLine}" +
                            $"Dequeue customer from queue with [red]-[red].{Environment.NewLine}" +
                            $"[red](Exit with any other key).[red]{Environment.NewLine}");
            do
            {
                string input = Console.ReadLine()!;
                char op = input.First();
                string customer = input[1..];

                switch (op.ToString())
                {
                    case "+":
                        customerQueue.Enqueue(customer);
                        io.WriteEncoded($"[green]{customer}[green] enters the queue...{Environment.NewLine}");
                        break;
                    case "-":
                        string dequeueCustomer = customerQueue.Dequeue();
                        io.WriteEncoded($"[red]{dequeueCustomer}[red] expedited from the queue!{Environment.NewLine}");
                        break;
                    default:
                        Main();
                        break;
                }
            }
            while (running);
        }


        /*
        Assignment 3
        */

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch with cases to push or pop items
             * Make sure to look at the Stack after pushing and and poping to see how it behaves
            */

            io.ClearAll();
            bool running = true;
            Stack<string> itemStack = new();

            io.WriteEncoded($"Push customer to stack with [green]+<ItemName>.[green]{Environment.NewLine}" +
                            $"pop customer from stack with [red]-[red].{Environment.NewLine}" +
                            $"[red](Exit with any other key).[red]{Environment.NewLine}");
            do
            {
                string input = Console.ReadLine()!;
                char op = input.First();
                string item = input[1..];

                switch (op.ToString())
                {
                    case "+":
                        itemStack.Push(item);
                        io.WriteEncoded($"[green]{item}[green] pushed on stack!{Environment.NewLine}");
                        break;
                    case "-":
                        string popItem = itemStack.Pop();
                        string popItemReversed = ReverseText(popItem);
                        io.WriteEncoded($"[red]{popItemReversed}[red] popped from stack!{Environment.NewLine}");
                        break;
                    default:
                        Main();
                        break;
                }
            }
            while (running);
        }

        static string ReverseText(string text)
        {

            Stack<string> charStack = new();

            foreach (char c in text)
            {
                charStack.Push(c.ToString());
            }

            string reversedText = string.Join("", charStack.ToArray());

            return reversedText;
        }

        /*
        Q1:
        Why is it preferential

        */

        /*
        Assignment 4
        */

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}


