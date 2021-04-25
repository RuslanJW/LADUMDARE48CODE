using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemys : MonoBehaviour
{

    public Vector2 vector;
    public float speed;

    void FixedUpdate()
    {
        transform.Translate(vector * speed * Time.deltaTime);
    }
}
