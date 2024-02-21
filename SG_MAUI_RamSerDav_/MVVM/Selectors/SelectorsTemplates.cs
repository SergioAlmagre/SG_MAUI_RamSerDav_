
using Microsoft.Maui.Controls;
using PropertyChanged;
using SG_MAUI_RamSerDav_.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SG_MAUI_RamSerDav_.MVVM.Selectors
{
    [AddINotifyPropertyChangedInterface]
    public class SelectorsTemplates : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {

            var usu = (Usuario)item;
            if (usu.EsDelegado)
            {
                Application
                    .Current
                    .Resources
                    .TryGetValue("vistaDelegado", out var estiloJefe);
                return (DataTemplate)estiloJefe;
            }
            else
            {
                Application
                   .Current
                   .Resources
                   .TryGetValue("vistaNormal", out var estiloNormal);
                return (DataTemplate)estiloNormal;
            }

        }
    }
}
