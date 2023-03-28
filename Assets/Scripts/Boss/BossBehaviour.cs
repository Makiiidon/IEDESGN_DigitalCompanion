using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Vuforia;

public class BossBehaviour : MonoBehaviour
{
    ContentPositioningBehaviour contentPosition;
    Animator bossAnimator;
    bool isContentPlaced = false;

    [SerializeField] GameObject BossGameObject;
    [SerializeField] GameObject PotionUI;

    [SerializeField] ParticleSystem SpawnFX;

    [SerializeField] SpriteRenderer bossRenderer;
    [SerializeField] Color NoColor;
    [SerializeField] Color FoamColor;
    [SerializeField] Color DustColor;
    [SerializeField] Color SparkColor;

    int points = 0;
    [SerializeField] int foamDamage = 3;
    [SerializeField] int dustDamage = 4;
    [SerializeField] int sparkDamage = 5;
    [SerializeField] int essenceDamage = 3;

    [SerializeField] int resistedDamage = 1;
    [SerializeField] int weaknessDamage = 2;

    Enums.Potions bossType = Enums.Potions.None;

    // Start is called before the first frame update
    void Start()
    {
        contentPosition = FindAnyObjectByType<ContentPositioningBehaviour>();
        bossAnimator = GetComponent<Animator>();
        PotionUI.SetActive(false);
        bossRenderer.color = NoColor;
    }

    public void PositionContentAtPlaneAnchor(HitTestResult hitTestResult)
    {
        if (!isContentPlaced)
        {
            contentPosition.PositionContentAtPlaneAnchor(hitTestResult);
            isContentPlaced = true;
            PotionUI.SetActive(true);
        }
    }

    public void Found()
    {
        BossGameObject.SetActive(true);
        SpawnFX.Play();

    }
    public void Lost()
    {
        BossGameObject.SetActive(false);
    }

    // outputs the number of points from that turn
    public int DamageBoss(Enums.Potions potion)
    {
        bool isFoamBased = false,
            isDustBased = false,
            isSparkBased = false,
            isEssenceBased = false;

        int damage = 0;

        if (potion == Enums.Potions.Foam || 
            potion == Enums.Potions.Float ||
            potion == Enums.Potions.Erosion ||
            potion == Enums.Potions.Vapor ||
            potion == Enums.Potions.Sludge)
        {
            isFoamBased = true;
        }

        if (potion == Enums.Potions.Dust || 
            potion == Enums.Potions.Erosion || 
            potion == Enums.Potions.Crystal ||
            potion == Enums.Potions.Magma || 
            potion == Enums.Potions.Obsidian) 
        {
            isDustBased = true;
        }

        if (potion == Enums.Potions.Spark || 
            potion == Enums.Potions.Vapor ||
            potion == Enums.Potions.Magma ||
            potion == Enums.Potions.BlueFire ||
            potion == Enums.Potions.Star)
        {
            isSparkBased = true;
        }

        if (potion == Enums.Potions.Essence || 
            potion == Enums.Potions.Sludge ||
            potion == Enums.Potions.Obsidian ||
            potion == Enums.Potions.Star ||
            potion == Enums.Potions.Void)
        {
            isEssenceBased = true;
        }

        // =============== Deals the damage ================== //
        if (isFoamBased)
        {
            damage += foamDamage;

            if (potion == Enums.Potions.Float)
            {
                damage += foamDamage;
            }
            SpawnFX.startColor = FoamColor;
        }

        if (isDustBased)
        {
            damage += dustDamage;
            if (potion == Enums.Potions.Crystal)
            {
                damage += dustDamage;
            }
            SpawnFX.startColor = DustColor;
        }

        if (isSparkBased)
        {
            damage += sparkDamage;
            if (potion == Enums.Potions.BlueFire)
            {
                damage += sparkDamage;
            }
            SpawnFX.startColor = SparkColor;
        }

        if (isEssenceBased)
        {
            damage = essenceDamage;
            if (potion == Enums.Potions.Void)
            {
                damage += essenceDamage;
            }
            SpawnFX.startColor = NoColor;
        }

        SpawnFX.Play();

        // ========================== Reactions ============================= //
        if (bossType == Enums.Potions.None)
        {
            if (isFoamBased)
            {
                bossType = Enums.Potions.Foam;
                bossRenderer.color = FoamColor;
            }
            else if (isSparkBased)
            {
                bossType = Enums.Potions.Spark;
                bossRenderer.color = SparkColor;
            }
            else if (isDustBased)
            {
                bossType = Enums.Potions.Dust;
                bossRenderer.color = DustColor;
            }
        }

        else if (bossType == Enums.Potions.Foam)
        {
            if (isFoamBased) // nullifies the dmg done
            {
                damage -= foamDamage;
            }
            if (isSparkBased) // reduces the dmg by 1
            {
                damage -= resistedDamage;
            }
            if (isDustBased) // deals aditional dmg
            {
                damage += weaknessDamage;
            }

        }
        else if (bossType == Enums.Potions.Dust)
        {
            if (isDustBased) // nullifies the dmg done
            {
                damage -= foamDamage;
            }
            if (isFoamBased)
            {
                damage -= resistedDamage;
            }
            if (isSparkBased)
            {
                damage += weaknessDamage;
            }

        }
        else if (bossType == Enums.Potions.Spark)
        {
            if (isSparkBased) // nullifies the dmg done
            {
                damage -= foamDamage;
            }
            if (isDustBased)
            {
                damage -= resistedDamage;
            }
            if (isFoamBased)
            {
                damage += weaknessDamage;
            }

        }

        if (potion == Enums.Potions.Void || potion == Enums.Potions.Essence)
        {
            bossType = Enums.Potions.None;
            bossRenderer.color = NoColor;
        }

        if (damage < 0)
        {
            damage = 0;
        }
        else
        {
            bossAnimator.SetTrigger("Hit");
        }
        // ============================= Add To score ================================ //
        Debug.Log($"Hit with {potion} Damage is : {damage}");
        return damage;
    }
}
