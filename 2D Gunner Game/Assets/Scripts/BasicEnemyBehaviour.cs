using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehaviour : MonoBehaviour {

    // movement variables
    private Rigidbody2D _rb;
    [SerializeField] private float _movementSpeed;
    private bool _movementChangeCoolingDown = false;
    Vector2 movement;

    // player variables
    private GameObject _player;

    // projectile variables
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _gunTransform;
    [SerializeField] private float _projectileSpeed;
    private bool _coolingDown = false;
    [SerializeField] private float _projectileCoolDownTime;

    // health and death variables
    [SerializeField] private int _health;

    // player detection
    private bool _playerFound = false;
    [SerializeField] private float _sightRadius;
    [SerializeField] private LayerMask _playerLayer;

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("player");

        // variable checks
        if(_projectileCoolDownTime <= 0)
        {
            _projectileCoolDownTime = 2;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (_playerFound)
        {
            LookAtPlayer();
            if (_coolingDown)
                return;
            else
            { FireProjectile(); }
        }
        else { SearchForTarget(); }
	}

    private void FixedUpdate()
    {
        if (_playerFound)
        {
            RandomMovement();
        }
    }

    private void RandomMovement()
    {
        _rb.AddForce(movement * _movementSpeed);

        if (_movementChangeCoolingDown)
            return;
        
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Random.Range(-1, 2);

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Random.Range(-1, 2);

        //Use the two store floats to create a new Vector2 variable movement.
        movement = new Vector2(moveHorizontal, moveVertical);



        _movementChangeCoolingDown = true;
        StartCoroutine(MovementCooldown());
    }

    private void LookAtPlayer()
    {
        Vector3 dir = _player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void FireProjectile()
    {
        GameObject newProjectile = Instantiate(_projectile, _gunTransform.position, _gunTransform.rotation);

        Vector3 dir = _player.transform.position - transform.position;
        Vector3 force = dir.normalized * _projectileSpeed;

        newProjectile.GetComponent<Rigidbody2D>().AddForce(force);

        _coolingDown = true;
        StartCoroutine(ProjectileCooldown());
    }

    private IEnumerator ProjectileCooldown()
    {
        yield return new WaitForSeconds(_projectileCoolDownTime);
        _coolingDown = false;
    }

    private IEnumerator MovementCooldown()
    {
        yield return new WaitForSeconds(2);
        _movementChangeCoolingDown = false;
    }

    public int GetHealth()
    {
        return _health;
    }

    public void ProjectileImpact(int damage)
    {
        _health -= damage;

        if(!_playerFound)
        { _playerFound = true; }

        if(_health <= 0)
        {
            // do death behaviour
            Destroy(this.gameObject);
        }
    }

    private void SearchForTarget()
    {
        if(Physics2D.Raycast(transform.position, _player.transform.position - transform.position, _sightRadius, _playerLayer))
        {
            _playerFound = true;
        }
    }
}
