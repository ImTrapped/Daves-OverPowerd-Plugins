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
using GorillaTagScripts.UI.ModIO;
using GorillaTagScripts.CustomMapSupport;
using UnityEngine.VFX;
using Viveport;
using System.Diagnostics;
using System.IO;
using System;
using Photon.Voice;
using UnityEngine.UIElements;
using System.Drawing;
using ExitGames.Client.Photon;
using Photon.Realtime;

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
        public static string Pluginversion = "2.0.0";


        public static void OnEnable()
        {
            UnityEngine.Debug.Log("Plugin " + Name + " has been enabled!");

            int category = AddCategory("Daves Overpowerd Plugins V" + Pluginversion);
            int category2 = AddCategory("Daves Plugin settings");

            AddButton(GetCategory("Main"), new ButtonInfo { buttonText = "Daves Overpowerd Plugins V" + Pluginversion, method = delegate { buttonsType = category; pageNumber = 0; }, isTogglable = false, toolTip = "Brings you to a category for plugins." });
            AddButton(category, new ButtonInfo { buttonText = "Exit Daves Overpowerd Plugins V" + Pluginversion, method = () => Settings.ReturnToMain(), isTogglable = false, toolTip = "Returns you back to the main page." });

       

            AddButton(category, new ButtonInfo { buttonText = "Lag all <color=grey>[</color><color=green>RT</color><color=grey>]</color>", method = () => LagAllStanderdized(), toolTip = "Lags everyone." });

            AddButton(category, new ButtonInfo { buttonText = "Lag All v1 <color=grey>[</color><color=green>RT</color><color=grey>]</color>", method = () => LagALlv1(), toolTip = "Lags everyone." });
            AddButton(category, new ButtonInfo { buttonText = "Lag Gun v1", method = () => LagGunv1(), toolTip = "Lags whoever is touched by your gun." });

            AddButton(category, new ButtonInfo { buttonText = "Lag All v2 <color=grey>[</color><color=green>RT</color><color=grey>]</color>", method = () => LagAllv2(), toolTip = "Lags everyone." });
            AddButton(category, new ButtonInfo { buttonText = "Lag Gun v2 ", method = () => LagGunv2(), toolTip = "Lags whoever is touched by your gun." });

            AddButton(category, new ButtonInfo { buttonText = "Lag All v3 <color=grey>[</color><color=green>RT</color><color=grey>]</color>", method = () => LagAllv3(), toolTip = "Lags everyone." });
            AddButton(category, new ButtonInfo { buttonText = "Lag Gun v3 ", method = () => LagGunv3(), toolTip = "Lags whoever is touched by your gun." });

            AddButton(category, new ButtonInfo { buttonText = "Lag all v4 <color=grey>[</color><color=green>RT</color><color=grey>]</color>", method = () => LagAllv4(), toolTip = "Lags everyone." });
            AddButton(category, new ButtonInfo { buttonText = "Lag Gun v4 ", method = () => LagGunv4(), toolTip = "Lags whoever is touched by your gun." });

            AddButton(category, new ButtonInfo { buttonText = "Lag Aura ", method = () => LagAura(), toolTip = "Lags whoever is touched by your gun." });

            AddButton(category, new ButtonInfo { buttonText = "Lag spike gun", method = () => LagSpikeGun(), toolTip = "Lags whoever is touched by your gun." });


            //plugin settings
            AddButton(GetCategory("Daves Overpowerd Plugins V" + Pluginversion), new ButtonInfo { buttonText = "Daves Plugin settings", method = delegate { buttonsType = category2; pageNumber = 0; }, isTogglable = false, toolTip = "Brings you to Plugin Settings." });
            AddButton(category2, new ButtonInfo { buttonText = "Exit Daves Plugin settings", method = delegate { buttonsType = category; pageNumber = 0; }, isTogglable = false, toolTip = "Returns you back to the main page." });


            AddButton(category2, new ButtonInfo { buttonText = "Lag Power setter", method = () => SetLagPower(), isTogglable = false, toolTip = "Set the lag power." });



        }


        public static void OnDisable()
        {
            UnityEngine.Debug.Log("Plugin " + Name + " has been disabled!");

            RemoveCategory("Daves Overpowerd Plugins V" + Pluginversion);
            RemoveButton(GetCategory("Main"), "Daves Overpowerd Plugins V" + Pluginversion);
        }

        public static void Update()
        {

        }

        public static void OnGUI()
        {
            GUI.Label(new Rect(450, 10, 500, 100), " <color=grey>[</color><color=green>Using:</color><color=grey>]</color>  <color=grey>[</color><color=red>Daves OverPowerd Plugins </color><color=grey>]</color>" + "version: " + Pluginversion);
            GUI.Label(new Rect(450, 35, 500, 100), "Made by: <color=blue>@iamtrapped_01310  </color>");
        }

        public static float laddelayss;
        public static float flushDelay;

        public static int LagPower = 1;
        public static int RealLagAmount;
        public static string FormatedLagPower;

        public static void UpdateState()
        {
            if (LagPower == 0) { RealLagAmount = 0; }
            else if (LagPower == 1) { RealLagAmount = 55; }
            else if (LagPower == 2) { RealLagAmount = 70; }
            else if (LagPower == 3) { RealLagAmount = 110; }
            else if (LagPower == 4) { RealLagAmount = 160; }
            else if (LagPower == 5) { RealLagAmount = 220; }
        }
        public static void SetLagPower()
        {
            if (LagPower >= 5)
            {
                LagPower = 0;
            }
            else
            {
                LagPower++;
                
            }
            if (LagPower < 4)
            {
                FormatedLagPower = "<color=grey>[</color><color=green>" + LagPower + "</color><color=grey>]</color>";
            }
            else
            {
                FormatedLagPower = "<color=grey>[</color><color=red>" + LagPower + "</color><color=grey>]</color>";
            }
            UpdateState();
            GetIndex("Lag Power setter").overlapText = "LagPower " + FormatedLagPower;
            NotifiLib.SendNotification("LagPower " + FormatedLagPower);
        }
        public static void LagALlv1()
        {
            if (rightTrigger > 0.5f || Mouse.current.rightButton.isPressed)
            {
                if (Time.time > laddelayss)
                {
                    laddelayss = Time.time + 0.5f;
                    for (int i = 0; i < RealLagAmount; i++)
                    {
                        FriendshipGroupDetection.Instance.photonView.RPC("PartyMemberIsAboutToGroupJoin", RpcTarget.Others, new object[] { null });

                    }
                }
                if (Time.time > flushDelay)
                {
                    flushDelay = Time.time + 0.4f;
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
                    laddelayss = Time.time + 0.5f;
                    for (int i = 0; i < RealLagAmount; i++)
                    {
                        FriendshipGroupDetection.Instance.photonView.RPC("RequestPartyGameMode", RpcTarget.Others, new object[] { null });
                    }
                }
                if (Time.time > flushDelay)
                {
                    flushDelay = Time.time + 0.4f;
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
                    laddelayss = Time.time + 0.5f;
                    for (int i = 0; i < RealLagAmount; i++)
                    {
                        FriendshipGroupDetection.Instance.photonView.RPC("VerifyPartyMember", RpcTarget.Others, new object[] { null });

                    }
                }
                if (Time.time > flushDelay)
                {
                    flushDelay = Time.time + 0.4f;
                    RPCProtection();
                }
            }


        }
        public static void LagAllv4()
        {
            if (rightTrigger > 0.5f || Mouse.current.rightButton.isPressed)
            {
                if (Time.time > laddelayss)
                {
                    laddelayss = Time.time + 0.5f;
                    for (int i = 0; i < RealLagAmount; i++)
                    {
                        FriendshipGroupDetection.Instance.photonView.RPC("NotifyPartyGameModeChanged", RpcTarget.Others, new object[] { null });
                    }
                }
                if (Time.time > flushDelay)
                {
                    flushDelay = Time.time + 0.4f;
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
                        laddelayss = Time.time + 0.5f;
                        for (int i = 0; i < RealLagAmount; i++)
                        {
                            FriendshipGroupDetection.Instance.photonView.RPC("PartyMemberIsAboutToGroupJoin", RigManager.NetPlayerToPlayer(RigManager.GetPlayerFromVRRig(whoCopy)), new object[] { null });
                        }
                        RPCProtection();
                    }
                    if (Time.time > flushDelay)
                    {
                        flushDelay = Time.time + 0.4f;
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
                        laddelayss = Time.time + 0.5f;
                        for (int i = 0; i < RealLagAmount; i++)
                        {
                            FriendshipGroupDetection.Instance.photonView.RPC("RequestPartyGameMode", RigManager.NetPlayerToPlayer(RigManager.GetPlayerFromVRRig(whoCopy)), new object[] { null });
                        }
                        RPCProtection();
                    }
                    if (Time.time > flushDelay)
                    {
                        flushDelay = Time.time + 0.4f;
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
                        laddelayss = Time.time + 0.5f;
                        for (int i = 0; i < RealLagAmount; i++)
                        {
                            FriendshipGroupDetection.Instance.photonView.RPC("VerifyPartyMember", RigManager.NetPlayerToPlayer(RigManager.GetPlayerFromVRRig(whoCopy)), new object[] { null });
                        }
                        RPCProtection();
                    }
                    if (Time.time > flushDelay)
                    {
                        flushDelay = Time.time + 0.4f;
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
        public static void LagGunv4()
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
                        laddelayss = Time.time + 0.5f;
                        for (int i = 0; i < RealLagAmount; i++)
                        {
                            FriendshipGroupDetection.Instance.photonView.RPC("NotifyPartyGameModeChanged", RigManager.NetPlayerToPlayer(RigManager.GetPlayerFromVRRig(whoCopy)), new object[] { null });
                        }
                        RPCProtection();
                    }
                    if (Time.time > flushDelay)
                    {
                        flushDelay = Time.time + 0.4f;
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

        public static void LagSpikeGun()
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
                        laddelayss = Time.time + 1.2f;
                        for (int i = 0; i < 600; i++)
                        {
                            FriendshipGroupDetection.Instance.photonView.RPC("RequestPartyGameMode", RigManager.NetPlayerToPlayer(RigManager.GetPlayerFromVRRig(whoCopy)), new object[] { null });
                        }
                        RPCProtection();
                    }
                    if (Time.time > flushDelay)
                    {
                        flushDelay = Time.time + 0.4f;
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


        public static void LagAura()
        {
            float radius = 3.2f;
            List<VRRig> closerigs = new List<VRRig>();

            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                float distance = Vector3.Distance(vrrig.transform.position, GorillaTagger.Instance.offlineVRRig.transform.position);

                if (distance <= radius && vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    closerigs.Add(vrrig);
                }
            }

            foreach (VRRig vrrig in closerigs)
            {
                if (Time.time > laddelayss)
                {
                    laddelayss = Time.time + 0.5f;
                    for (int i = 0; i < 79; i++)
                    {
                        FriendshipGroupDetection.Instance.photonView.RPC("NotifyPartyGameModeChanged", RigManager.NetPlayerToPlayer(RigManager.GetPlayerFromVRRig(vrrig)), new object[] { null });
                        FriendshipGroupDetection.Instance.photonView.RPC("RequestPartyGameMode", RigManager.NetPlayerToPlayer(RigManager.GetPlayerFromVRRig(vrrig)), new object[] { null });
                        FriendshipGroupDetection.Instance.photonView.RPC("VerifyPartyMember", RigManager.NetPlayerToPlayer(RigManager.GetPlayerFromVRRig(vrrig)), new object[] { null });
                    }
                    RPCProtection();
                }

            }

        }


        public static void LagAllStanderdized()
        {
            if (rightTrigger > 0.5f || Mouse.current.rightButton.isPressed)
            {
                StanderdLag();
            }
        }
        public static void StanderdLag()
        {
            if (Time.time > laddelayss)
            {
                laddelayss = Time.time + 0.5f;
                for (int i = 0; i < 56; i++)
                {
                    FriendshipGroupDetection.Instance.photonView.RPC("PartyMemberIsAboutToGroupJoin", RpcTarget.Others, new object[] { null });
                    FriendshipGroupDetection.Instance.photonView.RPC("RequestPartyGameMode", RpcTarget.Others, new object[] { null });
                    FriendshipGroupDetection.Instance.photonView.RPC("VerifyPartyMember", RpcTarget.Others, new object[] { null });
                    FriendshipGroupDetection.Instance.photonView.RPC("NotifyPartyGameModeChanged", RpcTarget.Others, new object[] { null });
                }
                RPCProtection();
            }
        }
    }
}

    

