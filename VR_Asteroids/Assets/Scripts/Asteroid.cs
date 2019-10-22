using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Player player;
    Rigidbody rb;
    Vector3 moveDirection;

    Vector3 rotation;
    public float moveSpeed = 10f;
    Vector3 scale;
    float scaleMod;

    AsteroidSpawner AS;
    // Start is called before the first frame update
    void Start()
    {
        scaleMod = Random.Range(200, 800);
        player = FindObjectOfType<Player>();
        if(GetComponent<Rigidbody>()){
            rb = GetComponent<Rigidbody>();
            Debug.Log("true");
        }

        scale = new Vector3(scaleMod, scaleMod, scaleMod);
        transform.localScale = scale;
        //rotation = new Vector3(Random.Range(0, 10),Random.Range(0, 10),Random.Range(0, 10));


        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
        Debug.Log(moveDirection);
        Debug.Log("-");
        //rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Debug.Log(moveDirection);
        AS.objectCount--;
        Destroy(gameObject, 10);

    }

    void Update(){
        //transform.Rotate(rotation);
        transform.Translate(moveDirection* Time.deltaTime);
    }

}
