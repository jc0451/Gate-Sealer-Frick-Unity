using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDmg : MonoBehaviour
{
    [SerializeField] private Transform floatingDamage;
    Vector3 button;

    void Start()
    {

        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            button = Input.mousePosition;
            button.z = 2.0f;       // we want 2m away from the camera position
            Vector3 objectPos = Camera.current.ScreenToWorldPoint(button);
            
            DamagePopup.Create(floatingDamage, objectPos, 300);
        }
    }
}
