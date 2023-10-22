using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree.KDTREE
{
    public class KdTree<T> where T : IComparable<T>, IConvertible
    {
        public Node<T> RootNode { get; set; }

        public List<Point<T>> _points;

        public int _numDim;

        public KdTree(List<Point<T>> points)
        {
            _points = points;
            _numDim = _points[0].NumDim;
            points.Sort((a, b) => a[0].CompareTo(b[0]));
            var median = points[points.Count / 2];
            RootNode = new Node<T>(median);
            var points1 = points.Where(x => median[0].CompareTo(x[0]) > 0).ToList();
            var points2 = points.Where(x => median[0].CompareTo(x[0]) < 0).ToList();
            RootNode.Left = AddRecursive(points1, 1);
            if (RootNode.Left != null) RootNode.Left.Parent = RootNode;
            RootNode.Right = AddRecursive(points2, 1);
            if (RootNode.Right != null) RootNode.Right.Parent = RootNode;
        }
        public Node<T> AddRecursive(List<Point<T>> points, int i)
        {
            if (points.Count == 0)
            {
                return null; // null 처리
            }
            points.Sort((a, b) => a[i].CompareTo(b[i]));
            var median = points[points.Count / 2];
            if (median.NumDim != _numDim) throw new ArgumentException();
            var node = new Node<T>(median);
            var points1 = points.Where(x => median[i].CompareTo(x[i]) > 0).ToList();
            var points2 = points.Where(x => median[i].CompareTo(x[i]) < 0).ToList();
            node.Left = AddRecursive(points1, (i + 1) % _numDim);
            if (node.Left != null)
            {
                node.Left.Parent = node;
            }
            node.Right = AddRecursive(points2, (i + 1) % _numDim);
            if (node.Right != null)
            {
                node.Right.Parent = node;
            }
            return node;
        }
        public bool Add(Point<T> point)
        {
            if (point.NumDim != _numDim) throw new ArgumentException();

            var node = RootNode;
            var nodeParent = RootNode.Parent;
            var axis = 0;
            while (node != null)
            {
                for (var i = 0; i < _numDim; i++)
                {
                    if (!point[i].Equals(node.Equals(node.Point[i]))) break;
                    else if (i == _numDim - 1) return false;
                }
                nodeParent = node;
                if (point[axis % _numDim].CompareTo(node.Point[axis % _numDim]) < 0) node = node.Left;
                else if (point[axis % _numDim].CompareTo(node.Point[_numDim - 1]) > 0) node = node.Right;
                axis++;
            }
            _points.Add(point);
            if (point[(axis - 1) % _numDim].CompareTo(nodeParent!.Point[(axis - 1) % _numDim]) < 0)
            {
                nodeParent.Left = new Node<T>(point);
                nodeParent.Left.Parent = nodeParent;
            }
            else if (point[(axis - 1) % _numDim].CompareTo(nodeParent!.Point[(axis - 1) % _numDim]) > 0)
            {
                nodeParent.Right = new Node<T>(point);
                nodeParent.Right.Parent = nodeParent;
            }
            return true;
        }
        public bool Contain(Point<T> point)
        {
            if (point.NumDim != _numDim) throw new ArgumentException();
            var node = RootNode;
            var axis = 0;
            while (node != null)
            {
                for (var i = 0; i < _numDim; i++)
                {
                    if (!point[i].Equals(node.Point[i])) break;
                    else if (i == _numDim - 1) return true;
                }
                if (point[axis % _numDim].CompareTo(node.Point[axis % _numDim]) < 0) node = node.Left;
                else if (point[axis % _numDim].CompareTo(node.Point[axis % _numDim]) > 0) node = node.Right;
            }
            return false;
        }
        public Point<T> NearestNeighbour(Point<T> point)
        {
            if (point.NumDim != _numDim) throw new AggregateException();
            var node = RootNode;
            var nodeParent = RootNode.Parent;
            var axis = 0;
            while (node != null)
            {
                for (var i = 0; i < _numDim; i++)
                {
                    if (!point[i].Equals(node.Point[i])) break;
                    else if (i == _numDim - 1) return point;
                }
                nodeParent = node;
                if (point[axis % _numDim].CompareTo(node.Point[axis % _numDim]) < 0) node = node.Left;
                else if (point[axis % _numDim].CompareTo(node.Point[axis % _numDim]) > 0) node = node.Right;
            }
            var listPoint = new List<Point<T>>();
            listPoint.Add(nodeParent.Point);
            var minDistance = GetDistance(point, nodeParent.Point);
            if (nodeParent.Left != null) GetTreeDistance(nodeParent.Left, point, ref minDistance, listPoint);
            if (nodeParent.Right != null) GetTreeDistance(nodeParent.Right, point, ref minDistance, listPoint);
            axis -= 2;
            while (nodeParent.Parent != null)
            {
                if (minDistance > Math.Pow(Subtraction(point[axis % _numDim], nodeParent.Parent.Point[axis % _numDim]), 2))
                {
                    listPoint.Add(nodeParent.Parent.Point);
                    if (IsLeftParent(nodeParent)) GetTreeDistance(nodeParent.Parent.Right, point, ref minDistance, listPoint);
                }
            }
            return null;
        }
        public double GetTreeDistance(Node<T> nodeChild, Point<T> point, ref double minDistance, List<Point<T>> listPoints)
        {
            if (nodeChild != null)
            {
                minDistance = Math.Min(minDistance, GetDistance(point, nodeChild.Parent.Point));
                minDistance = Math.Min(minDistance, GetDistance(point, nodeChild.Point));
                listPoints.Add(nodeChild.Point);
                if (nodeChild.Left != null) minDistance = GetTreeDistance(nodeChild.Left, point, ref minDistance, listPoints);
                if (nodeChild.Right != null) minDistance = GetTreeDistance(nodeChild.Right, point, ref minDistance, listPoints);
            }
            return minDistance;
        }
        public double GetDistance(Point<T> point1, Point<T> point2)
        {
            double distanceSquared = 0;
            for (var i = 0; i < _numDim; i++)
            {
                distanceSquared += Subtraction(point1[i], point2[i]) * Subtraction(point1[i], point2[i]);
            }
            return distanceSquared;
        }
        public bool Remove(Point<T> point)
        {
            if (point.NumDim != _numDim) throw new ArgumentException();
            if (_points.Remove(point))
            {
                _points.Sort((a,b) => a[0].CompareTo(b[0]));
                var median = _points[_points.Count /2];
                RootNode = new Node<T>(median);
                var points1 = _points.Where(x => median[0].CompareTo(x[0]) > 0).ToList();
                var points2 = _points.Where(x => median[0].CompareTo(x[0]) < 0).ToList();
                RootNode.Left = AddRecursive(points1, 1);
                if (RootNode.Left != null)
                {
                    RootNode.Left.Parent = RootNode;
                }
                RootNode.Right = AddRecursive(points2, 1);
                if (RootNode.Right != null)
                {
                    RootNode.Right.Parent = RootNode;
                }
                return true;
            }
            return false;
        }
        private bool IsRightParent(Node<T> node)
        {
            if (IsParent(node) && node.Parent!.Right != null && node.Parent!.Right.Equals(node))
            {
                return true;
            }
            return false;
        }
        private bool IsParent(Node<T> node)
        {
            if (node == null || node.Parent == null)
            {
                return false;
            }
            return true;
        }
        private bool IsLeftParent(Node<T> node)
        {
            if (IsParent(node) && node.Parent!.Left != null && node.Parent!.Left.Equals(node))
            {
                return true;
            }
            return false;
        }
        public double Subtraction(T values1, T values2)
        {
            if (!typeof(T).IsPrimitive || typeof(T) == typeof(bool)) throw new ArgumentException();
            return (double)(object)(Convert.ToDouble(values1) - Convert.ToDouble(values2)); 
        }
    } 
}
