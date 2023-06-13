using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionPlayerController : MonoBehaviour
{
    private PlayerInputSystem playerInputSystem;

    private bool itHasItem;

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
        if (itHasItem)
        {
            RaycastHit hit;
            Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Item"))
                {
                    //Acao de pegar item
                    GameObject item = hit.collider.gameObject;
                    Debug.Log("Peguei um item");
                }
                else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("DropZone"))
                {
                    //Acao de soltar o item
                    GameObject dropZone = hit.collider.gameObject;
                    Debug.Log("estou mirando em um lugar para soltar");
                }
            }
        }
    }

    private void PickingUpItensInput(InputAction.CallbackContext context)
    {
        itHasItem = context.ReadValueAsButton();
        if (itHasItem)
        {
            Debug.Log("estou funcionado");
        }
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
