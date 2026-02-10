using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float movespeed = 1f;

    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0f, v);
        controller.Move(move * movespeed * Time.deltaTime);
    }
}
