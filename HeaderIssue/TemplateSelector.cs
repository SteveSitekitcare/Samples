using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaderIssue
{
    public class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate EvenTemplate { get; set; }
        public DataTemplate UnevenTemplate { get; set; }        

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (((Model)item).Status)
            {
                case false:
                    return UnevenTemplate;                     
                default:
                    return EvenTemplate;
            }
        }
    }
}
