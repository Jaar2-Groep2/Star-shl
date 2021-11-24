using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJSDotnet51
{
    public class EditPages
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public EditPages(int id, String content)
        {
            this.Id = id;
            this.Content = content;
        }
    }
}