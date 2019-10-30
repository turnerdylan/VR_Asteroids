using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public AudioClip explode;
    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(explode, other.transform.position, 0.7f);
        Destroy(other.gameObject);
    }
}
