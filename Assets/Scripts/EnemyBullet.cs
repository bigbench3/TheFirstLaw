using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour {
    public float speed = 12f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        Debug.Log(transform.eulerAngles.y);
        if (transform.eulerAngles.y > 89 && transform.eulerAngles.y < 91) {
            pos.x += speed * Time.deltaTime;
        } else if (transform.eulerAngles.y > 170 && transform.eulerAngles.y < 181) {
            pos.z -= speed * Time.deltaTime;
        } else if (transform.eulerAngles.y > 269 && transform.eulerAngles.y < 271) {
            pos.x -= speed * Time.deltaTime;
        } else {
            pos.z += speed * Time.deltaTime;
        }

        transform.position = pos;
    }

    public void Remove() {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision col) {
        GameObject obj = col.gameObject;

        if (obj.tag == "Player") {
            SceneManager.LoadScene("Level2");
        }

        Destroy(this.gameObject);
    }
}