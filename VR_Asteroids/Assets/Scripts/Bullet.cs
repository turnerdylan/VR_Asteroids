using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    
    public AudioClip explode;
    public UIController UIC;
    // Start is called before the first frame update
    void Start()
    {
        UIC = FindObjectOfType<UIController>();
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Asteroid"){
            UIC.currentScore += 100;
            AudioSource.PlayClipAtPoint(explode, other.transform.position, 1f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    }
}
