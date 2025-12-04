using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 12f;
    [SerializeField] private float dashDuration = 0.15f;
    [SerializeField] private float dashCooldown = 0.4f;

    //Gun variables
    [Header("Shooting")]
    [SerializeField] private GameObject bulletProfab;
    [SerializeField] private Transform Firingpoint;
    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.25f;

    private Rigidbody2D rb;
    private float mx;
    private float my;

    private Vector2 mousePos;
    private float fireTimer;

    // Dash internal state
    private bool isDashing = false;
    private bool canDash = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Rotate player toward mouse
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        // Shooting
        if (Input.GetMouseButton(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }

        // Dash input
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = new Vector2(mx, my).normalized * speed;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        // Dash velocity
        Vector2 dashDirection = new Vector2(mx, my).normalized;

        // If not moving, dash forward (toward mouse direction)
        if (dashDirection == Vector2.zero)
        {
            Vector2 dirToMouse = (mousePos - (Vector2)transform.position).normalized;
            dashDirection = dirToMouse;
        }

        rb.velocity = dashDirection * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }

    private void Shoot()
    {
        Instantiate(bulletProfab, Firingpoint.position, Firingpoint.rotation);
    }
}


 