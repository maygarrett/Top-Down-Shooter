using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileImpact : MonoBehaviour {

    [SerializeField] private GameObject _impactParticles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.layer == 10 && collision.gameObject.tag == "enemy")
        {
            BasicEnemyBehaviour enemy = collision.gameObject.GetComponent<BasicEnemyBehaviour>();
            enemy.ProjectileImpact(1);
            Instantiate(_impactParticles, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.layer == 11 && collision.gameObject.tag == "player")
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.ProjectileImpact(1);
            Instantiate(_impactParticles, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
