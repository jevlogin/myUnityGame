using UnityEngine;


public class MFS : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    [SerializeField] private float _jumpHeigth;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform StartBullet;

    #region UnityMethods
    private void Start()
    {

    }

    private void Update()
    {
        var inputSpeed = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        var velocity = transform.right * inputSpeed;
        transform.position += velocity;

        var inputJump = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        var jumping = transform.up * inputJump * _jumpHeigth;
        transform.position += jumping;

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    #endregion

    public void Hurt(int damage)
    {
        _health -= damage;
    }

    private void Fire()
    {
        Instantiate(Bullet, StartBullet.position, StartBullet.rotation);
    }
}
