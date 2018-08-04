# StatsIO 🏅
[![Build status](https://img.shields.io/appveyor/ci/yucked/statsio/master.svg?longCache=true&style=for-the-badge&logo=appveyor&colorA=303030&colorB=72ffc9&label=Current+Build)](https://ci.appveyor.com/project/Yucked/statsio)

## `Usage:`

```cs
var client = new StatsClient("Client-ID", "Client-Secret");
await client.Statistics.AddOrUpdateAsync("Stats-Id", "Username");
```

## `Current Roadmap:`

- Statistics Implementations:  
    - [ ] `Statistics#UpdateAsync`
    - [x] `Statistics#ShowUserStatsAsync`
    - [ ] `Statistics#GetSectionAsync`
    - [ ] `Statistics#LeaderboadsAsync`
- Achivements Implementations: 
    - [ ] `Achivement#AllAsync`
    - [ ] `Achivements#ManualAsync`
    - [ ] `Achivements#DisplayUsersAsync`
- [ ] Need to figure linking out :thinking:    
- [ ] Come up with better method names (?) :weary:
- [x] `APIException` class for handling HTTP exceptions ⚠️
- [ ] Separate branch for Discord stuff.
