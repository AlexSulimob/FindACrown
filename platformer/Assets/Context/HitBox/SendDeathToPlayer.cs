using PlaytformerPlayersActions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SendDeathToPlayer : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Death();
        }
    }
}
