using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float cameraAxisX = -90f;
    [SerializeField] private float speedPlayer = 10f;
    [SerializeField] private bool isSizeChanged = false;
    Portal portal;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Move();
        RotatePlayer();
    }

    private void Move()
    {
        float ejeHorizontal = Input.GetAxisRaw("Horizontal");
        float ejeVertical = Input.GetAxisRaw("Vertical");
        transform.Translate(speedPlayer * Time.deltaTime * new Vector3(ejeHorizontal, 0, ejeVertical));
    }

    private void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion angle = Quaternion.Euler(0, cameraAxisX, 0);
        transform.localRotation = angle;
    }


    private void OnTriggerEnter(Collider other)
    {
        var isShrinker = other.TryGetComponent<Portal>(out portal) ? "Is a component Shrinker" : " Is not a component Shrinker";
        print(other.name + " " + isShrinker);
    }

    public void ChangeSize()
    {
        transform.localScale = isSizeChanged ? Vector3.one : Vector3.one * 0.5f;
        isSizeChanged = !isSizeChanged;
    }
}
