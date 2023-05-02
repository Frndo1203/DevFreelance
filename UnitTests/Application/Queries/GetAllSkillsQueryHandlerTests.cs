using Application.Queries.GetAllSkills;

namespace UnitTests.Application.Queries
{
  public class GetAllSkillsQueryHandlerTests
  {
    [Fact]
    public async Task Handle_Executed_ReturnsSkillViewModelList()
    {
      //Arrange
      var skillRepositoryMock = new Mock<ISkillsRepository>();
      var skills = new List<Skill>()
      {
        new Skill("Test skill 1"),
        new Skill("Test skill 2"),
        new Skill("Test skill 3")
      };

      skillRepositoryMock.Setup(s => s.GetAllAsync().Result).Returns(skills);

      var request = new GetAllSkillsQuery();
      var handler = new GetAllSkillsQueryHandler(skillRepositoryMock.Object);

      //Act
      var skillList = await handler.Handle(request, new CancellationToken());

      //Assert
      Assert.NotNull(skillList);
      Assert.NotEmpty(skillList);
      Assert.True(skillList.Count == skills.Count);

      skillRepositoryMock.Verify(s => s.GetAllAsync().Result, Times.Once());
    }
  }
}