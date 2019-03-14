using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    private GameObject playerCamera;
    public GameObject PlayerCamera { get { return this.playerCamera; } }

    private GameObject player;
    public GameObject Player { get { return this.player; } }

    private GameObject PM;
    private PlayerManager playerManager;
    public PlayerManager PlayerManager { get { return this.playerManager; } }

    // Start is called before the first frame update
    void Awake()
    {
        playerCamera = transform.Find("Camera").gameObject;
        player = transform.Find("Player").gameObject;
        PM = transform.Find("PlayerManager").gameObject;


        playerManager = PM.GetComponent<PlayerManager>();
    }

}
