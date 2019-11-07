using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool isActivatedDoor = false;
    public float startTimer = 0;
    public float chargedTimer = 0;
    public float chargeOverTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        chargedTimer = startTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActivatedDoor)
        {
            chargedTimer += chargeOverTime * Time.deltaTime;
            if(chargedTimer >= 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        isActivatedDoor = false;
        
    }

    public void ActivateDoor()
    {
        isActivatedDoor = true;
    }
}
