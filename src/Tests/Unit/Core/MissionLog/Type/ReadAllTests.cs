// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Moq;
using NUnit.Framework;
using com.github.olo42.ROM.Core.Application;
using com.github.olo42.ROM.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using com.github.olo42.ROM.Core.Application.MissionLog.Type;

namespace com.github.olo42.ROM.Test.Unit.Core.Log.Type
{
  [TestFixture]
  public class ReadAllTests
  {
    private IReadAll<IEnumerable<LogType>> readAll;
    private Mock<IRepository<LogType>> repository;

    [SetUp]
    public void Setup()
    {
      repository = new Mock<IRepository<LogType>>();
      readAll = new ReadAll(repository.Object);
    }

    [Test]
    public void ReadLogTypeObjects()
    {
      var logTypes = new List<LogType>{ new LogType(), new LogType() } as IEnumerable<LogType>;
      var logTypeTask = Task.FromResult(logTypes);
      repository.Setup(x => x.ReadAsync()).Returns(logTypeTask);

      var result = readAll.Execute();

      Assert.That(result.Result.Count, Is.EqualTo(2));
    }
  }
}