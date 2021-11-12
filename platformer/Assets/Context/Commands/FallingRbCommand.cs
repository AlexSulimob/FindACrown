using CommandPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingRbCommand : Command
{
    Rigidbody2D rb;
    Animator animator;
    public float fallingSpeed = 20f;
    public float waitTimeToFall = 1f;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public override void Execute()
    {
        StartCoroutine("Fall");
        animator.SetBool("StartFalling", true);
    }

    public override void Undo()
    {

    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(waitTimeToFall);
        for (int i = 0; i < 2000; i++)
        {
            rb.MovePosition((Vector2)transform.position + (Vector2.down * fallingSpeed * Time.fixedDeltaTime));
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }
}
