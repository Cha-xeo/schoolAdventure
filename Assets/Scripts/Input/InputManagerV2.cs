using System;
using UnityEngine.InputSystem;
using UnityEngine;

namespace SchoolAdventure.Input
{
    public class ExampleScript : MonoBehaviour
    {
        // assign the actions asset to this field in the inspector:
        public InputActionAsset actions;

        // private field to store move action reference
        private InputAction moveAction;

        void Awake()
        {
            // find the "move" action, and keep the reference to it, for use in Update
            moveAction = actions.FindActionMap("gameplay").FindAction("move");

            // for the "jump" action, we add a callback method for when it is performed
            actions.FindActionMap("gameplay").FindAction("jump").performed += OnJump;
        }

        void Update()
        {
            // our update loop polls the "move" action value each frame
            Vector2 moveVector = moveAction.ReadValue<Vector2>();
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            // this is the "jump" action callback method
            Debug.Log("Jump!");
        }

        void OnEnable()
        {
            actions.FindActionMap("gameplay").Enable();
        }
        void OnDisable()
        {
            actions.FindActionMap("gameplay").Disable();
        }
    }
    public class InputManagerV2 : MonoBehaviour
    {
        ExampleScript actions;
        public InputAction Move;
        public InputAction Fire;
        public InputAction Interraction;
        public InputAction Submit;
        public InputAction Journal;
        public InputAction jump;
        public InputAction MousePosition;
        public InputAction MouseRightClick;
        public InputAction MouseLeftClick;
        public InputAction Escape;
        public InputAction SaveGame;
        public InputAction LoadGame;
        public InputAction Up;
        public InputAction Down;
        public InputAction Left;
        public InputAction Right;
        public static InputManagerV2 Instance { get; private set; }

        public Vector2 inputVector;
        public Vector2 mouseVector;
        public bool submit = false;
        public bool interact = false;

        private void Awake()
        {
            //SceneManager.activeSceneChanged += SwitchCam;
            if (Instance == null)
            {
                Instance = this;
                Fire.started += ctx => { OnFire(ctx); };
                Fire.performed += ctx => { OnFireperformed(ctx); };
                Interraction.started += ctx => { OnInterraction(ctx); };
                Interraction.performed += ctx => { OnInterractionperformed(ctx); };
                Submit.started += ctx => { OnSubmit(ctx); };
                Submit.performed += ctx => { OnSubmitperformed(ctx); };
                jump.started += ctx => { Onjump(ctx); };
                jump.performed += ctx => { Onjumpperformed(ctx); };
                MouseRightClick.started += ctx => { OnMouseRightClick(ctx); };
                MouseRightClick.performed += ctx => { OnMouseRightClickperformed(ctx); };
                MouseLeftClick.started += ctx => { OnMouseLeftClick(ctx); };
                MouseLeftClick.performed += ctx => { OnMouseLeftClickperformed(ctx); };
                Escape.started += ctx => { OnEscape(ctx); };
                Escape.performed += ctx => { OnEscapeperformed(ctx); };
                Journal.started += ctx => { OnEscape(ctx); };
                Journal.performed += ctx => { OnEscapeperformed(ctx); };
                SaveGame.started += ctx => { OnSaveGame(ctx); };
                SaveGame.performed += ctx => { OnSaveGameperformed(ctx); };
                LoadGame.started += ctx => { OnLoadGame(ctx); };
                LoadGame.performed += ctx => { OnLoadGameperformed(ctx); };
                Up.started += ctx => { OnUp(ctx); };
                Up.performed += ctx => { OnUpperformed(ctx); };
                Down.started += ctx => { OnDown(ctx); };
                Down.performed += ctx => { OnDownperformed(ctx); };
                Left.started += ctx => { OnLeft(ctx); };
                Left.performed += ctx => { OnLeftperformed(ctx); };
                Right.started += ctx => { OnRight(ctx); };
                Right.performed += ctx => { OnRightperformed(ctx); };

        //DontDestroyOnLoad(gameObject);
    }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            inputVector = Move.ReadValue<Vector2>();
            mouseVector = MousePosition.ReadValue<Vector2>();
        }

        public void OnFire(InputAction.CallbackContext context) 
        {
            
        }
        public void OnFireperformed(InputAction.CallbackContext context) 
        {
            
        }
        public void OnInterraction(InputAction.CallbackContext context) 
        {
            interact = true;
            Debug.Log(interact);
        }
        public void OnInterractionperformed(InputAction.CallbackContext context) 
        {
            interact = false;
            Debug.Log(interact);
        }
        public void OnSubmit(InputAction.CallbackContext context) { }
        public void OnSubmitperformed(InputAction.CallbackContext context) { }
        public void Onjump(InputAction.CallbackContext context) { }
        public void Onjumpperformed(InputAction.CallbackContext context) { }
        public void OnMouseRightClick(InputAction.CallbackContext context) { }
        public void OnMouseRightClickperformed(InputAction.CallbackContext context) { }
        public void OnMouseLeftClick(InputAction.CallbackContext context) { }
        public void OnMouseLeftClickperformed(InputAction.CallbackContext context) { }
        public void OnEscape(InputAction.CallbackContext context) { }
        public void OnEscapeperformed(InputAction.CallbackContext context) { }
        public void OnJournal(InputAction.CallbackContext context) { }
        public void OnJournalperformed(InputAction.CallbackContext context) { }
        public void OnSaveGame(InputAction.CallbackContext context) { }
        public void OnSaveGameperformed(InputAction.CallbackContext context) { }
        public void OnLoadGame(InputAction.CallbackContext context) { }
        public void OnLoadGameperformed(InputAction.CallbackContext context) { }
        public void OnUp(InputAction.CallbackContext context) { }
        public void OnUpperformed(InputAction.CallbackContext context) { }
        public void OnDown(InputAction.CallbackContext context) { }
        public void OnDownperformed(InputAction.CallbackContext context) { }
        public void OnLeft(InputAction.CallbackContext context) { }
        public void OnLeftperformed(InputAction.CallbackContext context) { }
        public void OnRight(InputAction.CallbackContext context) { }
        public void OnRightperformed(InputAction.CallbackContext context) { }

        public void OnEnable()
        {
            Move.Enable();
            Fire.Enable();
            Interraction.Enable();
            Submit.Enable();
            jump.Enable();
            MousePosition.Enable();
            MouseRightClick.Enable();
            MouseLeftClick.Enable();
            Escape.Enable();
            Journal.Enable();
            SaveGame.Enable();
            LoadGame.Enable();
            Up.Enable();
            Down.Enable();
            Left.Enable();
            Right.Enable();
        }
        public void OnDisable()
        {
            Move.Disable();
            Fire.Disable();
            Interraction.Disable();
            Submit.Disable();
            jump.Disable();
            MousePosition.Disable();
            MouseRightClick.Disable();
            MouseLeftClick.Disable();
            Escape.Disable();
            Journal.Disable();
            SaveGame.Disable();
            LoadGame.Disable();
            Up.Disable();
            Down.Disable();
            Left.Disable();
            Right.Disable();
        }
    }
}
