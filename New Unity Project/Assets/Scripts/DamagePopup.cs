using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour {


    public static DamagePopup Create(Transform floatingDamage, Vector3 position, int damageAmount)
    {

        Transform floatingDmgPopupTransform = Instantiate(floatingDamage, position, Quaternion.identity);

        DamagePopup damagePopup = floatingDmgPopupTransform.GetComponent<DamagePopup>();
        damagePopup.setup(damageAmount);
        return damagePopup;
    }
    private static int sortingOrder;
    private const float DisappearTimer_Max = 0.5f;
    private TextMeshPro textMesh;
    private float disappeartimer;
    private Color textColor;
    private Vector3 []floatingDir;
    private Vector3 myDire;
    float moveAmount = 1f;
    float moveSpeed = 1f;
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());

        textColor = textMesh.color;
        disappeartimer = DisappearTimer_Max;
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;

        floatingDir = new[] { new Vector3(0.7f, 1f), new Vector3(-0.7f, -1f), new Vector3 (-1f, 0.9f)};
        myDire = floatingDir[Random.Range(0, floatingDir.Length)];
        // floatingDir = new Vector3(0.7f, 1f) * 6f;
    }
      
    
    private void Update()
    {


        transform.position = Vector3.MoveTowards(transform.position, transform.position + myDire, moveAmount * (moveSpeed * Time.deltaTime));

        if (disappeartimer > DisappearTimer_Max * 0.5f)
        {
            float increaseScaleAmount = 0.5f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            float decreaseScaleAmount = 0.5f;
            transform.localScale += Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappeartimer -= Time.deltaTime;

        if (disappeartimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
