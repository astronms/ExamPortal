using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Microsoft.Extensions.Logging;

namespace ExamPortal.Helpers.XML
{
    public class XmlValidator : IXmlValidator
    {
        private readonly ILogger<XmlValidator> _logger;

        public XmlValidator(ILogger<XmlValidator> logger)
        {
            _logger = logger;
        }
        public bool IsValid(string doc)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(doc);
                var schemaString = File.ReadAllText(".\\Helpers\\XML\\SessionSchema.xsd");
                xml.Schemas.Add("", XmlReader.Create(new StringReader(schemaString)));
                xml.Validate(ValidationEventHandler);
            }
            catch (XmlException ex)
            {
                _logger.LogError("XmlDocumentValidationExample.XmlException: " + ex.Message);
                return false;
            }
            catch (XmlSchemaValidationException ex)
            {
                _logger.LogError("XmlDocumentValidationExample.XmlSchemaValidationException: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError("XmlDocumentValidationExample.Exception: " + ex.Message);
                return false;
            }

            _logger.LogInformation("XML is Valid" );
            return true;
        }

        public void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
            {
                _logger.LogError("\nWARNING: " + args.Message);
                throw args.Exception;
            }

            if (args.Severity == XmlSeverityType.Error)
            {
                _logger.LogError("\nERROR: " + args.Message);
                throw args.Exception;
            }
        }
    }
}