using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SongsHighScore : MonoBehaviour
{
    public Dictionary<string, float> hsDict = new Dictionary<string, float>();
    public string hsStr = string.Empty;
    public GameObject[] songs;

    // Start is called before the first frame update
    void Start()
    {
        hsStr = PlayerPrefs.GetString("hsStr");
        Debug.Log($"String saved in PlayerPrefs:\n {hsStr}");
        DontDestroyOnLoad(gameObject);

        if (!String.IsNullOrEmpty(hsStr))
        {
            string[] items = hsStr.TrimEnd(Environment.NewLine.ToCharArray()).Split(Environment.NewLine.ToCharArray());
            foreach (string item in items)
            {
                string[] keyValue = item.Split('=');
                if (keyValue.Length > 1)
                {
                    if (!hsDict.ContainsKey(keyValue[0]))
                        hsDict.Add(keyValue[0], float.Parse(keyValue[1]));
                }
            }
        }
        else
        {
            foreach (GameObject song in songs)
            {
                hsDict.Add(song.name, 0.0f);
            }

            CreateString(hsDict);
        }

        Debug.Log($"Dictionary count: {hsDict.Count}");
        if (hsStr.Equals(string.Empty))
        {
            hsStr = CreateString(hsDict);
            Debug.Log($"String generated: {hsStr}");
        }
    }

    public float GetMaxScore(string songName)
    {
        return hsDict[songName];
    }

    public void SetHighScoreToSong(string songName, float score)
    {
        hsStr = PlayerPrefs.GetString("hsStr");
        string[] items = hsStr.TrimEnd(Environment.NewLine.ToCharArray()).Split(Environment.NewLine.ToCharArray());
        foreach (string item in items)
        {
            string[] keyValue = item.Split('=');
            if (keyValue.Length > 1)
            {
                if (!hsDict.ContainsKey(keyValue[0]))
                    hsDict.Add(keyValue[0], float.Parse(keyValue[1]));
            }
        }

        if (score > hsDict[$"Send {songName}"])
            hsDict[$"Send {songName}"] = score;

        Debug.Log($"Dictionary well parsed? {hsDict[$"Send {songName}"]}");

        hsStr = CreateString(hsDict);
        Debug.Log($"After setting score:\n{hsStr}");
        PlayerPrefs.SetString("hsStr", hsStr);
        PlayerPrefs.Save();
    }

    public string CreateString(Dictionary<string, float> dict)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var x in dict)
        {
            sb.Append(x.Key);
            sb.Append('=');
            sb.Append(x.Value);
            sb.Append(Environment.NewLine);
        }

        return sb.ToString();
    }
}
