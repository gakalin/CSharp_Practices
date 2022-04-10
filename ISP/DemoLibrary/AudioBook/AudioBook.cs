using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class AudioBook : IBorrowableAudioBook
    {
        public string LibraryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CheckOutDurationInDays { get; set; } = 14;
        public string Borrower { get; set; }
        public DateTime BorrowDate { get; set; }
        public int RuntimeInMinutes { get; set; }

        public void CheckOut(string borrower)
        {
            Borrower = borrower;
            BorrowDate = DateTime.Now;
        }

        public void CheckIn()
        {
            Borrower = "";
        }

        public DateTime GetDueDate()
        {
            return BorrowDate.AddDays(CheckOutDurationInDays);
        }
    }
}
