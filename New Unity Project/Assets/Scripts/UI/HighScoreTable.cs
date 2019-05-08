using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour {

    private Transform HSSlot;
    private Transform HSTamplate;
    private List<HighScoreSlot> highScoreSlotList;
    private List<Transform> highScoreSlotTransformList;

    private void Awake()
    {
        HSSlot = transform.Find("HSSlotContainer");
        HSTamplate = HSSlot.Find("HighScoreSlot");

        HSTamplate.gameObject.SetActive(false);

        //highScoreSlotList = new List<HighScoreSlot>()
        //{
        //    new HighScoreSlot { score = 521854, name = "bfbfb"},
        //    new HighScoreSlot { score = 27272, name = "sxcx"},
        //    new HighScoreSlot { score = 22231, name = "erere"},
        //    new HighScoreSlot { score = 578547, name = "dfsdf"},
        //    new HighScoreSlot { score = 837463, name = "df"},
        //}; 
        string json = PlayerPrefs.GetString("HighScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(json);

        for (int i = 0; i < highScoreSlotList.Count; i ++)
        {
            for (int j = i + 1; j < highScoreSlotList.Count; j++)
            {
                if (highScoreSlotList[j].score > highScoreSlotList[i].score)
                {
                    HighScoreSlot tmp = highScoreSlotList[i];
                    highScoreSlotList[i] = highScoreSlotList[j];
                    highScoreSlotList[j] = tmp;
                }
            }
        }

        highScoreSlotTransformList = new List<Transform>();

        foreach (HighScoreSlot highScoreSlot in highScoreSlotList)
        {
            CreateHSSlotTransform(highScoreSlot, HSSlot, highScoreSlotTransformList);
        }
        //HighScores highscores = new HighScores { highScoreSlotList = highScoreSlotList };
        //string json = JsonUtility.ToJson(highscores);
        //PlayerPrefs.SetString("HighScoreTable", json);
        //PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("HighScoreTable"));
        
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

        transformsList.Add(slotTransform);
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
