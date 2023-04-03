using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpawnManager : NetworkBehaviour
{

    public GameObject Troop1Shad;
    public GameObject Troop2Shad;

    public GameObject ARCamera;
    GameObject model;
    

    public override void OnStartClient()
    {
        base.OnStartClient();
        ARCamera = GameObject.Find("ARCamera");
        CmdSpawnShadow();

    }

    [Server]
    public override void OnStartServer()
    {
        
    }

    [Command]
    public void CmdSpawnShadow()
    {
        model = Instantiate(Troop1Shad, new Vector3(0, 0, 0), Quaternion.identity);
        NetworkServer.Spawn(model,connectionToClient);
        RpcSetShadPos(model);
    }
    [Command]
    public void CmdUpdateShadow(Vector3 size,Vector3 pos, Quaternion rotation)
    {
       model.transform.localScale = size;
       model.transform.position = pos;
       model.transform.rotation = rotation;
    }

    [ClientRpc]
    void RpcSetShadPos(GameObject model)
    {
        model.transform.SetParent(ARCamera.transform,false);
        model.transform.localScale = new Vector3 (1,1,1);
    }

    [ClientRpc]
    void RpcUpdateShadPos(GameObject model)
    {
        model.transform.localScale = new Vector3 (1,1,1);
    }
}

