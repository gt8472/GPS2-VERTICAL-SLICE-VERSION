using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public bool isActivatedDoor = false;
    public float startTimer = 0;
    public float chargedTimer = 0;
    public float chargeOverTime = 1.0f;

    [Header("Unity Stuff")]

    public Image chargeBar;
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
            chargeBar.fillAmount = chargedTimer / startTimer;
            if(chargedTimer >= 100)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
            }
        }
        isActivatedDoor = false;
        
    }

    public void ActivateDoor()
    {
        isActivatedDoor = true;
    }
}
