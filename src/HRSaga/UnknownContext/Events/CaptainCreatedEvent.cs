 using EventSourcing;
 
 namespace HRSaga.UnknownContext.Events
 {
     public class CaptainCreatedEvent : IEvent
     {
         public string Id { get; set; }
         public string Name { get; set; }
     }
 }