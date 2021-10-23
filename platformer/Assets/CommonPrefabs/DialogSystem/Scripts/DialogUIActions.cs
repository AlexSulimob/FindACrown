using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class DialogUIActions : MonoBehaviour
{
    public InputActionReference nextLineAction;

    DialogUICustom dialogUI;

    bool isOptionDisplayed;

    private void OnEnable()
    {
        nextLineAction.action.Enable();
    }
    private void OnDisable()
    {
        nextLineAction.action.Disable();
    }

    void Start()
    {
        dialogUI = GetComponent<DialogUICustom>();

        nextLineAction.action.performed += context => DialogAction();
    }


    void DialogAction()
    {
        if (!dialogUI.isOptionsDislpayed)
            dialogUI.MarkLineComplete();
    }


}
