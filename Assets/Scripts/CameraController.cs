using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraController : NetworkBehaviour
{
    [SerializeField] GameObject camHolder;
    [SerializeField] GameObject cam;

    float pitch;

    [SerializeField] float sensitivity;
    public override void OnStartAuthority()
    {
        cam.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) { return; }
        Cursor.visible = false;

        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        pitch -= mouseDelta.y * sensitivity;
        pitch = Mathf.Clamp(pitch, -90, 90);

        camHolder.transform.localEulerAngles = Vector3.right * pitch;

        transform.Rotate(Vector3.up * mouseDelta.x * sensitivity);
    }
}
