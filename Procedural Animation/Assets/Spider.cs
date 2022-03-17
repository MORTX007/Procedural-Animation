using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public float speed = 1f;
    public ProceduralAnimation[] legs;
    public Transform capsule;

    public bool legs1Move;
    public bool legs2Move;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, capsule.position, speed * Time.deltaTime);

        if (legs[1].grounded && legs[2].grounded)
        {
            legs[0].canMove = true;
            legs[3].canMove = true;
        }

        else if (legs[0].grounded && legs[3].grounded)
        {
            legs[1].canMove = true;
            legs[2].canMove = true;
        }
    }
}
