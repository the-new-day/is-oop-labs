using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistance.Repositories;

public interface ISessionRepository
{
    Session Add(Session session);

    IEnumerable<Session> Query(SessionQuery query);
}
