using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrelloCard : MonoBehaviour
{
    [Header("Labels")]
    public GameObject label1;
    public GameObject label2;
    public GameObject label3;
    public GameObject label4;
    public GameObject label5;
    public List<GameObject> labels = new List<GameObject>();

    [Header("LabelColours")]
    public Image colour1;
    public Image colour2;
    public Image colour3;
    public Image colour4;
    public Image colour5;
    public List<Image> colours = new List<Image>();

    [Header("Text")]
    public TextMeshProUGUI title;

    [Header("Members")]
    public GameObject member1;
    public GameObject member2;
    public GameObject member3;
    public GameObject member4;
    public GameObject member5;
    public List<GameObject> members = new List<GameObject>();

    [Header("MemberNames")]
    public TextMeshProUGUI name1;
    public TextMeshProUGUI name2;
    public TextMeshProUGUI name3;
    public TextMeshProUGUI name4;
    public TextMeshProUGUI name5;
    public List<TextMeshProUGUI> names = new List<TextMeshProUGUI>();

    private void Awake()
    {
        labels.Add(label1);
        labels.Add(label2);
        labels.Add(label3);
        labels.Add(label4);
        labels.Add(label5);

        colours.Add(colour1);
        colours.Add(colour2);
        colours.Add(colour3);
        colours.Add(colour4);
        colours.Add(colour5);

        members.Add(member1);
        members.Add(member2);
        members.Add(member3);
        members.Add(member4);
        members.Add(member5);

        names.Add(name1);
        names.Add(name2);
        names.Add(name3);
        names.Add(name4);
        names.Add(name5);
    }
}
