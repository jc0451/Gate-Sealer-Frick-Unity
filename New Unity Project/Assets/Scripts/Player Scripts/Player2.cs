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
    public Slider stunMeter;
    public Slider stuncool;
    public bool meterswitch;
    public bool invincible = false;
    public float Invtime;
    private float invtime;

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

    public GameObject Shield;
    public GameObject Shieldbreak;
    private bool shieldup = false;
    Vector2 shieldpos;
    private float shieldcoldw;
    public float Shieldcoldw;
    public static bool cooldw2=false;

    public Rigidbody2D rb;
    public float speed;
    public static bool stun2 = false;
    private bool shield = false;
    private float shieldtime;
    public float Shieldtime;

    public float Decaydelay;
    private float decaydelay;
    public float decayvalue;
    public float damage;
    public bool resetswitch;

    // Use this for initialization

    void Start()
    {
        resetswitch = true;
        spellsMeter.value = 0;
        shieldtime = Shieldtime;
        decaydelay = Decaydelay;
        shieldcoldw = Shieldcoldw;

    }


    // Update is called once per frame

    void Update()
    {
     
        if (invincible == true)
        {
            invtime -= Time.deltaTime;
            if (invtime <= 0f)
            {
                invincible = false;
                invtime = Invtime;
            }
        }

        if (stunMeter.value <= 0)
        {
            stun2 = true;
            shield = false;
        }
        if (stun2 == true && shield == false)
        {
            Shake.shake2 = true;
            Shake.time2 = 0.1f;
            invincible = true;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            if (resetswitch == true)
            {
                spellsMeter.value = 0;
                stunMeter.value = 0;
                meterswitch = true;
                resetswitch = false;
            }

            if (stunMeter.value >= 5)
            {
                rb.constraints = RigidbodyConstraints2D.None;

                // meterswitch = false;
                stun2 = false;

            }

        }
        else
            resetswitch = true;
        if (stun2 == true && shield == true)
        {
            stun2 = false;
        }
        if (Input.GetKey(KeyCode.U))
        {
            FindObjectOfType<AudioManager>().Play("Stun");
            Player1.stun1 = true;
            spellsMeter.value = 0;
        }
        if (Input.GetKey(KeyCode.I))
        {
               


              if (shieldup == false)
              {
                shieldpos = transform.position;
                shieldpos.y = -9;
                invincible = true;
                invtime = shieldtime;
                FindObjectOfType<AudioManager>().Play("ShieldCreate");
                GameObject shieldd = (GameObject)Instantiate(Shield);
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                shieldd.transform.position = shieldpos;
                shieldup = true;
                shield = true;
              }
            


            
        }

        if (shield == true)
        {

            shieldtime -= Time.deltaTime;
            if (shieldtime <= 0)
            {
                shieldpos = transform.position;
                shieldpos.y = -9;
                FindObjectOfType<AudioManager>().Play("Shieldshatter");
                GameObject shieldbreak = (GameObject)Instantiate(Shieldbreak);
                rb.constraints = RigidbodyConstraints2D.None;
                shieldbreak.transform.position = shieldpos;
                shield = false;
                cooldw2 = true;
                stuncool.value = 0;
                shieldtime = Shieldtime;
                shieldcoldw = Shieldcoldw;


            }
        }
        if (cooldw2 == true)
        {
            shieldcoldw -= Time.deltaTime;
            stuncool.value += Time.deltaTime;
            if (shieldcoldw <= 0)
            {
                shieldup = false;
                stuncool.value = Shieldcoldw;
                shieldcoldw = Shieldcoldw;
                cooldw2 = false;
            }

        }

        if (Input.GetKey(KeyCode.J) == false && Input.GetKey(KeyCode.L) == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }

        

        if (Input.GetKey(KeyCode.J) == false)
        {
            rb.velocity = new Vector2(speed, 0.0f);
          
            transform.eulerAngles = new Vector3(0, 180, 0);

        }

        if (Input.GetKey(KeyCode.L) == false)
        {
            rb.velocity = new Vector2(-speed, 0.0f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            if (meterswitch == false)
            {

                spellsMeter.value += 1;
                decaydelay = Decaydelay;
            }
            else if (meterswitch == true)
            {
                stunMeter.value += 1;
                if (stunMeter.value >= 5)
                {
                    meterswitch = false;


                }
            }

        }
        /*else 
        {
             decaydelay -= Time.deltaTime;
             if (decaydelay <= 0)
             {
                 spellsMeter.value -= 1;
                 decaydelay += 1;
             }
        }
        */
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
            FindObjectOfType<AudioManager>().Play("SnowballMK1");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 3 && spellsMeter.value >= 2 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell1Mk2);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("SnowballMK2");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 4 && spellsMeter.value >= 3 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell1Mk3);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("SnowballMK3");

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
            FindObjectOfType<AudioManager>().Play("ExplosionMK1");


            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 9 && spellsMeter.value >= 8 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell3Mk2);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("ExplosionMK2");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 10 && spellsMeter.value >= 9 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell3Mk3);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("ExplosionMK3");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 11 && spellsMeter.value >= 10 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell4Mk1);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("Thunder");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 12 && spellsMeter.value >= 11 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell4Mk2);
            SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("Thunder");

            urf = false;
            spellsMeter.value = 0;
        }
        if (spellsMeter.value < 13 && spellsMeter.value >= 12 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell4Mk3);
            //SpellInstance.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("Thunder");

            urf = false;
            spellsMeter.value = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (invincible == false)
        {
            if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "FireBall")
            {
                if (meterswitch == false)
                {

                    if (spellsMeter.value <= 0)
                    {
                        meterswitch = true;
                        stunMeter.value -= 1;
                        Shake.shake2 = true;
                        Shake.time2 = 0.5f;
                    }
                    else if (spellsMeter.value > 0)
                    {
                        spellsMeter.value -= damage;
                        Shake.shake2 = true;
                        Shake.time2 = 0.5f;
                    }
                }
                else if (meterswitch == true)
                {
                    stunMeter.value -= damage;
                    Shake.shake2 = true;
                    Shake.time2 = 0.5f;
                }
            }
        }
    }


}