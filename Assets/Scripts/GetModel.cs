using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GetModel : NetworkBehaviour
{
    
    public Vector3 boxsize;
    public Vector3 position; 
    public Quaternion rotation;
    public SpawnManager SpawnManager;

    // Update is called once per frame
    public void createShad()
    {

    }
    void Start(){
        
    }
    void Update()
    {

            boxsize = GetComponent<Collider>().bounds.size;
            position = GetComponent<Transform>().position;
            rotation = GetComponent<Transform>().localRotation;
            if(boxsize.x>0)
            {
                NetworkIdentity networkIdentity = NetworkClient.connection.identity;
                SpawnManager = networkIdentity.GetComponent<SpawnManager>();
                SpawnManager.CmdUpdateShadow(boxsize,position,rotation);
            }
            
    }
    

}
