using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
    public Text countText;
    public Text winText;
    public float jump;
	private Rigidbody rb;
    private int count;
	void Start(){
		rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        SetCountText();
    }
    void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        Vector3 ju = new Vector3(0, jump, 0);
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(ju * speed);
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        rb.AddForce (movement*speed);
        if((rb.position.x>10.5 || rb.position.z>10.5 || rb.position.x<-10.5 || rb.position.z<-10.5)&&(rb.position.y<0))
        {
            rb.gameObject.SetActive(false);
            winText.text = "YOU LOSE!";
            Application.Quit();
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))  
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count>=14)
        {
            winText.text = "YOU WIN!";
            rb.gameObject.SetActive(false);
            Application.Quit();
        }
    }
}
