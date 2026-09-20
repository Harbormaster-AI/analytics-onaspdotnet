using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Subscriber
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? SubscriberId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? Address { get; set; } 
public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();
 public virtual NotificationChannel? Channel { get; set; } 

    public static Subscriber FromRequest(SubscriberRequest request) {
        return new Subscriber {
            Id = request.Id,
            Name = request.Name,
            Address = request.Address,
            Channel = request.Channel,
        };
    }
}
