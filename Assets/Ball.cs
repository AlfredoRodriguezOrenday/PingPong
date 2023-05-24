using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float InitialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    public Rigidbody2D BallRb;
    TrailRenderer ballTrail;
    public Material material;
    private AudioSource audioSource;
    [SerializeField] private AudioClip Sound1;
    [SerializeField] private AudioClip Sound2;

    // Start is called before the first frame update
    void Start()
    {
       BallRb = GetComponent<Rigidbody2D>();
       ballTrail = BallRb.GetComponent<TrailRenderer>();
       ballTrail.enabled = false;
       audioSource = GetComponent<AudioSource>();
       Launch(); 
    }

    private void Launch()
    {
        float XVelocity = 0;
        float YVelocity = 0;
        XVelocity = Random.Range(0,2) == 0 ? 1 :-1;
        YVelocity = Random.Range(0,2) == 0 ? 1 :-1;
        BallRb.velocity = new Vector2(XVelocity,YVelocity) * InitialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Padle1") || collision.gameObject.CompareTag("Padle2"))
        {
            BallRb.velocity *= velocityMultiplier;
            ballTrail.enabled = true;
            audioSource.PlayOneShot(Sound2);
        }
        if (collision.gameObject.CompareTag("Padle1")){
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            material.color = new Color(0.6f, 0.4f, 0.3f);
            
        }
        if (collision.gameObject.CompareTag("Padle2")){
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            material.color = new Color(0.3f, 0.4f, 0.6f);
            //Color(0f, 0f, 0.6f, 0.4f);
        }
        if(collision.gameObject.CompareTag("Wall")){
            audioSource.PlayOneShot(Sound1);
        }

    }
    public void Stop(){
        BallRb.velocity = new Vector2(InitialVelocity, InitialVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Goal1")){
            GameManager.Instance.padel2Scored();
            GameManager.Instance.Restart();
            GameManager.Instance.ShowGoal(new Color(0.0f, 0.0f, 1.0f, 0.6f));
            Stop();
        }else{
            GameManager.Instance.padel1Scored();
            GameManager.Instance.Restart();
            GameManager.Instance.ShowGoal(new Color(1.0f, 0.0f, 0.0f, 0.6f));
            Stop();
        }
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            ballTrail.enabled = false;
    }
}
