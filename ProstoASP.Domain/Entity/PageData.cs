using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstoASP.Domain.Entity
{
    public class PageData
    {
        public int id { get; set; }
        //название раздела сайта, его "ключ"
        public String section { get; set; }
        //заголовок раздела для отображения
        public String title { get; set; }
        //содержимое описания раздела
        public String content { get; set; }
    }
}
