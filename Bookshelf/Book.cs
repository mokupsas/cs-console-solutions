using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf
{
    class Book
    {
        private double height;
        private double width;
        private int pages;      // number of pages in book
        private double thick;   // page thickness 

        /// <summary>
        /// Creates book object
        /// </summary>
        /// <param name="hei">Book height</param>
        /// <param name="wid">Book width</param>
        /// <param name="pag">Number of pages</param>
        /// <param name="thi">One page thickness</param>
        public Book(double hei, double wid, int pag, double thi)
        {
            height = hei;
            width = wid;
            pages = pag;
            thick = thi;
        }

        /// <summary>
        /// Get book height
        /// </summary>
        /// <returns>Height</returns>
        public double getHeight()
        {
            return height;
        }

        /// <summary>
        /// Set book height
        /// </summary>
        /// <param name="hei">Height</param>
        public void setHeight(double hei)
        {
            height = hei;
        }

        /// <summary>
        /// Get book wdth
        /// </summary>
        /// <returns>Width</returns>
        public double getWidth()
        {
            return width;
        }

        /// <summary>
        /// Set book width
        /// </summary>
        /// <param name="">Width</param>
        public void setWidth(double wid)
        {
            width = wid;
        }

        /// <summary>
        /// Get number of pages in a book
        /// </summary>
        /// <returns>Pages</returns>
        public int getPages()
        {
            return pages;
        }

        /// <summary>
        /// Get one page thickness
        /// </summary>
        /// <returns>Page thickness</returns>
        public double getPageThickness()
        {
            return thick;
        }

        /// <summary>
        /// Get whole book thickness
        /// </summary>
        /// <returns>Book thickness</returns>
        public double getBookThickness()
        {
            return thick * pages;
        }
    }
}
