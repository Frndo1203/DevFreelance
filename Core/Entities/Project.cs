

using Core.Enums;

namespace Core.Entities
{
  public class Project : BaseEntity
  {
    public Project(string title, string description, int idClient, int idFreelancer, decimal? totalCost)
    {
      Title = title;
      Description = description;
      IdClient = idClient;
      IdFreelancer = idFreelancer;
      TotalCost = totalCost;

      CreatedAt = DateTime.Now;
      Status = EProjectStatus.Created;
      Comments = new List<ProjectComment>();
    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public int IdClient { get; private set; }

    public int IdFreelancer { get; private set; }

    public decimal? TotalCost { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? StartedAt { get; private set; }

    public DateTime? FinishedAt { get; private set; }

    public EProjectStatus Status { get; private set; }

    public IList<ProjectComment> Comments { get; private set; }

    public void Cancel()
    {
      if (Status == EProjectStatus.InProgress || Status == EProjectStatus.Suspended)
      {
        Status = EProjectStatus.Cancelled;
      }
    }

    public void Finish()
    {
      if (Status == EProjectStatus.InProgress)
      {
        Status = EProjectStatus.Finished;
        FinishedAt = DateTime.Now;
      }
    }

    public void Start()
    {
      if (Status == EProjectStatus.Created || Status == EProjectStatus.Suspended)
      {
        Status = EProjectStatus.InProgress;
        StartedAt = DateTime.Now;
      }
    }

    public void Update(string title, string description, decimal totalCost)
    {
      Title = title;
      Description = description;
      TotalCost = totalCost;
    }
  }
}