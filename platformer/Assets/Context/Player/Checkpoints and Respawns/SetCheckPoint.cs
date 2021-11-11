using PlaytformerPlayersActions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SetCheckPoint : MonoBehaviour
{
    public Vector2 respawnPoint;
    Player player;

    public void Start()
    {
        respawnPoint += (Vector2)transform.position;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (player == null)
                player = other.GetComponent<Player>();


            JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.currentCheckPoint = respawnPoint;
            JasonWeimannSingleton.Singleton<GameSaves>.Instance.Save();
        }
    }

    private void OnDrawGizmos()
    {

        Gizmos.DrawWireSphere(respawnPoint + (Vector2)transform.position, 0.5f);

    }
}
