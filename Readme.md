DeepStreamNet
=============

dotnet Client for [deepstream.io](https://deepstream.io)

##Usage

```csharp
var client = new DeepStreamClient("localhost", 6021);

if(await client.LoginAsync())
{
 //Login was successful   
}

// Close Connection to deepstream.io endpoint
client.Dispose();
```

###Events

```csharp
// Subscribe to Event 'test'
var eventSubscription = await client.Events.Subscribe("test", x => { Console.WriteLine(x); });

// Send 'Hello' to all Subscribers of Event 'test'
await client.PublishAsync("test", "Hello");

// Send number '42' to all Subscribers of Event 'test'
await client.PublishAsync("test", 42);

// Send object '{Property1="Hello", Property2=42}' to all Subscribers of Event 'test'
await client.PublishAsync("test", new {Property1="Hello", Property2=42});

// Unsubscribe from Event 'test'
eventSubscription.Dispose();
```

###Records

```csharp
var record = await client.Records.GetRecordAsync("test");

record["FirstName"] = "John";
record["Age"] = 28;

// Save all changes
await client.Records.SaveAsync(record);

// Discard all changes
await client.Records.DiscardAsync(record);

// Delete Records
await client.Records.DeleteAsync(record);
```

###Dynamic Records

```csharp
dynamic record = await client.Records.GetRecordAsync("test");

record.FirstName = "Jane";
record.Age = 21;

// Save all changes
await client.Records.SaveAsync(record);
```