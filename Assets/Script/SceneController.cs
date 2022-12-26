using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject Window;
    public Text Title;
    private bool isActive = true;
    public static int time = 0;
    void Start()
    {
        PlayerData.Clear();
        Window.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if(PlayerData.GetKills() == 5)
        {
            Window.SetActive(true);
            Time.timeScale = 0;
            isActive= false;
            StopCoroutine(timer());
            Title.text = $"Вы победили!\nВаше время: {TimeConverter(time)}";
        }
        else if(isActive)
        {
            StartCoroutine(timer());
        }
    }
    private IEnumerator timer()
    {
        isActive = false;
        yield return new WaitForSeconds(1);
        StopCoroutine(timer());
        time++;
        isActive = true;
    }
    private string TimeConverter(int timeInSeconds)
    {
        return $"{time/60}:{time%60}";
    }
}
