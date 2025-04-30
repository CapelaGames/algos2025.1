using UnityEngine;

public class BinaryTree : MonoBehaviour
{
    public class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }
    }

    private TreeNode root;

    private void Start()
    {
        root = new TreeNode(50);
        Insert(10, root);
        Insert(70, root);
        Insert(7, root);
        Insert(90, root);
        Insert(20, root);
        Insert(1, root);
        Insert(9, root);
        Insert(2, root);

        PrintInPostOrder(root);
    }

    public void Insert(int value, TreeNode current)
    {
        if(value < current.value)
        {
            //Left branch
            if(current.left == null)
            {
                current.left = new TreeNode(value);
            }
            else
            {
                Insert(value, current.left);
            }
        }

        if(value >= current.value) 
        { 
            //Right branch
            if (current.right == null)
            {
                current.right = new TreeNode(value);
            }
            else 
            { 
                Insert(value, current.right);
            }
        }
    }

    void PrintInOrder(TreeNode node)
    {
        if (node == null) return;
        PrintInOrder(node.left);
        Debug.Log(node.value);
        PrintInOrder(node.right);
    }

    void PrintInPreOrder(TreeNode node)
    {
        if (node == null) return;
        Debug.Log(node.value);
        PrintInPreOrder(node.left);
        PrintInPreOrder(node.right);
    }

    void PrintInPostOrder(TreeNode node)
    {
        if (node == null) return;
        PrintInPostOrder(node.left);
        PrintInPostOrder(node.right);
        Debug.Log(node.value);
    }

    public TreeNode Delete(int value, TreeNode current)
    {
        if(current == null) return null;

        if (value < current.value)
        {
            current.left = Delete(value, current.left);
        }
        else if (value > current.value)
        {
            current.right = Delete(value, current.right);
        }
        else
        {
            if(current.left == null)
            {
                return current.right;
            }

            if(current.right == null)
            {
                return current.left;
            }

            TreeNode successor = GetSucessor(current);
            current.value = successor.value;
            current.right = Delete(successor.value, current.right);
        }
        return current;
    }

    public TreeNode GetSucessor(TreeNode current)
    {
        current = current.right;
        while (current != null && current.left != null)
        {
            current = current.left;
        }

        return current;
    }
}
