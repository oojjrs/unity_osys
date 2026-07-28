# com.oojjrs.osys

Unity에서 자주 쓰는 공용 유틸리티를 모아둔 로컬 패키지입니다.

## 패키지 정보

- Name: `com.oojjrs.osys`
- Version: `1.12.0`
- Unity: `6000.0`

## 구조

```text
Packages/src/
  package.json
  README.md
  Runtime/
    oojjrs.osys.asmdef
    BuildOptions.cs
    DateTimeExtensions.cs
    DictionaryExtensions.cs
    EnumerableExtensions.cs
    EnumExtensions.cs
    MyBoundedQueue.cs
    MyDictionaryListT.cs
    MyEquatableObjectT.cs
    MyHashQueue.cs
    MyRandom.cs
    NotifierBufferInterface.cs
    NotifierBufferT.cs
    ObjectPool.cs
    RegexHelper.cs
    StringExtensions.cs
    StringFormatHelper.cs
    TimeSpanExtensions.cs
    TinyMath.cs
    XmlHelper.cs
  Tests/
    Runtime/
      oojjrs.osys.Tests.asmdef
      EnumerableExtensionsTests.cs
      EnumExtensionsTests.cs
```

## 예시

```csharp
var recentValues = new MyBoundedQueue<int>(3);
recentValues.Enqueue(1);
recentValues.Enqueue(2);
recentValues.Enqueue(3);
recentValues.Enqueue(4);

recentValues.TryPeek(out var oldestValue); // 2
var snapshot = recentValues.ToArray(); // 2, 3, 4

foreach (var value in recentValues)
{
    // 2, 3, 4
}
```

```csharp
using System.Text.RegularExpressions;

var matched = "Player_001".RegexIsLike("Player%");
var matchedIgnoreCase = "player_001".RegexIsLike("PLAYER%", RegexOptions.IgnoreCase);
```

```csharp
var dateTimeText = DateTime.Now.ToOsysDateTimeString();
var elapsedText = TimeSpan.FromSeconds(5.123).ToOsysElapsedWithMillisecondsString();
var durationText = TimeSpan.FromHours(27.25).ToOsysDurationString();
```

```csharp
enum PageEnum
{
    Home,
    Inventory,
    Settings,
}

var pages = new[] { "Home", "Inventory", "Settings" };
var nextPage = pages.GetNext("Settings"); // Home
var previousPage = pages.GetPrevious("Home"); // Settings

var nextPageType = PageEnum.Home.GetNext(); // Inventory
var previousPageType = PageEnum.Home.GetPrevious(); // Settings
```

## 참고

- 런타임 코드는 `Runtime` 아래에 배치되어 있습니다.
- `ObjectPool`은 새 코드에서 `UnityEngine.Pool.ObjectPool` 사용을 권장합니다.
