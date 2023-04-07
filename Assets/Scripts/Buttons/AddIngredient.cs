using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddIngredient : MonoBehaviour
{
    [SerializeField] Enums.IngredientsTypes ingredient;
    Crafting craftingHandler;

    // Start is called before the first frame update
    void Start()
    {
        craftingHandler = Crafting.Instance;
        
    }

    public void Add()
    {
        craftingHandler.AddIngredient(ingredient);
        Debug.Log(ingredient + " has been added!");
    }

    
}
