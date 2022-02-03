using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ExamPortal.XML.Exam
{
    public interface IXmlValidator
    {
        bool IsValid(string doc);
        void ValidationEventHandler(object sender, ValidationEventArgs args);
    }
}
