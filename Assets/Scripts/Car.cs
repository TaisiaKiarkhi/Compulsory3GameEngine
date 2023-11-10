using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float change_x, change_y;
    float speed_move = 0.5f, speed = 5.0f;
    float weight = 1500f;
 
    // Update is called once per frame
    void Update()
    {
        key_input();
        GetComponent<Rigidbody>().mass = weight;
    }

    void key_input()
    {
        change_x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.W))
        {
            speed_move += 1.0f;
        }
        transform.Translate(change_x, 0, speed_move * Time.deltaTime);
    }
}
