using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreCategory
{
    public string name = "";
    public float score;
    public List<UnityEngine.UI.Text> uiText = new List<UnityEngine.UI.Text>();

    public void UpdateUI ()
    {
        foreach (UnityEngine.UI.Text t in uiText)
        {
            t.text = score.ToString();
        }
    }

    public void Reset ()
    {
        score = 0;
        UpdateUI();
    }
}

public class ScoreManager : MonoBehaviour {

    public List<ScoreCategory> scoreCatList = new List<ScoreCategory>();
    private Dictionary<string, ScoreCategory> scoreCatDict = new Dictionary<string, ScoreCategory>();

    private void Awake()
    {
        foreach (ScoreCategory scoreCat in scoreCatList)
        {
            scoreCatDict.Add(scoreCat.name, scoreCat);
        }
    }

    public void Add (string catname)
    {
        scoreCatDict[catname].score += 1;
        scoreCatDict[catname].UpdateUI();
    }
    
    public void Remove(string catname)
    {
        scoreCatDict[catname].score -= 1;
        scoreCatDict[catname].UpdateUI();
    }

    public void Reset(string catname)
    {
        scoreCatDict[catname].Reset();
    }

    public void ResetAll()
    {
        foreach (ScoreCategory scoreCat in scoreCatList)
        {
            scoreCat.Reset();
        }
    }
}
