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

    [Header("Camera Move Distances")]
    [SerializeField] private float _upDownDistance;
    [SerializeField] private float _leftRightDistance;

	// Use this for initialization
	void Start () {
		if(!_camera)
        {
            Debug.LogError("No camera attached to Camera Movement Barrier");
        }

        if(_upDownDistance == 0)
        {
            _upDownDistance = 60;
        }
        if(_leftRightDistance == 0)
        {
            _leftRightDistance = 104;
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
                    _cameraTransform.position = new Vector3(_cameraTransform.position.x, _cameraTransform.position.y + _upDownDistance, _cameraTransform.position.z);
                    break;
                //down
                case Direction.Down:
                    _cameraTransform.position = new Vector3(_cameraTransform.position.x, _cameraTransform.position.y - _upDownDistance, _cameraTransform.position.z);
                    break;
                // left
                case Direction.Left:
                    _cameraTransform.position = new Vector3(_cameraTransform.position.x - _leftRightDistance, _cameraTransform.position.y, _cameraTransform.position.z);
                    break;
                // right
                case Direction.Right:
                    _cameraTransform.position = new Vector3(_cameraTransform.position.x + _leftRightDistance, _cameraTransform.position.y, _cameraTransform.position.z);
                    break;
            }
        }
    }
}
