
using Microsoft.Maui.Controls;
using PropertyChanged;
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
        //protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        //{
            //var profe = (Profesor)item;
            //if (profe.EsJefe)
            //{
            //    Application
            //        .Current
            //        .Resources
            //        .TryGetValue("vistaJefe", out var estiloJefe);
            //    return (DataTemplate)estiloJefe;
            //}
            //else if (profe.Antiguedad > 10)
            //{
            //    Application
            //       .Current
            //       .Resources
            //       .TryGetValue("vistaMasExperiencia", out var estiloExperiencia);
            //    return (DataTemplate)estiloExperiencia;
            //}
            //else{
            //    Application
            //       .Current
            //       .Resources
            //       .TryGetValue("vistaNormal", out var estiloNormal);
            //    return (DataTemplate)estiloNormal;
            //}

        }
    }
}
