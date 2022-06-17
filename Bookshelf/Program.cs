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
            // Bookshelf space
            double bs_area = bookshelf.getHeight() * bookshelf.getWidth();
            // Space that all books take
            double b_area = CountAllArea(books);
            Console.WriteLine(b_area);

            // If bookshelf space is enough
            if(bs_area >= b_area)
            {
                Console.WriteLine("All books fit into bookshelf");
                return;
            }

            // If it doesn't fit, we double bookshelf height
            bookshelf.setHeight(bookshelf.getHeight() * 2);
            // Recounting bookshelf space
            bs_area = bookshelf.getHeight() * bookshelf.getWidth();

            // If bookshelf space is enough
            if (bs_area >= b_area)
            {
                Console.WriteLine("All books fit into bookshelf with double height");
                return;
            }

            // If it still doesn't fit, we double bookshelf width
            bookshelf.setWidth(bookshelf.getWidth() * 2);
            // Recounting bookshelf space
            bs_area = bookshelf.getHeight() * bookshelf.getWidth();

            if (bs_area >= b_area)
            {
                Console.WriteLine("All books fit into bookshelf with double height and width");
            }
            else
            {
                Console.WriteLine("Books doesn't fit into bookshelf after expanding " +
                    "height and width twice");
            }
        }

        /// <summary>
        /// Count how much area all books talr
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
