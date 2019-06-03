using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpellSwitchP1 : MonoBehaviour {

    public Sprite[] projectileSprites;

    public Sprite[] laserSprites;

    public Sprite[] explosionSprites;

    public Sprite[] thunderSprites;

    public Sprite[] Stunned;

    public Image projectiles;
    public Image lasers;
    public Image explosions;
    public Image thunders;
    public Image stun;


    public Slider spellMeterP1;
    public static int currentstatus;
    public static int currentProjectile;
    public static int currentBeam;
    public static int currentExplosion;
    public static int currentLightning;


    void Start()
    {


    }


    void Update()
    {
        if (spellMeterP1.value == 0)
        {
            currentBeam = 0;
            currentProjectile = 0;
            currentExplosion = 0;
            currentLightning = 0;
        }
        if (spellMeterP1.value == 1)
        {
            currentProjectile = 0;
        }

        if (spellMeterP1.value == 2)
        {
            currentProjectile = 1;
        }

        if (spellMeterP1.value == 3)
        {
            currentProjectile = 2;
        }

        if (spellMeterP1.value == 4)
        {
            currentBeam = 0;
            currentProjectile = 0;
        }

        if (spellMeterP1.value == 5)
        {
            currentBeam = 1;
        }

        if (spellMeterP1.value == 6)
        {
            currentBeam = 2;
        }

        if (spellMeterP1.value == 7)
        {
            currentBeam = 0;
            currentExplosion = 0;
        }

        if (spellMeterP1.value == 8)
        {
            currentExplosion = 1;
        }

        if (spellMeterP1.value == 9)
        {
            currentExplosion = 2;
        }

        if (spellMeterP1.value == 10)
        {
            currentExplosion = 0;
            currentLightning = 0;
        }

        if (spellMeterP1.value == 11)
        {
            currentLightning = 1;
        }

        if (spellMeterP1.value == 12)
        {
            currentLightning = 2;
        }



        projectiles.sprite = projectileSprites[currentProjectile];
        lasers.sprite = laserSprites[currentBeam];
        explosions.sprite = explosionSprites[currentExplosion];
        thunders.sprite = thunderSprites[currentLightning];
        stun.sprite = Stunned[currentstatus];
        if (Player1.stun1 == true)
        {
            StartCoroutine(stunanim());
            

        }
        else
        {
            currentstatus = 0;
        }
        
    }
    IEnumerator stunanim()
    {
        for (int n = 0; n < 2; n++)
        {
            currentstatus = 0;
            yield return new WaitForSeconds(0.4f);

            currentstatus = 1;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
