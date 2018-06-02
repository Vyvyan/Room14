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
    public GameObject normalLIGHT, ratLIGHT;
    public bool isMoving;
    bool hasWon;
    bool isDead;
    bool turnWinTiles;
    public float winTileSpinSpeed;
    Rigidbody rb;
    Vector3 UProt, DOWNrot, LEFTrot, RIGHTrot;
    int turnDirection; // 0none, 1up 2down 3left 4right

    public GameManager gameManager;

    public GameObject mazeCompleteLightObject;
    public Material mazeCompleteLightMaterial;

    Animator anim;

    public GameObject[] scriptObjectsToReset;

    public ParticleSystem shockEffect;

    Vector3 lightRotationOnWin = new Vector3(145, 0, 0);

	// Use this for initialization
	void Start ()
    {
        winImage.SetActive(false);
        //normalLIGHT.SetActive(true);
        ratLIGHT.SetActive(true);

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
        turnWinTiles = false;

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
        if (turnWinTiles)
        {
            normalLIGHT.transform.rotation = Quaternion.SlerpUnclamped(normalLIGHT.transform.rotation, Quaternion.Euler(lightRotationOnWin), winTileSpinSpeed * Time.deltaTime);
        }
        */
        

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

                    if (!GameManager.areControlsSwapped)
                    {
                        if (playerNumber == 1)
                        {
                            if (Input.GetKeyDown(KeyCode.X))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
                                turnDirection = 1;
                                isMoving = true;
                            }

                            if (Input.GetKeyDown(KeyCode.C))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 3;
                                isMoving = true;
                            }

                            if (Input.GetKeyDown(KeyCode.Z))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                                turnDirection = 2;
                                isMoving = true;
                            }

                            if (Input.GetKeyDown(KeyCode.V))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 4;
                                isMoving = true;
                            }
                        }
                        if (playerNumber == 2)
                        {
                            if (Input.GetKey(KeyCode.RightArrow))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
                                turnDirection = 1;
                                isMoving = true;
                            }

                            if (Input.GetKey(KeyCode.UpArrow))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 3;
                                isMoving = true;
                            }

                            if (Input.GetKey(KeyCode.LeftArrow))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                                turnDirection = 2;
                                isMoving = true;
                            }

                            if (Input.GetKey(KeyCode.DownArrow))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 4;
                                isMoving = true;
                            }
                        }
                        if (playerNumber == 3)
                        {
                            if (Input.GetKey(KeyCode.H))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
                                turnDirection = 1;
                                isMoving = true;
                            }

                            if (Input.GetKey(KeyCode.I))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 3;
                                isMoving = true;
                            }

                            if (Input.GetKey(KeyCode.F))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                                turnDirection = 2;
                                isMoving = true;
                            }

                            if (Input.GetKey(KeyCode.G))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 4;
                                isMoving = true;
                            }
                        }
                        if (playerNumber == 4)
                        {
                            if (Input.GetKey(KeyCode.L))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
                                turnDirection = 1;
                                isMoving = true;
                            }

                            if (Input.GetKey(KeyCode.T))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 3;
                                isMoving = true;
                            }

                            if (Input.GetKey(KeyCode.J))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                                turnDirection = 2;
                                isMoving = true;
                            }

                            if (Input.GetKey(KeyCode.K))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 4;
                                isMoving = true;
                            }
                        }
                    }
                    // SWAPPED CONTROLS
                    else
                    {
                        if (playerNumber == 1)
                        {
                            if (Input.GetButtonDown("Maze1_Right"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
                                turnDirection = 1;
                                isMoving = true;
                            }

                            if (Input.GetButtonDown("Maze1_Up"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 3;
                                isMoving = true;
                            }

                            if (Input.GetButtonDown("Maze1_Left"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                                turnDirection = 2;
                                isMoving = true;
                            }

                            if (Input.GetButtonDown("Maze1_Down"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 4;
                                isMoving = true;
                            }
                        }
                        if (playerNumber == 2)
                        {
                            if (Input.GetButtonDown("Maze2_Right"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
                                turnDirection = 1;
                                isMoving = true;
                            }

                            if (Input.GetButtonDown("Maze2_Up"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 3;
                                isMoving = true;
                            }

                            if (Input.GetButtonDown("Maze2_Left"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                                turnDirection = 2;
                                isMoving = true;
                            }

                            if (Input.GetButtonDown("Maze2_Down"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 4;
                                isMoving = true;
                            }
                        }
                        if (playerNumber == 3)
                        {
                            if (Input.GetButtonDown("Maze3_Right"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
                                turnDirection = 1;
                                isMoving = true;
                            }

                            if (Input.GetButtonDown("Maze3_Up"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 3;
                                isMoving = true;
                            }

                            if (Input.GetButtonDown("Maze3_Left"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                                turnDirection = 2;
                                isMoving = true;
                            }

                            if (Input.GetButtonDown("Maze3_Down"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 4;
                                isMoving = true;
                            }
                        }
                        if (playerNumber == 4)
                        {
                            if (Input.GetButtonDown("Maze4_Right"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
                                turnDirection = 1;
                                isMoving = true;
                            }

                            if (Input.GetButtonDown("Maze4_Up"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
                                turnDirection = 3;
                                isMoving = true;
                            }

                            if (Input.GetButtonDown("Maze4_Left"))
                            {
                                placeToMoveTo = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                                turnDirection = 2;
                                isMoving = true;
                            }

                            if (Input.GetButtonDown("Maze4_Down"))
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


        if (!hasWon)
        {
            if (other.gameObject.tag == "Good")
            {
                Debug.Log("WE WIN!");
                //Destroy(other.gameObject);
                hasWon = true;
                anim.SetTrigger("Win");
                StartCoroutine(WaitThenChangeLights());
                Win();
            }
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

    IEnumerator WaitThenChangeLights()
    {
        yield return new WaitForSeconds(2);
        //turnWinTiles = true;
        StartCoroutine(MoveWinLightToBlockLetters());
    }

    void Win()
    {
        /*
        // turn on the "light" of the completion object
        mazeCompleteLightObject.GetComponent<Renderer>().material = mazeCompleteLightMaterial;
        */

        if (playerNumber == 1)
        {
            gameManager.easyMazesComplete++;
        }
        else if (playerNumber == 2)
        {
            gameManager.easyMazesComplete++;
        }
        else if (playerNumber == 3)
        {
            gameManager.hardMazesComplete++;
        }
        else if (playerNumber == 4)
        {
            gameManager.hardMazesComplete++;
        }
    }

    IEnumerator MoveWinLightToBlockLetters()
    {
        /*
        normalLIGHT.SetActive(false);
        yield return new WaitForSeconds(2);
        winLIGHT.SetActive(true);
        */

        yield return new WaitForSeconds(2);
    }
}
