using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public int playerNumber;
    public float speed;
    public float turnSpeed;
    public Vector3 startingPOS;
    public Vector3 placeToMoveTo;
    public GameObject winImage;
    public bool isMoving;
    bool hasWon;
    bool isDead;
    Rigidbody rb;
    public Vector3 UProt, DOWNrot, LEFTrot, RIGHTrot;
    int turnDirection; // 0none, 1up 2down 3left 4right

    Animator anim;

	// Use this for initialization
	void Start ()
    {
        startingPOS = gameObject.transform.position;
        rb = GetComponent<Rigidbody>();
        winImage.SetActive(false);
        isMoving = false;

        UProt = new Vector3(0, 180, 0);
        DOWNrot = Vector3.zero;
        LEFTrot = new Vector3(0, 90, 0);
        RIGHTrot = new Vector3(0, -90, 0);

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
                        gameObject.transform.eulerAngles = UProt;
                    }
                    else if (turnDirection == 2)
                    {
                        gameObject.transform.eulerAngles = DOWNrot;
                    }
                    else if (turnDirection == 3)
                    {
                        gameObject.transform.eulerAngles = LEFTrot;
                    }
                    else if (turnDirection == 4)
                    {
                        gameObject.transform.eulerAngles = RIGHTrot;
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
                            gameObject.transform.Translate(Vector3.forward * (speed * Time.deltaTime));
                        }

                        if (Input.GetKey(KeyCode.F))
                        {
                            gameObject.transform.Translate(Vector3.left * (speed * Time.deltaTime));
                        }

                        if (Input.GetKey(KeyCode.G))
                        {
                            gameObject.transform.Translate(Vector3.back * (speed * Time.deltaTime));
                        }

                        if (Input.GetKey(KeyCode.H))
                        {
                            gameObject.transform.Translate(Vector3.right * (speed * Time.deltaTime));
                        }
                    }
                    if (playerNumber == 3)
                    {
                        if (Input.GetKey(KeyCode.I))
                        {
                            gameObject.transform.Translate(Vector3.forward * (speed * Time.deltaTime));
                        }

                        if (Input.GetKey(KeyCode.J))
                        {
                            gameObject.transform.Translate(Vector3.left * (speed * Time.deltaTime));
                        }

                        if (Input.GetKey(KeyCode.K))
                        {
                            gameObject.transform.Translate(Vector3.back * (speed * Time.deltaTime));
                        }

                        if (Input.GetKey(KeyCode.L))
                        {
                            gameObject.transform.Translate(Vector3.right * (speed * Time.deltaTime));
                        }
                    }
                    if (playerNumber == 4)
                    {
                        if (Input.GetKey(KeyCode.UpArrow))
                        {
                            gameObject.transform.Translate(Vector3.forward * (speed * Time.deltaTime));
                        }

                        if (Input.GetKey(KeyCode.LeftArrow))
                        {
                            gameObject.transform.Translate(Vector3.left * (speed * Time.deltaTime));
                        }

                        if (Input.GetKey(KeyCode.DownArrow))
                        {
                            gameObject.transform.Translate(Vector3.back * (speed * Time.deltaTime));
                        }

                        if (Input.GetKey(KeyCode.RightArrow))
                        {
                            gameObject.transform.Translate(Vector3.right * (speed * Time.deltaTime));
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
            StartCoroutine(DieAndRespawn());
        }

        if (other.gameObject.tag == "Good")
        {
            Debug.Log("WE WIN!");
            winImage.SetActive(true);
            Destroy(other.gameObject);
            hasWon = true;
            anim.SetTrigger("Win");
        }
    }

    IEnumerator DieAndRespawn()
    {
        isDead = true;
        yield return new WaitForSeconds(5);
        gameObject.transform.position = startingPOS;
        anim.SetTrigger("Respawn");
        isDead = false;
    }
}
