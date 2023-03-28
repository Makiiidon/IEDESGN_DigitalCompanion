using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsePotionHandler : MonoBehaviour
{
    IngredientHandler ingredientHandler;
    [SerializeField] GameObject ButtonPrefabTemplate;
    [SerializeField] Transform ButtonHolder;

    Enums.Potions equippedPotion = Enums.Potions.None;

    // Start is called before the first frame update
    void Start()
    {
        ingredientHandler = IngredientHandler.Instance;
        foreach (Enums.Potions potion in ingredientHandler.GetPotions())
        {
            GameObject btn = Instantiate(ButtonPrefabTemplate, ButtonHolder);
            btn.GetComponent<BossPotionEquip>().SetPotion(potion);
        }
    }

    public void RefreshPotionList()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EquipPotion(Enums.Potions potionToEquip)
    {
        equippedPotion = potionToEquip;
    }

    public void UsePotion()
    {
        ingredientHandler.RemoveFromPotions(equippedPotion);
        equippedPotion = Enums.Potions.None;
    }
}
