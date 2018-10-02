using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    // health and death variables
    [SerializeField] private int _health;

    public int GetHealth()
    {
        return _health;
    }

    public void ProjectileImpact(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            // do death behaviour
            Destroy(this.gameObject);
        }
    }
}
