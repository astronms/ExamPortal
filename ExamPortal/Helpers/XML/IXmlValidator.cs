using System.Xml.Schema;

namespace ExamPortal.Helpers.XML
{
    public interface IXmlValidator
    {
        bool IsSessionValid(string doc);
        bool IsResultValid(string doc);
        void ValidationEventHandler(object sender, ValidationEventArgs args);
    }
}
