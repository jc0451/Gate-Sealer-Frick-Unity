using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsMeterp1 : MonoBehaviour {

    public Slider spellsMeter;

	void Start ()
    {

        spellsMeter.value = 0;
      
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Player1.firstkey1 == true)
        {
            spellsMeter.value += 1;
        }
        else
        {
            spellsMeter.value -= 1;
        }
	}
}
