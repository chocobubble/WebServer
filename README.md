## 소개

> 언리얼 프로젝트의 서버로 이용하기 위해 제작한 웹 기반 서버입니다.

## 사용한 기술
- ASP.NET Core 
- Redis 
- Protobuf 

# 기능
## 1. 데이터 송수신
- Protobuf를 이용해 데이터를 serialize, deserialize 해 송수신했습니다.
	- [관련 코드](https://github.com/chocobubble/WebServer/tree/main/WebServer/HttpCommand)
## 2. 세션을 이용한 로그인 구현
- 로그인 성공 시 세션을 하나 생성하고, 일정 시간 유지되도록 했습니다.
	- C#의 `Guid.NewGuid()` 를 이용해 세션 아이디를 생성했고,
	- Redis 의 `TimeSpan` 을 이용해 세션이 일정시간 유지되게 했습니다.
	- [관련 코드](https://github.com/chocobubble/WebServer/blob/main/WebServer/Repository/SessionFromRedis.cs)
- Action Filter 를 이용해 클라이언트의 요청시마다 세션이 유효한 경우 세션을 연장해 주었습니다.
	- [관련 코드](https://github.com/chocobubble/WebServer/blob/main/WebServer/Filter/GlobalActionFilter.cs)
## 3. Redis를 DB로 사용
- 계정 정보, 세션, 캐릭터 데이터 등을 저장하는 데 Redis를 사용했습니다.
	- [관련 코드](https://github.com/chocobubble/WebServer/blob/main/WebServer/Repository/CharacterDataFromRedis.cs)

