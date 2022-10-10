using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 7; // Put here the number of pickups you have .
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI positionText;
    public TextMeshProUGUI velocityText;
    public TextMeshProUGUI distanceText;
    public Vector3 oldposition;
    public Vector3 newposition;
    public float velocity;
    void Start()
    {
        count = 0;
        winText.text = "";
        positionText.text = "";
        velocityText.text = "";
        distanceText.text = "";
        SetCountText();
        oldposition = transform.position;
        PositionText();
        VelocityText();
    }
    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();

    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
        newposition = transform.position;
        PositionText();
        VelocityText();
    }
void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    private void SetCountText()
    {
        scoreText.text = " Score : " + count.ToString();
        if (count >= numPickups)
        {
            winText.text = " You win ! ";
        }
    }
    private void Update()
    {

        

    }
    private void PositionText()
    {
        positionText.text = "position" + newposition.ToString();
    }
    private void VelocityText()
    {
        float dis = (newposition - oldposition).magnitude;
        velocity = dis / Time.deltaTime;
        oldposition = newposition;
        velocityText.text = "velocity" + velocity.ToString();
        
    }
}


