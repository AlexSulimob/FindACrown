using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DialogMover : MonoBehaviour
{
    NPC[] NPCs;
    public DialogUICustom dialogUICustom;
    public Canvas MovableBubble;

    void Start()
    {
        NPCs = FindObjectsOfType<NPC>();
        
    }

    public void SetDialogueOnTalkingCharacter()
    {
        string currentName = dialogUICustom.CurrentName;
        if (NPCs.Length != 0)
        {
            NPC npcObject = NPCs.Where(n => n.nameNpc == currentName).ToArray<NPC>()[0];

            MovableBubble.transform.position = npcObject.transform.position;

        }
        else
        {
            Debug.LogError("scene doesnt have npc");
        }

    }
}
