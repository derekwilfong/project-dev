using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace CreateSheetOop4
{
    class Titleblock
    {

        //field data

        

        Document doc;
        

        public ElementId TitleblockId()
        {
            IEnumerable<FamilySymbol> familyList =
                from elem in new FilteredElementCollector(doc)
                .OfClass(typeof(FamilySymbol))
                .OfCategory(BuiltInCategory.OST_TitleBlocks)
                let type = elem as FamilySymbol
                where type.Name.Contains("30")
                select type;

            ElementId gh = familyList.First().Id;
            return gh;
        }
    }

    
}
