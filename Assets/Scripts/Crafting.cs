using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crafting : MonoBehaviour
{
    [SerializeField] GameObject PotionUI;
    [SerializeField] GameObject PotionPrefab;
    [SerializeField] Transform PotionHolder;
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

        // For the Foam Potion:
        // ConcentratedLakeWater, MarbleShards, Dandelions, ButterflyWings
        if (ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.ConcentratedLakeWater) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.ButterflyWings))
        {
            //potionOutput.Add(Enums.Potions.Healing);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.ConcentratedLakeWater);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.ButterflyWings);

            ingredientHandler.AddToPotions(Enums.Potions.Foam);
        }

        // Dust  
        // GeometricRocks, Ruby, SalmonOil, MintLeaves,
        if (ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.GeometricRocks) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.Ruby))
        {
            //potionOutput.Add(Enums.Potions.Strength);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.GeometricRocks);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.Ruby);


            ingredientHandler.AddToPotions(Enums.Potions.Dust);

        }

        // Spark  
        // ArmadilloShell, Milk, DiamondShavings, GoldOre
        if (ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.DiamondShavings) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.GoldOre))
        {
            //potionOutput.Add(Enums.Potions.Defense);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.DiamondShavings);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.GoldOre);

            ingredientHandler.AddToPotions(Enums.Potions.Spark);
        }

        // Essence   
        // BeetleHorns, Honey, TruffleOil, CaveCarrots
        if (ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.BeetleHorns) &&
            ingredientHandler.GetIngredients().Contains(Enums.IngredientsTypes.CaveCarrots))
        {
            //potionOutput.Add(Enums.Potions.Stamina);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.BeetleHorns);
            ingredientHandler.RemoveFromIngredients(Enums.IngredientsTypes.CaveCarrots);

            ingredientHandler.AddToPotions(Enums.Potions.Essence);
        }

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

        GameObject[] UIElements = GameObject.FindGameObjectsWithTag("Potion");

        foreach (GameObject pot in UIElements)
        {
            Destroy(pot.gameObject);
        }
        PotionUI.SetActive(false);
    }

    void DisplayPotions()
    {
        string temp = "";
        foreach (Enums.Potions potion in ingredientHandler.GetPotions())
        {
            //temp += potion.ToString() + "\n";
            GameObject pot = Instantiate(PotionPrefab, PotionHolder);
            pot.GetComponent<PotionUI>().Initialize(potion); 
        }

        //PotionTextsUI.SetText(temp);
    }


    // Add the ingredient to the ingredient handler
    public void AddIngredient(Enums.IngredientsTypes ingredientToAdd)
    {
        //ingredients.Add(ingredientToAdd);
        ingredientHandler.AddToIngredients(ingredientToAdd);
    }


}
