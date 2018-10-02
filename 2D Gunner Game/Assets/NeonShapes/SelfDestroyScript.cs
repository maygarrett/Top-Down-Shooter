using UnityEngine;
using System.Collections;

public class SelfDestroyScript : MonoBehaviour 
{
    [SerializeField] private ParticleSystem _particles;
	
	void Start () 
	{
		Destroy (gameObject, _particles.main.startLifetime.constant);
	}
}
