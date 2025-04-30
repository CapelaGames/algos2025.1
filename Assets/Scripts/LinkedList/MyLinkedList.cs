using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OurLinkedList
{
    public class Node
    {
        public string name;
        public int age = 0;

        public Node next;
        public Node prev;

        public Node(string name, int age)
        {
            this.name = name;
            this.age = age;

            next = null;
        }
    }

    public class MyLinkedList : MonoBehaviour
    {
        private void Start()
        {
            Node Andrew = new Node("Andrew", 300);
            Node Anthony = new Node("Anthony", -10);
            Node BrainRot = new Node("Gen A", 13);

            LinkedList linkedList = new LinkedList(Andrew);
            linkedList.InsertNext(Anthony);
            linkedList.InsertNext(BrainRot);

            linkedList.Restart();
            linkedList.PrintCurrent();
            linkedList.Next();
            linkedList.PrintCurrent();
            linkedList.Restart();
            linkedList.DeleteNext();
            linkedList.Next();
            linkedList.PrintCurrent();


            linkedList.PrintAll();
        }
    }

    public class LinkedList
    {
        private Node current;

        private Node header;
        private Node tail;

        public LinkedList(Node node)
        {
            header = node;
            tail = node;
            current = node;
            header.next = null;
            header.prev = null;
        }

        public void InsertNext(Node newNode)
        {
            if (current.next == null)
            {
                current.next = newNode;
                newNode.prev = current;
                newNode.next = null;
                tail = newNode;
            }
            else
            {
                newNode.next = current.next;
                current.next = newNode;

                newNode.next.prev = newNode;
                newNode.prev = current;
            }
            current = newNode;
        }

        public void InsertPrev(Node newNode)
        {
            if (current.prev == null)
            {
                header = newNode;
                current.prev = newNode;
                newNode.next = current;
                newNode.prev = null;

            }
            else
            {
                newNode.prev = current.prev;
                current.prev = newNode;
                newNode.prev.next = newNode;
                newNode.next = current;
            }
            current = newNode;
        }

        public bool DeleteNext()
        {
            if(current.next == null) return false;

            //Node delNode = current.next;
            current.next = current.next.next;

            if(current.next == null)
            {
                tail = current;
            }
            else
            {
                current.next.prev = current;
            }
            //if c++ you must free the memory
            //delNode = null;
            return true;
        }

        public bool DeletePrev()
        {
            if (current.prev == null) return false;

            //Node delNode = current.next;
            current.prev = current.prev.prev;

            if (current.prev == null)
            {
                header = current;
            }
            else
            {
                current.prev.next = current;
            }
            //if c++ you must free the memory
            //delNode = null;
            return true;
        }

        public void DeleteCurrent()
        {
            if(Prev())
            {
                DeleteNext();
            }
            else if(Next())
            {
                DeletePrev();
            }
            else
            {
                header = null;
                tail = null;
                current = null;
            }
        }

        public bool Next()
        {
            if (current.next != null)
            {
                current = current.next;
                return true;
            }
            return false;
        }

        public bool Prev()
        {
            if (current.prev != null)
            {
                current = current.prev;
                return true;
            }
            return false;
        }


        public void Restart() => current = header;
        public void PrintCurrent() => Debug.Log(current.name + " aged " + current.age );
        public void Print(Node node) => Debug.Log(node.name + " aged " + node.age);
        public void PrintAll()
        {
            if (header == null) return;

            Node currentPrint = header;

            do
            {
                Print(currentPrint);
                currentPrint = currentPrint.next;
            } while (currentPrint != null);
        }

        public void PrintBackwardsAll()
        {
            if (tail == null) return;

            Node currentPrint = tail;

            do
            {
                Print(currentPrint);
                currentPrint = currentPrint.prev;
            } while (currentPrint != null);
        }
    }
}