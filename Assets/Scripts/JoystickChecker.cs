using UnityEngine;
using System.Collections;

public class JoystickChecker : MonoBehaviour 
{
    public float joystickCheckerTime = 1.0f;
    private float joystickCheckerTimer = 0.0f;

    private string[] joysticks;

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
        if (joysticks.Length > 1 && joysticks[1].Length > 0)
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
        joysticks = null;
        joysticks = Input.GetJoystickNames();
    }
}
