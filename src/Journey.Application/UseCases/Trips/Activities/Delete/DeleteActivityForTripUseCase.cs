using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips.Activities.Delete;

public class DeleteActivityForTripUseCase
{
    public void Execute(Guid tripId, Guid activityId)
    {
        var dbContext = new JourneyDbContext();
        var activity = dbContext
            .Activities
            .FirstOrDefault(activity => activity.Id == activityId && activity.TripId == tripId);

        if (activity is null)
        {
            throw new NotFoundException(ResourceErrorMessages.ATIVIDADE_NAO_ENCONTARDA);
        }
        
        dbContext.Activities.Remove(activity);
        dbContext.SaveChanges();
    }
}