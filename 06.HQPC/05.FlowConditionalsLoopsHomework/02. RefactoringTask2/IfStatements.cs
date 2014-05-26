using System;

public class IfStatements
{
    // FIRST STATEMENT
    Potato potato;
    //...
    if (potato != null)
    {
        if(potato.IsPeeled && !potato.IsRotten)
        {
            Cook(potato);
        }
    }    

    // SECOND STATEMENT
    bool xInRange = MIN_X <= x && x <= MAX_X;
    bool yInRange = MIN_Y <= y && y <= MAX_Y;
    if (xInRange && yInRange && shouldVisitCell)
    {
        VisitCell();
    }
}