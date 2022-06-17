using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf
{
    class Bookshelf
    {
        private double height;
        private double width;

        /// <summary>
        /// Creates bookshelf object
        /// </summary>
        /// <param name="hei">Bookshelf height</param>
        /// <param name="wid">Bookshelf width</param>
        public Bookshelf(double hei, double wid )
        {
            height = hei;
            width = wid;
        }

        /// <summary>
        /// Get bookshelf height
        /// </summary>
        /// <returns>Height</returns>
        public double getHeight()
        {
            return height;
        }

        /// <summary>
        /// Set bookshelf height
        /// </summary>
        /// <param name="hei">Height</param>
        public void setHeight(double hei)
        {
            height = hei;
        }

        /// <summary>
        /// Get bookshelf width
        /// </summary>
        /// <returns>Width</returns>
        public double getWidth()
        {
            return width;
        }

        /// <summary>
        /// Set bookshelf width
        /// </summary>
        /// <param name="wid">Width</param>
        public void setWidth(double wid)
        {
            width = wid;
        }
    }
}
