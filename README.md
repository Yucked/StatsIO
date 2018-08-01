# GlobalSharp 🏅
[![Build status](https://img.shields.io/appveyor/ci/yucked/globalsharp/master.svg?longCache=true&style=for-the-badge&logo=appveyor&colorA=303030&colorB=72ffc9&label=Current+Build)](https://ci.appveyor.com/project/Yucked/globalsharp)

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
