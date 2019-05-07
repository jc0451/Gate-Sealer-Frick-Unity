using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class Player1 : MonoBehaviour {
    public int Key1 = 0;
    public int Key2 = 0;
    public int KeysPressed = 0;
    public int FirstKey = 0;

    public static bool firstkey1 = false;
    public static bool firstkey2 = false;
    public static bool secondkey1 = false;
    public static bool secondkey2 = false;
    private bool urf = false;
    public Slider spellsMeter;

    public GameObject Spell1;
    public GameObject Spell2;
    public GameObject Spell3;
    public GameObject Spell4;

    private float time=1;
    // Use this for initialization
    void Start () {
        urf = true;
        time = 1;
        spellsMeter.value = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (urf == true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                urf = false;
                time = 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (KeysPressed < 1)
            {
                FirstKey = 1;
                firstkey1 = true;
            }
            if (KeysPressed == 1)
            {
                secondkey1 = true;
            }
            Key1++;
            KeysPressed++;
            spellsMeter.value += 1;

        }
        else
        {
            spellsMeter.value -= 0.03f;
        }
        if (Mike2.Mic2Loudness > 0.0001&&urf==false)
        {
            urf = true;
            if (KeysPressed < 1)
            {
                FirstKey = 2;
                firstkey2 = true;
            }
            if (KeysPressed == 1)
            {
                secondkey2 = true;
            }
            Key2++;
            KeysPressed++;

        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (KeysPressed < 1)
            { FirstKey = 2;
                firstkey2 = true; }
            if (KeysPressed == 1)
            {
                secondkey2 = true;
            }
            Key2++;
            KeysPressed++;
        }
        if (KeysPressed > 2)
        {
      
            Key1 = 0;
            Key2 = 0;
            FirstKey = 0;
            KeysPressed = 0;
        }
        if (Key1 == 1 && Key2 == 1 && KeysPressed == 2 && FirstKey == 1)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell1);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("SpellCast");
            FindObjectOfType<AudioManager>().Play("IceBeam");
            Key1 = 0;
            Key2 = 0;
            FirstKey = 0;
            KeysPressed = 0;
            spellsMeter.value = 0;

        }
        if (Key1 == 2 && Key2 == 0 && KeysPressed == 2)
        {
            FindObjectOfType<AudioManager>().Play("SpellCast");
            FindObjectOfType<AudioManager>().Play("EarthQuake");
            GameObject SpellInstance = (GameObject)Instantiate(Spell2);
            SpellInstance.transform.position = transform.position;
            Key1 = 0;
            Key2 = 0;
            FirstKey = 0;
            KeysPressed = 0;
            

        }
        if (Key1 == 0 && Key2 == 2 && KeysPressed == 2)
        {
            FindObjectOfType<AudioManager>().Play("SpellCast");
            FindObjectOfType<AudioManager>().Play("Explosion");
            Explosion();
            Key1 = 0;
            Key2 = 0;
            FirstKey = 0;
            KeysPressed = 0;
            spellsMeter.value = 0;
        }
        if (Key1 == 1 && Key2 == 1 && KeysPressed == 2 &&FirstKey==2)
        {
            FindObjectOfType<AudioManager>().Play("SpellCast");
            FindObjectOfType<AudioManager>().Play("Lightning");
            Storm();
            Key1 = 0;
            Key2 = 0;
            FirstKey = 0;
            KeysPressed = 0;
            spellsMeter.value = 0;
        }


    }
    void Explosion()
    {
        GameObject SpellInstance = (GameObject)Instantiate(Spell3);
    }
    void Storm()
    {
        GameObject SpellInstance = (GameObject)Instantiate(Spell4);
    }
}
