int row = 20; //matrix size
int col = 50; 
bool[,] matrix = new bool[row, col]; // create matrix
bool[,] tempMatrix = new bool[row, col]; // create matrix


matrix[10, 25] = true;  //R-pentomino
matrix[10, 26] = true;  //R-pentomino
matrix[11, 24] = true;  //R-pentomino
matrix[11, 25] = true;  //R-pentomino
matrix[12, 25] = true;  //R-pentomino




Random r = new((int)DateTime.Now.Ticks);

/*
for (int i = 0; i < matrix.GetLength(0); i++) // fill matrix with random values
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = r.Next(0, 7) == 0 ? true : false; // 1/7 chance to be true
    }
}
*/

void PrintMatrix(bool[,] matrix) // print matrix 
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] == false ? " " : "O"); //print . if false, # if true
        }
        System.Console.WriteLine();
    }
}


int CountNeighbours(int x, int y)
{
    int count = 0;
    for (int i = x - 1; i <= x + 1; i++) // count neighbours
    {
        for (int j = y - 1; j <= y + 1; j++) // count neighbours
        {
            if (i == x && j == y) // current cell
            {
                continue;
            }
            if (i < 0 || i >= matrix.GetLength(0) || j < 0 || j >= matrix.GetLength(1)) // out of bounds
            {
                continue;
            }
            if (matrix[i, j] == true)
            {
                count++;
            }
        }
    }
    return count;
}



void ChangeStatus(int x, int y) // game rules
{
    int count = CountNeighbours(x, y);
    if (matrix[x, y] == true) // if is alive
    {
        if (count < 2 || count > 3) //get ded => overpopulation or underpopulation
        {
            tempMatrix[x, y] = false;
        }
        else if (count == 2 || count == 3) // alive remains alive
        {
            tempMatrix[x, y] = true;
        }
    }
    else // if is dead
    {
        if (count == 3) // get alive => reproduction
        {
            tempMatrix[x, y] = true;
        }
    }


}

void ChangeStatusAllCells()
{
    for (int i = 0; i < matrix.GetLength(0); i++) // rows
    {
        for (int j = 0; j < matrix.GetLength(1); j++) // columns
        {
            ChangeStatus(i, j);
        }
    }
    matrix = tempMatrix;                // copy tempMatrix to matrix
    tempMatrix = new bool[row, col];    // clear tempMatrix
}


while (true) // program loop
{
    Console.Clear();                        // clear console
    PrintMatrix(matrix);                    // print matrix
    System.Console.WriteLine();             // empty line
    ChangeStatusAllCells();                 // game rules for all cells
    System.Threading.Thread.Sleep(100);    // wait 1 second
}
//comment
