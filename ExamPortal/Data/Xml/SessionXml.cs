using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExamPortal.Data.Xml
{
    [XmlRoot(ElementName = "session")]
    public class SessionXml
    {
        [XmlElement(ElementName = "exam")]
        public List<ExamXml> Exams { get; set; }
    }

    [XmlRoot(ElementName = "exam")]
    public class ExamXml
    {
        [XmlElement(ElementName = "task")]
        public List<TaskXml> Task { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "task")]
    public class TaskXml
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "questions")]
        public QuestionsXml Questions { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public int Time { get; set; }
        [XmlElement(ElementName = "image")]
        public string Image { get; set; }
    }

    [XmlRoot(ElementName = "questions")]
    public class QuestionsXml
    {
        [XmlElement(ElementName = "value")]
        public List<ValueXml> Value { get; set; }
    }

    [XmlRoot(ElementName = "value")]
    public class ValueXml
    {
        [XmlAttribute(AttributeName = "regex")]
        public string Regex { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}
