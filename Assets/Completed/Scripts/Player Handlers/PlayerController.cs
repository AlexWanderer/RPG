using UnityEngine;
using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;

public class PlayerController : MonoBehaviour {

    Animator anim;
    Random rnd = new Random();
    MobHandler enemyScript;
    public GameObject pauseMenu;
    public static bool gamePaused = false;

    //Player Combat Stats
    public bool playerDamageLeft = false;
    public bool playerDamageRight = false;

    //Player Mechanics
    public bool isMoving = false;
    //EDIT START
    public bool isMovingHorizontal = false;
    public bool isMovingUp = false;
    public bool isMovingDown = false;
    public bool isMovingLeft = false;
    public bool isMovingRight = false;
    public bool playerDodge = false;
    public bool isMovingVertical = false;
    //EDIT END
    public bool playerIsAttacking = false;
    public string playerAttack = "";
    public bool playerIsRolling = false;
    public bool playerIsJumping = false;
    public bool playerIsStunned = false;
    public bool playerFacingEntity = false;
    public bool playerInCombat = false;
    public bool facingRight;

    public float resetDrag = Time.time + .5f; // EDIT


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Start")) {
            Debug.Log("Pressed start/menu button");
            if (gamePaused == false) {
                Pause();
            } else {
                Unpause();
            }
        }
        //Pause Menu inputs
        //Game inputs
        if (gamePaused == true) {
            return;
        }
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("Pressed A button");
        }
        else if (Input.GetButtonDown("Item"))
        {
            Debug.Log("Pressed X button");
            float pos1 = Random.Range(-5, 5);
            float pos2 = Random.Range(-5, 5);
            pos1 = pos1 + this.gameObject.transform.position.x;
            pos2 = pos2 + this.gameObject.transform.position.y;
            Vector3 position = new Vector3(pos1, pos2, 0);
            Debug.Log(pos1 + " " + pos2);
            GameObject monster = Instantiate(Resources.Load("watcherPref")) as GameObject;
            monster.transform.position = position;
        }
        else if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Pressed Y button");
        }
        else if (Input.GetButtonDown("Left Button"))
        {
            playerIsAttacking = true;
            playerAttack = "L";
        }
        else if (Input.GetButtonDown("Right Button"))
        {
            playerIsAttacking = true;
            playerAttack = "R";
        }
        else if (Input.GetButtonDown("Select"))
        {
            Debug.Log("Pressed Select/map button");
        }
        

        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");
        //Absolutes are taken to create a positive inference statement.
        isMoving = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0;
        isMovingHorizontal = Mathf.Abs(input_x) > 0; // EDIT
        isMovingVertical = Mathf.Abs(input_y) > 0; // EDIT
        anim.SetBool("isMoving", isMoving);


        //EDIT START//////////////////////////////////////////////////////////////////////
        if (!isMoving && (Input.GetButtonDown("Dodge") || Input.GetKeyDown(KeyCode.Space)) && Time.time >= resetDrag)
        {
            Debug.Log("Pressed B button");
            Debug.Log(GetComponent<Rigidbody2D>().velocity.x + "b4");
            playerDodge = true;
        }
        else if (isMoving && input_y > 0 && input_x == 0 && (Input.GetButtonDown("Dodge") || Input.GetKeyDown(KeyCode.Space)) && Time.time >= resetDrag)
        {
            isMovingUp = true;
        }
        else if (isMoving && input_y < 0 && input_x == 0 && (Input.GetButtonDown("Dodge") || Input.GetKeyDown(KeyCode.Space)) && Time.time >= resetDrag)
        {
            isMovingDown = true;
        }
        else if (isMoving && input_x < 0 && input_y == 0 && (Input.GetButtonDown("Dodge") || Input.GetKeyDown(KeyCode.Space)) && Time.time >= resetDrag)
        {
            isMovingLeft = true;
        }
        else if (isMoving && input_x > 0 && input_y == 0 && (Input.GetButtonDown("Dodge") || Input.GetKeyDown(KeyCode.Space)) && Time.time >= resetDrag)
        {
            isMovingRight = true;
        }

        //EDIT END//////////////////////////////////////////////////////////////////////////////

        if (playerIsJumping)
        {
            Debug.Log("--- Player Jumped");
            playerIsJumping = true;
        }

        if (playerIsAttacking)
        {
            playerIsAttacking = false;
            if (playerAttack == "L")
            {
                executePlayerAttackLeftLight();
            }
            else if (playerAttack == "R")
            {
                Debug.Log("attack r b4 ex");
                executePlayerAttackRightLight();
                Debug.Log("attack r after ex");
            }
        }

        if (playerIsRolling)
        {
            Debug.Log("-- Player Rolled");
            playerIsRolling = true;
        }

        if (isMoving)
        {
            if (!playerIsStunned)
            {
                if (input_x < 0f) {
                    facingRight = false;
                } else if (input_x > 0f) {
                    facingRight = true;
                }
                anim.SetFloat("X", input_x);
                anim.SetFloat("Y", input_y);
                //normalized transformation removes increased momentum from diagonal inputs
                transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        //EDIT START!//////////////////////////////////////////////////////////////////////

        if (playerDodge)
        {
            Debug.Log("Pressed B button");
            ExecutePlayerDodge();
            resetDrag = Time.time + .5f;
            Debug.Log(GetComponent<Rigidbody2D>().velocity.x + "AF");
        }
        else if (isMovingRight)
        {
            Debug.Log("Pressed B button + right");
            Debug.Log(GetComponent<Rigidbody2D>().velocity.x + "b4");
            ExecutePlayerDodgeRoll(7f, 0f);
            resetDrag = Time.time + .5f;
            Debug.Log(GetComponent<Rigidbody2D>().velocity.x + "AF");
            isMovingRight = false;
        }
        else if (isMovingLeft)
        {
            Debug.Log("Pressed B button + left");
            Debug.Log(GetComponent<Rigidbody2D>().velocity.x + "b4");
            ExecutePlayerDodgeRoll(-7f, 0f);
            resetDrag = Time.time + .5f;
            Debug.Log(GetComponent<Rigidbody2D>().velocity.x + "AF");
            isMovingLeft = false;
        }
        else if (isMovingUp)
        {
            Debug.Log("Pressed B button + up");
            Debug.Log(GetComponent<Rigidbody2D>().velocity.x + "b4");
            ExecutePlayerDodgeRoll(0f, 7f);
            resetDrag = Time.time + .5f;
            Debug.Log(GetComponent<Rigidbody2D>().velocity.x + "AF");
            isMovingUp = false;
        }
        else if (isMovingDown)
        {
            Debug.Log("Pressed B button + down");
            Debug.Log(GetComponent<Rigidbody2D>().velocity.x + "b4");
            ExecutePlayerDodgeRoll(0f, -7f);
            resetDrag = Time.time + .5f;
            Debug.Log(GetComponent<Rigidbody2D>().velocity.x + "AF");
            isMovingDown = false;
        }

        if (Time.time >= resetDrag)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            this.GetComponent<Rigidbody2D>().drag = 0;
        }

        //EDIT END/////////////////////////////////////////////////////////
    }



    void executePlayerAttackLeftLight()
    {
        if (facingRight == false) {
            foreach (GameObject enemy in RangeCheck.enemiesInRange) {
                if (enemy.transform.position.x <= this.gameObject.transform.position.x) {
                    Debug.Log(enemy + " was damaged");
                    enemyScript = enemy.GetComponent<MobHandler>();
                    executeDamageOutput();
                }
            }
        }
        else
        {
            foreach (GameObject enemy in RangeCheck.enemiesInRange) {
                if (enemy.transform.position.x >= this.gameObject.transform.position.x) {
                    Debug.Log(enemy + " was damaged");
                    enemyScript = enemy.GetComponent<MobHandler>();
                    executeDamageOutput();
                }
            }
        }
    }

    void executePlayerAttackRightLight()
    {
        Debug.Log("Executed Right Attack");
    }

    void ExecutePlayerDodge()
    {
        if (facingRight == false)
        {
            this.GetComponent<Rigidbody2D>().drag = 5;
            GetComponent<Rigidbody2D>().velocity = new Vector2 (5f,0f);
            if (playerDodge)
            { playerDodge = false;
            }
        }
        else
        {
            this.GetComponent<Rigidbody2D>().drag = 5;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
            if (playerDodge)
            { playerDodge = false;
            }

        }
    }

    void ExecutePlayerDodgeRoll(float x, float y)
    {
        if (facingRight == false )
        {
            this.GetComponent<Rigidbody2D>().drag = 5;
            GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);

        }
        else if (facingRight == true)
        {
            this.GetComponent<Rigidbody2D>().drag = 5;
            GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
        }
        
    }


    void executeDamageOutput()
	{
		Debug.Log (enemyScript);
		Debug.Log (enemyScript.currentHealth);
		Debug.Log (playerDamageLeft);
		enemyScript.currentHealth = enemyScript.currentHealth - 2f;
		Debug.Log (enemyScript.currentHealth);
	}

	void Pause ()
	{
		gamePaused = true;
		pauseMenu.SetActive(true);
		Time.timeScale = 0.0f;
	}

	void Unpause ()
	{
		gamePaused = false;
		pauseMenu.SetActive(false);
		Time.timeScale = 1.0f;
	}
}