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
                string book_name;

                // Get book name (first, second, etc.)
                if(i==0)
                {
                    book_name = "First";
                }
                else if(i==1)
                {
                    book_name = "Second";
                }
                else
                {
                    book_name = "Third";
                }

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
        }

        static void PrintData(Book[] books, Bookshelf bs)
        {
            // Variables
            string book_name;

            Console.WriteLine("-------------------------------------" +
                            "---------------------------------------");

            for(int i=0; i<3; i++)
            {
                // Get book name (first, second, etc.)
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
    }
}
