using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ExamPortal.Data.ExamData;

namespace ExamPortal.Data.Xml
{
    [XmlRoot(ElementName = "session")]
    public class SessionAnswersXml
    {
        [XmlElement(ElementName = "exam")]
        public List<ExamAnswersXml> ExamAnswers { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public Guid SessionAnswersId { get; set; }
    }

    [XmlRoot(ElementName = "exam")]
    public class ExamAnswersXml
    {
        [XmlElement(ElementName = "task")]
        public List<TaskAnswersXml> TaskAnswers { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public Guid ExamAnswersId { get; set; }
        [XmlAttribute(AttributeName = "userId")]
        public string UserId { get; set; }
    }
    
    [XmlRoot(ElementName = "task")]
    public class TaskAnswersXml
    {
        [XmlElement(ElementName = "answers")]
        public AnswersXml Answers { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int TaskAnswersId { get; set; }
    }

    [XmlRoot(ElementName = "answers")]
    public class AnswersXml
    {
        [XmlElement(ElementName = "value")]
        public List<string> Value { get; set; }
    }
}
