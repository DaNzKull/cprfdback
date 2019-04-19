using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CPRFeedbackER;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CPRFFeedBackTests
{


	[TestClass]
	public class RepositoryTest
	{

		public IRepository MockRepository;
		ObservableCollection<Measurement> Measurements;
		Measurement mm;
		[TestInitialize]
		public void Init()
		{
			Measurements = new ObservableCollection<Measurement>
				{
					new Measurement { Id = 1, Name = "Laci", Values = "594;587;577;570;561;552;541;531;520;509;497;486;474;460;448" },
					new Measurement { Id = 2, Name = "Kati", Values = "594;587;577;570;561;552;541;531;520;509;497;486;474;460;448"},
					new Measurement { Id = 3, Name = "Jözsi", Values = "594;587;577;570;561;552;541;531;520;509;497;486;474;460;448"}

				};


			// Mock the Products Repository using Moq
			mm = new Measurement { Id = 1, Name = "Laci", Values = "594;587;577;570;561;552;541;531;520;509;497;486;474;460;448" };

			Mock<IRepository> mockRepository = new Mock<IRepository>();

			mockRepository.Setup(mr => mr.UpdateItem(mm));
			mockRepository.Setup(mr => mr.DeleteItem(mm));
			mockRepository.Setup(mr => mr.GetAllItems()).Returns(Measurements);

			mockRepository.Setup(mr => mr.AddItem(It.IsAny<Measurement>())).Returns(

				(Measurement target) =>
				{
					var original = mm;
					if (original == null)
					{
						return false;
					}

					original.Name = target.Name;
					original.Values = target.Values;
					return true;
				});
			this.MockRepository = mockRepository.Object;
		}
		[TestMethod]
		public void CanSave()
		{
			int count = this.MockRepository.GetAllItems().Count;
			var mes = new Measurement { Id = 1, Name = "Laci", Values = "594;587;577;570;561;552;541;531;520;509;497;486;474;460;448" };
			this.MockRepository.AddItem(mes);
			

			Assert.AreEqual(3, count);
			count = this.MockRepository.GetAllItems().Count;

			Assert.AreEqual(4, count); // Verify the expected Number post-insert
		}
		[TestMethod]
		public void CanUpdate()
		{
			int count = this.MockRepository.GetAllItems().Count;
			var mes = new Measurement { Id = 1, Name = "Laci", Values = "594;587;577;570;561;552;541;531;520;509;497;486;474;460;448" };
			this.MockRepository.AddItem(mes);


			Assert.AreEqual(3, count);
			count = this.MockRepository.GetAllItems().Count;

			Assert.AreEqual(4, count); // Verify the expected Number post-insert
		}
	}
}
