using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.UnityConverters;

public class GameSaves : JasonWeimannSingleton.Singleton<GameSaves>
{
    [HideInInspector]
    public SavingData data = new SavingData();

    public void Awake()
    {
        data = data.Load();

    }
    public void Save()
    {
        data.Save();
    }
}

[Serializable]
public class SavingData
{
    public int CurrentLevel { get; set; }
    public Vector2 currentCheckPoint;

    public bool CanAirJump { get; set; }
    public bool CanDash { get; set; }
    public bool CanWallSlide { get; set; }

    public int DeathCount { get; set; }


    public void Save()
    {
        JsonSerializer serializer = new JsonSerializer();
        //serializer.NullValueHandling = NullValueHandling.Ignore;
        serializer.Converters.Add(new Newtonsoft.Json.UnityConverters.Math.Vector2Converter());
        Debug.Log(Application.persistentDataPath + "/MySaveData.txt");

        using (StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/MySaveData.txt"))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, this);
            //serializer.Deserialize<SavingData>(new JsonTextReader(new StringReader(Application.persistentDataPath + "/MySaveData.txt")));
        }
        //serializer.Converters.Add(new json)
    }
    
    public SavingData Load()
    {
        JsonSerializer serializer = new JsonSerializer();
        //serializer.NullValueHandling = NullValueHandling.Ignore;
        serializer.Converters.Add(new Newtonsoft.Json.UnityConverters.Math.Vector2Converter());
        Debug.Log("load");

        using (StringReader sr = new StringReader(File.ReadAllText(Application.persistentDataPath + "/MySaveData.txt")))
        using (JsonTextReader reader = new JsonTextReader(sr))
        {
            return serializer.Deserialize<SavingData>(reader);
        }

    }
    
}
