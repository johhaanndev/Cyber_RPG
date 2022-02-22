using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{
    public Transform player;

    public Joystick pointJoystick;
    public Transform spritePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        var hor = pointJoystick.Horizontal;
        var ver = pointJoystick.Vertical;
        if (gameObject.name.Equals("BasicPointingSprite"))
        {
            hor *= -1;
            ver *= -1;
        }

        if (Mathf.Abs(hor) > 0.5f || Mathf.Abs(ver) > 0.5f)
        {
            spritePosition.position = new Vector3(hor + transform.position.x, 0.6f, ver + transform.position.z);
        }
    }
}
