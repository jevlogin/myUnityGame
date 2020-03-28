using UnityEngine;


public class CameraFollowPlayer : MonoBehaviour
{
    private float _damping = 2.5f;
    private Vector2 _offset = new Vector2(3f, 4f);
    [SerializeField] public bool _isFaceLeft;
    private Transform _player;
    private int _lastX;

    #region UnityMethods
    void Start()
    {
        _offset = new Vector2(Mathf.Abs(_offset.x), _offset.y);
        FindPlayer(_isFaceLeft);
    }

    void Update()
    {
        if (_player)
        {
            int currentX = Mathf.RoundToInt(_player.position.x);
            if (currentX > _lastX) _isFaceLeft = false; else if (currentX < _lastX) _isFaceLeft = true;
            _lastX = Mathf.RoundToInt(_player.position.x);

            Vector3 target;
            if (_isFaceLeft)
            {
                _player.localScale = new Vector3(-1, 1, 1);
                target = new Vector3(_player.position.x - _offset.x, _player.position.y + _offset.y, transform.position.z);
            }
            else
            {
                _player.localScale = new Vector3(1, 1, 1);
                target = new Vector3(_player.position.x + _offset.x, _player.position.y + _offset.y, transform.position.z);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, _damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
    #endregion


    private void FindPlayer(bool faceLeft)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _lastX = Mathf.RoundToInt(_player.position.x);
        if (faceLeft)
        {
            transform.position = new Vector3(_player.position.x - _offset.x, _player.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(_player.position.x + _offset.x, _player.position.y, transform.position.z);
        }
    }

}
