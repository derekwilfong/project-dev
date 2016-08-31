using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace FindStuff
{
    [Transaction(TransactionMode.Manual)]

    public class CmdReportItem : IExternalCommand
    {
       
        public Result Execute(ExternalCommandData commandData, 
            ref string message, 
            ElementSet elements)
        {
            UIApplication app = commandData.Application;
            Document doc = app.ActiveUIDocument.Document;


            FilteredElementCollector coll = new FilteredElementCollector(doc);
            IList<Element> doorList = 
            coll.OfClass(typeof(FamilyInstance))
            .OfCategory(BuiltInCategory.OST_Doors).ToList();
            int doorCount = doorList.Count;

            TaskDialog.Show(
                "Door Count", "Your project has " + doorCount + "doors");

            return Result.Succeeded;
        }
    }
}
