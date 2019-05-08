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


    public GameObject Spell1;
    public GameObject Spell2;
    public GameObject Spell3;
    public GameObject Spell4;

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
                spellsMeter.value -= 0.03f;
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
      

        if (spellsMeter.value < 7 && spellsMeter.value >= 4 && urf == true)
        {
            GameObject SpellInstance = (GameObject)Instantiate(Spell1);
            SpellInstance.transform.position = transform.position;
            SpellInstance.transform.parent = gameObject.transform;
            FindObjectOfType<AudioManager>().Play("SpellCast");
            FindObjectOfType<AudioManager>().Play("IceBeam");
            urf = false;
            spellsMeter.value = 0;


        }
        if (spellsMeter.value < 4 && spellsMeter.value > 0 && urf == true)
        {
            FindObjectOfType<AudioManager>().Play("SpellCast");
            FindObjectOfType<AudioManager>().Play("EarthQuake");
            GameObject SpellInstance = (GameObject)Instantiate(Spell2);
            SpellInstance.transform.position = transform.position;
            urf = false;
            spellsMeter.value = 0;


        }
        if (spellsMeter.value < 10 && spellsMeter.value >= 7 && urf == true)
        {
            FindObjectOfType<AudioManager>().Play("SpellCast");
            FindObjectOfType<AudioManager>().Play("Explosion");
            Explosion();
            urf = false;
            spellsMeter.value = 0;

        }
        if (spellsMeter.value >= 10 && urf == true)
        {
            FindObjectOfType<AudioManager>().Play("SpellCast");
            FindObjectOfType<AudioManager>().Play("Lightning");
            Storm();
            urf = false;
            spellsMeter.value = 0;

        }


    }
    void Explosion()
    {
        GameObject SpellInstance = (GameObject)Instantiate(Spell3);
        SpellInstance.transform.position = transform.position;
    }
    void Storm()
    {
        GameObject SpellInstance = (GameObject)Instantiate(Spell4);
        SpellInstance.transform.position = transform.position;
    }
}
