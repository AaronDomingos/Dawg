//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/004-Scripts/Player/UserInput/UserInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @UserInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @UserInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UserInput"",
    ""maps"": [
        {
            ""name"": ""Drone"",
            ""id"": ""74830570-94ea-4df4-a9e7-690fa1db7337"",
            ""actions"": [
                {
                    ""name"": ""Thrust"",
                    ""type"": ""Value"",
                    ""id"": ""36406cc6-a007-43e8-a19e-f220426bcb7e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""010150ca-81ea-4b65-a6cf-1af9e1321158"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""a826e5ca-bd56-45c7-be57-1653ed3464df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""deb3833a-b057-4317-9799-e3af3730bb76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""bb62536c-69ee-48fd-a69a-194bd0a71690"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""3976c6f1-32d0-48ea-a92a-621e3fc6de73"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ef30833e-5d57-4050-805e-600ed12ca0d6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b227c4bf-154f-4934-9acf-1e28e196f3bc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""01455861-357d-4e46-b499-c6dcdc3f88e5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b137e9b8-4942-4d3b-80b2-759e5b6dfdc3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""543e6790-cc04-4228-9255-5e7c2a1cf483"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54172d90-de96-43c8-b736-a74e63e9467a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13bbdbbf-6e1e-4892-a8aa-2c90bff1a098"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7aa01e0-0135-410a-b94c-96621a9a9db4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cea5e366-303b-4711-b5d9-527b4c577d7b"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35d88fc2-b31e-47ea-9430-85d7def7b8d5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04b35cc5-d686-45b3-a89f-1e7f2e16ed51"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Crew"",
            ""id"": ""24ca4ed4-1d5a-4568-afb1-99165889a2ef"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""4ab16952-dda2-47f8-8965-7ef2159c608c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7281e533-d679-42ca-a4f9-aa5bf9b90e08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""f344bddf-cdeb-4dcf-a74f-9b6a94b67e8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""212e8575-301f-4cd2-88b0-9d98b17d888c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f5bde55c-c336-41f7-ba30-f1b4289ddd81"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b62f3375-ec11-4ded-9301-aa06e6a75b03"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cc305768-8d16-42a3-8b53-dd5468fce6e3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""55412a3a-e900-4b95-bfa6-8122678871af"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e680bf52-dbf4-4687-847e-ef99fd8492bb"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b279d69d-3da5-4b5e-a7be-0b7592b3f722"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d518f31-901e-4472-a121-055a0b475a91"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2c9cde6-fdc8-4764-a6d4-d11459d61c58"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc4c9097-fd04-40dc-9441-64eb37a863d1"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""User"",
            ""id"": ""0916df10-d4f5-449a-bb69-bd1d6b14ab58"",
            ""actions"": [
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""f104975c-93f0-46fd-88b9-bf10f4e01274"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextPlayable"",
                    ""type"": ""Button"",
                    ""id"": ""5a1d6b75-a28e-4742-911b-00a52ff46439"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LastPlayable"",
                    ""type"": ""Button"",
                    ""id"": ""d01ea426-bbf6-4ed0-932e-7e4d4fcf4ac3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6c53143a-5a0c-40eb-857c-b4ecd5ea1bcf"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35f8c626-79ac-4694-adef-dfb768f56b3d"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a8b1b90-f1f1-44bb-a885-59e945f71a13"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextPlayable"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98870e9f-cfd5-4eee-8743-cbe07154ea22"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextPlayable"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bf524ee-fc13-4fdb-af72-96c4447e1b08"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LastPlayable"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Admin"",
            ""id"": ""c0aba9b0-88f3-4b8f-be23-caa80918b836"",
            ""actions"": [],
            ""bindings"": []
        }
    ],
    ""controlSchemes"": []
}");
        // Drone
        m_Drone = asset.FindActionMap("Drone", throwIfNotFound: true);
        m_Drone_Thrust = m_Drone.FindAction("Thrust", throwIfNotFound: true);
        m_Drone_Rotate = m_Drone.FindAction("Rotate", throwIfNotFound: true);
        m_Drone_Interact = m_Drone.FindAction("Interact", throwIfNotFound: true);
        m_Drone_Cancel = m_Drone.FindAction("Cancel", throwIfNotFound: true);
        m_Drone_PrimaryWeapon = m_Drone.FindAction("PrimaryWeapon", throwIfNotFound: true);
        // Crew
        m_Crew = asset.FindActionMap("Crew", throwIfNotFound: true);
        m_Crew_Walk = m_Crew.FindAction("Walk", throwIfNotFound: true);
        m_Crew_Interact = m_Crew.FindAction("Interact", throwIfNotFound: true);
        m_Crew_Cancel = m_Crew.FindAction("Cancel", throwIfNotFound: true);
        // User
        m_User = asset.FindActionMap("User", throwIfNotFound: true);
        m_User_Quit = m_User.FindAction("Quit", throwIfNotFound: true);
        m_User_NextPlayable = m_User.FindAction("NextPlayable", throwIfNotFound: true);
        m_User_LastPlayable = m_User.FindAction("LastPlayable", throwIfNotFound: true);
        // Admin
        m_Admin = asset.FindActionMap("Admin", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Drone
    private readonly InputActionMap m_Drone;
    private IDroneActions m_DroneActionsCallbackInterface;
    private readonly InputAction m_Drone_Thrust;
    private readonly InputAction m_Drone_Rotate;
    private readonly InputAction m_Drone_Interact;
    private readonly InputAction m_Drone_Cancel;
    private readonly InputAction m_Drone_PrimaryWeapon;
    public struct DroneActions
    {
        private @UserInput m_Wrapper;
        public DroneActions(@UserInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Thrust => m_Wrapper.m_Drone_Thrust;
        public InputAction @Rotate => m_Wrapper.m_Drone_Rotate;
        public InputAction @Interact => m_Wrapper.m_Drone_Interact;
        public InputAction @Cancel => m_Wrapper.m_Drone_Cancel;
        public InputAction @PrimaryWeapon => m_Wrapper.m_Drone_PrimaryWeapon;
        public InputActionMap Get() { return m_Wrapper.m_Drone; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DroneActions set) { return set.Get(); }
        public void SetCallbacks(IDroneActions instance)
        {
            if (m_Wrapper.m_DroneActionsCallbackInterface != null)
            {
                @Thrust.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnThrust;
                @Thrust.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnThrust;
                @Thrust.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnThrust;
                @Rotate.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnRotate;
                @Interact.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnInteract;
                @Cancel.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnCancel;
                @PrimaryWeapon.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnPrimaryWeapon;
                @PrimaryWeapon.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnPrimaryWeapon;
                @PrimaryWeapon.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnPrimaryWeapon;
            }
            m_Wrapper.m_DroneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Thrust.started += instance.OnThrust;
                @Thrust.performed += instance.OnThrust;
                @Thrust.canceled += instance.OnThrust;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @PrimaryWeapon.started += instance.OnPrimaryWeapon;
                @PrimaryWeapon.performed += instance.OnPrimaryWeapon;
                @PrimaryWeapon.canceled += instance.OnPrimaryWeapon;
            }
        }
    }
    public DroneActions @Drone => new DroneActions(this);

    // Crew
    private readonly InputActionMap m_Crew;
    private ICrewActions m_CrewActionsCallbackInterface;
    private readonly InputAction m_Crew_Walk;
    private readonly InputAction m_Crew_Interact;
    private readonly InputAction m_Crew_Cancel;
    public struct CrewActions
    {
        private @UserInput m_Wrapper;
        public CrewActions(@UserInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Crew_Walk;
        public InputAction @Interact => m_Wrapper.m_Crew_Interact;
        public InputAction @Cancel => m_Wrapper.m_Crew_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_Crew; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CrewActions set) { return set.Get(); }
        public void SetCallbacks(ICrewActions instance)
        {
            if (m_Wrapper.m_CrewActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_CrewActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_CrewActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_CrewActionsCallbackInterface.OnWalk;
                @Interact.started -= m_Wrapper.m_CrewActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_CrewActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_CrewActionsCallbackInterface.OnInteract;
                @Cancel.started -= m_Wrapper.m_CrewActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_CrewActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_CrewActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_CrewActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public CrewActions @Crew => new CrewActions(this);

    // User
    private readonly InputActionMap m_User;
    private IUserActions m_UserActionsCallbackInterface;
    private readonly InputAction m_User_Quit;
    private readonly InputAction m_User_NextPlayable;
    private readonly InputAction m_User_LastPlayable;
    public struct UserActions
    {
        private @UserInput m_Wrapper;
        public UserActions(@UserInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Quit => m_Wrapper.m_User_Quit;
        public InputAction @NextPlayable => m_Wrapper.m_User_NextPlayable;
        public InputAction @LastPlayable => m_Wrapper.m_User_LastPlayable;
        public InputActionMap Get() { return m_Wrapper.m_User; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UserActions set) { return set.Get(); }
        public void SetCallbacks(IUserActions instance)
        {
            if (m_Wrapper.m_UserActionsCallbackInterface != null)
            {
                @Quit.started -= m_Wrapper.m_UserActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnQuit;
                @NextPlayable.started -= m_Wrapper.m_UserActionsCallbackInterface.OnNextPlayable;
                @NextPlayable.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnNextPlayable;
                @NextPlayable.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnNextPlayable;
                @LastPlayable.started -= m_Wrapper.m_UserActionsCallbackInterface.OnLastPlayable;
                @LastPlayable.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnLastPlayable;
                @LastPlayable.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnLastPlayable;
            }
            m_Wrapper.m_UserActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @NextPlayable.started += instance.OnNextPlayable;
                @NextPlayable.performed += instance.OnNextPlayable;
                @NextPlayable.canceled += instance.OnNextPlayable;
                @LastPlayable.started += instance.OnLastPlayable;
                @LastPlayable.performed += instance.OnLastPlayable;
                @LastPlayable.canceled += instance.OnLastPlayable;
            }
        }
    }
    public UserActions @User => new UserActions(this);

    // Admin
    private readonly InputActionMap m_Admin;
    private IAdminActions m_AdminActionsCallbackInterface;
    public struct AdminActions
    {
        private @UserInput m_Wrapper;
        public AdminActions(@UserInput wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_Admin; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AdminActions set) { return set.Get(); }
        public void SetCallbacks(IAdminActions instance)
        {
            if (m_Wrapper.m_AdminActionsCallbackInterface != null)
            {
            }
            m_Wrapper.m_AdminActionsCallbackInterface = instance;
            if (instance != null)
            {
            }
        }
    }
    public AdminActions @Admin => new AdminActions(this);
    public interface IDroneActions
    {
        void OnThrust(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPrimaryWeapon(InputAction.CallbackContext context);
    }
    public interface ICrewActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
    public interface IUserActions
    {
        void OnQuit(InputAction.CallbackContext context);
        void OnNextPlayable(InputAction.CallbackContext context);
        void OnLastPlayable(InputAction.CallbackContext context);
    }
    public interface IAdminActions
    {
    }
}
