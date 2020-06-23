// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Moq;
using NUnit.Framework;
using com.github.olo42.SAROnion.Core.Application;
using com.github.olo42.SAROnion.Core.Domain;

namespace com.github.olo42.SAROnion.Test.Unit.CoreTest
{
  [TestFixture]
  public class CreateLogTypeTests
  {
    private ICreate<CreateLogTypeInput, LogType> create;
    private Mock<IRepository<LogType>> logTypeRepository;

    [SetUp]
    public void Setup()
    {
      logTypeRepository = new Mock<IRepository<LogType>>();
      create = new CreateLogType(logTypeRepository.Object);
    }

    [Test]
    public void CreatesLogTypeObject()
    {
      var input = new CreateLogTypeInput { Name = "Action 1" };
      var result = create.Execute(input).Result;

      Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void AssignesNewId()
    {
      var input = new CreateLogTypeInput { Name = "Action 1" };
      var result = create.Execute(input).Result;

      Assert.That(result.Id, Is.Not.Null);
    }

    [Test]
    public void RequiresNameParameter()
    {
      var input = new CreateLogTypeInput { Name = null };

      Assert.That(() => create.Execute(input).Result, Throws.ArgumentNullException);
    }

    [Test]
    public void AssignesName()
    {
      var input = new CreateLogTypeInput { Name = "Alert" };
      var result = create.Execute(input).Result;

      Assert.That(result.Name, Is.EqualTo("Alert"));
    }

    [Test]
    public void StoresInRepository()
    {
      var input = new CreateLogTypeInput { Name = "Action 1" };
      var result = create.Execute(input).Result;

      logTypeRepository.Verify(x => x.Write(result), Times.Once);

    }

    [Test]
    public void RequiresRepositoryParameter()
    {
      IRepository<LogType> repository = null;

      Assert.That(() => new CreateLogType(repository), Throws.ArgumentNullException);
    }
  }
}