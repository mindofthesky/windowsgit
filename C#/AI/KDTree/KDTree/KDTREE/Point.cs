using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree.KDTREE
{
    public class Point<T> where T : IComparable<T>, IConvertible
    {

        public int NumDim { get; }
        public List<T> Value { get; set; }

        public Point(params T[]? values)
        {              
            Value = Value.ToList();
            NumDim = Value.Count;
        }
       
        public T this[int index]
        {   
            get => Value[index];
            set => Value[index] = value;
            
        }
        public override string ToString()
        {
            return $"{string.Join(" ",Value)}";
        }
    }
}
