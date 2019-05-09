using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDmg : MonoBehaviour
{
    [SerializeField] private Transform floatingDamage;

    void Start()
    {

        DamagePopup.Create(floatingDamage,Vector3.zero, 300);
    }

    
}
