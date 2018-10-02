using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour {

    [SerializeField] private GameObject _projectile;

    [SerializeField] private Transform _gunTransform;

    [SerializeField] private float _projectileSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Bang Bang");
            FireProjectile();
        }

	}

    private void FireProjectile()
    {
        GameObject newProjectile = Instantiate(_projectile, _gunTransform.position, _gunTransform.rotation);

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        Vector3 force = dir.normalized * _projectileSpeed;

        newProjectile.GetComponent<Rigidbody2D>().AddForce(force);
    }
}
