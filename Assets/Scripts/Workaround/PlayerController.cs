using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // elemental components
    private Rigidbody rb;
    private Animator anim;

    [Header("Scene references")]
    [SerializeField]
    private Joystick moveJoystick;
    [SerializeField]
    private Joystick attackJoystick;
    public Transform walkingSprite;
    public Transform attackSprite;

    [Header("Movement parameters")]
    public float moveForce;

    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        moveJoystick = GameObject.Find("MovementJoystick").GetComponent<Joystick>();
        attackJoystick = GameObject.Find("AttackJoystick").GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var hor = moveJoystick.Horizontal;
        var ver = moveJoystick.Vertical;

        var attackHor = attackJoystick.Horizontal;
        var attackVer = attackJoystick.Vertical;

        if (Mathf.Abs(hor) > 0.05f || Mathf.Abs(ver) > 0.05f)
        {
            rb.velocity = new Vector3(hor * moveForce, 0f, ver * moveForce);

            transform.LookAt(walkingSprite.position);
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
        }

        walkingSprite.position = new Vector3(transform.position.x + hor, transform.position.y, transform.position.z + ver);

        if (Mathf.Abs(attackHor) > 0.25f || Mathf.Abs(attackVer) > 0.25f)
            attackSprite.position = new Vector3(transform.position.x + attackHor, transform.position.y, transform.position.z + attackVer);
        else
            attackSprite.position = walkingSprite.position;

        anim.SetFloat("Speed", rb.velocity.magnitude / moveForce);
        Debug.Log(isAttacking);
    }

    public void Attack()
    {
        isAttacking = true;
        Invoke(nameof(StopAttacking), 1.0f);
    }

    public void StopAttacking()
    {
        isAttacking = false;
    }
}
