using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ReferenceBook : IBook
    {
        public string LibraryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
    }
}
