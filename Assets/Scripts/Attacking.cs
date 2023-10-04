using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [Range(0f,10f)]
    public float damageAmount = 8f;

    private void OnCollisionEnter(Collision collision) {
        //debug
        Debug.Log("ENTERED COLLISION: " + collision.gameObject.tag);


        //check tags
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("troop")) {
            

            //try to get the 'Life' component from the collided object.
            life enemyLife = collision.gameObject.GetComponent<life>();

            //catch missing componenet error
            if (enemyLife != null) {                
                // Call the 'takeDamage' function on the 'Life' component with the specified damage.
                enemyLife.takeDamage(damageAmount);
            }
            else {
                Debug.LogWarning("Fucky Wucky Made: No 'Life' component found on the enemy.");
            }
        }
    }
}
