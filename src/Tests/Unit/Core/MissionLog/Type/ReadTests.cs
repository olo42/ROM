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
  public class ReadTests
  {
    private IRead<LogType> read;
    private Mock<IRepository<LogType>> repository;

    [SetUp]
    public void Setup()
    {
      repository = new Mock<IRepository<LogType>>();
      read = new BaseReadAction<LogType>(repository.Object);
    }

    [Test]
    public void ReadLogTypeObject()
    {
      var logType = Task.FromResult(new LogType());
      repository.Setup(x => x.ReadAsync(It.IsAny<string>())).Returns(logType);
      var input = new Identifier("1");
      
      var result = read.Execute(input);

      Assert.That(result.Result, Is.Not.Null);
    }

    [TestCase]
    public void ReturnForSpecificId()
    {
      var logType = Task.FromResult(new LogType { Id = "abcdefg" });
      repository.Setup(x => x.ReadAsync(It.IsAny<string>())).Returns(logType);

      var input = new Identifier("abcdefg");
      var result = read.Execute(input);

      Assert.That(result.Result.Id, Is.EqualTo("abcdefg"));
    }
  }
}