using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Identification
{
    public enum Tags
    {
        //---Player: 0 - 9
        Player = 0,
        Crew = 1,
        Drone = 2,
        Fighter = 3,
        Mining = 4,
        Satelite = 5,

        //---Enemy: 10 - 19
        Enemy = 10,
        Gnat = 11,
        Wasp = 12,
        Beetle = 13,
        Turret = 14,

        //--- Interactable
        Interactable = 20,
        Terminal = 21,
        Window = 22,

        //--- Weapon Effects: 30 - 39
        WeaponEffect = 30,
        Shot = 31,
        Beam = 32,
        Rocket = 33,

        //--- Warp Gates: 40 - 49
        WarpGate = 40,
        AsteroidSpawning = 41,

        //--- Asteroids: 50 - 59
        Asteroid = 50,
        MineralRich = 51,

        //--- Planets: 60 - 69
        Planet = 60,
        GasGiant = 61,
        Habitable = 62,
        Molten = 63,
        Frozen = 64,
        Oceanic = 65,

        //--- Collectibles: 70 - 99
        Collectible = 70,
        Materium = 71,
        Survivors = 72,

        //--- Miscellaneous: 100+
        Colony = 100
    }
}
