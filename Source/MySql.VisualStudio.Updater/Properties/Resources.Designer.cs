﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MySql.VisualStudio.Updater.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MySql.VisualStudio.Updater.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to The argument cannot be null or empty..
        /// </summary>
        internal static string ArgumentCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("ArgumentCannotBeNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The length is expected to be equal to 3..
        /// </summary>
        internal static string ArgumentsOutOfRange {
            get {
                return ResourceManager.GetString("ArgumentsOutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attempting to update the PKGDEF file for {0}....
        /// </summary>
        internal static string AttemptingToUpdatePkgdefFile {
            get {
                return ResourceManager.GetString("AttemptingToUpdatePkgdefFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updating the PKGDEF files is not required. Connector/NET is not installed..
        /// </summary>
        internal static string ConnectorNETNotInstalled {
            get {
                return ResourceManager.GetString("ConnectorNETNotInstalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Extension has been refreshed. {0} needs to be manually restarted..
        /// </summary>
        internal static string ExtensionRefreshed {
            get {
                return ResourceManager.GetString("ExtensionRefreshed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The string provided is not in the correct format to be converted to a version object..
        /// </summary>
        internal static string InvalidVersionFormat {
            get {
                return ResourceManager.GetString("InvalidVersionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updating the PKGDEF files is not required. Both versions of MySql.Data libraries match..
        /// </summary>
        internal static string MySqlDataVersionsMatch {
            get {
                return ResourceManager.GetString("MySqlDataVersionsMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MySQLforVisualStudio {
            get {
                object obj = ResourceManager.GetObject("MySQLforVisualStudio", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PKGDEF files have been updated for all versions of Visual Studio where MySQL for Visual Studio is installed..
        /// </summary>
        internal static string PkgdefFilesUpdateCompleted {
            get {
                return ResourceManager.GetString("PkgdefFilesUpdateCompleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to update {0}..
        /// </summary>
        internal static string PkgdefFileUpdateFailed {
            get {
                return ResourceManager.GetString("PkgdefFileUpdateFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updating the PKGDEF files is not required..
        /// </summary>
        internal static string PkgdefFileUpdateNotRequired {
            get {
                return ResourceManager.GetString("PkgdefFileUpdateNotRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is not installed..
        /// </summary>
        internal static string ProductNotInstalled {
            get {
                return ResourceManager.GetString("ProductNotInstalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Refreshing extension in {0}....
        /// </summary>
        internal static string RefreshingExtension {
            get {
                return ResourceManager.GetString("RefreshingExtension", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please restart affected versions of Visual Studio for the changes to take effect..
        /// </summary>
        internal static string RestartVisualStudioRequired {
            get {
                return ResourceManager.GetString("RestartVisualStudioRequired", resourceCulture);
            }
        }
    }
}