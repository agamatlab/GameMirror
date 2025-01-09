using Mirror;
using Mirror.BouncyCastle.Asn1.Esf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBlock : NetworkBehaviour
{
    // Start is called before the first frame update


    //protected override void OnValidate()
    //{
    //    if (Application.isPlaying) return;
    //    base.OnValidate();

    //    // initialize for all cases
    //    rb.isKinematic = true;
    //}

    //[ServerCallback]
    //private void OnCollisionEnter2D(Collision2D collision)
    //    print("OnEnter");
    //    if (collision.gameObject.tag.ToLower() != "player") return;
    //    print("OnEnter1");
    //    // if someone already owns this thing, abort
    //    if (connectionToClient != null) return;
    //    print("OnEnter2");
    //    var ni = collision.gameObject.GetComponent<NetworkIdentity>();
    //    print("OnEnter3");

    //    // order matters here for host client
    //    //rb.isKinematic = true;
    //    print("OnEnter4");        //netIdentity.AssignClientAuthority(ni.connectionToCent);
    //    print("NewClient Added");
    //}


    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    print("OnExit");
    //    if (collision.gameObject.tag.ToLower() != "player") return;
    //    var ni = collision.gameObject.GetComponent<NetworkIdentity>();
    //    // if 'other' isn't the current owner of this thing, abort
    //    if (connectionToClient != ni.connectionToClient) return;

    //    // order matters here for host client
    //}

    //// Enable / Disable owner ability to push this thing
    //public override void OnStartAuthority() { rb.isKinematic = false; }

    //public override void OnStopAuthority() { rb.isKinematic = true; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
