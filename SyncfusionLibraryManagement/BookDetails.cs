using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibraryManagement
{
    public class BookDetails
    {
        private static int s_bookID=1000;
        public string BookID { get; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int BookCount { get; set; }

        public BookDetails()
        {
            BookID="BID"+(++s_bookID);
        }

        public BookDetails(string bookName,string authorName,int bookCount)
        {
            BookID="BID"+(++s_bookID);
            BookName=bookName;
            AuthorName=authorName;
            BookCount=bookCount;
        }
    }
}