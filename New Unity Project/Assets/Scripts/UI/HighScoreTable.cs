using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour {

    private Transform HSSlot;
    private Transform HSTamplate;

    private void Awake()
    {
        HSSlot = transform.Find("HSSlotContainer");
        HSTamplate = HSSlot.Find("HighScoreSlot");

        HSTamplate.gameObject.SetActive(false);

        float TemplateHeight = 60f;
        for (int i = 0; i<10; i++)
        {
            Transform slotTransform = Instantiate(HSTamplate, HSSlot);
            RectTransform HSrectTransform = slotTransform.GetComponent<RectTransform>();
            HSrectTransform.anchoredPosition = new Vector2(0, -TemplateHeight * i);
            slotTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankName;
            switch (rank)
            {
                default:
                    rankName = rank + "TH"; break;

                case 1: rankName = "1ST"; break;
                case 2: rankName = "2ND"; break;
                case 3: rankName = "3RD"; break;
            }


            slotTransform.Find("RankText").GetComponent<Text>().text = rankName;

            int score = Random.Range(0, 10000);
            slotTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

            string name = "AAA";
            slotTransform.Find("NameText").GetComponent<Text>().text = name;
        }
    }








	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
