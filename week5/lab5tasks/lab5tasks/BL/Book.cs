using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5tasks.BL
{
    class Book
    {
        public string author;
        public int pages;
        public int bookMark;
        public int price;
        List<string> chapters = new List<string>();
        public Book(string author, int pages, int price)
        {
            this.author = author;
            this.pages = pages;
            this.price = price;
        }
        public void addChapter(string chapter)
        {
            chapters.Add(chapter);
        }
        public string getChapter(int chapterNo)
        {
            return chapters[chapterNo-1];
        }
        public int getBookMark()
        {
            return bookMark;
        }
        public void setBookMark(int pageNo)
        {
            bookMark = pageNo;
        }
        public int getBookPrice()
        {
            return price;
        }
        public void setBookPrice(int newPrice)
        {
            price = newPrice;
        }
    }
}
