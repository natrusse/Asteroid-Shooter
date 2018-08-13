using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float enemySpawn = 20;
    private Manager M;
    public int enemyMovSpeed = 10;
    public int enemyRotSpeed = 30;
    private Transform Tar;
    private float angle;
    private float AngleRad;
    private Transform enemyLoc;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        // calls specific game manager script
        M = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        //Target = GameObject.FindWithTag("Player");
        enemyLoc = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * enemyMovSpeed;

        //Etimer += Time.deltaTime;

        //if (Etimer >= enemySpawn)
        //{
        //    Destroy(gameObject);
        //}

        AngleRad = Mathf.Atan2(M.currentShip.transform.position.y - enemyLoc.position.y, M.currentShip.transform.position.x - enemyLoc.position.x);
        angle = (120 / Mathf.PI) * AngleRad * enemyRotSpeed;

        rb.transform.localEulerAngles = new Vector3(0, 0, angle);
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.gameObject.tag == "Player")
        {

            Debug.Log("Player is dead.");
            M.enemies -= 1;
            Destroy(col.collider.gameObject);
            Destroy(gameObject);
            M.Death();
        }
        else if (col.collider.gameObject.tag == "Bullet")
        {

            Debug.Log("Enemy Ship destroyed");
            Destroy(col.collider.gameObject);
            Destroy(gameObject);
            M.score += 50;
            M.SetScoreText();
            M.enemies -= 1;
        }
    }
}