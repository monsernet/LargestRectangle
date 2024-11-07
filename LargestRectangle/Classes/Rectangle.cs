using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestRectangle.Classes
{
    public class Rectangle<T>
    {
        /// <summary>
        /// Represents the width of the rectangle.
        /// </summary>
        public T Width { get; set; }

        /// <summary>
        /// Represents the height of the rectangle.
        /// </summary>
        public T Height { get; set; }

        /// <summary>
        /// Represents the calculated area of the rectangle.
        /// </summary>
        public T Area { get; }

        /// <summary>
        /// Initializes a new instance of the Rectangle class.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle(T width, T height)
        {
            Width = width;
            Height = height;
            Area = CalculateArea();
        }

        /// <summary>
        /// Calculates the area of the rectangle using dynamic typing.
        /// </summary>
        /// <returns>The calculated area of the rectangle.</returns>
        private T CalculateArea()
        {
            dynamic widthDynamic = Width;
            dynamic heightDynamic = Height;

            try
            {
                return (T)(object)(widthDynamic * heightDynamic);
            }
            catch
            {
                Console.WriteLine("Unsupported Type.");
                return default(T);
            }
        }

        /// <summary>
        /// Returns a string representation of the rectangle, including its width, height, and area.
        /// </summary>
        /// <returns>A string representation of the rectangle.</returns>
        public override string ToString()
        {
            return $"Width: {Width}, Height: {Height}, Area: {CalculateArea()}";
        }
    }
}
