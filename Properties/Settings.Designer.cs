﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BubblesHack.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point PointerWindowLocation {
            get {
                return ((global::System.Drawing.Point)(this["PointerWindowLocation"]));
            }
            set {
                this["PointerWindowLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point MainWindowLocation {
            get {
                return ((global::System.Drawing.Point)(this["MainWindowLocation"]));
            }
            set {
                this["MainWindowLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10000")]
        public int FindMaxNodes {
            get {
                return ((int)(this["FindMaxNodes"]));
            }
            set {
                this["FindMaxNodes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20")]
        public int FindMinThreshold {
            get {
                return ((int)(this["FindMinThreshold"]));
            }
            set {
                this["FindMinThreshold"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BubblesHack.Solvers.SortColourRandomSolver")]
        public string FindSolverType {
            get {
                return ((string)(this["FindSolverType"]));
            }
            set {
                this["FindSolverType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string FindSaveTree {
            get {
                return ((string)(this["FindSaveTree"]));
            }
            set {
                this["FindSaveTree"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1000")]
        public int AutoFindMaxNodes {
            get {
                return ((int)(this["AutoFindMaxNodes"]));
            }
            set {
                this["AutoFindMaxNodes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int AutoFindMinThreshold {
            get {
                return ((int)(this["AutoFindMinThreshold"]));
            }
            set {
                this["AutoFindMinThreshold"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BubblesHack.Solvers.TabuColourRandomSolver")]
        public string AutoFindSolverType {
            get {
                return ((string)(this["AutoFindSolverType"]));
            }
            set {
                this["AutoFindSolverType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20000")]
        public int AutoFindDesiredScore {
            get {
                return ((int)(this["AutoFindDesiredScore"]));
            }
            set {
                this["AutoFindDesiredScore"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("63")]
        public int AutoFindMinBubbles {
            get {
                return ((int)(this["AutoFindMinBubbles"]));
            }
            set {
                this["AutoFindMinBubbles"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Пузыри - выигрывай монетки в турнирах! - Google Chrome")]
        public string AutoFindBrowserString {
            get {
                return ((string)(this["AutoFindBrowserString"]));
            }
            set {
                this["AutoFindBrowserString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1500")]
        public int AutoFindShortPause {
            get {
                return ((int)(this["AutoFindShortPause"]));
            }
            set {
                this["AutoFindShortPause"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1500")]
        public int AutoFindLongPause {
            get {
                return ((int)(this["AutoFindLongPause"]));
            }
            set {
                this["AutoFindLongPause"] = value;
            }
        }
    }
}
