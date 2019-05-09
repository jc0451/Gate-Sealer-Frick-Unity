using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour {

    private Transform HSSlot;
    private Transform HSTamplate;
    
    private List<Transform> highScoreSlotTransformList;

    private void Awake()
    {
        HSSlot = transform.Find("HSSlotContainer");
        HSTamplate = HSSlot.Find("HighScoreSlot");

        HSTamplate.gameObject.SetActive(false);

        //AddHSSlot(10000, "CMK");

        string jsonstring = PlayerPrefs.GetString("HighScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonstring);

        for (int i = 0; i < highScores.highScoreSlotList.Count; i++)
        {
            for (int j = i + 1; j < highScores.highScoreSlotList.Count; j++)
            {
                if (highScores.highScoreSlotList[j].score > highScores.highScoreSlotList[i].score)
                {
                    HighScoreSlot tmp = highScores.highScoreSlotList[i];
                    highScores.highScoreSlotList[i] = highScores.highScoreSlotList[j];
                    highScores.highScoreSlotList[j] = tmp;
                }
            }
        }

        highScoreSlotTransformList = new List<Transform>();

        foreach (HighScoreSlot highScoreSlot in highScores.highScoreSlotList)
        {
            CreateHSSlotTransform(highScoreSlot, HSSlot, highScoreSlotTransformList);
        }
        
        
    }

    private void CreateHSSlotTransform (HighScoreSlot highScoreSlot, Transform Slot, List<Transform> transformsList)
    {
        float TemplateHeight = 60f;
        Transform slotTransform = Instantiate(HSTamplate, Slot);
        RectTransform HSrectTransform = slotTransform.GetComponent<RectTransform>();
        HSrectTransform.anchoredPosition = new Vector2(0, -TemplateHeight * transformsList.Count);
        slotTransform.gameObject.SetActive(true);

        int rank = transformsList.Count + 1;
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

        int score = highScoreSlot.score;
        slotTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

        string name = highScoreSlot.name;
        slotTransform.Find("NameText").GetComponent<Text>().text = name;

        slotTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        //if (rank == 1)
        //{
        //    slotTransform.Find("nameText").GetComponent<Text>().color == Color.green;
        //}

        transformsList.Add(slotTransform);
    }

    private void AddHSSlot (int score, string name)
    {
        HighScoreSlot highScoreSlot = new HighScoreSlot { score = score, name = name };

        string jsonstring = PlayerPrefs.GetString("HighScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonstring);

        highScores.highScoreSlotList.Add(highScoreSlot);

        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("HighScoreTable", json);
        PlayerPrefs.Save();
    }
    private class HighScores
    {
        public List<HighScoreSlot> highScoreSlotList;
    }


    [System.Serializable]
    private class HighScoreSlot
    {
        public int score;
        public string name;


    }







	void Start () {
		
	}
	
	
	void Update () {
		
	}
}
