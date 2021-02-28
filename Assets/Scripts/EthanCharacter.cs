using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class EthanCharacter : MonoBehaviour
{
  private Animator animator;
  public Rigidbody rb;
  public float modifier = 1;
  public float jumpForce = 1;
    public GameObject stone;
    public GameObject UI;
    public Transform parentTransform;
  [Range(-2, 2)] public float speed = 0;
  private bool jump = false;


  void Awake()
  {
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    float horizontal = Input.GetAxis("Horizontal");
    if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.1) {
        rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
    }

    //horizontal = speed;

    //Set character rotation
    float y = (horizontal < 0) ? -90 : 90;
    Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, y, transform.rotation.eulerAngles.z);
    transform.rotation = newRotation;

    //Set character animation
    animator.SetFloat("Speed", Mathf.Abs(horizontal));

    //move character
    transform.Translate(transform.forward * horizontal * modifier* Time.deltaTime);

    Vector3 cameraPos = GameObject.Find("Main Camera").transform.position;
    GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, cameraPos.y, cameraPos.z);
        //GameObject.Find("Main Camera").transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, (y < 0) ? 180 : 0, transform.rotation.eulerAngles.x);
        transform.position = new Vector3(transform.position.x,transform.position.y, -0.5f);
  }

    /*void FixedUpdate()
    {
          if (jump) {
              rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
          }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        //destroy bricks
        var selectionRenderer = transform.GetComponent<Renderer>();

        //Finish level
        if (collision.gameObject.name.StartsWith("Goalpost"))
        {
            UI.GetComponent<UIScript>().win();
        }

        //are you jumping?
        if (Mathf.Abs(rb.velocity.y) < 0.1 && collision.transform.position.y - 2 > transform.position.y)
        {
            if (collision.gameObject.name.StartsWith("Brick"))
            {
                UI.GetComponent<UIScript>().scorePoints(100, 0);
                //Debug.Log("Block destroyed");
                Destroy(collision.gameObject);
                return;
            }

            //get a coin from a mystery box
            if (collision.gameObject.name.StartsWith("Question"))
            {
                GameObject ToSpawn;
                UI.GetComponent<UIScript>().scorePoints(100, 1);
                var oldTransform = collision.gameObject.transform.position;
                Destroy(collision.gameObject);
                ToSpawn = GameObject.Instantiate(stone, parentTransform);
                ToSpawn.transform.position = oldTransform;
            }

            
        }
    }
}
