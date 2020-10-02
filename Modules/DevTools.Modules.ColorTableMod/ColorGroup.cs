using System.Collections.Generic;

namespace DevTools.Modules.ColorTableMod
{
    public class ColorSubItem
    {
        public string Color { get; set; }
    }

    public class ColorGroup
    {
        public string GroupName { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ColorSubItem> ColorSubItems { get; set; }

        public ColorGroup()
        {
            GroupName = "";
            Description = "";
            ColorSubItems = new List<ColorSubItem>();
        }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ColorGroup> ColorGroups { get; set; }
    }
}
