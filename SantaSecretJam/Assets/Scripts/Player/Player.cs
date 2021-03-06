using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;

    private float initialSpeed;
    private bool _isRunning;
    private bool _canWalk;

    private Vector2 _direction;

    public bool IsRunning { get => _isRunning; set => _isRunning = value; }
    public bool CanWalk { get => _canWalk; set => _canWalk = value; }

    public Vector2 Direction { get => _direction; set => _direction = value; }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        _canWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        OnInput();
        OnRun();
    }
    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));    
    }

    void OnMove()
    {
        if (_canWalk)
        {
            rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
        }
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    #endregion
}
