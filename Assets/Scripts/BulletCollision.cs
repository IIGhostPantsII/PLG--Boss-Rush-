using System.Collections;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            return;
        }
        
        Destroy(gameObject);
    }
}
