using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace Hotkeys
{
    // Global hotkey handler that works regardless of current menu state
    [HarmonyPatch(typeof(UIRoot_Play), nameof(UIRoot_Play.UIRootOnGUI))]
    public class Patch_GlobalArchitectHotkeys
    {
        static void Postfix()
        {
            if (Event.current.type != EventType.KeyDown) return;
            if (!Hotkeys.settings.useArchitectHotkeys) return;
            
            List<KeyBindingDef> categories = DefDatabase<KeyBindingDef>.AllDefsListForReading.FindAll(x => x.category == DefDatabase<KeyBindingCategoryDef>.GetNamed("ArchitectHotkeys"));
            
            foreach (var category in categories)
            {
                if (category.JustPressed)
                {
                    string tab = category.defName.Remove(0, 23);
                    OpenArchitectTab(tab);
                    break;
                }
            }
        }
        
        static void OpenArchitectTab(string tabName)
        {
            var architectTab = DefDatabase<MainButtonDef>.GetNamed("Architect");
            Find.MainTabsRoot.SetCurrentTab(architectTab, true);
            
            var architectWindow = Find.MainTabsRoot.OpenTab as MainTabWindow_Architect;
            if (architectWindow != null)
            {
                var targetPanel = architectWindow.desPanelsCached.Find(x => x.def.defName.Contains(tabName));
                if (targetPanel != null)
                {
                    architectWindow.selectedDesPanel = targetPanel;
                    Find.DesignatorManager.Deselect();
                }
            }
        }
    }

    [HarmonyPatch(typeof(MainTabWindow_Architect), nameof(MainTabWindow_Architect.ExtraOnGUI))]
    public class Patch_ArchitectHotkeys
    {
        static bool keyWasDown = false;
        
        static void Prefix(ref ArchitectCategoryTab ___selectedDesPanel, ref List<ArchitectCategoryTab> ___desPanelsCached)
        {
            keyWasDown = false;
            if (Event.current.type != EventType.KeyDown) { return; }
            if (!Hotkeys.settings.useArchitectHotkeys) { return; }
            
            List<KeyBindingDef> categories = DefDatabase<KeyBindingDef>.AllDefsListForReading.FindAll(x => x.category == DefDatabase<KeyBindingCategoryDef>.GetNamed("ArchitectHotkeys"));
            
            foreach (var category in categories)
            {
                string tab = category.defName.Remove(0, 23);
                if (category.JustPressed)
                {
                    // Check if Architect menu is closed and open it
                    var architectTab = DefDatabase<MainButtonDef>.GetNamed("Architect");
                    if (Find.MainTabsRoot.OpenTab != architectTab)
                    {
                        Find.MainTabsRoot.SetCurrentTab(architectTab, true);
                        // Small delay might be needed for the panels to initialize
                        // The panels should be available immediately after opening
                    }
                    
                    var panel = ___desPanelsCached.Find(x => x.def.defName.Contains(tab));
                    if (panel != null && panel != ___selectedDesPanel)
                    {
                        keyWasDown = true;
                        ___selectedDesPanel = panel;
                    }
                }
            }
        }
        
        static void Postfix()
        {
            // Due to keydown persisting for 6 frames (why?) this immediately deselects the 'carry through'
            if (keyWasDown)
                Find.DesignatorManager.Deselect();
        }
    }
}
