# GlobalSharp 🏅
API wrapper for [GlobalStats.io](https://globalstats.io/api).

## `Usage:`

```cs
var client = new GlobalClient("Client-ID", "Client-Secret");
await client.Statistics.AddOrUpdateAsync("Stats-Id", "Username");
```

## `Current Roadmap:`

- Statistics Implementations:  
    - [ ] `Statistics#UpdateAsync`
    - [ ] `Statistics#ShowAsync`
    - [ ] `Statistics#GetSectionAsync`
    - [ ] `Statistics#LeaderboadsAsync`
- Achivements Implementations: 
    - [ ] `Achivement#AllAsync`
    - [ ] `Achivements#ManualAsync`
    - [ ] `Achivements#DisplayUsersAsync`
- [ ] Need to figure linking out :thinking:    
- [ ] Come up with better method names (?) :weary:
- [ ] `GlobalException` class for handling HTTP exceptions ⚠️
- [ ] Separate branch for Discord stuff.
