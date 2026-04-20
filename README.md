# UnityOsys

Unity에서 자주 쓰는 공용 유틸리티를 로컬 패키지 형태로 관리하는 저장소입니다.

## 환경

- Unity `6000.3.3f1`
- Assembly: `oojjrs.osys`
- Package: `com.oojjrs.osys`

## 패키지 위치

- 실제 패키지 루트: `Packages/src`
- 런타임 코드: `Packages/src/Runtime`

## 포함 기능

- `BuildOptions`: 빌드 매크로 분기 (`USE_STANDALONE`, `USE_STEAM`, `USE_STOVE`)
- `DictionaryExtensions`: `Dictionary` 일괄 추가
- `MyDictionaryListT<TKey, TValue>`: 키 하나에 여러 값 저장
- `MyEquatableObjectT<T>`: 값 비교 기반 클래스
- `MyHashQueue<T>`: 중복 없는 큐
- `MyRandom`: 랜덤 범위, 셔플, 선택, 가중치 선택
- `NotifierBufferT<T>`: 변경 버퍼링 후 일괄 이벤트 전달
- `ObjectPool`: 기존 커스텀 오브젝트 풀
- `RegexHelper`: `%` 와일드카드 기반 문자열 매칭
- `StringExtensions`: 문자열 -> enum 변환
- `StringFormatHelper`: 숫자/화폐/퍼센트 포맷
- `TinyMath`: `Clamp`, `Clamp01`
- `XmlHelper`: XML 문자열 -> 배열 객체 역직렬화

## 사용 경로

```text
Packages/src/
  package.json
  README.md
  Runtime/
    oojjrs.osys.asmdef
    BuildOptions.cs
    DictionaryExtensions.cs
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
    TinyMath.cs
    XmlHelper.cs
```

## 참고

- 현재 프로젝트에서는 `Packages/manifest.json`에서 `com.oojjrs.osys`를 `file:src`로 참조합니다.
- `ObjectPool`은 `[Obsolete("Use UnityEngine.Pool.ObjectPool instead.")]` 상태입니다.
