using Microsoft.VisualStudio.DesignTools.Extensibility.Features;
using Microsoft.VisualStudio.DesignTools.Extensibility.Metadata;

[assembly: ProvideMetadata(typeof(CustomControlLibrary.DesignTools.Metadata))]
namespace CustomControlLibrary.DesignTools
{
    public class Metadata : IProvideAttributeTable
    {
        public AttributeTable AttributeTable
        {
            get
            {
                AttributeTableBuilder builder = new AttributeTableBuilder();
                builder.AddCustomAttributes("CustomControlLibrary.Group", new FeatureAttribute(typeof(BGAdornerProvider)));

                return builder.CreateTable();
            }
        }
    }
}