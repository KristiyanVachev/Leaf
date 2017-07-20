﻿using System.Linq;
using Bytes2you.Validation;
using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Contracts;

namespace Leaf.Services
{
    public class TestsService : ITestsService
    {
        private readonly ITestService testService;
        private readonly IQuestionService questionService;
        private readonly IUserService userService;
        private readonly IAuthenticationProvider authenticationProvider;

        public TestsService(
            ITestService testService,
            IQuestionService questionService,
            IUserService userService,
            IAuthenticationProvider authenticationProvider)
        {
            //TODO: Extract "cannot be null" message to costant
            Guard.WhenArgument(testService, "testService cannot be null").IsNull().Throw();
            Guard.WhenArgument(questionService, "questionService cannot be null").IsNull().Throw();
            Guard.WhenArgument(userService, "userService cannot be null").IsNull().Throw();
            Guard.WhenArgument(authenticationProvider, "authenticationProvider cannot be null").IsNull().Throw();

            this.testService = testService;
            this.questionService = questionService;
            this.userService = userService;
            this.authenticationProvider = authenticationProvider;
        }

        public Test CreateTest(TestType type)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            //TODO get tailored questions for practice tests
            var questions = this.questionService.GetQuestions();

            return this.testService.CreateTest(userId, type, questions);
        }

        public Test ContinueTest(TestType type)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            return this.testService.GetLastTest(userId, type);
        }

        public bool HasUnfinishedTest(TestType type)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var userTest = this.testService.GetLastTest(userId, type);

            return !(userTest == null || userTest.IsFinished);
        }

        public Test GetTestById(int testId)
        {
            return this.testService.GetTestById(testId);
        }

        public void SendAnswer(int testId, int questionId, int answerId)
        {
            this.testService.AddAnswer(testId, questionId, answerId);

            this.testService.RemoveQuestionById(testId, questionId);
        }

        public Question GetNextQuestion(int testId)
        {
            var test = this.testService.GetTestById(testId);

            return test.Questions.FirstOrDefault();
        }

        public void EndTest(int testId)
        {
            this.testService.EndTest(testId);

            var testStats = this.testService.GatherTestStatistics(testId);

            var test = this.testService.GetTestById(testId);
            var userId = test.User.Id;

            this.userService.UpdateUserStatistics(userId, testStats);

            //TODO update statistics of answers
        }

        public bool UserIsOwner(int testId)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var test = this.testService.GetTestById(testId);

            //BUG throws when test id doesn't exist

            return test.UserId == userId;
        }
    }
}
