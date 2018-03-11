using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public int playerNumber;
    public float speed;
    public float turnSpeed;
    public Vector3 startingPOS;
    public Quaternion startingROT;
    public Vector3 placeToMoveTo;
    public GameObject winImage;
    public bool isMoving;
    bool hasWon;
    bool isDead;
    Rigidbody rb;
    Vector3 UProt, DOWNrot, LEFTrot, RIGHTrot;
    int turnDirection; // 0none, 1up 2down 3left 4right

    Animator anim;

    public GameObject[] scriptObjectsToReset;

    public ParticleSystem shockEffect;

	// Use this for initialization
	void Start ()
    {
        startingPOS = gameObject.transform.position;
        startingROT = gameObject.transform.rotation;
        rb = GetComponent<Rigidbody>();
        winImage.SetActive(false);
        isMoving = false;

        UProt = new Vector3(0, 180, 0);
        DOWNrot = new Vector3(0, 0, 0);
        LEFTrot = new Vector3(0, 90, 0);
        RIGHTrot = new Vector3(0, 270, 0);

        turnDirection = 0;

        hasWon = false;
        isDead = false;

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isDead)
        {
            if (!hasWon)
            {
                if (isMoving)
                {
                    anim.SetBool("Walk", true);

                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, placeToMoveTo, speed * Time.deltaTime);

                    // hard code rotations lol
                    if (turnDirection == 1)
                    {
                        gameObject.transform.rotation = Quaternion.SlerpUnclamped(gameObject.transform.rotation, Quaternion.Euler(UProt), turnSpeed * Time.deltaTime);
                    }
                    else if (turnDirection == 2)
                    {
                        gameObject.transform.rotation = Quaternion.SlerpUnclamped(gameObject.transform.rotation, Quaternion.Euler(DOWNrot), turnSpeed * Time.deltaTime);
                    }
                    else if (turnDirection == 3)
                    {
                        gameObject.transform.rotation = Quaternion.SlerpUnclamped(gameObject.transform.rotation, Quaternion.Euler(LEFTrot), turnSpeed * Time.deltaTime);
                    }
                    else if (turnDirection == 4)
                    {
                        gameObject.transform.rotation = Quaternion.SlerpUnclamped(gameObject.transform.rotation, Quaternion.Euler(RIGHTrot), turnSpeed * Time.deltaTime);
                    }

                    // if we get to the destination, then we can move again
                    if (gameObject.transform.position == placeToMoveTo)
                    {
                        isMoving = false;
                    }
                }
                else
                {
                    anim.SetBool("Walk", false);
                    if (playerNumber == 1)
                    {
                        if (Input.GetKey(KeyCode.W))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
                            turnDirection = 1;
                            isMoving = true;
                        }

                        if (Input.GetKey(KeyCode.A))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
                            turnDirection = 3;
                            isMoving = true;
                        }

                        if (Input.GetKey(KeyCode.S))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                            turnDirection = 2;
                            isMoving = true;
                        }

                        if (Input.GetKey(KeyCode.D))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
                            turnDirection = 4;
                            isMoving = true;
                        }
                    }
                    if (playerNumber == 2)
                    {
                        if (Input.GetKey(KeyCode.T))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
                            turnDirection = 1;
                            isMoving = true;
                        }

                        if (Input.GetKey(KeyCode.F))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
                            turnDirection = 3;
                            isMoving = true;
                        }

                        if (Input.GetKey(KeyCode.G))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                            turnDirection = 2;
                            isMoving = true;
                        }

                        if (Input.GetKey(KeyCode.H))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
                            turnDirection = 4;
                            isMoving = true;
                        }
                    }
                    if (playerNumber == 3)
                    {
                        if (Input.GetKey(KeyCode.I))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
                            turnDirection = 1;
                            isMoving = true;
                        }

                        if (Input.GetKey(KeyCode.J))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
                            turnDirection = 3;
                            isMoving = true;
                        }

                        if (Input.GetKey(KeyCode.K))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                            turnDirection = 2;
                            isMoving = true;
                        }

                        if (Input.GetKey(KeyCode.L))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
                            turnDirection = 4;
                            isMoving = true;
                        }
                    }
                    if (playerNumber == 4)
                    {
                        if (Input.GetKey(KeyCode.UpArrow))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
                            turnDirection = 1;
                            isMoving = true;
                        }

                        if (Input.GetKey(KeyCode.LeftArrow))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
                            turnDirection = 3;
                            isMoving = true;
                        }

                        if (Input.GetKey(KeyCode.DownArrow))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                            turnDirection = 2;
                            isMoving = true;
                        }

                        if (Input.GetKey(KeyCode.RightArrow))
                        {
                            placeToMoveTo = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
                            turnDirection = 4;
                            isMoving = true;
                        }
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bad")
        {
            anim.SetTrigger("IsDie");
            isMoving = false;
            shockEffect.Play();
            StartCoroutine(DieAndRespawn());
        }

        if (other.gameObject.tag == "Good")
        {
            Debug.Log("WE WIN!");
            winImage.SetActive(true);
            //Destroy(other.gameObject);
            hasWon = true;
            anim.SetTrigger("Win");
        }
    }

    IEnumerator DieAndRespawn()
    {
        isDead = true;
        yield return new WaitForSeconds(3);
        foreach(GameObject objectorino in scriptObjectsToReset)
        {
            objectorino.SendMessage("ResetSwitch");
        }
        gameObject.transform.position = startingPOS;
        gameObject.transform.rotation = startingROT;
        anim.SetTrigger("Respawn");
        isDead = false;
    }
}
