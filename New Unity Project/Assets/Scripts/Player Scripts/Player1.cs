using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Player1 : MonoBehaviour {
    public int Key1 = 0;
    public int Key2 = 0;
    public int KeysPressed = 0;
    public int FirstKey = 0;
    public GameObject Spell1;
    public GameObject Spell2;
    public GameObject Spell3;
    public GameObject Spell4;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (KeysPressed < 1)
            { FirstKey = 1; }
            Key1++;
            KeysPressed++;
            
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (KeysPressed < 1)
            { FirstKey = 2; }
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
        if (Key1 == 1 && Key2 == 1 && KeysPressed == 2 && FirstKey==1)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell1);
            SpellInstance.transform.position = transform.position;
            Key1 = 0;
            Key2 = 0;
            FirstKey = 0;
            KeysPressed = 0;
        }
        if (Key1 == 2 && Key2 == 0 && KeysPressed == 2)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell2);
            SpellInstance.transform.position = transform.position;
            Key1 = 0;
            Key2 = 0;
            FirstKey = 0;
            KeysPressed = 0;
        }
        if (Key1 == 0 && Key2 == 2 && KeysPressed == 2)
        {
            Explosion();
            Key1 = 0;
            Key2 = 0;
            FirstKey = 0;
            KeysPressed = 0;
        }
        if (Key1 == 1 && Key2 == 1 && KeysPressed == 2 &&FirstKey==2)
        {
            Storm();
            Key1 = 0;
            Key2 = 0;
            FirstKey = 0;
            KeysPressed = 0;
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
