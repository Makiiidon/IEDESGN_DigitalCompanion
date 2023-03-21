using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crafting : MonoBehaviour
{
    [SerializeField] GameObject PotionUI;
    [SerializeField] TMP_Text PotionTextsUI;

    IngredientHandler ingredientHandler;

    public static Crafting Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        ingredientHandler = IngredientHandler.Instance;
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
        if (ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.ConcentratedLakeWater) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.MarbleShards) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.Dandelions) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.ButterflyWings))
        {
            //potionOutput.Add(Enums.Potions.Healing);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.ConcentratedLakeWater);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.MarbleShards);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.Dandelions);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.ButterflyWings);

            ingredientHandler.AddToPotions(Enums.Potions.Healing);
        }

        // Strength 
        // GeometricRocks, Ruby, SalmonOil, MintLeaves,
        if (ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.GeometricRocks) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.Ruby) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.SalmonOil) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.MintLeaves))
        {
            //potionOutput.Add(Enums.Potions.Strength);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.GeometricRocks);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.Ruby);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.SalmonOil);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.MintLeaves);

            ingredientHandler.AddToPotions(Enums.Potions.Strength);

        }

        // Defense 
        // ArmadilloShell, Milk, DiamondShavings, GoldOre
        if (ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.ArmadilloShell) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.Milk) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.DiamondShavings) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.GoldOre))
        {
            //potionOutput.Add(Enums.Potions.Defense);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.ArmadilloShell);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.Milk);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.DiamondShavings);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.GoldOre);

            ingredientHandler.AddToPotions(Enums.Potions.Defense);
        }

        // Stamina  
        // BeetleHorns, Honey, TruffleOil, CaveCarrots
        if (ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.BeetleHorns) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.Honey) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.TruffleOil) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.CaveCarrots))
        {
            //potionOutput.Add(Enums.Potions.Stamina);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.BeetleHorns);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.Honey);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.TruffleOil);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.CaveCarrots);

            ingredientHandler.AddToPotions(Enums.Potions.Stamina);
        }

        // If there was no potions made create a Failed Potion
        //if (potionOutput.Count == 0)
        //{
        //    potionOutput.Add(Enums.Potions.Failed);
        //}


        // For Debugging
        foreach (Enums.Potions potion in ingredientHandler.GetPotions())
        {
            Debug.Log(potion);

        }

        PotionUI.SetActive(true);
        DisplayPotions();
    }
    
    // Calls when you want to empty the Lists
    public void Clear()
    {
        //ingredients.Clear();
        //potionOutput.Clear();
        PotionUI.SetActive(false);
    }

    void DisplayPotions()
    {
        string temp = "";
        foreach (Enums.Potions potion in ingredientHandler.GetPotions())
        {
            temp += potion.ToString() + "\n";
        }

        PotionTextsUI.SetText(temp);
    }


    // Add the ingredient to the ingredient handler
    public void AddIngredient(Enums.IngredientsTypes ingredientToAdd)
    {
        //ingredients.Add(ingredientToAdd);
        ingredientHandler.AddToIngredients(ingredientToAdd);
    }


}
