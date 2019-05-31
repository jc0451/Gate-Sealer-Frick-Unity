using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

public class Player1 : MonoBehaviour {

    public bool urf = false;
    public Slider spellsMeter;
    public Slider stunMeter;
    public Slider stuncool;
    public bool meterswitch;
    public bool invincible = false;
    public float Invtime;
    private float invtime;
    
    SpriteRenderer sr;
    

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
    public static bool cooldw1 = false;

    public Rigidbody2D rb;
    public float speed ;
    public static bool stun1 = false;
    private bool shield = false;
    private float shieldtime;
    public float Shieldtime;

    public float Decaydelay;
    private float decaydelay;
    public float decayvalue;
    public float damage;
    public bool resetswitch;

    private bool active = false;
    public float flashtime;
    private float flashCounter;

    void Start() {
        resetswitch = true;
        spellsMeter.value = 0;
        shieldtime = Shieldtime;
        decaydelay = Decaydelay;
        invtime = Invtime;
        shieldcoldw = Shieldcoldw;

        sr = GetComponent<SpriteRenderer>();
    }


   

    void Update () {
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
            stun1 = true;
            shield = false;
        }
        if (stun1 == true && shield==false)
        {
            Shake.shake1 = true;
            Shake.time1 = 0.1f;
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
                stun1 = false;
                
            }
         
        }
        else
            resetswitch = true;
        if (stun1 == true && shield == true)
        {
            stun1 = false;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Player2.stun2 = true;
            spellsMeter.value = 0;
            FindObjectOfType<AudioManager>().Play("Stun");
        }
        if (Input.GetKey(KeyCode.R))
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
                cooldw1 = true;
                stuncool.value = 0;
                shieldtime = Shieldtime;


            }
        }
        if (cooldw1 == true)
        {
            shieldcoldw -= Time.deltaTime;
            stuncool.value += Time.deltaTime;
            if (shieldcoldw <= 0)
            {
                shieldup = false;
                stuncool.value = Shieldcoldw;
                shieldcoldw = Shieldcoldw;
                cooldw1 = false;
            }

        }



       


        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        

        if (Input.GetKey(KeyCode.D) == false)
        {
            
            rb.velocity = new Vector2(-speed, 0.0f);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
 
        if (Input.GetKey(KeyCode.A) == false)
        {
            
            rb.velocity = new Vector2(+speed, 0.0f);
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (meterswitch == false)
            {
               
                spellsMeter.value += 1;
                decaydelay = Decaydelay;
            }
            else if(meterswitch==true)
            {
                stunMeter.value += 1;
                if(stunMeter.value>=5){
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
        if (Mike.Mic1Loudness > 0.0001&&urf==false)
        {
            urf = true;

        }
        if (Input.GetKeyUp(KeyCode.E))
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
                active = true;
                flashCounter = flashtime;
                if (meterswitch == false)
                {

                    if (spellsMeter.value <= 0)
                    {
                        meterswitch = true;
                        stunMeter.value -= 1;
                        Shake.shake1 = true;
                        Shake.time1 = 0.5f;
                    }
                    else if (spellsMeter.value > 0)
                    {
                        spellsMeter.value -= damage;
                        Shake.shake1 = true;
                        Shake.time1 = 0.5f;
                    }
                }
                else if (meterswitch == true)
                {
                    stunMeter.value -= damage;
                    Shake.shake1 = true;
                    Shake.time1 = 0.5f;
                }

               
            }
            
        }
        
    }
    

    
}
