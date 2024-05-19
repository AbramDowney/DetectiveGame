using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    
    public float startingTime = 20f;
    public float currentTime;
    public Text countdown;

    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        countdown.text = currentTime.ToString("0");

        if (currentTime <= 0) {
            ResetGame();
        }
    }

    void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
