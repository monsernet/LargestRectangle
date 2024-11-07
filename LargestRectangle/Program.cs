using LargestRectangle.Classes;

static void Main(string[] args)
{
    try
    {
        // Generate a list of 10 rectangles with random integer sizes
        // We can, as well, change the type of sizes as we wish
        List<Rectangle<int>> rectangles = GenerateRandomRectangles<int>(10);

        Console.WriteLine("Generated Rectangles:");
        if (rectangles.Count > 0)
        {
            foreach (var rectangle in rectangles)
            {
                Console.WriteLine(rectangle);
            }
        }
        else
        {
            Console.WriteLine("No rectangles generated.");
        }

        // Find and display the largest rectangle
        Rectangle<int> largestRectangle = FindLargestRectangle(rectangles);
        Console.WriteLine("\nLargest Rectangle:");
        Console.WriteLine(largestRectangle);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

/// <summary>
/// Generates a list of random rectangles of the specified type and count.
/// </summary>
/// <typeparam name="T">The type of the rectangle's dimensions.</typeparam>
/// <param name="count">The number of rectangles to generate.</param>
/// <returns>A list of randomly generated rectangles.</returns>
static List<Rectangle<T>> GenerateRandomRectangles<T>(int count)
{
    if (count <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(count), "Count must be a positive integer.");
    }

    Random random = new Random();
    List<Rectangle<T>> rectangles = new List<Rectangle<T>>();

    
    for (int i = 0; i < count; i++)
    {
        // Generate random values and convert them to the specified type
        int randomValue = random.Next();
        T width = (T)Convert.ChangeType(randomValue, typeof(T));
        T height = (T)Convert.ChangeType(randomValue, typeof(T));
        rectangles.Add(new Rectangle<T>(width, height));
    }

    return rectangles;
}

/// <summary>
/// Finds the largest rectangle in a given list of rectangles.
/// </summary>
/// <typeparam name="T">The type of the rectangle's dimensions.</typeparam>
/// <param name="rectangles">The list of rectangles to search.</param>
/// <returns>The largest rectangle in the list.</returns>
static Rectangle<T> FindLargestRectangle<T>(List<Rectangle<T>> rectangles)
{
    if (rectangles == null || rectangles.Count == 0)
    {
        throw new ArgumentException("The provided list of rectangles cannot be null or empty.");
    }

    return rectangles
        .OrderByDescending(r => r.Area) // sorting by area first
        .ThenByDescending(r => r.Height) // then sorting by height in case of multiple areas
        .First(); // ensures a rectangle is always returned
}