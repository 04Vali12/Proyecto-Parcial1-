using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Froger : MonoBehaviour
{
    public float salud;
    public float Velocidad;
    private Rigidbody2D rb;
    private Vector2 velocidadMov;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocidadMov = moveInput.normalized * Velocidad;
        rb.MovePosition(rb.position + velocidadMov * Time.fixedDeltaTime);
    } 
 }


