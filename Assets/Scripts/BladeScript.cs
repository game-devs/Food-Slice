using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script represents the blade that hits the food (they player)
public class BladeScript : MonoBehaviour
{
    private Collider bladeCollider;
    private Camera mainCamera;
    private TrailRenderer bladeTrail;

    private const int mouseLeftKey = 0;
    private Boolean slicing = false;

    [SerializeField]
    private float eps = 0.01f;

    public Vector3 direction { get; private set; } // get public set private

    private void Awake()
    {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<Collider>();
        bladeTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        StopSlice();
    }

    private void OnDisable()
    {
        StopSlice();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(mouseLeftKey))
        {
            StartSlice();
        }
        else if (Input.GetMouseButtonUp(mouseLeftKey))
        {
            StopSlice();
        }
        else if (slicing)
        {
            ContinueSlicing();
        }
    }

    // adjust the camera and mouse positions.
    //what happen when we start slicing.
    private void StartSlice()
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0f;
        transform.position = position;

        slicing = true;
        bladeCollider.enabled = true;
        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }

    //what happen when we stop slicing.
    private void StopSlice()
    {
        slicing = false;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;
    }

    //balde following the mouse
    private void ContinueSlicing()
    {
        Vector3 bladeNewPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        bladeNewPos.z = 0f;

        direction = bladeNewPos - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > eps;

        transform.position = bladeNewPos;
    }
}
