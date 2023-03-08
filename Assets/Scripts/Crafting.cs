using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crafting : MonoBehaviour
{
    [SerializeField] List<Enums.IngredientsTypes> ingredients;
    [SerializeField] List<Enums.Potions> potionOutput;
    [SerializeField] GameObject PotionUI;
    [SerializeField] TMP_Text PotionTextsUI;

    public static Crafting Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        PotionUI.SetActive(false);
    }

    // Calls when you craft a potion
    public void CheckAvailablePotions()
   {
        // Check if the player has the list of ingredients

        // For the Healing Potion:
        // ConcentratedLakeWater, MarbleShards, Dandelions, ButterflyWings
        if (ingredients.Contains(Enums.IngredientsTypes.ConcentratedLakeWater) && 
            ingredients.Contains(Enums.IngredientsTypes.MarbleShards) &&
            ingredients.Contains(Enums.IngredientsTypes.Dandelions) &&
            ingredients.Contains(Enums.IngredientsTypes.ButterflyWings))
        {
            potionOutput.Add(Enums.Potions.Healing);
        }

        // Strength 
        // GeometricRocks, Ruby, SalmonOil, MintLeaves,
        if (ingredients.Contains(Enums.IngredientsTypes.GeometricRocks) &&
            ingredients.Contains(Enums.IngredientsTypes.Ruby) &&
            ingredients.Contains(Enums.IngredientsTypes.SalmonOil) &&
            ingredients.Contains(Enums.IngredientsTypes.MintLeaves))
        {
            potionOutput.Add(Enums.Potions.Strength);
        }

        // Defense 
        // ArmadilloShell, Milk, DiamondShavings, GoldOre
        if (ingredients.Contains(Enums.IngredientsTypes.ArmadilloShell) &&
            ingredients.Contains(Enums.IngredientsTypes.Milk) &&
            ingredients.Contains(Enums.IngredientsTypes.DiamondShavings) &&
            ingredients.Contains(Enums.IngredientsTypes.GoldOre))
        {
            potionOutput.Add(Enums.Potions.Defense);
        }

        // Stamina  
        // BeetleHorns, Honey, TruffleOil, CaveCarrots
        if (ingredients.Contains(Enums.IngredientsTypes.BeetleHorns) &&
            ingredients.Contains(Enums.IngredientsTypes.Honey) &&
            ingredients.Contains(Enums.IngredientsTypes.TruffleOil) &&
            ingredients.Contains(Enums.IngredientsTypes.CaveCarrots))
        {
            potionOutput.Add(Enums.Potions.Stamina);
        }

        // If there was no potions made create a Failed Potion
        if (potionOutput.Count == 0)
        {
            potionOutput.Add(Enums.Potions.Failed);
        }


        // For Debugging
        foreach (Enums.Potions potion in potionOutput)
        {
            Debug.Log(potion);

        }

        PotionUI.SetActive(true);
        DisplayPotions();
    }
    
    // Calls when you want to empty the Lists
    public void Clear()
    {
        ingredients.Clear();
        potionOutput.Clear();
        PotionUI.SetActive(false);
    }

    void DisplayPotions()
    {
        string temp = "";
        foreach (Enums.Potions potion in potionOutput)
        {
            temp += potion.ToString() + "\n";
        }

        PotionTextsUI.SetText(temp);
    }



    // Getter
    public List<Enums.Potions> GetPotions() { return potionOutput; }


    // Setter
    public void AddIngredient(Enums.IngredientsTypes ingredientToAdd)
    {
        ingredients.Add(ingredientToAdd);
    }


}
