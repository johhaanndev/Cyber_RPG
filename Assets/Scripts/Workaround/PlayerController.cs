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
    public GameObject kickCollider;

    [Header("Movement parameters")]
    public float moveForce;

    private bool isAttacking = false;

    private float timerToAttack = 0;
    private float limitTimer = 0.5f;

    private bool isWin = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        moveJoystick = GameObject.Find("MoveJoystick").GetComponent<Joystick>();
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

            if (!isAttacking)
            {
                transform.LookAt(walkingSprite.position);
            }
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
        }

        walkingSprite.position = new Vector3(transform.position.x + hor, transform.position.y, transform.position.z + ver);

        if (Mathf.Abs(attackHor) > 0.25f || Mathf.Abs(attackVer) > 0.25f)
        {
            attackSprite.position = new Vector3(transform.position.x + attackHor, transform.position.y, transform.position.z + attackVer);
        }
        else
        {
            if (timerToAttack >= limitTimer)
            {
                timerToAttack = 0;
                attackSprite.position = walkingSprite.position;
            }
            else
            {
                timerToAttack += Time.deltaTime;
            }
        }

        anim.SetFloat("Speed", rb.velocity.magnitude / moveForce);
    }

    public void EnableAttack()
    {
        transform.LookAt(attackSprite.position);
        anim.SetTrigger("isAttacking");
        isAttacking = true;
    }

    public void DisableAttack()
    {
        isAttacking = false;
    }

    public void EnableSwordCollider()
    {
        kickCollider.SetActive(true);
        Debug.Log("Collider enabled");
    }

    public void DisableSwordCollider()
    {
        kickCollider.SetActive(false);
        Debug.Log("Collider disabled");
    }

    public void SetIsWin(bool win) => isWin = win;

    public bool GetIsWin() => isWin;
}
