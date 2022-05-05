using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MidSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text place, date, time;
    public string placeStr, dateStr, timeStr;
    void Start()
    {
        place.text = "";
        date.text = "";
        time.text = "";
        StartCoroutine(Next());
    }

    IEnumerator Next()
    {
        StartCoroutine(Typing());
        float waitingtime;
        waitingtime = placeStr.Length + dateStr.Length + timeStr.Length;
        waitingtime *= 0.06f;
        waitingtime += 4f;
        yield return new WaitForSeconds(waitingtime);
        if (SceneManager.GetActiveScene().buildIndex >= 7)
        {
            Application.Quit();
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Typing()
    {
        foreach (char letter in placeStr)
        {
            place.text += letter;
            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(0.5f);

        foreach (char letter in dateStr)
        {
            date.text += letter;
            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(0.5f);

        foreach (char letter in timeStr)
        {
            time.text += letter;
            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(1f);

        string[] temp;
        temp = timeStr.Split(':');
        temp[2] = (int.Parse(temp[2]) + 1).ToString();
        time.text = "";
        time.text = temp[0] + ":" + temp[1] + ":" + temp[2];

        yield return new WaitForSeconds(1f);
        temp[2] = (int.Parse(temp[2]) + 1).ToString();
        time.text = "";
        time.text = temp[0] + ":" + temp[1] + ":" + temp[2];
    }
}
