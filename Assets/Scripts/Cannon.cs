using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public int rotationSpeed;
    bool rotation = true;
    int direction = 1;
    float holdDownStartTime;
    public float launchForce;
    public GameObject launchDirObj;
    public GameObject ball;


    // Start is called before the first frame update
    void Start()
    {
        rotation = true;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z <= 100){
            direction = -1;
        }
        if(transform.rotation.eulerAngles.z >=350){
            direction = 1;
        }
        if(rotation==true){
            transform.Rotate(new Vector3(0, 0, direction * rotationSpeed * Time.deltaTime));
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            holdDownStartTime = Time.time;
            rotation = false;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            rotation = true;
            float holdDownTime = Time.time - holdDownStartTime;
            CalculateForce(holdDownTime);
            LaunchBall(CalculateForce(holdDownTime));
        }
    }

    public float CalculateForce(float time){
        float maxHoldDownTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(time / maxHoldDownTime);
        float force = holdTimeNormalized * launchForce;
        return force;
    }

    public void LaunchBall(float force){
        Vector3 position = new Vector3(launchDirObj.transform.position.x, launchDirObj.transform.position.y, launchDirObj.transform.position.z);
        Vector3 launchDir = new Vector3(position.x-transform.position.x, position.y-transform.position.y, position.z-transform.position.z);
        GameObject newBall = Instantiate(ball);
        newBall.transform.position = position;
        newBall.GetComponent<Rigidbody2D>().AddForce(launchDir * launchForce * force);
    }
}
