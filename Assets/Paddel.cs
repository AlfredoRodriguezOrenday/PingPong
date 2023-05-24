using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Paddel : MonoBehaviour
{
    [SerializeField] private float Speed = 7f;
    [SerializeField] private bool isPadel1;
    private float yBound = 3.65f;
    private float Movement;
    

    public void Move(){
        if(isPadel1){
            Movement =  Input.GetAxisRaw("Vertical2");
        }else{
            Movement =  Input.GetAxisRaw("Vertical");
        }
        Vector2 PadelPosition = transform.position;
        PadelPosition.y = Mathf.Clamp(PadelPosition.y + Movement * Speed * Time.deltaTime, -yBound, yBound);

        transform.position = PadelPosition;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
