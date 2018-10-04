using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehaviour : MonoBehaviour {

    [SerializeField] private GameObject _destructionParticles;
    private SpriteRenderer _renderer;

    private GameObject _explosion;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            // start destruction behaviour
            StartCoroutine(DestroySelf(_destructionParticles.GetComponentInChildren<ParticleSystem>().main.duration));
            // instantiate particles
            _explosion = Instantiate(_destructionParticles, transform.position, transform.rotation);
            // turn off renderer for crate
            _renderer.enabled = false;
            // turn off collider for crate
            if(GetComponent<BoxCollider2D>())
            { GetComponent<BoxCollider2D>().enabled = false; }
        }
    }

    private IEnumerator DestroySelf(float delay)
    {
        yield return new WaitForSeconds(delay - 0.01f);
        Destroy(_explosion);
        Destroy(this.gameObject);
    }
}
