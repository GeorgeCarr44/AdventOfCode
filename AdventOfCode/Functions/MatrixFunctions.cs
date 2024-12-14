namespace AdventOfCode.Functions;

public static class MatrixFunctions
{
    /// <summary>
    /// Generates a 2D char matrix. Splitting on new lines
    /// </summary>
    /// <param name="input">String input</param>
    /// <returns></returns>
    public static char[,] CreateMatrix (string input)
    {
        var lines = File.ReadAllLines(input);

        var matrix = new char[lines[0].Length, lines.Length];
        var y = 0;
        foreach (var l in lines)
        {
            var x = 0;
            foreach (var c in l.ToCharArray())
            {
                matrix[x, y] = c;
                x++;
            }
            y++;
        }
        return matrix;
    }
}