using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitplayer : MonoBehaviour
{

    [SerializeField]
    private GameObject testObject;


    [SerializeField]
    private GameObject hitMarkerPrefab;

    [SerializeField]
    private Color[] markerColour;

    [SerializeField]

    private float markerKillTime;

   


    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            HitNow();
        }
    }

    public void HitNow()
    {
        GameObject newMarker = Instantiate(hitMarkerPrefab, testObject.transform.position, Quaternion.identity);
        newMarker.SetActive(true);
        newMarker.GetComponent<DmgFloatingControlller>().SetTextAndMove(Random.Range(0, 101).ToString(), markerColour[Random.Range(0, markerColour.Length)]);
        Destroy(newMarker.gameObject, markerKillTime);
    }
}
