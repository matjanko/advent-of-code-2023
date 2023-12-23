namespace CosmicExpansion;

internal class Universe
{
    private string[,] _image;

    public Universe(IReadOnlyList<string> inputs)
    {
        _image = GenerateImage(inputs, isExpandSpaces: true);
    }

    private static string[,] GenerateImage(IReadOnlyList<string> inputs, bool isExpandSpaces)
    {
        var newInputs = inputs.ToList();
        if (isExpandSpaces)
        {
            for (var i = 0; i < inputs.Count; i++)
            {
                if (inputs[i].Any(c => c.ToString() != ".")) continue;
                newInputs.Insert(i + 1, inputs[i]);
                i++;
            }
        }

        var width = newInputs[0].Length;
        var height = newInputs.Count;
        var image = new string[height, width];

        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                image[i, j] = newInputs[i][j].ToString();
            }
        }

        return image;
    }
}