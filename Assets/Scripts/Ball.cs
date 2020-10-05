using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject target;
	public int rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(new Vector3(0, 0, -1 * rotationSpeed * Time.deltaTime));
	}

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            GameObject.Find("ScoreUI").GetComponent<Score>().LivesDown();
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Target"){
            GameObject.Find("ScoreUI").GetComponent<Score>().ScoreUp();
            Vector3 newTargetPos = new Vector3(1.325f, Random.Range(1.0f, 0.015f), 0);
            GameObject ball = Instantiate(target);
            ball.transform.position = newTargetPos;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
