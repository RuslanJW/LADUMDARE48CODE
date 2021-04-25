using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScene : MonoBehaviour
{
    public Vector2 dir;
    public float speed;

    void FixedUpdate()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
