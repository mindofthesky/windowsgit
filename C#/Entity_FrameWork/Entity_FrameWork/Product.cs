using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_FrameWork
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        //string? > 모든 변수에 null 허용하지 않는 참조 형식 값이 붙었다면 Name = null 될수없음을 지정
        // https://learn.microsoft.com/ko-kr/dotnet/csharp/nullable-references
        public int CategoryId { get; set; }
        public virtual CategoryAttribute Category {  get; set; }
    }
}
