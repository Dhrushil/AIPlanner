using Planner_Backend.Mongo;

namespace Planner_Backend.Model;

[BsonCollection("events")]
public class EventDocument : Document
{
    public EventDocument(string? title, string? description, DateTime? startDate, DateTime? endDate,
        List<string>? attendees, IReadOnlyList<string>? tags)
    {
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        Attendees = attendees;
        Tags = tags;
    }

    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public List<string>? Attendees { get; private set; }
    public IReadOnlyList<string>? Tags { get; private set; }
    
    public EventDocument AddAttendee(string attendeeId)
    {
        Attendees ??= new List<string>();
        Attendees.Add(attendeeId);
        return this;
    }
}