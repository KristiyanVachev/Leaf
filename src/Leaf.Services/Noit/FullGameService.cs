using System.Linq;
using Bytes2you.Validation;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;

namespace Leaf.Services.Noit
{
    public class FullGameService : IFullGameService
    {
        //TODO: Extract IQuestion interface
        private readonly IRepository<Question> questionRepository;
        private readonly IUnitOfWork unitOfWork;

        public FullGameService(IRepository<Question> queRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(queRepository, "queRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.questionRepository = queRepository;
            this.unitOfWork = unitOfWork;
        }

        public Question GetQuestions()
        {
            var question = this.questionRepository.Entities.FirstOrDefault();

            return question;
        }
    }
}
