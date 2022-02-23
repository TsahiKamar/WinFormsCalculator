using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel;
using System.Windows.Forms;
using WinFormsCalculator.Interfaces;

namespace WinFormsCalculator.Views
{

    [TypeDescriptionProvider(typeof(AbstractDescriptionProvider<WinFormsCalculator.Views.ViewBase, UserControl>))]
    public abstract class ViewBase : UserControl, Interfaces.IView 
    {
        // Ensure derived Views implement their method to set bindings between control properties => model properties.
        public abstract void PerformBinding();
    }

}
