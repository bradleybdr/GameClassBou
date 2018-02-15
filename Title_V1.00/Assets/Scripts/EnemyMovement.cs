using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float range;
    public GameObject Player;
    public float speed;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Vector2.Distance(Player.transform.position, transform.position) <= range)
        {
            //transform.Translate(Vector2.MoveTowards(transform.position, -Player.position, 0) * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, step);
        }
    }
}
