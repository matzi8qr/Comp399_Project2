using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator anim;
    public Rigidbody body;
    public GameObject sword;

    private bool attacking;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float movementSpeed = Time.deltaTime * 5;
        float rotationSpeed = Time.deltaTime * 150;
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
  
        Vector3 moveVector = new Vector3(hInput * movementSpeed, 0, vInput * movementSpeed);
        moveVector = transform.TransformDirection(moveVector.normalized * movementSpeed);
        transform.position += moveVector;

        float camX = Input.GetAxisRaw("Mouse X") * rotationSpeed;
        Vector3 rotVector = new Vector3(0, camX, 0);
        transform.Rotate(rotVector);

        // Animator
        anim.SetBool("FWD", vInput > 0);
        anim.SetBool("BWD", vInput < 0);
        anim.SetBool("LFT", hInput < 0);
        anim.SetBool("RGT", hInput > 0);

        // Attack
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
        {
            anim.SetTrigger("Attack");
            attacking = true;
            sword.SetActive(true);
            timer = 0;
        }

        if (attacking) {
            if (timer >= 0.8f){
                attacking = false;
                sword.SetActive(false);
            } else timer += Time.deltaTime;
        }
     }
 }
