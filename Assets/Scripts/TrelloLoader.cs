using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrelloLoader : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public Button display;
    public TrelloConnector trelloConnector;

    private Card[] cards;
    private List[] lists;
    private Label[] labels;
    private Member[] members;

    public GameObject trelloList;
    public GameObject trelloCard;

    private void Start()
    {
        trelloConnector.Load();
    }

    public void PopulateForm()
    {
        cards = trelloConnector.cards;
        lists = trelloConnector.lists;
        labels = trelloConnector.labels;
        members = trelloConnector.members;

        foreach (List l in lists)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = l.name });
        }
    }

    public void ViewList()
    {
        string listName = dropdown.options[dropdown.value].text;
        List list = new List();

        foreach (List l in lists)
        {
            if (listName == l.name)
            {
                list = l;
                break;
            }
        }

        GameObject listObj = Instantiate(trelloList, new Vector3(0, 0, 2), Quaternion.identity);

        TrelloList listVariables = listObj.GetComponent<TrelloList>();
        listVariables.title.text = list.name;

        foreach (Card c in cards)
        {
            if (c.idList == list.id)
            {
                GameObject cardObj = Instantiate(trelloCard, listVariables.content);
                TrelloCard cardVariables = cardObj.GetComponent<TrelloCard>();
                
                // Labels
                // if 1 or more labels exist
                if (c.idLabels.Count != 0)
                {
                    int labelCount = 0;
                    // match idLabel with the label id in labels
                    foreach (string idLabel in c.idLabels)
                    {
                        foreach (Label l in labels)
                        {
                            if (l.id == idLabel)
                            {
                                Color labelColour = new Color(0, 1, 1);
                                if (ColorUtility.TryParseHtmlString(l.color, out labelColour))
                                {
                                    cardVariables.colours[labelCount].color = labelColour;
                                }
                                cardVariables.labels[labelCount].SetActive(true);
                                break;
                            }
                        }

                        // only 5 labels are currently supported
                        if (labelCount == 4)
                        {
                            break;
                        }

                        labelCount++;
                    }
                }

                // Title
                cardVariables.title.text = c.name;

                // Members
                if (c.idMembers.Count != 0)
                {
                    int memberCount = 0;

                    foreach (string idMember in c.idMembers)
                    {
                        foreach (Member m in members)
                        {
                            if (m.id == idMember)
                            {
                                //Debug.Log(m.fullName);
                                //Debug.Log(memberCount);
                                //Debug.Log(cardVariables.names[memberCount].text);
                                string[] initials = m.fullName.Split(' ');
                                foreach (string s in initials)
                                {
                                    cardVariables.names[memberCount].text += s.Substring(0, 1).ToUpper();
                                }
                                cardVariables.members[memberCount].SetActive(true);
                                break;
                            }
                        }

                        if (memberCount == 4)
                        {
                            break;
                        }

                        memberCount++;
                    }
                }
            }
        }
    }
}
