using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class voiceinputtest : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;

    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    public GameObject[] spells;
    public static int currentspell;

    void Start()
    {
        keywords.Add("Ürf", Cast);
        keywords.Add("attack", Cast2);
        keywordRecognizer  = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += onKeywordsRecognized;
        keywordRecognizer.Start();
    }
    private void onKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("keyword:" + args.text);
        keywords[args.text].Invoke();

    }
    private void Cast()
    {
        currentspell = 0;

        Instantiate(spells[currentspell], transform.position, transform.rotation);

    }
    private void Cast2()
    {
        currentspell = 1;

        Instantiate(spells[currentspell], transform.position, transform.rotation);

    }


    void Update ()
    {
		
	}
}
