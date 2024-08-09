using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private objectPool bulletsPool;
    [SerializeField] private Rigidbody bullet;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Camera myCamera;
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Transform PickupTip;

    [Header("Interaction Settings")]
    [SerializeField] private LayerMask interactableFilter;
    

    [Header("Movement Settings")]
    [SerializeField] private float Speed;
    [SerializeField] private float looksensitivity;
    [SerializeField] private float sprintMultipiier;
    [SerializeField] private float jumpForce;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody rigidbodyp;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private LayerMask layerFilter;
    private bool disabled;
    private IInteractable selectedInteraaction;
    private Vector3 moveDirection;
    private Vector2 lookDirection;

    [SerializeField] CommanderModule commanderModule;

    private const float gravity = -9.81f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        disabled = false;
    }

    public void DisablePlayer(bool isDisabled)
    {
        disabled = isDisabled;
    }
    void Update()
    {
        if (!disabled)
        {
            MovePlayer();
            ShootWeapon();
        }
        
        rotatePlayer();
        JumpPlayer();
        GravityCaclulation();
      
        Interact();
        SendCommand();
        

    }

    private void Interact()
    {
       
        Ray ray = new Ray(myCamera.transform.position, myCamera.transform.forward);

        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction, Color.red, 3f);

        if (Physics.Raycast(ray, out hit, 10f, interactableFilter))
        {
           if(selectedInteraaction == null)
           {
             selectedInteraaction = hit.collider.gameObject.GetComponent<IInteractable>();
             selectedInteraaction.OnHoverEnter();
           }
           else if (Input.GetKeyDown(KeyCode.E))
           {
             selectedInteraaction.Interact(this);
             
           }
            
        }
        else if(selectedInteraaction != null)
        {
           selectedInteraaction.OnHoverExit();
           selectedInteraaction = null;
        }

        
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, controller.radius, layerFilter);
    }

    void GravityCaclulation()
    {
        
        if (!IsGrounded())
        {
            velocity.y += gravity + Time.deltaTime;
        }
        else if (velocity.y <= 0)
        {
            velocity.y = -1f;
        }
        controller.Move(velocity * Time.deltaTime);
    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            velocity.y = jumpForce;
        }
    }

    void MovePlayer()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        Vector3 moveForword = transform.forward * moveDirection.z;
        Vector3 moveRight = transform.right * moveDirection.x;

        float speedMultipler = 1;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedMultipler = sprintMultipiier;
        }

        controller.Move((moveForword + moveRight) * Time.deltaTime * Speed * speedMultipler);
    }

    void ShootWeapon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            PooledObject pooledObj = bulletsPool.RetrivePoolObject();
            Rigidbody projectileClone = pooledObj.GetRigidbody();
            projectileClone.position = weaponTip.position;
            projectileClone.rotation = weaponTip.rotation;
            projectileClone.AddForce(myCamera.transform.forward * projectileSpeed, ForceMode.Impulse);
            pooledObj.ResetPooledObject(5f);
        }
    }

    void rotatePlayer()
    {
        lookDirection.x += Input.GetAxisRaw("Mouse X") * Time.deltaTime * looksensitivity;
        lookDirection.y += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * looksensitivity;

        lookDirection.y = Mathf.Clamp(lookDirection.y, -85f, 85f);

        myCamera.transform.localRotation = Quaternion.Euler(-lookDirection.y, 0, 0);
        transform.rotation = Quaternion.Euler(0, lookDirection.x, 0);

    }

    public void PickObject(Pickable pick)
    {
        pick.transform.rotation = PickupTip.rotation;
        pick.transform.position = PickupTip.position;
        
       
    }

    public void DropObject(Pickable pick)
    {

    }

    public Rigidbody GetPlayerRigidbody()
    {
        return rigidbodyp;
    }

    public Transform GetPickUpLoactation()
    {
        return PickupTip;
    }

    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
        }
    }

    private void SendCommand()
    {
        if (Input.GetMouseButtonDown(1))
        {
            commanderModule.CreateCommand();
        }
    }

    public void TpPlayer(GameObject respawnPoint)
    {
        controller.enabled = false;
        this.transform.position = respawnPoint.transform.position;
        controller.enabled = true;
    }

    
}
