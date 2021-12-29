using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Serilog;

namespace ExamPortal.XML.Exam
{
    public class XmlValidator : IXmlValidator
    {
        private static readonly ILogger _logger;

        public bool IsValid(XmlDocument doc)
        {
            try
            {
                var schemaString = File.ReadAllText(".\\XML\\Exam\\ExamSchema.xsd");
                doc.Schemas.Add("", XmlReader.Create(new StringReader(schemaString)));
                doc.Validate(ValidationEventHandler);
            }
            catch (XmlException ex)
            {
                _logger.Fatal("XmlDocumentValidationExample.XmlException: " + ex.Message);
                return false;
            }
            catch (XmlSchemaValidationException ex)
            {
                _logger.Fatal("XmlDocumentValidationExample.XmlSchemaValidationException: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                _logger.Fatal("XmlDocumentValidationExample.Exception: " + ex.Message);
                return false;
            }

            _logger.Information("XML is Valid" );
            return true;
        }

        public void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
            {
                _logger.Error("\nWARNING: " + args.Message);
                throw args.Exception;
            }

            if (args.Severity == XmlSeverityType.Error)
            {
                _logger.Error("\nERROR: " + args.Message);
                throw args.Exception;
            }
        }
    }
}