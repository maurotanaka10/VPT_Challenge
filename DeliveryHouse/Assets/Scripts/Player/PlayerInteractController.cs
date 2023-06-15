using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractController : MonoBehaviour
{
    private PlayerInputSystem playerInputSystem;

    private bool mouseClicked;
    [SerializeField] private GameObject objHolding;
    [SerializeField] private GameObject objAim;
    [SerializeField] private float maxDistanceRay;
    [SerializeField] private Transform handTransform;
    private bool isHolding;

    private void Awake()
    {
        playerInputSystem = new PlayerInputSystem();

        playerInputSystem.Player.MouseClick.started += PickingUpItensInput;
        playerInputSystem.Player.MouseClick.canceled += PickingUpItensInput;
    }

    private void InteractingItens()
    {
        RaycastHit[] hits;
        Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        hits = Physics.RaycastAll(ray, maxDistanceRay, LayerMask.GetMask("Interactable"));

        foreach (var hit in hits)
        {
            if (mouseClicked)
            {
                if (hit.collider.gameObject.tag == ("Item"))
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
                        break;
                    }
                }
            }
            else
            {
                if (!objHolding)
                    return;

                if (hit.collider.gameObject.tag == ("Dish"))
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

                Transform previourParent = objHolding.transform.parent;
                objHolding.transform.parent = null;

                objHolding.GetComponent<Rigidbody>().isKinematic = false;
                objHolding = null;
                isHolding = false;

                break;
            }
        }
    }

    private void PickingUpItensInput(InputAction.CallbackContext context)
    {
        mouseClicked = context.ReadValueAsButton();

        InteractingItens();
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
