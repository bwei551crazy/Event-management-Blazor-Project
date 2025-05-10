using System.Collections.Generic;
using System.Linq;
using EventEaseApp.Models;
namespace EventEaseApp.Services {
public class EventService
{
    private List<Event> Events = new()
    {
        new Event { Id = 1, Name = "Tech Conference", Date = DateTime.Now.AddDays(10), Location = "Auckland" },
        new Event { Id = 2, Name = "Music Festival", Date = DateTime.Now.AddDays(20), Location = "Wellington" }
    };

    // public List<Event> GetEvents() => Events;
    public async Task<List<Event>> GetEvents() => await Task.FromResult(Events);

    // public Event? GetEventById(int id) => Events.FirstOrDefault(e => e.Id == id);
    public async Task<Event?> GetEventById(int id) => await Task.FromResult(Events.FirstOrDefault(e => e.Id == id));
    
    public async Task AddEvent(Event newEvent)
    {
        
         // Check for duplicates
        if (Events.Any(e => e.Id != newEvent.Id && e.Name == newEvent.Name && e.Date == newEvent.Date && e.Location == newEvent.Location))
        {
            return; // Prevent adding duplicate event
        }

        newEvent.Id = Events.Count + 1; // Assign a new ID
        Events.Add(newEvent);

        await Task.CompletedTask; // Simulate async processing
    }

    public async Task UpdateEvent(Event updatedEvent)
    {
        var eventItem = Events.FirstOrDefault(e => e.Id == updatedEvent.Id);
        if (eventItem != null)
        {
            eventItem.Name = updatedEvent.Name;
            eventItem.Date = updatedEvent.Date;
            eventItem.Location = updatedEvent.Location;
        }
        await Task.CompletedTask; // Simulate async processing
    }

    public async Task DeleteEvent(int id)
    {
        var eventItem = Events.FirstOrDefault(e => e.Id == id);
        if (eventItem != null)
        {
            Events.Remove(eventItem);
        }
        await Task.CompletedTask;
    }

    
}
}
