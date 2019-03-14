using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    private Transform playerCamera;
    public Transform PlayerCamera { get { return this.playerCamera; } }

    private Transform player;
    public Transform Player { get { return this.player; } }

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        playerCamera = transform.Find("Camera");
        player = transform.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
