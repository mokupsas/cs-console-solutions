using System;

namespace Bookshelf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bookshelf data
            double bs_height, bs_width;

            Book[] books = new Book[3];
            Bookshelf bookshelf;

            // Input books data
            for(int i=0; i<3; i++)
            {
                int pages;
                double height, width, thick;
                string book_name = BookNameByKey(i);

                // Input first book data
                Console.Write(book_name + " book number of pages: ");
                pages = int.Parse(Console.ReadLine());
                Console.Write(book_name +  " book page thickness: ");
                thick = double.Parse(Console.ReadLine());
                Console.Write(book_name +  " book height: ");
                height = double.Parse(Console.ReadLine());
                Console.Write(book_name +  " book number of pages: ");
                width = double.Parse(Console.ReadLine());
                Console.WriteLine("");

                books[i] = new Book(height, width, pages, thick);
            }

            //Input bookshelf data
            Console.Write("Bookshelf height: ");
            bs_height = double.Parse(Console.ReadLine());
            Console.Write("Bookshelf width: ");
            bs_width = double.Parse(Console.ReadLine());
            bookshelf = new Bookshelf(bs_height, bs_width);

            Console.Clear(); // clear console

            // Output data
            PrintData(books, bookshelf);
            PrintThinnest(books);
            PrintBiggestPages(books);
        }

        static void PrintData(Book[] books, Bookshelf bs)
        {
            // Variables
            

            Console.WriteLine("-------------------------------------" +
                            "---------------------------------------");

            for(int i=0; i<3; i++)
            {
                string book_name = BookNameByKey(i);

                Console.WriteLine("| {0, -38} | {1, -31} |",
                    book_name + " book number of pages: ", books[i].getPages());
                Console.WriteLine("| {0, -38} | {1, -31} |",
                    book_name + " book pages thickness: ", books[i].getPageThickness());
                Console.WriteLine("| {0, -38} | {1, -31} |",
                    book_name + " book width: ", books[i].getWidth());
                Console.WriteLine("| {0, -38} | {1, -31} |",
                    book_name + " book height: ", books[i].getHeight());
            }

            Console.WriteLine("| {0, -38} | {1, -31} |", null, null);

            Console.WriteLine("| {0, -38} | {1, -31} |",
                "Bookshelf width", bs.getWidth());
            Console.WriteLine("| {0, -38} | {1, -31} |",
                "Bookshelf height", bs.getHeight());

            Console.WriteLine("-------------------------------------" +
                            "---------------------------------------");
        }

        static void PrintThinnest(Book[] books)
        {
            int min_key = -1;
            double min_thickness = 9999999;

            for (int i=0; i<3; i++)
            {
                if(books[i].getPageThickness() < min_thickness)
                {
                    min_key = i;
                    min_thickness = books[i].getPageThickness();
                }

            }

             Console.WriteLine(BookNameByKey(min_key) + " book is thinnest, one page " +
                 "thickness is " + books[min_key].getPageThickness());
        }

        static void PrintBiggestPages(Book[] books)
        {
            int min_key = -1;
            double max_book_thickness = -1;

            for (int i = 0; i < 3; i++)
            {
                if (books[i].getBookThickness() > max_book_thickness)
                {
                    min_key = i;
                    max_book_thickness = books[i].getPageThickness();
                }

            }

            Console.WriteLine(BookNameByKey(min_key) + " book is thickest, with " +
                books[min_key].getPages() + " pages");
        }

        static string BookNameByKey(int i)
        {
            string book_name;

            if (i == 0)
            {
                book_name = "First";
            }
            else if (i == 1)
            {
                book_name = "Second";
            }
            else
            {
                book_name = "Third";
            }

            return book_name;
        }
    }
}
