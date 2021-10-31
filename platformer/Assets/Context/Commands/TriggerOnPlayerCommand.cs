using CommandPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnPlayerCommand : MonoBehaviour
{
    public Command executeCommand;
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            executeCommand.Execute();
        }
    }
}
