using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreCategory
{
    public string name = "";
    public float score;
    public List<UnityEngine.UI.Text> uiText = new List<UnityEngine.UI.Text>();

    public void UpdateUI()
    {
        foreach (UnityEngine.UI.Text item in uiText)
        {
            item.text = score.ToString();
        }
    }

    public void Reset()
    {
        score = 0;
        UpdateUI();
    }
}

public class ScoreManager : MonoBehaviour
{
    public List<ScoreCategory> scoreCatList = new List<ScoreCategory>();
    private Dictionary<string, ScoreCategory> scoreCatDict = new Dictionary<string, ScoreCategory>();

    private void Awake()
    {
        foreach (ScoreCategory item in scoreCatList)
        {
            scoreCatDict.Add(item.name, item);
        }
    }

    public void Add(string catname)
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
    private void ResetAll()
    {
        foreach (ScoreCategory item in scoreCatList)
        {
            item.Reset();
        }
    }

    public void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }
    }
}
