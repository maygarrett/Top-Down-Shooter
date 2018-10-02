using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    [SerializeField] private Direction _direction;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _cameraTransform;

	// Use this for initialization
	void Start () {
		if(!_camera)
        {
            Debug.LogError("No camera attached to Camera Movement Barrier");
        }
	}
	
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 11)
        {
            switch (_direction)
            {
                // up
                case Direction.Up:
                    _cameraTransform.position = new Vector3(_cameraTransform.position.x, _cameraTransform.position.y + 60, _cameraTransform.position.z);
                    break;
                //down
                case Direction.Down:
                    _cameraTransform.position = new Vector3(_cameraTransform.position.x, _cameraTransform.position.y - 60, _cameraTransform.position.z);
                    break;
                // left
                case Direction.Left:
                    _cameraTransform.position = new Vector3(_cameraTransform.position.x - 115, _cameraTransform.position.y, _cameraTransform.position.z);
                    break;
                // right
                case Direction.Right:
                    _cameraTransform.position = new Vector3(_cameraTransform.position.x + 115, _cameraTransform.position.y, _cameraTransform.position.z);
                    break;
            }
        }
    }
}
