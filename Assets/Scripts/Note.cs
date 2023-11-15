using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;
    [Header("AudioStuff")]
    public float beatOfThisNote;

    void Start()
    {
        speed = beatOfThisNote - beatOfThisNote + 4;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if(transform.position.y <= -10) Destroy(gameObject);
    }
}
