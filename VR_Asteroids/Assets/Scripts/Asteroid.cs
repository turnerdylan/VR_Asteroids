using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Player player;
    Rigidbody rb;
    Vector3 moveDirection;
    public float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        if(GetComponent<Rigidbody>()){
            rb = GetComponent<Rigidbody>();
            Debug.Log("true");
        }

        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
        Debug.Log(moveDirection);
        Debug.Log("-");
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Debug.Log(moveDirection);
        Destroy(gameObject, 10);
    }

}
