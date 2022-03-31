using OrdersWPF.View;
using System.Collections.Generic;

namespace OrdersWPF.Services
{
    public interface ITagEditor
    {
        string[] Splitter(string line);

        string TagsUpdateSave(List<Tag> tags);
    }
}
