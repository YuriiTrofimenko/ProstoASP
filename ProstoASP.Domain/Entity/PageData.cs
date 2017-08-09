using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstoASP.Domain.Entity
{
    public class PageData
    {
        private int id;
        //название раздела сайта, его "ключ"
        private String section;
        //заголовок раздела для отображения
        private String title;
        //содержимое описания раздела
        private String content;

        public PageData() { }

        public PageData(
                String _section
                , String _title
                , String _content
            )
        {

            section = _section;
            title = _title;
            content = _content;
        }

        public String getTitle()
        {
            return title;
        }

        public void setTitle(String title)
        {
            this.title = title;
        }

        public String getContent()
        {
            return content;
        }

        public void setContent(String content)
        {
            this.content = content;
        }

        public int getId()
        {
            return id;
        }

        public String getSection()
        {
            return section;
        }

        public void setSection(String section)
        {
            this.section = section;
        }
    }
}
