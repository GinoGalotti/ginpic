/* Copyright 1998-2015 Epic Games, Inc. All Rights Reserved. */

/*** The following code implements a singly-linked list using C#. Please review
 *   the code looking for errors and poor coding standards. Treat this code as
 *   if you own it and will be putting it into heavy production upon the
 *   submission of your code test.
 * 
 *** Rank the issues in what you believe to be the order of importance. Resolve
 *   the issues found and implement unit tests to ensure that the errors will
 *   not reoccur.
 * 
 *** In addition to the bugs, there are three stubs for `Insert`, `Find`, and
 *    `Length`. Implement these.
 *
 *** Is there anything else that you would fix or add?
 *
 */

using System;

namespace BugHunt
{
    public class Node
    {
        public Object Data;
        public Node Next;

        public override string ToString()
        {
            String dataString = Data == null ? "{Data: null," : "{Data: " + Data.ToString() + ",";
            String nextString = Next == null ? " Next: null}" : " Next: " + Next.ToString() + "}";
            return dataString + nextString;
        }

    }

    public class MyList
    {
        public Node Head;

        /* Adds a head element */
        [ObsoleteAttribute("Call Add if you want to add an element to the list, including the first one.")]
        public void AddHead(Object Data)
        {
            // I don't know if you have some automation that will call AddHead, so I would keep it as a deprecated method
            Add(Data);
        }

        /* Adds an element to the list */
        public void Add(Object d)
        {
            if (Head == null)
            {
                Node NewNode = new Node();
                NewNode.Data = d;
                Head = NewNode;
            }
            else
            {
                Node c = Last();

                Node e = new Node { Data = d };
                c.Next = e;
            }

        }

        /* Prints all elements to the console */
        public void PrintAll()
        {
            var c = Head;

            while (true)
            {
                Console.WriteLine(c.Data);
                c = c.Next;

                if (c == null)
                    goto Finish;
            }

        Finish:
            Console.WriteLine();
        }

        // This is not the prettiest way to do assertions but it is a very easy and visual way to debug that the code is doing what I wanted on the tests
        public override String ToString()
        {
            var c = Head;
            String output = "";

            while (c != null)
            {
                if (output.Length == 0)
                {
                    output = "{" + c.Data;
                }
                else
                {
                    output = output + "," + c.Data;
                }
                c = c.Next;
            }

            output += "}";

            return output;
        }

        /* Returns the last element in the list */
        public Node Last()
        {
            var c = Head;
            Node LastNode = null;

            while (c != null)
            {
                if (c.Next == null)
                {
                    LastNode = c;
                }
                c = c.Next;
            }

            return LastNode;
        }

        /* Deletes the nth element in the list, with the head being 0 */
        public void Delete(int n)
        {
            int i = 0;
			if (Head == null)
			{
				// Here we should raise a custom exception on "delete out of bounds". I'm just cutting things fast to finish earlier
                return;
			}
            var c = Head;

            while (n != i)
            {
                i = i + 1;
                c = c.Next;
				if (c == null)
                {
                    // Here we should raise a custom exception on "delete out of bounds". I'm just cutting things fast to finish earlier
                    return;
                }
            }

            if (c.Next != null)
            {
                c.Data = c.Next.Data;
                c.Next = c.Next.Next;
            }
            else
            {
				c.Data = null;
                c = null;
            }

        }

        /* Returns and deletes the last element in the list */
        public Node Pop()
        {
			if (Head == null)
			{
				// Throw an exception or handle doing Pop on an empty List.
				return null; 
			}
			
            var c = Head;
            Node PreviousNode = c;
            Node LastNode = null;
			if (c.Next == null)
			{
				//Special case of popping a 1-member list
				Head = null;
				return c;
			}

            while (c != null)
            {
                if (c.Next == null)
                {
                    LastNode = c;
                    break;
                }
                PreviousNode = c;
                c = c.Next;
            }

            PreviousNode.Next = null;
            return LastNode;
        }

        /* Insert element at position. If length of the list is lower than pos; it'll be added at the end if the list*/
        public void Insert(int pos, Node node)
        {
			if (Head == null)
			{
				Head = node;
				return;
			}

			int i = 0;
            var c = Head;
			Node PreviousNode = c;

            while (i < pos)
            {
                i = i + 1;
				if (c.Next == null)
                {
                    c.Next = node;
                    return;
                }
				PreviousNode = c;
                c = c.Next;
				
            }

			// This is the case of inserting a node wihout next
			if (node.Next == null)
			{
				node.Next = c;
				c = node;
				PreviousNode.Next = c;
			} else { 
				Node j = node;
				while (j.Next != null)
				{
					j = j.Next;
				}
				j.Next = c;
				c = node;
				PreviousNode.Next = c;
			}
			// This is the case of inserting a List in that position

			
        }

        /* Locate the node for given data */
        public Node Find(Object data)
        {
			var c = Head;
            while (c != null)
            {
                if (c.Data == data)
				{
					return c;
				}
                c = c.Next;
            }

            return null;
        }

        /* Returns the length of the list */
        public int Length
        {
            get
            {
             	var c = Head;
                var i = 0;

				if (c != null)
				{	
					if (c.Data == null)
					{
						// This is a special case when we have deleted all members of a list
						return 0;
					}
				}

                while (c != null)
                {
                    i++;
                    c = c.Next;
                }

                return i;
            }
        }
    }
}