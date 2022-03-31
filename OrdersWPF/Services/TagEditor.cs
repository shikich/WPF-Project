using OrdersWPF.View;
using System.Collections.Generic;

namespace OrdersWPF.Services
{
    class TagEditor : ITagEditor
    {
        public string[] Splitter(string line)
        {
            string[] arrTags;
            if (line != null)
            {
                arrTags = line.Split(',');
                return arrTags;
            }
            return null;
        }
        public string TagsUpdateSave(List<Tag> tags)
        {
            string save = "";
            foreach (var tag in tags)
            {
                if (tag._check == true)
                {
                    save += tag._tag + ",";
                }
            }
            return save.Trim(',');
        }
    }
}
