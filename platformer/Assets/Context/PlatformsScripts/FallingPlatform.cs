using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    public float fallingSpeed = 20f;
    public float waitTimeToFall = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Fall");
            //collision.collider.transform.SetParent(transform);       
        }
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
