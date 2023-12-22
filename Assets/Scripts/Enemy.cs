using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private Vector2 endPos;

    private Vector2 startPos;
    private float alpha;
    private float speed = 0.5f; // 0 to 1
    private int direction = 1;

    private void Awake()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        alpha = Mathf.Clamp01(alpha + Time.deltaTime * direction * speed);

        if (alpha == 1)
        {
            direction = -1;
            speed = Random.Range(0.4f, 1.0f);
        }
        else if (alpha == 0)
        {
            direction = 1;
            speed = Random.Range(0.4f, 1.0f);
        }

        transform.position = Vector2.Lerp(startPos, endPos, alpha);
    }

}
