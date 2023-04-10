using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UsePotionHandler : MonoBehaviour
{
    IngredientHandler ingredientHandler;
    [SerializeField] GameObject ButtonPrefabTemplate;
    [SerializeField] Transform ButtonHolder;

    Enums.Potions equippedPotion = Enums.Potions.None;

    [SerializeField] Image body;
    [SerializeField] Image liquid;
    [SerializeField] TMP_Text name;

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

    private void Update()
    {
        ChangeSprite();
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

    public void ChangeSprite()
    {
        Color foam = ingredientHandler.GetColor(0);
        Color dust = ingredientHandler.GetColor(1);
        Color spark = ingredientHandler.GetColor(2);
        Color essence = ingredientHandler.GetColor(3);
        Color floatColor = ingredientHandler.GetColor(4);
        Color erosion = ingredientHandler.GetColor(5);
        Color vapor = ingredientHandler.GetColor(6);
        Color sludge = ingredientHandler.GetColor(7);
        Color crystal = ingredientHandler.GetColor(8);
        Color magma = ingredientHandler.GetColor(9);
        Color obsidian = ingredientHandler.GetColor(10);
        Color blueFire = ingredientHandler.GetColor(11);
        Color star = ingredientHandler.GetColor(12);
        Color voidColor = ingredientHandler.GetColor(13);

        if (equippedPotion == Enums.Potions.Foam)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = foam;
        }
        else if (equippedPotion == Enums.Potions.Dust)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = dust;
        }
        else if (equippedPotion == Enums.Potions.Spark)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = spark;
        }
        else if (equippedPotion == Enums.Potions.Essence)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = essence;
        }
        else if (equippedPotion == Enums.Potions.Float)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = floatColor;
        }
        else if (equippedPotion == Enums.Potions.Erosion)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = erosion;
        }
        else if (equippedPotion == Enums.Potions.Vapor)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = vapor;
        }
        else if (equippedPotion == Enums.Potions.Sludge)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = sludge;
        }
        else if (equippedPotion == Enums.Potions.Crystal)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = crystal;
        }
        else if (equippedPotion == Enums.Potions.Magma)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = magma;
        }
        else if (equippedPotion == Enums.Potions.Obsidian)
        {
            body.sprite = ingredientHandler.GetBodySprite(2);
            liquid.sprite = ingredientHandler.GetLiquidSprite(2);
            liquid.color = obsidian;
        }
        else if (equippedPotion == Enums.Potions.BlueFire)
        {
            body.sprite = ingredientHandler.GetBodySprite(3);
            liquid.sprite = ingredientHandler.GetLiquidSprite(3);
            liquid.color = blueFire;
        }
        else if (equippedPotion == Enums.Potions.Star)
        {
            body.sprite = ingredientHandler.GetBodySprite(0);
            liquid.sprite = ingredientHandler.GetLiquidSprite(0);
            liquid.color = star;
        }
        else if (equippedPotion == Enums.Potions.Void)
        {
            body.sprite = ingredientHandler.GetBodySprite(1);
            liquid.sprite = ingredientHandler.GetLiquidSprite(1);
            liquid.color = voidColor;
        }
        name.SetText(equippedPotion.ToString());

    }
}
