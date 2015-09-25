using UnityEngine;
using System.Collections;

public class CameraMoving : MonoBehaviour
{
    public JoyStick MyStick; // virtual joystick in hierarchy
    public GameButton ShootButton; // shooting button
    float speed = 0.5f; // rotation speed for main camera

    public Transform LeftGun, RightGun; // gun's transform for rotate
    public ParticleSystem LeftBullet, RightBullet; // bullet particles
    public ParticleEmitter LeftFire, RightFire; // gunfire particles

    void Start()
    {
        Physics.IgnoreLayerCollision(8, 8); // disable UFO's collision
    }

	void Update()
	{
        if (MyStick.isClick) // camera axis rotation, if you press virtual joystick
        {
            transform.Rotate(Vector3.up, MyStick.GetHorizontal() * speed * Time.deltaTime);
            transform.Rotate(Vector3.left, MyStick.GetVertical() * speed * Time.deltaTime);
        }
        else // if you dont use a joystick, can use keyboard in control
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * 50f * Time.deltaTime); 
            transform.Rotate(Vector3.left, Input.GetAxis("Vertical") * 50f * Time.deltaTime);
        }

        if (ShootButton.isClick) // when you pressed shoot button
        {
            LeftGun.localRotation = Quaternion.AngleAxis(Time.time * 500f, Vector3.down); // left gun rotation
            RightGun.localRotation = Quaternion.AngleAxis(Time.time * 500f, Vector3.up); // right gun rotation

            LeftBullet.enableEmission = RightBullet.enableEmission = true; // enable bullet particles
            LeftFire.emit = RightFire.emit = true; // enable gunfire particles
        }
        else
        {
            LeftBullet.enableEmission = RightBullet.enableEmission = false; // disable bullet particles
            LeftFire.emit = RightFire.emit = false; // disable gunfire particles
        }
	}
}
