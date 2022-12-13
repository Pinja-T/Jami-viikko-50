using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class myTimer : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 5;
    public bool takingAway = false;
    private GameObject Player;

    // Start is called before the first frame update
    private void Start()
    {
        textDisplay.GetComponent<Text>().text = "0" + secondsLeft;
    }

    // Update is called once per frame
    private void Update()
    {
        if (takingAway == false && secondsLeft >= 0)
        {
            StartCoroutine(TimerTake());
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft += 1;
        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "" + secondsLeft;
        }
        takingAway = false;

        if (secondsLeft >= 120)
        {
            TimeIsUp();
        }
    }

    private void TimeIsUp()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Destroy(Player);

        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
        GetComponent<PlayerMovement>().enabled = false;
    }
}

