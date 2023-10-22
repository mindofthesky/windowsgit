using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree.KDTREE
{
    public class Node<T> where T : IComparable<T>, IConvertible
    {
        // KD 알고리즘도 차원이 있지만 점과 점끼리 모아두는 형태이기때문에
        // 이진트리지만 우리는 차원을 나눠서 계속 등분하여 모아두기때문에 트리형식임 
        // 1/2 > 1/4 > 1/8 > 1/16 계속 나누어서 보는형태 
        public Point<T> Point { get; set; }
        public Node<T>? Parent { get; set; }
        // 부모는 Null 존재하면 안됨
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }

        public Node(Point<T> point, Node<T>? parent, Node<T>? left, Node<T>? right)
        {
            Point = point;
            Parent = parent;
            if (IsLeftParent(this))
            {
                Parent.Left = this;
            }
            
            Left = left;
            if(left != null)
            {
                Left!.Parent = this;
            }
            Right = right;
            if(right != null)
            {
                Right!.Parent = this;
            }
            
        }
        
        public Node(Point<T> point) 
        {
            Point = point;
        }
        public bool IsLeftParent(Node<T> node)
        {
            if (IsLeftParent(node) && node.Parent.Left !=  null && node.Parent!.Left.Equals(node))
            {
                return true;
            }  
            return false;
        }
        public bool IsRightParent(Node<T> node)
        {
            if(ISParent(node) && node.Parent!.Right != null && node.Parent!.Right.Equals(node))
            {
                return true;
            }
            return false;
        }
        public bool ISParent(Node<T> node)
        {
            if(node == null | node.Parent == null)
            {
                return false;
            }
            return true;

        }
    }
}
