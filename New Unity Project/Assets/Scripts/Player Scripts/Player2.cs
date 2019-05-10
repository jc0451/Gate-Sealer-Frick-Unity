using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI; 

public class Player2 : MonoBehaviour
{
    public bool urf = false;
    public Slider spellsMeter;


    public GameObject Spell1Mk1;
    public GameObject Spell1Mk2;
    public GameObject Spell1Mk3;
    public GameObject Spell2Mk1;
    public GameObject Spell2Mk2;
    public GameObject Spell2Mk3;
    public GameObject Spell3Mk1;
    public GameObject Spell3Mk2;
    public GameObject Spell3Mk3;
    public GameObject Spell4Mk1;
    public GameObject Spell4Mk2;
    public GameObject Spell4Mk3;

    public Rigidbody2D rb;
    public float speed;
    public static bool stun2;
    private bool shield = false;
    private float stuntime;
    private float shieldtime;
    public float Stuntime;
    public float Shieldtime;

    public float Decaydelay;
    private float decaydelay;

    // Use this for initialization

    void Start()
    {

        spellsMeter.value = 0;
        stuntime = Stuntime;
        shieldtime = Shieldtime;
        decaydelay = Decaydelay;


    }

    // Update is called once per frame
    void Update()
    {
        if (stun2 == true && shield == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            spellsMeter.value = 0;
            stuntime -= Time.deltaTime;
            if (stuntime <= 0)
            {
                rb.constraints = RigidbodyConstraints2D.None;
                stun2 = false;
                stuntime = Stuntime;
            }
        }
        if (stun2 == true && shield == true)
        {
            stun2 = false;
        }
        if (Input.GetKey(KeyCode.U))
        {
            Player1.stun1 = true;
            spellsMeter.value = 0;
        }
        if (Input.GetKey(KeyCode.I))
        {
            shield = true;
            spellsMeter.value = 0;
            shieldtime -= Time.deltaTime;
            if (shieldtime <= 0)
            {
                shield = false;
                shieldtime = Shieldtime;
            }
        }

        if (Input.GetKey(KeyCode.J))
        {
            rb.velocity = new Vector2(-speed, 0.0f);

        }

        if (Input.GetKey(KeyCode.L))
        {
            rb.velocity = new Vector2(speed, 0.0f);


        }

        if (Input.GetKeyUp(KeyCode.O))
        {

            spellsMeter.value += 1;
            decaydelay = Decaydelay;

        }
        else
        {
            decaydelay -= Time.deltaTime;
            if (decaydelay <= 0)
            {
                spellsMeter.value -= 1f;
                decaydelay += 1f;
            }
        }
        if (Mike2.Mic2Loudness > 0.0001 && urf == false)
        {
            urf = true;

        }
        if (Input.GetKeyUp(KeyCode.P))
        {

            urf = true;

        }
        if (spellsMeter.value == 0)
        {
            urf = false;
        }


        if (spellsMeter.value < 2 && spellsMeter.value >= 1 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell1Mk1);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("EarthQuake");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 3 && spellsMeter.value >= 2 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell1Mk2);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("EarthQuake");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 4 && spellsMeter.value >= 3 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell1Mk3);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("EarthQuake");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 5 && spellsMeter.value >= 4 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell2Mk1);
            SpellInstance.transform.position = transform.position;
            SpellInstance.transform.parent = gameObject.transform;
            FindObjectOfType<AudioManager>().Play("IceBeam");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 6 && spellsMeter.value >= 5 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell2Mk2);
            SpellInstance.transform.position = transform.position;
            SpellInstance.transform.parent = gameObject.transform;
            FindObjectOfType<AudioManager>().Play("IceBeam");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 7 && spellsMeter.value >= 6 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell2Mk3);
            SpellInstance.transform.position = transform.position;
            SpellInstance.transform.parent = gameObject.transform;
            FindObjectOfType<AudioManager>().Play("IceBeam");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 8 && spellsMeter.value >= 7 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell3Mk1);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("Explosion");


            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 9 && spellsMeter.value >= 8 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell3Mk2);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("Explosion");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 10 && spellsMeter.value >= 9 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell3Mk3);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("Explosion");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 11 && spellsMeter.value >= 10 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell4Mk1);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("Lightning");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 12 && spellsMeter.value >= 11 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell4Mk2);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("Lightning");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 13 && spellsMeter.value >= 12 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell4Mk3);
            //SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("Lightning");

            urf = false;
            spellsMeter.value = 0;
        }
    }
}
