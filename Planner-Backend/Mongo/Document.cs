using MongoDB.Bson;

namespace Planner_Backend.Mongo;

public abstract class Document : IDocument
{
    public ObjectId Id { get; set; }

    public DateTime CreatedAt => Id.CreationTime;
}