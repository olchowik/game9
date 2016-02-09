using UnityEngine;
using System.Collections;
/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class DestroyOnColision : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
     //   Destroy(gameObject);

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
