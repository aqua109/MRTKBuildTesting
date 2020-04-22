using UnityEngine;
using Newtonsoft.Json;
using System.Threading.Tasks;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using System;

public class TrelloManager : MonoBehaviour
{
    public string key;
    public string token;
    public string board_id;

    public Card[] cards;
    public Member[] members;
    public List[] lists;
    public Label[] labels;

    public TrelloLoader trelloLoader;


    public void Load()
    {
        StartCoroutine(CallTrelloAPI());
    }

    public IEnumerator CallTrelloAPI()
    {
        yield return StartCoroutine(GetJson(GetUrl("cards"), json =>
        {
            cards = JsonConvert.DeserializeObject<Card[]>(json);
        }));

        yield return StartCoroutine(GetJson(GetUrl("members"), json =>
        {
            members = JsonConvert.DeserializeObject<Member[]>(json);
        }));

        yield return StartCoroutine(GetJson(GetUrl("lists"), json =>
        {
            lists = JsonConvert.DeserializeObject<List[]>(json);
        }));

        yield return StartCoroutine(GetJson(GetUrl("labels"), json =>
        {
            labels = JsonConvert.DeserializeObject<Label[]>(json);
        }));

        trelloLoader.PopulateForm();
    }


    public IEnumerator GetJson(string url, System.Action<string> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                callback(webRequest.downloadHandler.text);
            }
        }
    }

    public string GetUrl(string resource)
    {
        return $"https://api.trello.com/1/boards/{board_id}/{resource}?key={key}&token={token}";
    }
}
