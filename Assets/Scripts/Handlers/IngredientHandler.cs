using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientHandler : MonoBehaviour
{
    public static IngredientHandler Instance;

    [SerializeField] List<Enums.IngredientsTypes> ingredients;
    [SerializeField] List<Enums.Potions> potionOutput;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddToIngredients(Enums.IngredientsTypes ingredient)
    {
        ingredients.Add(ingredient);
    }

    public void AddToPotions(Enums.Potions potion)
    {
        potionOutput.Add(potion);
    }

    public void RemoveFromIngredients(Enums.IngredientsTypes ingredientToRemove)
    {
        if (ingredients.Contains(ingredientToRemove))
        {
            int flag = -1;
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i] == ingredientToRemove)
                {
                    flag = i;
                    break;
                }
            }

            if (flag != -1)
            {
                ingredients.RemoveAt(flag);
            }
        }
        else
        {
            Debug.Log($"Do not have {ingredientToRemove} on the ingredient list");
        }
    }

    public void RemoveFromPotions(Enums.Potions potionToRemove)
    {
        if (potionOutput.Contains(potionToRemove))
        {
            int flag = -1;
            for (int i = 0; i < potionOutput.Count; i++)
            {
                if (potionOutput[i] == potionToRemove)
                {
                    flag = i;
                    break;
                }
            }

            if (flag != -1)
            {
                potionOutput.RemoveAt(flag);
            }
        }
        else
        {
            Debug.Log($"Do not have {potionToRemove} on the ingredient list");
        }
    }

    // Getter
    public List<Enums.Potions> GetPotions() { return potionOutput; }
    public List<Enums.IngredientsTypes> GetIngredients() { return ingredients; }

}
