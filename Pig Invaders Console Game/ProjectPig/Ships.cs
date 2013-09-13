using System.Collections.Generic;

class Ships
{
    // PLAYER SHIP MODEL ASEN 1
    public static char[,] PlayerShipModelOne =
        {
            {' ',' ',' ','^', ' ', ' ', ' '},
            {' ',' ','|','+', '|', ' ', ' '},
            {' ','/','_','=', '_', '\\', ' '},
            {'<','.','.','.', '.', '.', '>'},
            {' ','^',' ',' ', ' ', '^', ' '},
        };

    // PLAYER SHIP MODEL ASEN 2
    public static char[,] PlayerShipModelTwo =
        {
            {' ',' ',' ','/', '\\', ' ', ' ', ' '},
            {' ',' ',' ','|', '|', ' ', ' ', ' '},
            {' ','/',' ','=', '=', ' ', '\\', ' '},
            {'/','\\','/',' ', ' ', '\\', '/', '\\'},
            {' ',' ',' ','/', '\\', ' ', ' ', ' '},
        };

    // PLAYER SHIP MODEL ASEN 3
    public static char[,] PlayerShipModelThree =
        {
            {' ',' ',' ','^', '^', ' ', ' ', ' '},
            {' ',' ',' ','|', '|', ' ', ' ', ' '},
            {'|',' ','/','|', '|', '\\', ' ', '|'},
            {'|','|','_','.', '.', '_', '|', '|'},
            {' ',' ',' ','^', '^', ' ', ' ', ' '},
        };

    // ENEMY ONE SHIP MODEL ASEN 1
    public static char[,] EnemyShipModel1 =
        {
            {' ', '/', '.', ' ', '.', '\\', ' '},
            {'<', '#', '*', ' ', '*', '#', '>'},
            {' ', '^', ' ', '_', ' ', '^', ' '}
        };

    // ENEMY ONE SHIP MODEL ASEN 2
    public static char[,] EnemyShipModel2 =
        {
            {' ', '_', ' ', ' ', ' ', '_', ' '},
            {' ', '\\', '\\', '*', '/', '/', ' '},
            {'<', '*', '*', '*', '*', '*', '>'},
            {' ', '^', ' ', ' ', ' ', '^', ' '}
        };

    // DEAD SHIP MODEL 1
    public static char[,] DeadShip1 =
        {
            {'\\', ' ', '/'},
            {' ', '+', ' '},
            {'/', ' ', '\\'}, 
        };

    // DEAD SHIP MODEL 2
    public static char[,] DeadShip2 =
        {
            {' ', '|', ' '},
            {'-', '*', '-'},
            {' ', '|', ' '}, 
        };

    // DEAD SHIP MODEL 3
    public static char[,] DeadShip3 =
        {
            {' ', ' ', ' '},
            {' ', '#', ' '},
            {' ', ' ', ' '},  
        };


    // RETURN MODEL HORIZONTAL DIMENSION
    public static int GetHorizontalDimension(int shipModel)
    {
        switch (shipModel)
        {
            case 1: return PlayerShipModelOne.GetLength(1);
            case 2: return PlayerShipModelTwo.GetLength(1);
            case 3: return PlayerShipModelThree.GetLength(1);
            case 11: return EnemyShipModel1.GetLength(1);
            case 12: return EnemyShipModel2.GetLength(1);
            default: break;
        }
        return 0;
    }

    // RETURN MODEL VERTICAL DIMENSION
    public static int GetVerticalDimension(int shipModel)
    {
        switch (shipModel)
        {
            case 1: return PlayerShipModelOne.GetLength(0);
            case 2: return PlayerShipModelTwo.GetLength(0);
            case 3: return PlayerShipModelThree.GetLength(0);
            case 11: return EnemyShipModel1.GetLength(0);
            case 12: return EnemyShipModel2.GetLength(0);
            default: break;
        }
        return 0;
    }


    // RETURN MODEL
    public static char[,] GetModel(int shipNumber)
    {
        int model = SpawnedShipsList[shipNumber][0];
        switch (model)
        {
            case 1: return PlayerShipModelOne;
            case 2: return PlayerShipModelTwo;
            case 3: return PlayerShipModelThree;
            case 11: return EnemyShipModel1;
            case 12: return EnemyShipModel2;
            default: break;
        }
        return PlayerShipModelOne;
    }

    // LIST OF SPAWNED SHIPS
    public static List<int[]> SpawnedShipsList = new List<int[]>();
}