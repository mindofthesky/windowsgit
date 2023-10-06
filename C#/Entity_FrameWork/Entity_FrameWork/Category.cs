using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace Entity_FrameWork
{
    public class Category
    {

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ObservableCollectionListSource<Product> Products { get; set; }
        // ObservableCollectionListSource<T> 명시적 리스트소스 확장코드 
        // 원폼에 데이터 바인딩을 하기위해 선언하는 제너릭타입
    }
}
