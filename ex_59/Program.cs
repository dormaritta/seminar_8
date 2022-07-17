// Задача 59: Задайте двумерный массив из целых чисел. 
// Напишите программу, которая удалит строку и столбец, 
// на пересечении которых расположен наименьший элемент массива.

int[,] GetMatrix(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    var rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

void FindMinElement(int[,] matrix, ref int indexI, ref int indexJ)
{
    int min = int.MaxValue;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < min)
            {
                min = matrix[i, j];
                indexI = i;
                indexJ = j;
            }
        }
    }
}

int[,] DeleteRowAndColumnByIndexes(int[,] matrix, int indexI, int indexJ)
{
    int[,] resultArr = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
    int offsetI = 0; 
    int offsetJ = 0;
    for (int i = 0; i < resultArr.GetLength(0); i++)
    {
        if (i == indexI) offsetI++;
        for (int j = 0; j < resultArr.GetLength(1); j++)
        {
            if (j == indexJ) offsetJ++;
            resultArr[i, j] = matrix[i + offsetI, j + offsetJ];
        }
        offsetI = 0;
        offsetJ = 0;
    }

    return resultArr;
}

int[,] arr = GetMatrix(4, 4, 0, 10);
Console.WriteLine("Исходная матрица");
PrintMatrix(arr);
int minI = 0;
int minJ = 0;
FindMinElement(arr, ref minI, ref minJ);
PrintMatrix(DeleteRowAndColumnByIndexes(arr, minI, minJ));
