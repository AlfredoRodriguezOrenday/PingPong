using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public float Speed = 7f;
    private bool MoveUp;
    private bool MoveDown;

    void Update(){
        Vector2 PadelPosition = transform.position;
        if(MoveUp){
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }else if(MoveDown){
            transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }
    }
    
    public void ButtonUp(){
        MoveUp = true;
    }
    public void ButtonNoUp(){
        MoveUp = false;
    }
    public void ButtonDown(){
        MoveDown = true;
    }
    public void ButtonNoDown(){
        MoveDown = false;
    }
}
