using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using EnvDTE;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Telerik.RazorConverter;

namespace OlympicSoftware.RazorConverterExtension
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the information needed to show this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideAutoLoad(UIContextGuids80.SolutionExists)]
    [Guid(GuidList.guidRazorConverterExtensionPkgString)]
    public sealed class RazorConverterExtensionPackage : Package
    {
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public RazorConverterExtensionPackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }


        /////////////////////////////////////////////////////////////////////////////
        // Overridden Package Implementation

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Debug.WriteLine(CultureInfo.CurrentCulture.ToString(), "Entering Initialize() of: {0}", this);
            base.Initialize();


            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null != mcs)
            {
                // Create the command for the menu item.
                CommandID menuCommandID = new CommandID(GuidList.guidRazorConverterExtensionCmdSet,
                    (int)PkgCmdIDList.cmdidConvertAspxToRazor);
                var menuItem = new OleMenuCommand(MenuItemCallback, menuCommandID);
                menuItem.BeforeQueryStatus += QueryStatus;


                mcs.AddCommand(menuItem);
            }
        }

        private void QueryStatus(object sender, EventArgs eventArgs)
        {
            OleMenuCommand menuCommand = sender as OleMenuCommand;
            var targetFile = GetSelectedProjectItem();

            menuCommand.Visible = (targetFile != null &&
                                   (targetFile.Name.EndsWith(".aspx") || targetFile.Name.EndsWith(".ascx")));

        }


        #endregion

        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            var projectItem = GetSelectedProjectItem();

            var razorConverter = new RazorConverter();
            var razor = razorConverter.ConvertAspx(projectItem.FileNames[0]);

            var querySave2 = GetGlobalService(typeof(SVsQueryEditQuerySave)) as IVsQueryEditQuerySave2;
            uint verdict;
            uint moreInfo;
            querySave2.QueryEditFiles((uint)tagVSQueryEditFlags.QEF_SilentMode, 1, new[] { projectItem.FileNames[0] }, null,
                null, out verdict, out moreInfo);


            var window = projectItem.Open();
            window.Activate();

            TextDocument o = (TextDocument)projectItem.Document.Object("TextDocument");
            TextSelection textSelection = o.Selection;
            textSelection.SelectAll();
            textSelection.Delete();
            textSelection.Text = razor;

        }


        private ProjectItem GetSelectedProjectItem()
        {
            IntPtr hierarchyPointer, selectionContainerPointer;
            Object selectedObject = null;
            IVsMultiItemSelect multiItemSelect;
            uint projectItemId;

            IVsMonitorSelection monitorSelection =
                    (IVsMonitorSelection)Package.GetGlobalService(
                    typeof(SVsShellMonitorSelection));

            monitorSelection.GetCurrentSelection(out hierarchyPointer,
                                                 out projectItemId,
                                                 out multiItemSelect,
                                                 out selectionContainerPointer);

            IVsHierarchy selectedHierarchy = Marshal.GetTypedObjectForIUnknown(
                                                 hierarchyPointer,
                                                 typeof(IVsHierarchy)) as IVsHierarchy;



            if (selectedHierarchy != null)
            {
                ErrorHandler.ThrowOnFailure(selectedHierarchy.GetProperty(
                                                  projectItemId,
                                                  (int)__VSHPROPID.VSHPROPID_ExtObject,
                                                  out selectedObject));
            }

            var selectedProject = selectedObject as ProjectItem;
            return selectedProject;
        }


    }
}