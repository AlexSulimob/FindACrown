using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRbObject : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2[] anchorsPoints;

    public bool isPingPong = true;

    public float speed = 5f;
    public float min_distance = 0.1f;

    int _currentPoint = 0;
    bool _Up = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < anchorsPoints.Length; i++)
        {
            anchorsPoints[i] += (Vector2)transform.position;
        }
    }

    void FixedUpdate()
    {
        MoveToPoint(anchorsPoints[_currentPoint]);
    }

    void MoveToPoint(Vector2 PointToMove)
    {
        if (Vector2.Distance(PointToMove, transform.position) >= min_distance)
        {
            var dir = PointToMove - (Vector2)transform.position;
            rb.MovePosition(new Vector3(transform.position.x + speed * dir.normalized.x * Time.fixedDeltaTime
                ,transform.position.y + speed * dir.normalized.y * Time.fixedDeltaTime));

        }
        else
        {
            if (isPingPong)
            {
                ChangePointPingPong();
            }
            else
            {
                ChangeCycle();
            }

        }
    }

    private void ChangePointPingPong()
    {
        if (_currentPoint < anchorsPoints.Length - 1 && _Up)
        {
            _currentPoint++;
        }
        else
        {
            if (_currentPoint != 0)
            {
                _currentPoint--;
                _Up = false;
            }
            else
            {
                _Up = true;
            }

        }

    }
    private void ChangeCycle()
    {
        if (_currentPoint < anchorsPoints.Length - 1)
        {
            _currentPoint++;
        }
        else
        {
            _currentPoint = 0;
        }

    }
    private void OnDrawGizmos()
    {
        foreach (var item in anchorsPoints)
        {
            Gizmos.DrawWireSphere(item + (Vector2)transform.position, 0.5f);
            Gizmos.DrawWireSphere(item + (Vector2)transform.position, 0.5f);
        }

    }
}
