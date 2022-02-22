using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private CharacterAttack attackScript;
    private CharacterHealth healthScript;

    public GameObject kickCollider;

    public Joystick moveJoystick;

    [SerializeField]
    private Transform playerSprite;
    [SerializeField]
    private Transform basicPointSprite;
    [SerializeField]
    private Transform dashPointSprite;

    public float moveForce;
    public float dashForce;

    private bool isWin;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        attackScript = GetComponent<CharacterAttack>();
        healthScript = GetComponent<CharacterHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!healthScript.GetIsDead() && !isWin)
        {
            Debug.Log($"is character attacking? {attackScript.GetIsAttacking()}");
            if (!GetComponent<CharacterAttack>().GetIsDashing())
            {
                Movement();
            }
            else
            {
                Dash();
            }
            //anim.SetFloat("Speed", rb.velocity.magnitude / moveForce);
        }
    }

    private void Movement()
    {
        var hor = moveJoystick.Horizontal;
        var ver = moveJoystick.Vertical;

        playerSprite.position = new Vector3(hor + transform.position.x, transform.position.y, ver + transform.position.z);

            if (Mathf.Abs(hor) > 0.05f || Mathf.Abs(ver) > 0.05f)
            {
                rb.velocity = new Vector3(hor * moveForce, 0f, ver * moveForce);
                if (attackScript.GetIsAttacking())
                {
                    //Debug.Log("Player is attacking");
                    transform.LookAt(new Vector3(basicPointSprite.position.x, 0, basicPointSprite.position.z));
                    transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
                }
                else
                {
                Debug.Log("It should not be attacking");
                    transform.LookAt(new Vector3(playerSprite.position.x, 0f, playerSprite.position.z));
                }
                transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
            }
            else
            {
                if (attackScript.GetIsAttacking())
                {
                    //Debug.Log("Player is attacking");
                    transform.LookAt(new Vector3(basicPointSprite.position.x, 0, basicPointSprite.position.z));
                    transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
                }
            }
        anim.SetFloat("Speed", rb.velocity.magnitude / moveForce);
    }

    private void Dash()
    {
        var x = dashPointSprite.position.x - transform.position.x;
        var z = dashPointSprite.position.z - transform.position.z;
        transform.LookAt(new Vector3(dashPointSprite.position.x, 0, dashPointSprite.position.z));
        rb.AddForce(new Vector3(x, 0, z) * dashForce, ForceMode.Impulse);
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
    }

    public void EnableSwordCollider()
    {
        kickCollider.SetActive(true);
    }

    public void DisableSwordCollider()
    {
        kickCollider.SetActive(false);
    }

    // ******************* GETTER & SETTER *******************
    public void SetIsWin(bool win) => isWin = win;

    public bool GetIsWin() => isWin;
    // ***************** GETTER & SETTER END *****************
}
