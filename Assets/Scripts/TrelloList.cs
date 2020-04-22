using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TrelloList : MonoBehaviour
{
    public Transform content;
    public TextMeshProUGUI title;
    public VerticalLayoutGroup verticalLayoutGroup;
    public ContentSizeFitter contentSizeFitter;
    public List<Transform> cards;
}
