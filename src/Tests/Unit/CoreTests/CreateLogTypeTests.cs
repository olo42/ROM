// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.SAROnion.Core.Application;
using com.github.olo42.SAROnion.Core.Domain;
using Moq;
using NUnit.Framework;

namespace com.github.olo42.SAROnion.Test.Unit.CoreTest
{
  [TestFixture]
  public class CreateLogTypeTests
  {
    private CreateLogType createAction;
    private Mock<ILogTypeRepository> logTypeRepository;

    [SetUp]
    public void Setup()
    {
      logTypeRepository = new Mock<ILogTypeRepository>();
      createAction = new CreateLogType(logTypeRepository.Object);
    }

    [Test]
    public void CreatesLogTypeObject()
    {
      var result = createAction.Run("Type 1").Result;

      Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void AssignesNewId()
    {
      var result = createAction.Run("Type 1").Result;

      Assert.That(result.Id, Is.Not.Null);
    }

    [Test]
    public void RequiresNameParameter()
    {
      string name = null;

      Assert.That(() => createAction.Run(name).Result, Throws.ArgumentNullException);
    }

    [Test]
    public void AssignesName()
    {
      var name = "Alert";
      var result = createAction.Run(name).Result;

      Assert.That(result.Name, Is.EqualTo("Alert"));
    }

    [Test]
    public void StoresInRepository()
    {
      var result = createAction.Run("Type 1").Result;

      logTypeRepository.Verify(x => x.Write(result), Times.Once);

    }

    [Test]
    public void RequiresRepositoryParameter()
    {
      ILogTypeRepository repository = null;

      Assert.That(() => new CreateLogType(repository), Throws.ArgumentNullException);
    }
  }
}