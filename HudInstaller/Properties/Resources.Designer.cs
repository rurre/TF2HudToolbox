﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HudInstaller.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HudInstaller.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;HelpInfo_English&quot;
        ///{
        ///	&quot;button_MinimalDefault_name&quot;	&quot;Minimal to Default&quot;
        ///	&quot;button_MinimalDefault_desc&quot;	&quot;Turns Minimal Hud (cl_Hud_minmode 1) values into Default Hud (cl_Hud_minmode 0) values then removes the Minimal values from the Hud.&quot;
        ///	
        ///	&quot;button_StripMinimal_name&quot;		&quot;Strip Minimal Hud&quot;
        ///	&quot;button_StripMinimal_desc&quot;		&quot;This option will remove all Minimal Hud (cl_Hud_minmode 1) values from the selected Hud. This doesn&apos;t overwrite the selected Hud, only the one that gets installed.&quot;
        ///	
        ///	&quot;button_fragment_n [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string helpinfo_English {
            get {
                return ResourceManager.GetString("helpinfo_English", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;HelpInfo_Test&quot;
        ///{
        ///	&quot;button_MinimalDefault_name&quot;	&quot;Minimal ta Default&quot;
        ///	&quot;button_MinimalDefault_desc&quot;	&quot;Turns Minimal Hud (cl_Hud_minmode 1) joints tha fuck into Default Hud (cl_Hud_minmode 0) joints then removes tha Minimal joints from tha Hud.&quot;
        ///	
        ///	&quot;button_StripMinimal_name&quot;		&quot;Strip Minimal Hud&quot;
        ///	&quot;button_StripMinimal_desc&quot;		&quot;This option will remove all Minimal Hud (cl_Hud_minmode 1) joints from tha selected Hud. Y&apos;all KNOW dat shit, muthafucka! This don&apos;t overwrite tha selected Hud, only tha one dat gets [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string helpinfo_test {
            get {
                return ResourceManager.GetString("helpinfo_test", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon icon {
            get {
                object obj = ResourceManager.GetObject("icon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap icon_settings {
            get {
                object obj = ResourceManager.GetObject("icon_settings", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap logo_default {
            get {
                object obj = ResourceManager.GetObject("logo_default", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap logo_main {
            get {
                object obj = ResourceManager.GetObject("logo_main", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap logo_main_transparent {
            get {
                object obj = ResourceManager.GetObject("logo_main_transparent", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;Toolbox_English&quot;
        ///{
        ///	
        ///	//Install Tab
        ///	&quot;label_Static_Hud&quot;					&quot;Hud&quot;
        ///	&quot;label_Static_Hudname&quot;				&quot;Name&quot;
        ///	&quot;label_Static_HudVersion&quot;			&quot;Version&quot;
        ///	&quot;label_Static_HudWebsite&quot;			&quot;Website&quot;
        ///	&quot;label_Static_HudAuthor&quot;			&quot;Author&quot;
        ///	&quot;label_static_logo&quot;					&quot;Logo&quot;	
        ///	&quot;label_static_result&quot;				&quot;Result&quot;
        ///	&quot;label_TF2Folder&quot;					&quot;TF2 Folder:&quot;
        ///
        ///	&quot;groupbox_HudInfo&quot;					&quot;Hud Info&quot;
        ///	&quot;groupbox_InstallMode&quot;				&quot;Install Mode&quot;
        ///
        ///	&quot;checkbox_CombineUseMinimal&quot;		&quot;Use minmode values&quot;
        ///	&quot;checkbox_CombineHudUseDefault&quot;		&quot;Use Defa [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string toolbox_english {
            get {
                return ResourceManager.GetString("toolbox_english", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;Toolbox_Test&quot;
        ///{
        ///	
        ///	//Install Tab
        ///	&quot;label_Static_Hud&quot;					&quot;Hddd&quot;
        ///	&quot;label_Static_Hudname&quot;				&quot;namae&quot;
        ///	&quot;label_Static_HudVersion&quot;			&quot;Ver&quot;
        ///	&quot;label_Static_HudWebsite&quot;			&quot;We&quot;
        ///	&quot;label_Static_HudAuthor&quot;			&quot;Aut&quot;
        ///	&quot;label_static_logo&quot;					&quot;Lo&quot;	
        ///	&quot;label_static_result&quot;				&quot;lt&quot;
        ///	&quot;label_TF2Folder&quot;					&quot;TF2 :&quot;
        ///
        ///	&quot;groupbox_HudInfo&quot;					&quot;Hud INFO&quot;
        ///	&quot;groupbox_InstallMode&quot;				&quot;Install &quot;
        ///
        ///	&quot;checkbox_CombineUseMinimal&quot;		&quot;Use values&quot;
        ///	&quot;checkbox_CombineHudUseDefault&quot;	&quot;Use TF2 Hud&quot;	
        ///	
        ///	&quot;button_MainBrowse&quot;					&quot;Br [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string toolbox_test {
            get {
                return ResourceManager.GetString("toolbox_test", resourceCulture);
            }
        }
    }
}
