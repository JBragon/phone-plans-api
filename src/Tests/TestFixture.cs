using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using JBragon.Business.Interfaces;
using JBragon.Business.Services;
using JBragon.DataAccess.Context;
using JBragon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using Moq.AutoMock;
using System.Collections.Generic;
using System.Linq;

namespace JBragon.Business.Tests
{
    public class TestFixture
    {
        public readonly IPhonePlanService PhonePlanService;
        public readonly Mock<IUnitOfWork<MainContext>> unitOfWorkMock;
        public readonly Mock<IRepository<PhonePlan>> repositoryMock;
        public readonly IMapper mapper;

        public TestFixture()
        {
            repositoryMock = new Mock<IRepository<PhonePlan>>();
            var context = new Mock<MainContext>();
            var dbFacade = new Mock<DatabaseFacade>(context.Object);

            var mockMapper = new MapperConfiguration(cfg =>
            {
            });

            mapper = mockMapper.CreateMapper();

            var phonePlan = new PhonePlan()
            {
                Id = 1,
                DDDId = 1,
                TelephoneOperatorId = 1,
                PhonePlanTypeId = 1,
                Minutes = 500,
                InternetFranchise = 5000,
                PlanPrice = 129.9M,
                Name = "Mais Controle 500 minutos",
                DDD = new DDD
                {
                    Id = 1,
                    State = "MG",
                    Region = "Sudeste",
                    DDDCode = 31
                },
                TelephoneOperator = new TelephoneOperator
                {
                    Id = 1,
                    Name = "VIVO"
                },
                PhonePlanType = new PhonePlanType
                {
                    Id = 1,
                    Description = "Controle"
                }
            };

            List<PhonePlan> entitybases = new List<PhonePlan>() { phonePlan };

            var dbSetMock = new Mock<DbSet<PhonePlan>>();

            dbSetMock.As<IQueryable<PhonePlan>>().Setup(x => x.Provider).Returns(entitybases.AsQueryable().Provider);
            dbSetMock.As<IQueryable<PhonePlan>>().Setup(x => x.Expression).Returns(entitybases.AsQueryable().Expression);
            dbSetMock.As<IQueryable<PhonePlan>>().Setup(x => x.ElementType).Returns(entitybases.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<PhonePlan>>().Setup(x => x.GetEnumerator()).Returns(entitybases.AsQueryable().GetEnumerator());

            context.Setup(x => x.Set<PhonePlan>()).Returns(dbSetMock.Object);

            var repository = new Repository<PhonePlan>(context.Object);

            var dbContextTransaction = new Mock<IDbContextTransaction>();

            AutoMocker mocker = new AutoMocker();
            mocker.GetMock<IUnitOfWork<MainContext>>().Setup(uow => uow.GetRepository<PhonePlan>(false)).Returns(repository);
            mocker.GetMock<IUnitOfWork<MainContext>>().Setup(uow => uow.DbContext.Database).Returns(dbFacade.Object);
            mocker.GetMock<IUnitOfWork<MainContext>>().Setup(uow => uow.DbContext.Database.BeginTransaction()).Returns(dbContextTransaction.Object);
            mocker.GetMock<IUnitOfWork<MainContext>>().Setup(uow => uow.DbContext.Set<PhonePlan>()).Returns(dbSetMock.Object);

            unitOfWorkMock = mocker.GetMock<IUnitOfWork<MainContext>>();

            PhonePlanService = new PhonePlanService(unitOfWorkMock.Object, mapper);
        }

    }
}
