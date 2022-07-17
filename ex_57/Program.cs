/* Задача 57: Составить частотный словарь элементов двумерного массива. 
Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных. 
{ 1, 9, 9, 0, 2, 8, 0, 9 } */

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

void GetFreqOfMatrixElements(int[,] matrix)
{
    int[] count = new int[10];
    for (int i = 0; i < matrix.GetLength(0); i++){
        for (int j = 0; j < matrix.GetLength(1); j++){
            count[matrix[i,j]]++;
        }
    }
    for (int i = 0; i < count.Length; i++){
        Console.WriteLine($"Число {i} встретилось {count[i]} раз(а)");
    }
}

int[,] arr = GetMatrix(4, 4, 0, 10);
PrintMatrix(arr);
GetFreqOfMatrixElements(arr);


