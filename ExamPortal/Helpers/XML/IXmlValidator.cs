using System.Xml.Schema;

namespace ExamPortal.Helpers.XML
{
    public interface IXmlValidator
    {
        bool IsValid(string doc);
        void ValidationEventHandler(object sender, ValidationEventArgs args);
    }
}
