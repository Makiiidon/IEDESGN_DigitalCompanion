using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    public enum IngredientsTypes
    {
        ConcentratedLakeWater = 0,
        MarbleShards,
        Dandelions,
        ButterflyWings,

        GeometricRocks,
        Ruby,
        SalmonOil,
        MintLeaves,

        ArmadilloShell,
        Milk,
        DiamondShavings,
        GoldOre,

        BeetleHorns,
        Honey,
        TruffleOil,
        CaveCarrots,
    }

    public enum Potions
    {
        None = 0,

        // Base Potions
        Foam,
        Dust,
        Spark,
        Essence,

        // Potion Combinations
        Float, // Foam + Foam
        Erosion, // Foam + Dust
        Vapor, // Foam + Spark
        Sludge, // Foam + Essence
        Crystal, // Dust + Dust
        Magma, // Dust + Spark
        Obsidian, // Dust + Essence
        BlueFire, // Spark + Spark
        Star, // Spark + Essence
        Void // Essence + Essence
    }
}
