using System;

/*

    Create a class Book that has variables for the number of pages in a book and the thickness of the book page
    to store the thickness of the page. Three books have been selected for the bookshop. Find the book with the smallest page thickness and how much
    pages the thickest book has.

    Add a variable to the Book class to store the height of the book. Create a class Shelf that
    has variables to store the height and length of a shelf. Will the three books all fit on the shelf?

    Add a Shelf class using the Put() method that allows you to change the height and length of the shelf. Will the shelves fit all
    all the books on the shelf if the height of the shelf is doubled? If the shelf length is
    is increased twice?

 */

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
            for(int i=0; i<books.Length; i++)
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
            PrintPutBooks(books, bookshelf);
        }

        static void PrintData(Book[] books, Bookshelf bs)
        {
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

            for (int i=0; i<books.Length; i++)
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

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].getBookThickness() > max_book_thickness)
                {
                    min_key = i;
                    max_book_thickness = books[i].getPageThickness();
                }

            }

            Console.WriteLine(BookNameByKey(min_key) + " book is thickest, with " +
                books[min_key].getPages() + " page(-s)");
        }

        static void PrintPutBooks(Book[] books, Bookshelf bookshelf)
        {
            bool fit_height = DoBooksFitHeight(books, bookshelf.getHeight());
            bool fit_width = DoBooksFitWidth(books, bookshelf.getWidth());

            // Bookshelf increase tracking variables
            bool height_inc = false;
            bool width_inc = false;

            // If books doesn't fit height, expand twice
            if(!fit_height)
            {
                height_inc = true;
                bookshelf.setHeight(bookshelf.getHeight() * 2);

                if(!(fit_height = DoBooksFitHeight(books, bookshelf.getHeight())))
                {
                    Console.WriteLine("Books doesn't fit into bookshelf with twice expanded height");
                    return;
                }    
            }

            // If books doesn't fit height, expand twice
            if (!fit_width)
            {
                width_inc = true;
                bookshelf.setWidth(bookshelf.getHeight() * 2);

                if(!(fit_width = DoBooksFitWidth(books, bookshelf.getWidth())))
                {
                    Console.WriteLine("Books doesn't fit into bookshelf with twice expanded width");
                    return;
                }
            }


            if (height_inc && width_inc)
            {
                Console.WriteLine("All books fit into bookshelf with twice expanded height and width");
            }
            else if(!height_inc && width_inc)
            {
                Console.WriteLine("All books fit into bookshelf with twice expanded width");
            }
            else if(height_inc && !width_inc)
            {
                Console.WriteLine("All books fit into bookshelf with twice expanded height");
            }
            else 
            {
                Console.WriteLine("All books fit into bookshelf");
            }
        }

        /// <summary>
        /// Check if every book fits into given height
        /// </summary>
        /// <param name="books">Array of all books</param>
        /// <param name="height"></param>
        /// <returns>True if fits</returns>
        static bool DoBooksFitHeight(Book[] books, double height)
        {
            for(int i=0; i<books.Length; i++)
            {
                if (books[i].getHeight() > height)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Check if every book fits into given height
        /// </summary>
        /// <param name="books">Array of all books</param>
        /// <param name="height"></param>
        /// <returns>True if fits</returns>
        static bool DoBooksFitWidth(Book[] books, double width)
        {
            double books_width = 0;

            for (int i = 0; i < books.Length; i++)
            {
                books_width += books[i].getPages() * books[i].getPageThickness();
            }

            if(width >= books_width)
                return true;
            return false;
        }

        /// <summary>
        /// Count how much area all books take
        /// </summary>
        /// <param name="books">Array of all books</param>
        /// <returns>Area</returns>
        static double CountAllArea(Book[] books)
        {
            double area = 0;

            for(int i=0; i<books.Length; i++)
            {
                area += books[i].getHeight() * books[i].getPages() * books[i].getPageThickness();
            }

            return area;
        }

        /// <summary>
        /// Get book name by it's array key (first, second, etc.)
        /// </summary>
        /// <param name="i">Array key</param>
        /// <returns>Name</returns>
        static string BookNameByKey(int i)
        {
            if (i == 0)
            {
                return "First";
            }
            else if (i == 1)
            {
                return "Second";
            }  

            return "Third";
        }
    }
}
