using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossPotionEquip : MonoBehaviour
{
    UsePotionHandler usePotionHandler;
    [SerializeField] TMP_Text Text;
    [SerializeField] Enums.Potions potionType = Enums.Potions.None;
    bool calledOnce = false;

    private void Start()
    {
        usePotionHandler = FindAnyObjectByType<UsePotionHandler>();
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
            usePotionHandler.EquipPotion(potionType);
            calledOnce = true;
            gameObject.SetActive(false);
        }
    }

    public void SetPotion(Enums.Potions potion)
    {
        potionType = potion;
        Text.SetText(potion.ToString());
    }

    public void RemoveButton()
    {
        Destroy(this.gameObject);
    }

}
