using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed = 10.0f;
    int Count = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Count == 10)
        SceneManager.LoadScene("End");
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector3.right * speed);
        }

    }

    void OnCollisionEnter(Collision CoinCol)
    {
        Coin coin = CoinCol.gameObject.GetComponent<Coin>();
        if (coin)
        {
            Destroy(CoinCol.gameObject);
            Count = Count + 1;
        }
    }
}
