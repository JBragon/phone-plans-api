using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using JBragon.Business.Interfaces;
using JBragon.DataAccess.Context;
using JBragon.Models;
using JBragon.Models.Filters;
using JBragon.Models.Infrastructure;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JBragon.Business.Tests
{
    public class PhonePlansTest : IClassFixture<TestFixture>
    {
        private readonly IPhonePlanService _phonePlanService;
        private readonly Mock<IUnitOfWork<MainContext>> _unitOfWorkMock;
        private readonly IMapper _mapper;

        public PhonePlansTest()
        {
            var fixture = new TestFixture();

            _phonePlanService = fixture.PhonePlanService;
            _unitOfWorkMock = fixture.unitOfWorkMock;
            _mapper = fixture.mapper;
        }

        #region CRUD

        [Fact]
        public void PhonePlan_Create_Success()
        {
            var phonePlan = new PhonePlan()
            {
                DDDId = 1,
                TelephoneOperatorId = 1,
                PhonePlanTypeId = 1,
                Minutes = 1000,
                InternetFranchise = 10000,
                PlanPrice = 159.9M,
                Name = "Mais Controle 1000 minutos"
            };

            var result = _phonePlanService.Create<PhonePlan>(phonePlan);

            Assert.True(result != null);
            Assert.IsType<PhonePlan>(result);
            _unitOfWorkMock.Verify(uow => uow.SaveChanges(false), Times.Once);
        }

        [Theory]
        [InlineData(1)]
        public void PhonePlan_Get_Success(int Id)
        {
            var result = _phonePlanService.GetById<PhonePlan>(Id);

            Assert.True(result != null);
            Assert.True(result.Id == Id);
            Assert.IsType<PhonePlan>(result);
        }

        [Theory]
        [InlineData(0)]
        public void PhonePlan_Get_Null(int Id)
        {
            var result = _phonePlanService.GetById<PhonePlan>(Id);

            Assert.True(result == null);
        }

        [Fact]
        public void PhonePlan_Search_Success()
        {
            var filter = new PhonePlanFilter()
            {
                Name = "Mais Controle 500 minutos",
                DDDCode= 31
            };

            var result = _phonePlanService.Search<PhonePlan>(filter);

            Assert.NotNull(result);
            Assert.True(result.Items.Any());
            Assert.Equal(1, result.Items.FirstOrDefault().Id);
            Assert.IsType<List<PhonePlan>>(result.Items);
            Assert.IsType<SearchResponse<PhonePlan>>(result);
        }

        [Fact]
        public void PhonePlan_Search_Null()
        {
            //Arrange
            var filter = new PhonePlanFilter()
            {
                Name = "Mais Controle 500 minutos",
                DDDCode = 33
            };

            //Act
            var result = _phonePlanService.Search<PhonePlan>(filter);

            //Assert
            Assert.NotNull(result);
            Assert.False(result.Items.Any());
            Assert.IsType<List<PhonePlan>>(result.Items);
            Assert.IsType<SearchResponse<PhonePlan>>(result);
        }

        [Fact]
        public void PhonePlan_Update_Success()
        {
            var phonePlan = new PhonePlan()
            {
                Id = 1,
                DDDId = 1,
                TelephoneOperatorId = 1,
                PhonePlanTypeId = 1,
                Minutes = 500,
                InternetFranchise = 5000,
                PlanPrice = 139.9M,
                Name = "Mais Controle 500 minutos"
            };

            var result = _phonePlanService.Update<PhonePlan>(phonePlan);

            Assert.True(result != null);
            Assert.IsType<PhonePlan>(result);
            _unitOfWorkMock.Verify(uow => uow.SaveChanges(false), Times.Once);
        }

        [Theory]
        [InlineData(1)]
        public void PhonePlan_Delete_Success(int Id)
        {
            _phonePlanService.Delete(Id);

            _unitOfWorkMock.Verify(uow => uow.SaveChanges(false), Times.Once);
        }

        #endregion
    }
}
