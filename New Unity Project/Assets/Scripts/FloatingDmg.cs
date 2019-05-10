using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDmg : MonoBehaviour
{
    [SerializeField] private Transform floatingDamage;
   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //button = Input.mousePosition;


            DamagePopup.Create(floatingDamage, Vector3.zero, 300);
        }
    }
}
