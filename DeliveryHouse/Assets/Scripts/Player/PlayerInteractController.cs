using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractController : MonoBehaviour
{
    private PlayerInputSystem _playerInputSystem;
    [SerializeField] private BurgerValidate _burgerValidate;
    [SerializeField] private CleanDish _cleanDish;
    [SerializeField] private AudioController _audioController;

    private bool _mouseClicked;
    private GameObject _objHolding;
    private GameObject _objAim;
    [SerializeField] private float _maxDistanceRay;
    [SerializeField] private Transform _handTransform;
    private bool _isHolding;
    private Vector3 offset;

    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();

        _playerInputSystem.Player.MouseClick.started += PickingUpItensInput;
        _playerInputSystem.Player.MouseClick.canceled += PickingUpItensInput;
    }

    private void InteractingItens()
    {
        RaycastHit[] hits;
        Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        hits = Physics.RaycastAll(ray, _maxDistanceRay, LayerMask.GetMask("Interactable"));

        foreach (var hit in hits)
        {
            if (_mouseClicked)
            {
                if (!_isHolding)
                {
                    if (hit.collider.gameObject.tag == "Button")
                    {
                        _burgerValidate.IngredientsOnPlate.Clear();
                        _cleanDish.CleanDishAfterRecipe();
                        break;
                    }

                    if (hit.collider.gameObject.tag == ("Dish"))
                    {
                        continue;
                    }

                    _isHolding = true;
                    _objHolding = hit.transform.gameObject;
                    _cleanDish.AddItensToDestroy(_objHolding);
                    _audioController.CatchSomethingSound();
                    if (_objHolding.GetComponent<Rigidbody>())
                    {
                        _objHolding.GetComponent<Rigidbody>().isKinematic = true;
                        _objHolding.transform.position = _handTransform.transform.position;
                        _objHolding.transform.rotation = _handTransform.transform.rotation;
                        _objHolding.transform.parent = _handTransform.transform;
                    }
                    break;
                }

            }
            else
            {
                if (!_isHolding)
                    return;

                if (hit.collider.gameObject.tag == ("Dish"))
                {
                    DishController dishController = hit.collider.gameObject.GetComponent<DishController>();
                    Vector3 offset = new Vector3(0, 0, 0);

                    if (dishController.lastItem == null)
                    {
                        _objAim = hit.transform.gameObject;
                        offset = new Vector3(0, 0.02f, 0);
                    }
                    else
                    {
                        _objAim = dishController.lastItem;
                        offset = new Vector3(0, 0.01f, 0);
                    }

                    
                    _objHolding.GetComponent<Rigidbody>().isKinematic = true;
                    _objHolding.transform.position = _objAim.transform.position + offset;
                    _objHolding.transform.rotation = _objAim.transform.rotation;
                    _objHolding.transform.SetParent(_objAim.transform);
                    _burgerValidate.AddIngredientsToPlate(_objHolding);
                    dishController.lastItem = _objHolding;
                    _isHolding = false;
                    _objHolding = null;
                    break;
                }
            }
        }

        if (_isHolding && !_mouseClicked)
        {
            _objHolding.transform.parent = null;
            _objHolding.GetComponent<Rigidbody>().isKinematic = false;
            _objHolding = null;
            _isHolding = false;
        }
    }

    private void PickingUpItensInput(InputAction.CallbackContext context)
    {
        _mouseClicked = context.ReadValueAsButton();

        InteractingItens();
    }

    private void OnEnable()
    {
        _playerInputSystem.Player.Enable();
    }
    private void OnDisable()
    {
        _playerInputSystem.Player.Disable();
    }
}
