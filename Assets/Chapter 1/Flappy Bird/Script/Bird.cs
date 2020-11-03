using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    //global variabel
    [SerializeField] private Text scoreText;
    [SerializeField] private float upForce = 100f;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent onJump, onDead;
    [SerializeField] private int score = 0;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private UnityEvent OnAddPoint;
    
    //local variabel
    private Rigidbody2D rg;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //inisiasi variabel rg untuk mendapatkan kompenen Rigidbody 2D
        rg = GetComponent<Rigidbody2D>();
        //inisiasi variabel untuk mendapatkan komponen Animator
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //cek jika belum mati dan klik mouse
        if(!isDead && Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (!isDead && Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }

    //fungsi untuk mengecek sudah mati atau belum 
    public bool IsDead()
    {
        return isDead;
    }

    public int finalScore()
    {
        return score;
    }
    //method pada saat mati
    public void Dead()
    {
        //cek jika belum mati
        if(!isDead && onDead != null)
        {
            //memanggul semua event yang ada di onDead
            upForce = 0f;
            onDead.Invoke();
        }
        //set variabel isDead menjadi true
        isDead = true;
    }

    //method pada saat melakukan lompat
    public void Jump()
    {
        //cek rigidbody null atau tidak
        if (rg)
        {
            //menghentikan kecepatan burung jatuh
            rg.velocity = Vector2.zero;

            //menambahkan gaya ke arah sumbu y agar burung melompat / terbang
            rg.AddForce(new Vector2(0, upForce));
        }
        if (onJump != null)
        {
            //memanggil semua event yang ada onJump
            onJump.Invoke();
        }
    }


    //method jika Collider 2D masuk pada Collider lain
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision)
        anim.enabled = false;
        //if (!isDead)
        //{
        //    Dead();
        //}
    }


    public void addScore(int value)
    {
        //menambah score value
        score += value;

        if(OnAddPoint != null) {
            OnAddPoint.Invoke();
        }
        scoreText.text = score.ToString();
    }


    void shoot() {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

}
