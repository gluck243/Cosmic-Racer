using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public GameObject playerShip;

    private float height = 4.0f;
    private float distance = 5.0f;
    private float followDamping = 8f;
    private float rotationDamping = 100.0f;

    void Start() {
        transform.position = playerShip.transform.TransformPoint(0f, height, -distance);
    }
    
    void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, playerShip.transform.TransformPoint(0f, height, -distance), Time.deltaTime * followDamping);
        Quaternion rotation =
            Quaternion.LookRotation(playerShip.transform.position
            - transform.position + Vector3.up * 3);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
            Time.deltaTime * rotationDamping);
    }
}
// The PlayerCamera script is attached to the Main Camera GameObject. The script has a public GameObject variable called playerShip that is used to reference the player ship GameObject. The height and distance variables are used to set the position of the camera relative to the player ship. The followDamping and rotationDamping variables are used to control the smoothness of the camera movement and rotation.