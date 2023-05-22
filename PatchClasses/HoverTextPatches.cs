﻿using HarmonyLib;
using WardIsLove.Extensions;
using WardIsLove.Util;
using static WardIsLove.WardIsLovePlugin;

namespace WardIsLove.PatchClasses
{
    [HarmonyPatch]
    internal class HoverTextPatches
    {
        [HarmonyPatch(typeof(Sign), nameof(Sign.GetHoverText))]
        [HarmonyPostfix]
        private static string SignGetHoverTextion(string __result, Sign __instance)
        {
            if (!WardEnabled.Value)
                return __result;
            string hoverText = __result;
            string localize = !WardMonoscript.CheckAccess(__instance.transform.position, flash: false)
                ? "\"" + __instance.GetText() + "\""
                : "\"" + __instance.GetText() + "\"\n" +
                  Localization.instance.Localize(__instance.m_name +
                                                 "\n[<color=#FFFF00><b>$KEY_Use</b></color>] $piece_use");
            return localize;
        }

        [HarmonyPatch(typeof(ItemStand), nameof(ItemStand.GetHoverText))]
        [HarmonyPostfix]
        private static string ItemStandGetHoverText(string __result, ItemStand __instance)
        {
            if (!WardEnabled.Value)
                return __result;
            string hoverText = __result;


            if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
            {
                WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                if (pa.GetItemStandInteractOn()) return __result;
                hoverText = Localization.instance.Localize(__instance.m_name + "\n<color=#FF0000>$piece_noaccess</color>");
                return hoverText;
            }

            return __result;
        }

        [HarmonyPatch(typeof(TeleportWorld), nameof(TeleportWorld.GetHoverText))]
        [HarmonyPostfix]
        private static string PortalHoverText(string __result, TeleportWorld __instance)
        {
            if (!WardEnabled.Value)
                return __result;
            string hoverText = __result;
            if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
            {
                WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                if (!pa.GetNoTeleportOn()) return __result;
                hoverText = Localization.instance.Localize(__instance.GetHoverName() +
                                                           "\n<color=#FF0000>$piece_noaccess</color>");
                return hoverText;
            }

            return __result;
        }

        [HarmonyPatch(typeof(Door), nameof(Door.GetHoverText))]
        [HarmonyPostfix]
        private static string DoorGetHoverText(string __result, Door __instance)
        {
            if (!WardEnabled.Value)
                return __result;
            string hoverText = __result;
            if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
            {
                WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                if (pa.GetDoorInteractOn()) return __result;
                hoverText = Localization.instance.Localize(__instance.m_name + "\n<color=#FF0000>$piece_noaccess</color>");
                return hoverText;
            }

            return __result;
        }

        [HarmonyPatch(typeof(Container), nameof(Container.GetHoverText))]
        [HarmonyPostfix]
        private static string ContainerGetHoverText(string __result, Container __instance)
        {
            if (!WardEnabled.Value)
                return __result;
            string hoverText = __result;
            if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
            {
                WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                if (pa.GetChestInteractOn()) return __result;
                hoverText = Localization.instance.Localize(__instance.GetHoverName() +
                                                           "\n<color=#FF0000>$piece_noaccess</color>");
                return hoverText;
            }

            return __result;
        }


        [HarmonyPatch(typeof(Pickable), nameof(Pickable.GetHoverText))]
        [HarmonyPostfix]
        private static string PickableGetHoverText(string __result, Pickable __instance)
        {
            if (!WardEnabled.Value)
                return __result;
            string hoverText = __result;
            if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
            {
                WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                if (pa.GetPickableInteractOn()) return __result;
                hoverText = Localization.instance.Localize(__instance.GetHoverName() +
                                                           "\n<color=#FF0000>$piece_noaccess</color>");
                return hoverText;
            }

            return __result;
        }

        [HarmonyPatch(typeof(ItemDrop), nameof(ItemDrop.GetHoverText))]
        [HarmonyPostfix]
        private static string IDHoverText(string __result, ItemDrop __instance)
        {
            if (!WardEnabled.Value)
                return __result;
            string hoverText = __result;
            if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
            {
                WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                if (pa.GetItemInteractOn()) return __result;
                hoverText = Localization.instance.Localize(__instance.GetHoverName() +
                                                           "\n<color=#FF0000>$piece_noaccess</color>");
                return hoverText;
            }

            return __result;
        }

        [HarmonyPatch(typeof(ShipControlls), nameof(ShipControlls.GetHoverText))]
        [HarmonyPostfix]
        private static string ShipHoverText(string __result, ShipControlls __instance)
        {
            if (!WardEnabled.Value)
                return __result;
            string hoverText = __result;
            if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
            {
                WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                if (pa.GetShipInteractOn()) return __result;
                hoverText = Localization.instance.Localize(__instance.GetHoverName() +
                                                           "\n<color=#FF0000>$piece_noaccess</color>");
                return hoverText;
            }

            return __result;
        }

        /*[HarmonyPatch(typeof(ArmorStand), nameof(ArmorStand.Awake))]
        static class ArmorStand_Awake_Patch
        {
            static void Postfix(ArmorStand __instance)
            {
                foreach (ArmorStand.ArmorStandSlot slot in __instance.m_slots)
                {
                    ArmorStand.ArmorStandSlot item = slot;
                    if (item.m_switch.m_onUse != null) continue;
                   // if (WardMonoscript.CheckAccess(__instance.transform.position, flash: false)) continue;
                    WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                    item.m_switch.m_onHover += (Switch.TooltipCallback)(() => pa.GetItemStandInteractOn()
                        ? Localization.instance.Localize(item.m_switch.m_hoverText +
                                                         "\n[<color=#FFFF00><b>1-8</b></color>] $piece_itemstand_attach" +
                                                         (__instance.GetNrOfAttachedItems() > 0
                                                             ? "\n[<color=#FFFF00><b>$KEY_Use</b></color>] $piece_itemstand_take"
                                                             : ""))
                        : Localization
                            .instance.Localize(__instance.m_name + "\n$piece_noaccess"));
                }
            }
        }*/


        [HarmonyPatch(typeof(CraftingStation), nameof(CraftingStation.GetHoverText))]
        [HarmonyPostfix]
        private static string CraftingStation_HoverTextCheck(string __result, CraftingStation __instance)
        {
            if (!WardEnabled.Value)
                return __result;
            string hoverText = __result;
            if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
            {
                WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                if (pa.GetCraftingStationInteractOn()) return __result;
                hoverText = Localization.instance.Localize(__instance.GetHoverName() +
                                                           "\n<color=#FF0000>$piece_noaccess</color>");
                return hoverText;
            }

            return __result;
        }
        
        [HarmonyPatch(typeof(Smelter),nameof(Smelter.OnHoverAddOre))]
        static class SmelterOnHoverAddOrePatch
        {
            static void Postfix(Smelter __instance, ref string __result)
            {
                if (!WardEnabled.Value)
                    return;
                if (!Player.m_localPlayer) return;
                if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
                {
                    WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                    if (pa.GetSmelterInteractOn()) return;
                    __result = Localization.instance.Localize(__instance.m_name + "\n<color=#FF0000>$piece_noaccess</color>");
                }
            }
        }
        
        [HarmonyPatch(typeof(Smelter),nameof(Smelter.OnHoverAddFuel))]
        static class SmelterOnHoverAddFuelPatch
        {
            static void Postfix(Smelter __instance, ref string __result)
            {
                if (!WardEnabled.Value)
                    return;
                if (!Player.m_localPlayer) return;
                if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
                {
                    WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                    if (pa.GetSmelterInteractOn()) return;
                    __result = Localization.instance.Localize(__instance.m_name + "\n<color=#FF0000>$piece_noaccess</color>");
                }
            }
        }
        
        [HarmonyPatch(typeof(Smelter),nameof(Smelter.OnHoverEmptyOre))]
        static class SmelterOnHoverEmptyOrePatch
        {
            static void Postfix(Smelter __instance, ref string __result)
            {
                if (!WardEnabled.Value)
                    return;
                if (!Player.m_localPlayer) return;
                if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
                {
                    WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                    if (pa.GetSmelterInteractOn()) return;
                    if (__instance.m_emptyOreSwitch && __instance.m_spawnStack)
                        __result = Localization.instance.Localize(__instance.m_name + "\n<color=#FF0000>$piece_noaccess</color>");
                }
            }
        }

        [HarmonyPatch(typeof(Beehive), nameof(Beehive.GetHoverText))]
        [HarmonyPostfix]
        private static string Beehive_HoverTextCheck(string __result, Beehive __instance)
        {
            if (!WardEnabled.Value)
                return __result;
            string hoverText = __result;
            if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
            {
                WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                if (pa.GetBeehiveInteractOn()) return __result;
                hoverText = Localization.instance.Localize(__instance.GetHoverName() +
                                                           "\n<color=#FF0000>$piece_noaccess</color>");
                return hoverText;
            }

            return __result;
        }

        [HarmonyPatch(typeof(MapTable), nameof(MapTable.GetWriteHoverText))]
        [HarmonyPostfix]
        private static string MapTable_HoverTextCheck(string __result, MapTable __instance)
        {
            if (!WardEnabled.Value)
                return __result;
            string hoverText = __result;
            if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
            {
                WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                if (pa.GetMapTableInteractOn()) return __result;
                hoverText = Localization.instance.Localize(__instance.m_name + "\n<color=#FF0000>$piece_noaccess</color>");
                return hoverText;
            }

            return __result;
        }

        [HarmonyPatch(typeof(MapTable), nameof(MapTable.GetReadHoverText))]
        [HarmonyPostfix]
        private static string MapTable_HoverTextCheckOnRead(string __result, MapTable __instance)
        {
            if (!WardEnabled.Value)
                return __result;
            string hoverText = __result;
            if (!WardMonoscript.CheckAccess(__instance.transform.position, flash: false))
            {
                WardMonoscript pa = WardMonoscriptExt.GetWardMonoscript(__instance.transform.position);
                if (pa.GetMapTableInteractOn()) return __result;
                hoverText = Localization.instance.Localize(__instance.m_name + "\n<color=#FF0000>$piece_noaccess</color>");
                return hoverText;
            }

            return __result;
        }
    }
}