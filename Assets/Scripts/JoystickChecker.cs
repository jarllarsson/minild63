using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JoystickChecker : MonoBehaviour 
{
    public float joystickCheckerTime = 1.0f;
    private float joystickCheckerTimer = 0.0f;

    private List<string> joysticks = new List<string>();

    public PlayerScript secondPlayerToHideWhenNoController;

	// Use this for initialization
	void Start () {
        updateList();
        updatePlayer();
	}
	
	// Update is called once per frame
	void Update () 
    {
        joystickCheckerTimer += Time.deltaTime;
        if (joystickCheckerTimer>joystickCheckerTime)
        {
            joystickCheckerTimer = 0.0f;
            updateList();
            updatePlayer();
        }
	}

    void updatePlayer()
    {
        if (joysticks.Count > 1 && joysticks[1].Length > 0)
        {
            if (!secondPlayerToHideWhenNoController.isLoggedIn())
            {
                secondPlayerToHideWhenNoController.Login();
            }
        }
        else
        {
            if (secondPlayerToHideWhenNoController.isLoggedIn())
            {
                secondPlayerToHideWhenNoController.Logout();
            }
        }
    }

    void updateList()
    {
        joysticks.Clear();
        joysticks = new List<string>(Input.GetJoystickNames());
    }
}
