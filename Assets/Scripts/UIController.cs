using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject welcomeScreen;
    public GameObject inGameUI;
    public GameObject gameOverScreen;
    public Text catLives;
    public Text hoomanSleep;

    public void SetWelcomeScreenActive(bool active)
    {
        welcomeScreen.SetActive(active);
    }
    
    public void SetInGameUIActive(bool active)
    {
        inGameUI.SetActive(active);
    }

    public void SetGameOverActive(bool active)
    {
        gameOverScreen.SetActive(active);
    }

    public void SetCatLives(int lives)
    {
        catLives.text = $"LIVES: {lives}";
    }
    
    public void SetHoomanSleep(int sleep)
    {
        hoomanSleep.text = $"HOOMAN SLEEP: {sleep}";
    }
}
