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

        public LinkedList(Node node)
        {
            header = node;
            current = node;
            header.next = null;
        }

        public void InsertNext(Node newNode)
        {
            if (current.next == null)
            {
                current.next = newNode;
                newNode.next = null;
            }
            else
            {
                newNode.next = current.next;
                current.next = newNode;
            }
            current = current.next;
        }

        public bool DeleteNext()
        {
            if(current.next == null) return false;
            //Node delNode = current.next;
            current.next = current.next.next;
            //delNode = null;
            return true;
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
    }
}