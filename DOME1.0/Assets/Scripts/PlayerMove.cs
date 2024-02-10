using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    PlayerControls controls;
    // Start is called before the first frame update
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
