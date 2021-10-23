using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JasonWeimannSingleton;
using Yarn.Unity;

public class DialogRunnerSingleton : Singleton<DialogRunnerSingleton>
{
    public DialogueRunner dialogRunner { get; private set; }
    public void Start()
    {
        dialogRunner = GetComponent<DialogueRunner>();
    }
}
