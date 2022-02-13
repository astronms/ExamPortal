using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ExamPortal.Data.Answers
{
    [XmlRoot(ElementName = "answers")]
    public class Answers
    {
        [Key]
        public Guid AnswerId { get; set; }

        [XmlElement(ElementName = "value")]
        public List<AnswersValue> AnsversValue { get; set; }

        [ForeignKey(nameof(TaskAnswers))]
        public Guid TaskAnswersId { get; set; }
        public virtual TaskAnswers TaskAnswers { get; set;}
    }
}
