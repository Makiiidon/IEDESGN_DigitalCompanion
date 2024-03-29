using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Mixing : MonoBehaviour
{
    IngredientHandler ingredientHandler;
    [SerializeField] List<Enums.Potions> potionsToMix; // ingredients for mixing

    public static Mixing Instance;
    [SerializeField] GameObject OutputPanel;

    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform buttonHolder;

    [SerializeField] PotionSprite potion1;
    [SerializeField] PotionSprite potion2;

    [SerializeField] PotionUI outputPotion;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ingredientHandler = IngredientHandler.Instance;
        foreach (Enums.Potions potion in ingredientHandler.GetPotions())
        {
            if (potion == Enums.Potions.Foam ||
                potion == Enums.Potions.Dust ||
                potion == Enums.Potions.Spark ||
                potion == Enums.Potions.Essence)
            {
                GameObject btn = Instantiate(buttonPrefab, buttonHolder);
                btn.GetComponentInChildren<TMP_Text>().SetText(potion.ToString());
                btn.GetComponent<AddToMix>().SetPotionType(potion);
            }
            
        }
        OutputPanel.SetActive(false);

    }

    public void AddToMix(Enums.Potions potion)
    {
        if (potionsToMix.Count != 2)
        {
            Debug.Log(potion + " Has been Added!!");
            potionsToMix.Add(potion); // add to the list of potions to use in mixing
            if (potionsToMix.Count == 1)
            {
                potion1.ChangeSprite();
            }
            else
            {
                potion2.ChangeSprite();
            }

        }
        else
        {
            Debug.Log(potion + " Was Not Added Because you could only mix two potions :<");
        }

    }

    public void MixPotions()
    {
        bool doesHaveFoam = potionsToMix.Contains(Enums.Potions.Foam);
        bool doesHaveDust = potionsToMix.Contains(Enums.Potions.Dust);
        bool doesHaveSpark = potionsToMix.Contains(Enums.Potions.Spark);
        bool doesHaveEssence = potionsToMix.Contains(Enums.Potions.Essence);

        if (GetNumberOfDuplicatePotions(Enums.Potions.Foam) == 2) // if there are 2 copies of Foam potions
        {
            ingredientHandler.AddToPotions(Enums.Potions.Float);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Foam);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Foam);
            potionsToMix.Clear();
        }
        else if (GetNumberOfDuplicatePotions(Enums.Potions.Spark) == 2) // To make Blue Fire Potion
        {
            ingredientHandler.AddToPotions(Enums.Potions.BlueFire);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Spark);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Spark);
            potionsToMix.Clear();
        }
        else if (GetNumberOfDuplicatePotions(Enums.Potions.Dust) == 2) // To make Crystal Potion
        {
            ingredientHandler.AddToPotions(Enums.Potions.Crystal);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Dust);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Dust);
            potionsToMix.Clear();
        }
        else if (GetNumberOfDuplicatePotions(Enums.Potions.Essence) == 2) // To make Void Potion
        {
            ingredientHandler.AddToPotions(Enums.Potions.Void);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Essence);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Essence);
            potionsToMix.Clear();
        }


        else if (doesHaveFoam && doesHaveDust) // To make Erosion Potion
        {
            ingredientHandler.AddToPotions(Enums.Potions.Erosion);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Foam);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Dust);
            potionsToMix.Clear();
        }
        else if (doesHaveFoam && doesHaveSpark) // To make Vapor Potion
        {
            ingredientHandler.AddToPotions(Enums.Potions.Vapor);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Foam);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Spark);
            potionsToMix.Clear();
        }
        else if (doesHaveFoam && doesHaveEssence) // To make Sludge Potion
        {
            ingredientHandler.AddToPotions(Enums.Potions.Sludge);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Foam);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Essence);
            potionsToMix.Clear();
        }
        else if (doesHaveSpark && doesHaveDust) // To make Magma Potion
        {
            ingredientHandler.AddToPotions(Enums.Potions.Magma);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Spark);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Dust);
            potionsToMix.Clear();
        }
        else if (doesHaveEssence && doesHaveDust) // To make Obsidian Potion
        {
            ingredientHandler.AddToPotions(Enums.Potions.Obsidian);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Essence);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Dust);
            potionsToMix.Clear();
        }
        else if (doesHaveSpark && doesHaveEssence) // To make Star Potion
        {
            ingredientHandler.AddToPotions(Enums.Potions.Star);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Spark);
            ingredientHandler.RemoveFromPotions(Enums.Potions.Essence);
            potionsToMix.Clear();
        }

        OutputPanel.SetActive(true);

        outputPotion.Initialize(ingredientHandler.GetPotions()[ingredientHandler.GetPotions().Count - 1]);
        
    }

    public void CloseOutputPanel()
    {
        //OutputPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public int GetNumberOfDuplicatePotions(Enums.Potions potionToCheck)
    {
        int flag = 0;
        foreach (Enums.Potions potion in potionsToMix)
        {
            if (potion == potionToCheck)
            {
                flag++;
            }
        }
        return flag;
    }

    public List<Enums.Potions> GetPotionsToMixList()
    {
        return potionsToMix;
    }
}
