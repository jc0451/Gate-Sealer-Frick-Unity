using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DmgFloatingControlller : MonoBehaviour
{

    private Text FloatingNumbers;

    [SerializeField]
    private float moveAmount;
    [SerializeField]
    private float moveSpeed;

    private Vector3[] moveDirection;
    private Vector3 myDire;

    private bool canMove = false;

    void Start()
    {
        moveDirection = new Vector3[]
            { transform.up, (transform.up + transform.right), (transform.up + -transform.right)


            };

        myDire = moveDirection[Random.Range(0, moveDirection.Length)];

    }


    void Update()
    {
        if (canMove) transform.position = Vector3.MoveTowards(transform.position, transform.position + myDire, moveAmount * (moveSpeed * Time.deltaTime));

    }

    public void SetTextAndMove(string textStr, Color textColour)
    {
        FloatingNumbers = GetComponent<Text>();
        FloatingNumbers.color = textColour;
        FloatingNumbers.text = textStr;
        canMove = true;
    }
}
