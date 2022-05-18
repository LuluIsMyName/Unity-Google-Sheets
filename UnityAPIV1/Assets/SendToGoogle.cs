using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

//byte[] rawData = form.data;
public class SendToGoogle : MonoBehaviour
{
    [SerializeField] InputField feedback1, feedback2, feedback3, feedback4;
    private string URL =
"https://docs.google.com/forms/u/0/d/e/1FAIpQLSfL9l9kwbm4HAI449qHOgWy-tAF9VnFqmtOtfpV360mJVLhvg/formResponse";

    public void Send() 
    {
        StartCoroutine(Post(feedback1.text, feedback2.text, feedback3.text, feedback4.text)); 

    }

    IEnumerator Post(string score, string timecompleted, string name, string heartrate)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1476023267", score);
        form.AddField("entry.219785088", timecompleted);
        form.AddField("entry.1901248204", name);
        form.AddField("entry.520134128", heartrate);
        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();
    
    }
}
