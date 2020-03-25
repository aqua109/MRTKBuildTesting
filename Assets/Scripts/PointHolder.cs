using Microsoft.MixedReality.Toolkit.Input;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointHolder : MonoBehaviour, IMixedRealityFocusHandler
{
    public GameObject point;
    public GameObject cube;

    [PunRPC]
    void CreatePoints(int id, object[] positions)
    {
        GameObject pointHolder = PhotonView.Find(id).gameObject;
        PointHolder phScript = pointHolder.GetComponent<PointHolder>();
        Transform cubeTransform = phScript.cube.transform;

        foreach (Vector3 p in positions)
        {
            Instantiate(point, p, Quaternion.identity, cubeTransform);
            //Instantiate(point, p, Quaternion.identity);
        }
    }

    public void OnFocusEnter(FocusEventData eventData)
    {
        // ask the photonview for permission
        var photonView = this.GetComponent<PhotonView>();
        photonView?.RequestOwnership();
    }

    public void OnFocusExit(FocusEventData eventData)
    {
    }

}
