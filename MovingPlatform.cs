using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float PlatformSpeed;
    public int StartPoint;
    public Transform[] points;

    private int i;

    private void Start()
    {
        transform.position = points[StartPoint].position;

    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) <0.1f)
        {
            i++;

            if(i == points.Length)
            {
                i = 0;

            }
            
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, PlatformSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}

