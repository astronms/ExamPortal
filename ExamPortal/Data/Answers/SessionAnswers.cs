﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using ExamPortal.Data.ExamData;

namespace ExamPortal.Data.Answers
{
    [XmlRoot(ElementName = "session")]
    public class SessionAnswers
    {
        [XmlElement(ElementName = "exam")]
        public List<Exam> Exam { get; set; }
        [Key]
        [XmlAttribute(AttributeName = "id")]
        public Guid SessionAnswersId { get; set; }
        
        public virtual IList<ExamAnswers> ExamAnswers { get; set; }
    }
}
