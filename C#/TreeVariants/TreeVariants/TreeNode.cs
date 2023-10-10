using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeVariants
{
    public class TreeNode<T>
    {
        // 제네릭 타입으로 코드 단순하게 다중 변수로 코드가 꼬일걸 막아두자
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }
        public int GetHeight()
        {
            int height = 1;
            TreeNode<T> current = null;
            while(current.Parent != null) 
            {
                height++;
                current = current.Parent;
            }
            return height;
        }
    }
}
