using static iiMenu.Menu.Main;
using iiMenu.Classes;
using iiMenu.Mods;
using UnityEngine;
using GorillaTagScripts;
using Photon.Pun;
using System.Reflection;
using UnityEngine.InputSystem;
using GorillaNetworking;
using iiMenu.Notifications;
using System.Collections.Generic;
using static NetworkSystem;
using PlayFab.ClientModels;
using GorillaTag.Cosmetics;

namespace StupidPlugin
{
    public class Plugin
    {
        /*
            Plugin template used for ii's Stupid Menu 5.5.0+

            If you've ever created a menu before, this should be easy:
                + GetIndex(ButtonName); Gets a button's ButtonInfo
                + AddButton(CategoryID, new ButtonInfo); Creates a button in a category
                - RemoveButton(CategoryID, ButtonName); Removes a button in a category

                + GetCategory(CategoryName); Gets a category, you can find the category names in the menu's Buttons.cs file at the bottom
                + AddCategory(CategoryName); Creates a category, does not automatically create the navigation button
                - RemoveCategory(CategoryName); Removes the category created, does not automatically

            Feel free to modify, add, or remove any methods or fields below
        */

        public static string Name = "Daves Overpowerd Plugins";
        public static string Description = "A Overpowerd Plugin Pack by dave or @iamtrapped_01310 in discord.";
        public static string Pluginversion = "1.1.0";

        // This runs when the plugin starts, at the beginning of the game if enabled before launch
        // You should put all of your adding of buttons / categories here
        public static void OnEnable()
        {
            UnityEngine.Debug.Log("Plugin " + Name + " has been enabled!");

            int category = AddCategory("Daves Overpowerd Plugins V" + Pluginversion);
            AddButton(GetCategory("Main"), new ButtonInfo { buttonText = "Daves Overpowerd Plugins V" + Pluginversion, method = delegate { buttonsType = category; pageNumber = 0; }, isTogglable = false, toolTip = "Brings you to a category for plugins." });
            AddButton(category, new ButtonInfo { buttonText = "Exit Daves Overpowerd Plugins V" + Pluginversion, method = () => Settings.ReturnToMain(), isTogglable = false, toolTip = "Returns you back to the main page." });

            AddButton(category, new ButtonInfo { buttonText = "Lag All v1 <color=grey>[</color><color=green>RT</color><color=grey>]</color>", method = () => LagALlv1(), toolTip = "Lags everyone." });
            AddButton(category, new ButtonInfo { buttonText = "Lag Gun v1", method = () => LagGunv1(), toolTip = "Lags whoever is touched by your gun." });
            AddButton(category, new ButtonInfo { buttonText = "Lag All v2 <color=grey>[</color><color=green>RT</color><color=grey>]</color>", method = () => LagAllv2(), toolTip = "Lags everyone." });
            AddButton(category, new ButtonInfo { buttonText = "Lag Gun v2 ", method = () => LagGunv2(), toolTip = "Lags whoever is touched by your gun." });

            AddButton(category, new ButtonInfo { buttonText = "Lag All v3 <color=grey>[</color><color=green>RT</color><color=grey>]</color>", method = () => LagAllv3(), toolTip = "Lags everyone." });
            AddButton(category, new ButtonInfo { buttonText = "Lag Gun v3 ", method = () => LagGunv3(), toolTip = "Lags whoever is touched by your gun." });


            //AddButton(category, new ButtonInfo { buttonText = "Lag test v4 works ", method = () => LagTest4(), toolTip = "Lags whoever is touched by your gun." });
            //      AddButton(category, new ButtonInfo { buttonText = "Lag test v5 ", method = () => LagTest5(), toolTip = "Lags whoever is touched by your gun." });

            //   AddButton(category, new ButtonInfo { buttonText = "testing ground ", method = () => CrashAll(), toolTip = "Lags whoever is touched by your gun." });


        }

        // This runs when the plugin stops, or when plugins are reloaded
        // You should put all of your removing of buttons / categories here
        public static void OnDisable()
        {
            UnityEngine.Debug.Log("Plugin " + Name + " has been disabled!");

            RemoveCategory("Daves Overpowerd Plugins V" + Pluginversion);
            RemoveButton(GetCategory("Main"), "Daves Overpowerd Plugins V" + Pluginversion);
        }

        // This runs every frame before the mods
        public static void Update()
        {
            // UnityEngine.Debug.Log(Time.time);
        }

        // This runs when the menu UI is open (togglable with backslash)
        // I don't recommend using this as an update method
        public static void OnGUI()
        {
            GUI.Label(new Rect(450, 10, 500, 100), " <color=grey>[</color><color=green>Using:</color><color=grey>]</color>  <color=grey>[</color><color=red>Daves OverPowerd Plugins </color><color=grey>]</color>" + "version: " + Pluginversion);
            //   GUI.Button(new Rect(25, 10, 200, 100), "Player Leave");
        }

        public static float laddelayss = 1f;
        public static float flushDelay;

        public static void LagALlv1()
        {
            if (rightTrigger > 0.5f || Mouse.current.rightButton.isPressed)
            {
                if (Time.time > laddelayss)
                {
                    laddelayss = Time.time + 0.049f;
                    for (int i = 0; i < 25; i++)
                    {
                        FriendshipGroupDetection.Instance.photonView.RPC("PartyMemberIsAboutToGroupJoin", RpcTarget.Others, new object[] { null });
                    }
                }
                if (Time.time > flushDelay)
                {
                    flushDelay = Time.time + 0.5f;
                    RPCProtection();
                }
            }

        }

        public static void LagAllv2()
        {
            if (rightTrigger > 0.5f || Mouse.current.rightButton.isPressed)
            {
                if (Time.time > laddelayss)
                {
                    laddelayss = Time.time + 0.049f;
                    for (int i = 0; i < 25; i++)
                    {
                        FriendshipGroupDetection.Instance.photonView.RPC("RequestPartyGameMode", RpcTarget.Others, new object[] { null });
                    }
                }
                if (Time.time > flushDelay)
                {
                    flushDelay = Time.time + 0.5f;
                    RPCProtection();
                }
            }
        }
        public static void LagAllv3()
        {
            if (rightTrigger > 0.5f || Mouse.current.rightButton.isPressed)
            {
                if (Time.time > laddelayss)
                {
                    laddelayss = Time.time + 0.049f;
                    for (int i = 0; i < 25; i++)
                    {
                        FriendshipGroupDetection.Instance.photonView.RPC("VerifyPartyMember", RpcTarget.Others, new object[] { null });
                    }
                }
                if (Time.time > flushDelay)
                {
                    flushDelay = Time.time + 0.5f;
                    RPCProtection();
                }
            }


        }


        public static void LagGunv1()
        {
            if (rightGrab || Mouse.current.rightButton.isPressed)
            {
                var GunData = RenderGun();
                RaycastHit Ray = GunData.Ray;
                GameObject NewPointer = GunData.NewPointer;

                if (isCopying && whoCopy != null)
                {
                    if (Time.time > laddelayss)
                    {
                        laddelayss = Time.time + 0.049f;
                        for (int i = 0; i < 25; i++)
                        {
                            FriendshipGroupDetection.Instance.photonView.RPC("PartyMemberIsAboutToGroupJoin", RigManager.NetPlayerToPlayer(RigManager.GetPlayerFromVRRig(whoCopy)), new object[] { null });
                        }
                    }
                    if (Time.time > flushDelay)
                    {
                        flushDelay = Time.time + 0.5f;
                        RPCProtection();
                    }

                }
                if (rightTrigger > 0.5f || Mouse.current.leftButton.isPressed)
                {
                    VRRig possibly = Ray.collider.GetComponentInParent<VRRig>();
                    if (possibly && possibly != GorillaTagger.Instance.offlineVRRig)
                    {
                        isCopying = true;
                        whoCopy = possibly;
                    }
                }
            }
            else
            {
                if (isCopying)
                {
                    isCopying = false;
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }

        public static void LagGunv2()
        {
            if (rightGrab || Mouse.current.rightButton.isPressed)
            {
                var GunData = RenderGun();
                RaycastHit Ray = GunData.Ray;
                GameObject NewPointer = GunData.NewPointer;

                if (isCopying && whoCopy != null)
                {
                    if (Time.time > laddelayss)
                    {
                        laddelayss = Time.time + 0.049f;
                        for (int i = 0; i < 25; i++)
                        {
                            FriendshipGroupDetection.Instance.photonView.RPC("RequestPartyGameMode", RigManager.NetPlayerToPlayer(RigManager.GetPlayerFromVRRig(whoCopy)), new object[] { null });
                        }
                    }
                    if (Time.time > flushDelay)
                    {
                        flushDelay = Time.time + 0.5f;
                        RPCProtection();
                    }

                }
                if (rightTrigger > 0.5f || Mouse.current.leftButton.isPressed)
                {
                    VRRig possibly = Ray.collider.GetComponentInParent<VRRig>();
                    if (possibly && possibly != GorillaTagger.Instance.offlineVRRig)
                    {
                        isCopying = true;
                        whoCopy = possibly;
                    }
                }
            }
            else
            {
                if (isCopying)
                {
                    isCopying = false;
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }


        public static void LagGunv3()
        {
            if (rightGrab || Mouse.current.rightButton.isPressed)
            {
                var GunData = RenderGun();
                RaycastHit Ray = GunData.Ray;
                GameObject NewPointer = GunData.NewPointer;

                if (isCopying && whoCopy != null)
                {
                    if (Time.time > laddelayss)
                    {
                        laddelayss = Time.time + 0.049f;
                        for (int i = 0; i < 25; i++)
                        {
                            FriendshipGroupDetection.Instance.photonView.RPC("VerifyPartyMember", RigManager.NetPlayerToPlayer(RigManager.GetPlayerFromVRRig(whoCopy)), new object[] { null });
                        }
                    }
                    if (Time.time > flushDelay)
                    {
                        flushDelay = Time.time + 0.5f;
                        RPCProtection();
                    }

                }
                if (rightTrigger > 0.5f || Mouse.current.leftButton.isPressed)
                {
                    VRRig possibly = Ray.collider.GetComponentInParent<VRRig>();
                    if (possibly && possibly != GorillaTagger.Instance.offlineVRRig)
                    {
                        isCopying = true;
                        whoCopy = possibly;
                    }
                }
            }
            else
            {
                if (isCopying)
                {
                    isCopying = false;
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }




    }
 }

    


