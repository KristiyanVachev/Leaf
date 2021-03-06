﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Leaf.Models.Enums;

namespace Leaf.Models
{
    public class Test
    {
        private ICollection<AnsweredQuestion> answeredQuestions;
        private ICollection<Question> questions;

        public Test()
        {
            this.answeredQuestions = new HashSet<AnsweredQuestion>();
            this.questions = new HashSet<Question>();
        }

        public Test(string userId, ICollection<Question> questions, DateTime createdOn, TestType type) : this()
        {
            this.UserId = userId;
            this.questions = questions;
            this.CreatedOn = createdOn;
            this.Type = type;
            this.IsFinished = false;
        }

        public int Id { get; set; }

        public TestType Type { get; set; }

        public bool IsFinished { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? FinishedOn { get; set; }

        public int CorrectCount { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<AnsweredQuestion> AnsweredQuestions
        {
            get { return this.answeredQuestions; }
            set { this.answeredQuestions = value; }
        }

        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }
    }
}
