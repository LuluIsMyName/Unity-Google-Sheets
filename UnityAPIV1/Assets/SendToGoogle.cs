using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

//byte[] rawData = form.data;
public class SendToGoogle : MonoBehaviour
{
    [SerializeField] TMP_InputField feedback1, feedback2, feedback3, feedback4;
    private string URL =
"https://docs.google.com/forms/u/0/d/e/1FAIpQLSc4S_OWM1NnzXDIc6wW24rlWbOfZiLpj499GDoXE43Spqne0g/formResponse";

    public void Send() 
    {
        StartCoroutine(Post(feedback1.text, feedback2.text, feedback3.text, feedback4.text)); 

    }

    IEnumerator Post(string score, string timecompleted, string name, string heartrate)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1612856189", score);
        form.AddField("entry.1704271813", timecompleted);
        form.AddField("entry.420973508", name);
        form.AddField("entry.176062768", heartrate);
        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();
    
    }
}
