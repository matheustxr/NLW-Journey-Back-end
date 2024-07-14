using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Enums;

namespace Journey.Application.UseCases.Trips.Activities.Complete;

public class CompleteActivityForTripUseCase
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

        activity.Status = ActivityStatus.Done;
        
        dbContext.Activities.Update(activity);
        dbContext.SaveChanges();
    }
}