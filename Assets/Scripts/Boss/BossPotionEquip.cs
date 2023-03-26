using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossPotionEquip : MonoBehaviour
{
    IngredientHandler ingredientHandler;
    BossPotionHandler bossPotionHandler;

    [SerializeField] TMP_Text Text;
    [SerializeField] Enums.Potions potionType = Enums.Potions.None;
    bool calledOnce = false;

    private void Start()
    {
        ingredientHandler = IngredientHandler.Instance;
        bossPotionHandler = FindAnyObjectByType<BossPotionHandler>();
        Text.SetText(potionType.ToString());
    }

    private void OnEnable()
    {
        calledOnce = false;
        gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        RemoveButton();
    }

    public void EquipPotion() {
        if (!calledOnce)
        {
            bossPotionHandler.SetEquippedPotion(potionType.ToString());
            bossPotionHandler.OpenPotionMenu();
            calledOnce = true;
            gameObject.SetActive(false);
        }
    }

    public void SetPotion(Enums.Potions potion)
    {
        potionType = potion;
    }

    public void RemoveButton()
    {
        Destroy(this.gameObject);
    }

}
