using Microsoft.MixedReality.Toolkit.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrelloLoader : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public Button display;
    public TrelloManager trelloManager;

    private Card[] cards;
    private List[] lists;
    private Label[] labels;
    private Member[] members;

    public GameObject trelloBoard;
    public GameObject trelloList;
    public GameObject trelloCard;

    private GameObject boardObj;

    private void Start()
    {
        trelloManager.Load();
    }

    public void PopulateForm()
    {
        cards = trelloManager.cards;
        lists = trelloManager.lists;
        labels = trelloManager.labels;
        members = trelloManager.members;
    }

    public void CreateTrelloBoard()
    {
        boardObj = Instantiate(trelloBoard, new Vector3(0, 0, 2), Quaternion.identity);

        GridObjectCollection boardOrganiser = boardObj.GetComponent<GridObjectCollection>();

        Dictionary<string, List<string>> isListEmpty = new Dictionary<string, List<string>>();

        foreach (List list in lists)
        {
            isListEmpty.Add(list.id, new List<string>());
        }

        foreach (Card card in cards)
        {
            isListEmpty[card.idList].Add(card.id);
        }

        int count = 0;
        try
        {
            foreach (KeyValuePair<string, List<string>> kvp in isListEmpty)
            {
                if (kvp.Value.Count != 0)
                {
                    foreach (List list in lists)
                    {
                        if (list.id == kvp.Key)
                        {
                            StartCoroutine(CreateList(list, boardObj.transform));
                            break;
                        }
                    }

                    count++;
                }
            }
        }
        catch (MissingReferenceException)
        {
            Debug.Log("TrelloBoard was destroyed before instantiation was complete");
        }

        boardOrganiser.Radius = (float)((count * 2) / (2 * Math.PI));
        boardOrganiser.UpdateCollection();
    }

    private IEnumerator CreateList(List list, Transform board)
    {
        GameObject listObj = Instantiate(trelloList, board);

        TrelloList listVariables = listObj.GetComponent<TrelloList>();
        listVariables.title.text = list.name;

        foreach (Card c in cards)
        {
            if (c.idList == list.id)
            {
                yield return null;
                GameObject cardObj = Instantiate(trelloCard, listVariables.content);

                yield return null;
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

                listVariables.cards.Add(cardObj.transform);
            }
        }

        listVariables.verticalLayoutGroup.enabled = true;

        foreach (Transform t in listVariables.cards)
        {
            yield return null;
            t.localScale = new Vector3(1, 1, 1);
        }
        
    }

    public void RemoveTrelloBoard()
    {
        Destroy(boardObj);
    }
}
