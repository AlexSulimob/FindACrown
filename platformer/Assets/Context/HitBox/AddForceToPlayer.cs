using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AddForceToPlayer : MonoBehaviour
{
    public Vector2 directionOfAddedPower;

    public float powerOfHit_x = 50f;
    public float powerOfHit_y = 50f;
    Rigidbody2D playersRb;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 dir;
            if (directionOfAddedPower == Vector2.zero)
            {
                dir = other.transform.position - transform.position;//opposite direction to player
                dir = dir.normalized;
            }else
            {
                dir = directionOfAddedPower;
            }

            if (playersRb == null)
                playersRb = other.GetComponent<Rigidbody2D>();

            playersRb.velocity = Vector2.zero;
            playersRb.AddForce(new Vector2(dir.x * powerOfHit_x, dir.y * powerOfHit_y));

        }
    }
}
