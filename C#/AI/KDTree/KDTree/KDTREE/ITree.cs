using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree.KDTREE
{
    // Tree 기본 유형을 선언 
    public interface ITree<T> where T : IComparable<T>, IConvertible
    {
        Node<T> RootNode { get; set; }
        bool Add(Point<T> point);
        bool Remove(Point<T> point);

        bool Contains(Point<T> point);
        Point<T> NearestNeighbour(Point<T> point);
        Node<T> Find(Point<T> point);
    }
}
