using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;

public sealed record SessionQuery(SessionKey[] SessionKeys);
