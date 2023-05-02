namespace UnitTests.Core.Entities
{
  public class ProjectTests
  {
    [Fact]
    public void TestIfProjectStartWorks()
    {
      var project = new Project("Nome de teste", "Descricao de teste", 1, 2, 10000);

      Assert.Equal(EProjectStatus.Created, project.Status);
      Assert.Null(project.StartedAt);

      Assert.NotNull(project.Title);
      Assert.NotEmpty(project.Title);

      Assert.NotNull(project.Description);
      Assert.NotEmpty(project.Description);

      project.Start();

      Assert.Equal(EProjectStatus.InProgress, project.Status);
      Assert.NotNull(project.StartedAt);
    }
  }
}