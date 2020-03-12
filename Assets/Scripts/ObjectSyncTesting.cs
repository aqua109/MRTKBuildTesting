using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSyncTesting : MonoBehaviour
{
    public GameObject point;
    public GameObject pointHolder;

    [Range(1, 10000)]
    public int numberOfPoints = 100;

    public void CreateGameObject()
    {
        GameObject holder = PhotonNetwork.Instantiate(pointHolder.name, new Vector3(0, 1, 1), Quaternion.identity, 0);

        PhotonView pView = holder.GetComponent<PhotonView>();

        object[] pointsArray = new object[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            float x = Random.Range(-0.5f, 0.5f), y = Random.Range(0.5f, 1.5f), z = Random.Range(0.5f, 1.5f);
            Vector3 p = new Vector3(x, y, z);
            pointsArray[i] = p;
        }

        //foreach (Vector3 p in pointsArray)
        //{
        //    Debug.Log($"X: {p.x}\tY: {p.y}\tZ: {p.z}");
        //}

        pView.RPC("CreatePoints", RpcTarget.AllBuffered, pView.ViewID, pointsArray);

    }
}
