using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExamPortal.Data.Xml
{

    [XmlRoot(ElementName = "session")]
    public class SessionResultXml
    {
        [XmlElement(ElementName = "exam")]
        public List<ExamResultXml> Exam { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public Guid Id { get; set; }
    }

    [XmlRoot(ElementName = "exam")]
    public class ExamResultXml
    {
        [XmlElement(ElementName = "task")]
        public List<TaskResultXml> Task { get; set; }
        [XmlElement(ElementName = "finalScore")]
        public double FinalScore { get; set; }
        [XmlElement(ElementName = "maxScore")]
        public double MaxScore { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public Guid Id { get; set; }
        [XmlAttribute(AttributeName = "userId")]
        public string UserId { get; set; }
    }

    [XmlRoot(ElementName = "task")]
    public class TaskResultXml
    {
        [XmlElement(ElementName = "answer")]
        public List<AnswerResultXml> Answer { get; set; }
        [XmlElement(ElementName = "taskScore")]
        public double TaskScore { get; set; }
        [XmlElement(ElementName = "taskMaxScore")]
        public double TaskMaxScore { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }

    [XmlRoot(ElementName = "answer")]
    public class AnswerResultXml
    {
        [XmlElement(ElementName = "actual")]
        public string Actual { get; set; }
        [XmlElement(ElementName = "correct")]
        public string Correct { get; set; }
        [XmlElement(ElementName = "score")]
        public double Score { get; set; }
        [XmlElement(ElementName = "maxScore")]
        public double MaxScore { get; set; }
    }
}
