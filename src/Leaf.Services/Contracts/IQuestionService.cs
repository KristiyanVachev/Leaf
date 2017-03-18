﻿using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetQuestions();
    }
}