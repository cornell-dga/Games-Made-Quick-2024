using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigAstriod : MonoBehaviour
{

    public static BigAstriod Instance;
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float starting_speed;
    [SerializeField] private float bonus_speed;
    [SerializeField] private float wait_time;
    [SerializeField] private float start_delay;
    [SerializeField] float hit_speed;
    [SerializeField] float star_speed;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(starting_speed, 0);
        InvokeRepeating(nameof(SpeedUp), start_delay, wait_time);
    }

    void SpeedUp(){
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + bonus_speed, 0);
        Debug.Log("speedUp");
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            GameManager.Instance.LoseGame();
        }
    }

    public void HitAsteroid()
    {
        rigidbody2D.velocity += Vector2.right * hit_speed;
    }

    public void HitStar() {
        rigidbody2D.velocity += Vector2.right * -star_speed;

    }
}
