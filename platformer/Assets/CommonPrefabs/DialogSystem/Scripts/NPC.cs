using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using JasonWeimannSingleton;

public class NPC : MonoBehaviour
{
    public string nameNpc = "";
    public string talkToNode = "";
    public YarnProgram scriptToLoad;

    void Start()
    {        
        if (Singleton<DialogRunnerSingleton>.Instance.dialogRunner != null)
        {
            Singleton<DialogRunnerSingleton>.Instance.dialogRunner.Add(scriptToLoad);
        } 
        
    } 

    public void StartDialog()
    {
        Singleton<DialogRunnerSingleton>.Instance.dialogRunner.StartDialogue(talkToNode);
    }

}
