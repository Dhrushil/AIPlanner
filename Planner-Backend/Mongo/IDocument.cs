using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Planner_Backend.Mongo;

public interface IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    ObjectId Id { get; set; }

    DateTime CreatedAt { get; }
}