using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionPlayerController : MonoBehaviour
{
    private PlayerInputSystem playerInputSystem;

    private bool getItens;
    [SerializeField] private GameObject objHolding;
    [SerializeField] private GameObject objAim;
    [SerializeField] private bool isHolding;
    [SerializeField] private Transform handTransform;
    [SerializeField] private float maxDistanceRay;

    private void Awake()
    {
        playerInputSystem = new PlayerInputSystem();

        playerInputSystem.Player.MouseClick.started += PickingUpItensInput;
        playerInputSystem.Player.MouseClick.canceled += PickingUpItensInput;
    }

    private void Update()
    {
        PickingUpItens();
    }

    private void PickingUpItens()
    {
        if (getItens)
        {
            RaycastHit hit;
            Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);

            if (Physics.Raycast(ray, out hit, maxDistanceRay))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Item"))
                {
                    if (!isHolding)
                    {
                        isHolding = true;
                        objHolding = hit.transform.gameObject;
                        if (objHolding.GetComponent<Rigidbody>())
                        {
                            objHolding.GetComponent<Rigidbody>().isKinematic = true;
                            objHolding.transform.position = handTransform.transform.position;
                            objHolding.transform.rotation = handTransform.transform.rotation;
                            objHolding.transform.parent = handTransform.transform;
                        }
                    }
                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("DropZone"))
                {
                    objAim = hit.transform.gameObject;
                    Vector3 offset = new Vector3(0, 0.08f, 0);
                    if (isHolding)
                    {
                        objHolding.GetComponent<Rigidbody>().isKinematic = true;
                        objHolding.transform.position = objAim.transform.position + offset;
                        objHolding.transform.rotation = objAim.transform.rotation;
                        objHolding.transform.SetParent(objAim.transform);
                    }
                }
                else if (hit.collider.gameObject.layer == 0)
                {
                    if (isHolding)
                    {
                        if (objHolding.GetComponent<Rigidbody>())
                        {
                            objHolding.GetComponent<Rigidbody>().isKinematic = true;
                            objHolding.transform.position = handTransform.transform.position;
                            objHolding.transform.rotation = handTransform.transform.rotation;
                            objHolding.transform.parent = handTransform.transform;
                        }
                    }
                }
            }
        }
        else
        {
            if (isHolding)
            {
                Transform previourParent = objHolding.transform.parent;
                objHolding.transform.parent = null;

                objHolding.GetComponent<Rigidbody>().isKinematic = false;
                objHolding = null;
                isHolding = false;

                if(previourParent != null)
                {
                    objHolding.transform.SetParent(previourParent);
                }
            }
        }
    }

    private void PickingUpItensInput(InputAction.CallbackContext context)
    {
        getItens = context.ReadValueAsButton();
    }

    private void OnEnable()
    {
        playerInputSystem.Player.Enable();
    }
    private void OnDisable()
    {
        playerInputSystem.Player.Disable();
    }
}
