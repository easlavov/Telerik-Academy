using System.Collections.Generic;

class Weapons
{
    public static int CurrentWeapon = 1;

    // LIST OF FIRED WEAPONS
    public static List<int[]> FiredWeaponsList = new List<int[]>();


    // WEAPON ONE MODEL - LASER

    public static char LaserBeam = '|';


    public static char GetModel(int weaponNumber)
    {
        int model = FiredWeaponsList[weaponNumber][0];
        switch (model)
        {
            case 1: return LaserBeam;
            default: break;
        }
        return LaserBeam;
    }
}