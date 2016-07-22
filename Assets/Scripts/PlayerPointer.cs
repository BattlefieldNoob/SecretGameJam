using UnityEngine;
using System.Collections;

public class PlayerPointer : MonoBehaviour
{
    public bool joyConnected = false;
    public GameObject player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetJoystickNames().Length > 0 && Input.GetJoystickNames()[0] != "")
        {
            joyConnected = true;
        }
        else
            joyConnected = false;
        transform.position = player.transform.position;
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

        mouse_pos.x = mouse_pos.x - player_pos.x;
        mouse_pos.y = mouse_pos.y - player_pos.y;
        if (joyConnected)
        {
            if (Input.GetAxis("JoyRightY") != 0 || Input.GetAxis("JoyRightX") != 0)
            {
                float angle = -Mathf.Atan2(Input.GetAxis("JoyRightY"), Input.GetAxis("JoyRightX")) * Mathf.Rad2Deg;
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
        else
        {
            float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
