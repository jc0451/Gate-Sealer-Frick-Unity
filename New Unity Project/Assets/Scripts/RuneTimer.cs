using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTimer : MonoBehaviour {

    private SpriteRenderer spriterenderer;
    public Sprite rune1;
    public Sprite rune2;
    public Sprite rune3;
    public Sprite rune4;
    public Sprite rune5;
    public Sprite rune6;
    public static int spriteChanger = 0;

    public Sprite[] sprites = new Sprite[6];

    void Start ()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();

        sprites[0] = rune1;
        sprites[1] = rune2;
        sprites[2] = rune3;
        sprites[3] = rune4;
        sprites[4] = rune5;
        sprites[5] = rune6;

    }
	
	
	void Update ()
    {
        if (timerScript.timer <= 59)
        {
            spriterenderer.sprite = sprites[0];
        }

        if (timerScript.timer <= 60f)
        {
            spriterenderer.sprite = sprites[1];
        }
        else if (timerScript.timer <= 120f)
        {
            spriterenderer.sprite = sprites[2];
        }
        else if (timerScript.timer <= 180f)
        {
            spriterenderer.sprite = sprites[3];
        }
        else if (timerScript.timer <= 240f)
        {
            spriterenderer.sprite = sprites[4];
        }
        else if (timerScript.timer <= 300f)
        {
            spriterenderer.sprite = sprites[5];
        }
    }
}

