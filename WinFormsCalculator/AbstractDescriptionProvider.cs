using System;
using System.ComponentModel;
namespace WinFormsCalculator
{
    /// <summary>
    /// Provides backward-compatability for 'older' versions of Visual studio that don't properly
    /// infer designer context when using an abstract base.
    /// 
    /// </para>
    /// </summary>
    public class AbstractDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        public AbstractDescriptionProvider() : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
        {
        }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType.FullName == typeof(TAbstract).FullName)
            {
                return typeof(TBase);
            }

            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType.FullName == typeof(TAbstract).FullName)
            {
                objectType = typeof(TBase);
            }


            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}



