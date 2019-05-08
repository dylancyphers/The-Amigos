using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Fox_Move : MonoBehaviour {

    public float speed,jumpForce,cooldownHit;
	public bool running,up,down,jumping,crouching,dead,attacking,special;
    private Rigidbody2D rb;
    private Animator anim;
	private SpriteRenderer sp;
	private float rateOfHit;
	private GameObject[] life;
	private int qtdLife;
    private int jumpCount = 0;
    private Vector2 l;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		sp=GetComponent<SpriteRenderer>();
		running=false;
		up=false;
		down=false;
		jumping=false;
		crouching=false;
		rateOfHit=Time.time;
		life=GameObject.FindGameObjectsWithTag("Life");
		qtdLife=life.Length;
        l = new Vector2();
        l = 5* Vector2.left;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && jumpCount != 2 && Powers.doubleJump == true)
        {
           jumpCount++;
           rb.AddForce(new Vector2(0, jumpForce));

        }
        if(Powers.doubleJump == false && Input.GetKeyDown(KeyCode.X) && jumpCount < 1)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jumpCount++;
        }



        if (dead == false)
            Crouch();
    }


    // Update is called once per frame
    void FixedUpdate () {
		if(dead==false){
		//Character doesnt choose direction in Jump									//If you want to choose direction in jump
			if(attacking==false){													//just delete the (jumping==false)
				if(crouching==false){
					Movement();
					Attack();
					Special();
                    Jump();
				}
				
				
			}
			Dead();
		}

	}

	void Movement(){
        
		//Character Move
		float move = Input.GetAxisRaw("Horizontal");
        if(Powers.dash == true && Input.GetKey(KeyCode.F))
        {
            Vector2 newloc = new Vector2();
            if (rb.velocity.x < 0)
            {
                newloc.x = this.transform.position.x - 1;
            } else if (rb.velocity.x>0)
            {
                newloc.x = this.transform.position.x + 1; 
            }
            newloc.y = this.transform.position.y;
            this.transform.position = newloc;
        }
        if (Input.GetKey(KeyCode.Z) && Powers.sprint == true){
			//Run
			rb.velocity = new Vector2(move*speed*Time.deltaTime*3,rb.velocity.y);
			running=true;
		}else{
			//Walk
			rb.velocity = new Vector2(move*speed*Time.deltaTime,rb.velocity.y);
			running=false;
		}

		//Turn
		if(rb.velocity.x<0){
			sp.flipX=true;
		}else if(rb.velocity.x>0){
			sp.flipX=false;
		}
		//Movement Animation
		if(rb.velocity.x!=0&&running==false){
			anim.SetBool("Walking",true);
		}else{
			anim.SetBool("Walking",false);
		}
		if(rb.velocity.x!=0&&running==true){
			anim.SetBool("Running",true);
		}else{
			anim.SetBool("Running",false);
		}
	}

	void Jump(){
        //Jump
        //double jump unlocked
        //if (Powers.doubleJump == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.X) && jumpCount != 2)
        //    {
        //        jumpCount++;
        //        rb.AddForce(new Vector2(0, jumpForce));

        //    }
        //}
        //Jump Animation
        if (rb.velocity.y>0&&up==false){
			up=true;
			jumping=true;
			anim.SetTrigger("Up");
		}else if(rb.velocity.y<0&&down==false){
			down=true;
			jumping=true;
			anim.SetTrigger("Down");
		}else if(rb.velocity.y==0&&(up==true||down==true)){
			up=false;
			down=false;
			jumping=false;
			anim.SetTrigger("Ground");
            jumpCount = 0;
		}
	}

	void Attack(){																//I activated the attack animation and when the 
		//Atacking																//animation finish the event calls the AttackEnd()
		if(Input.GetKeyDown(KeyCode.C)){
			rb.velocity=new Vector2(0,0);
			anim.SetTrigger("Attack");
			attacking=true;
		}
	}

	void AttackEnd(){
		attacking=false;
	}

	void Special(){
		if(Input.GetKey(KeyCode.Space)){
			anim.SetBool("Special",true);
		}else{
			anim.SetBool("Special",false);
		}
	}

	void Crouch(){
        //Crouch
        if (Powers.crouch == true)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetBool("Crouching", true);
            }
            else
            {
                anim.SetBool("Crouching", false);
            }
        }
	}

	void OnTriggerEnter2D(Collider2D other){							//Case of Bullet
		if(other.tag=="Enemy"){
			anim.SetTrigger("Damage");
			Hurt();
		}

    }		

    						

	void OnCollisionEnter2D(Collision2D other) {						//Case of Touch
		if(other.gameObject.tag=="Enemy"){
			anim.SetTrigger("Damage");
			Hurt();
		}

        if (other.gameObject.name == "DoubleJump")
        {
            Powers.FoundDoubleJump();
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "WallJump")
        {
            Powers.FoundWallJump();
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Crouch")
        {
            Powers.FoundCrouch();
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Dash")
        {
            Powers.FoundDash();
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Sprint")
        {
            Powers.FoundSprint();
            Destroy(other.gameObject);
        }

        //allows walljumping 
        if (Powers.wallJump == true && other.gameObject.tag == "TileMap")
        {

            jumpCount = 0;
        }
            //walljump


    }

	void Hurt(){
		if(rateOfHit<Time.time){
			rateOfHit=Time.time+cooldownHit;
			Destroy(life[qtdLife-1]);
			qtdLife-=1;
            this.transform.position = PlayerLocationController.futurePos;
        }
	}

	void Dead(){
		if(qtdLife<=0){
			anim.SetTrigger("Dead");
			dead=true;
            SceneManager.LoadScene("d1");
        }
	}

	public void TryAgain(){														//Just to Call the level again
		SceneManager.LoadScene(0);
	}
}
