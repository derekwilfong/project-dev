using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;


using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace highestLevel
{
    [Transaction(TransactionMode.Manual)]

    public class CmdhighestLevel : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {

            UIApplication app = commandData.Application;
            Document doc = app.ActiveUIDocument.Document;


            ElementCategoryFilter lvl = new ElementCategoryFilter(BuiltInCategory.OST_Levels);
            FilteredElementCollector coll = new FilteredElementCollector(doc);
            IList<Element> pLvl = coll.WherePasses(lvl).ToElements();
            foreach (Element e in pLvl)
            {
                Parameter paramLvl = e.get_Parameter(BuiltInParameter.LEVEL_ELEV);

                if(paramLvl == null)
                {
                    continue;
                }


                string a = string.Format(paramLvl.AsValueString());


                TaskDialog.Show(
                    "Levels",
                    a, TaskDialogCommonButtons.Ok);


            }

            return Result.Succeeded;
        }
    }
}
