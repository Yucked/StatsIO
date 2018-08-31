# StatsIO 🏅
[![Build status](https://img.shields.io/appveyor/ci/yucked/statsio/master.svg?longCache=true&style=for-the-badge&logo=appveyor&colorA=303030&colorB=72ffc9&label=Current+Build)](https://ci.appveyor.com/project/Yucked/statsio)

## `Usage:`

```cs
var client = new StatsClient("Client-ID", "Client-Secret");
await client.Statistics.CreateAsync("Stats-Id", "Username");
```

## `Current Roadmap:`

- Statistics Implementations:
    - [x] `Statistics#CreateAsync`
    - [ ] `Statistics#UpdateAsync`
    - [ ] `Statistics$GetAsync`
    - [x] `Statistics#ShowUserStatsAsync`
    - [x] `Statistics#GetSectionAsync`
    - [ ] `Statistics#LeaderboadsAsync`
- Achivements Implementations: 
    - [ ] `Achivement#AllAsync`
    - [ ] `Achivements#ManualAsync`
    - [ ] `Achivements#DisplayUsersAsync`
- [ ] Need to figure linking out :thinking:
- [x] Renamed project to something better.
- [x] Come up with better method names (?) :weary:
- [x] `APIException` class for handling HTTP exceptions ⚠️
