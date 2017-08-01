using System;
using System.Collections.Generic;

namespace binary_tree_validation
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArrays = new List<List<int>>()
            {
                new List<int>{ 1,3,4,2 },
                new List<int>{ 3,2,1,5,4,6 },
                new List<int>{ 1,3,2 }

            };
            
            TreeMethods.Master(inputArrays);
        }


        public class Tree
        {
            public class TreeNode
            {
                public int Value;
                public TreeNode Left; // левое поддерево
                public TreeNode Right; // правое поддерево
            }
            public TreeNode Node; // экземпляр класса "элемент дерева"
        }
        public static class TreeMethods
        {

            public static bool RightCheck(Tree.TreeNode node, int min)
            {
                if (node == null)
                    return true;

                if (node.Left != null && node.Left.Value < min)
                    return false;

                if (node.Right != null && node.Right.Value < min)
                    return false;


                var rightResult = node.Right == null ? true : RightCheck(node.Right, node.Value);
                var leftResult = node.Left == null ? true : RightCheck(node.Left, node.Value);

                return leftResult && rightResult;
            }

            public static bool LeftCheck(Tree.TreeNode node, int max)
            {
                if (node == null)
                    return true;

                if (node.Left != null && node.Left.Value > max)
                    return false;

                if (node.Right != null && node.Right.Value > max)
                    return false;

                var rightResult = node.Right == null ? true : LeftCheck(node.Right, node.Value);
                var leftResult = node.Left == null ? true : LeftCheck(node.Left, node.Value);

                return leftResult && rightResult;
            }

            public static int CheckTree(Tree.TreeNode node)
            {
                var result = LeftCheck(node.Left, node.Value) && RightCheck(node.Right, node.Value) ? 1 : 0;
                return result;
            }

            public static Tree.TreeNode AddToTree(Tree.TreeNode node, int val)
            {
                if (val < node.Value)
                {
                    if (node.Left == null)
                        node.Left = new Tree.TreeNode() { Value = val };

                    return node.Left;
                }
                else
                {
                    node.Right = new Tree.TreeNode() { Value = val };

                    return node.Right;
                }
            }

            public static void Master(List<List<int>> arrays)
            {
                var resultList = new List<int>();
                 
               

                foreach (var arrray in arrays)
                {
                    var length = arrray.Count;
                    var tree = new Tree();

                    tree.Node = new Tree.TreeNode() { Value = arrray[0] };
                    var root = tree.Node;
                    var current = tree.Node;

                    for (int i = 1; i < length; i++)
                    {
                        current = TreeMethods.AddToTree(current, arrray[i]);
                    }
                    var checkResult = CheckTree(root);
                    //возвращаем результат
                    resultList.Add(checkResult);
                    Console.WriteLine(checkResult);
                }

            }
        }

    }
}