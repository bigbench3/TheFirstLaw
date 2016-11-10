using UnityEngine;
using System.Collections;

public class FPSInput : MonoBehaviour {
	public const float BASE_SPEED = 6.0f;

    public float speed;
    public float gravity = -9.8f;
    public float jumpSpeed = 100;
    public float vertSpeed = 0;

    private CharacterController charController;

    void Start() {
        charController = GetComponent<CharacterController>();
    }

    void Update() {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        if (charController.isGrounded) {
            if (Input.GetButtonDown("Jump"))
                vertSpeed = jumpSpeed;
            else
                vertSpeed = 0;
        } else {
            vertSpeed += gravity;
        }
		if (Input.GetButton ("LeftStick")||Input.GetButton("Run")) {
			Debug.Log ("Left Stick pressed");
			speed = BASE_SPEED*2;

		} else {
			speed = BASE_SPEED;
		}

        movement = new Vector3(deltaX, vertSpeed, deltaZ);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
		
}
