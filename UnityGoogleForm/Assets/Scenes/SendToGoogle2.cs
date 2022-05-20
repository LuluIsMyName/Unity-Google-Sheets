using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject heart_rate;
    public GameObject name;
    public GameObject time_completed;
    public GameObject score;

    private string HeartRate;
    private string Name ;
    private string TimeCompleted;
    private string Score; 

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfL9l9kwbm4HAI449qHOgWy-tAF9VnFqmtOtfpV360mJVLhvg/formResponse";

    IEnumerator Post(string heartrate, string name, string timecompleted, string score) {
        WWWForm form = new WWWForm();
        form.AddField("entry.1476023267",heartrate);
        form.AddField("entry.219785088",name);
        form.AddField("entry.1901248204",timecompleted);
        form.AddField("entry.520134128",score);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www; 
    }
    public void Send() {
        HeartRate = heart_rate.GetComponent<InputField>().text;
        Name = name.GetComponent<InputField>().text;
        TimeCompleted = time_completed.GetComponent<InputField>().text;
        Score = score.GetComponent<InputField>().text;

        StartCoroutine(Post(HeartRate, Name, TimeCompleted, Score));
    }

}
