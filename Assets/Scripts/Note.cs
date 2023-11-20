using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;
    public Transform spawn;
    public Transform goal;
    public float beatOfThisNote;

    [HideInInspector] public Player player;

    void Start()
    {
        speed = beatOfThisNote - beatOfThisNote + 4;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
            player.health -= 10;
            player.combo = 0;
        }
    }
}
