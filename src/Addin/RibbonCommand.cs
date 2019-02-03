using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace CodeCave.Revit.Threejs.Exporter
{
    /// <summary>
    /// A sample ribbon command, demonstrates the possibility to bing Revit commands to ribbon buttons
    /// </summary>
    /// <seealso cref="T:Autodesk.Revit.UI.IExternalCommand" />
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class RibbonCommand : IExternalCommand
    {
        /// <summary>
        /// Executes the specified Revit command <see cref="ExternalCommand"/>.
        /// The main Execute method (inherited from IExternalCommand) must be public.
        /// </summary>
        /// <param name="commandData">The command data / context.</param>
        /// <param name="message">The message.</param>
        /// <param name="elements">The elements.</param>
        /// <returns>The result of command execution.</returns>
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements
        )
        {
            TaskDialog.Show("It's alive!", StringLocalizer.CallingAssembly["Localization: test string with spaces"]);
            return Result.Succeeded;
        }
    }
}
