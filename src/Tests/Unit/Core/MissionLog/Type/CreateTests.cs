// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Moq;
using NUnit.Framework;
using com.github.olo42.ROM.Core.Application;
using com.github.olo42.ROM.Core.Domain;
using System.Threading.Tasks;

namespace com.github.olo42.ROM.Test.Unit.Core.Log.Type
{
  [TestFixture]
  public class CreateTests
  {
    private ICreate<LogType> create;
    private Mock<IRepository<LogType>> logTypeRepository;

    [SetUp]
    public void Setup()
    {
      logTypeRepository = new Mock<IRepository<LogType>>();
      create = new BaseCreate<LogType>(logTypeRepository.Object);
    }

    [Test]
    public async Task DoesNotThrow()
    {
      var input = new LogType { Name = "Action 1" };
      await create.Execute(input);

      Assert.That((async () => await create.Execute(input)), Throws.Nothing);
    }

    [Test]
    public async Task StoresInRepositoryAsync()
    {
      var input = new LogType { Name = "Action 1" };
      await create.Execute(input);

      logTypeRepository.Verify(x => x.WriteAsync(input), Times.Once);

    }

    [Test]
    public void RequiresRepositoryParameter()
    {
      IRepository<LogType> repository = null;

      Assert.That(() => new BaseCreate<LogType>(repository), Throws.ArgumentNullException);
    }
  }
}