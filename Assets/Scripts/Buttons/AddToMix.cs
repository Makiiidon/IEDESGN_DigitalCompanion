using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToMix : MonoBehaviour
{
    Mixing mixing;
    Enums.Potions potionType;
    bool calledOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        mixing = Mixing.Instance;
    }


    public void AddPotion()
    {
        if (!calledOnce)
        {
            mixing.AddToMix(potionType);
            calledOnce = true;
            this.gameObject.SetActive(false);
        }
    }

    public void SetPotionType(Enums.Potions potion)
    {
        potionType = potion;
    }
}
