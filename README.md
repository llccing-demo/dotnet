## steps

- myApp 命令行应用
- dotnetWebApi, rest api
- AspNetCoreTodo, todo mvc

## myApp

de

## AspNetCoreTodo

### identity

认证服务能够注册，但是登录卡住了。

### 参考

- https://windsting.github.io/little-aspnetcore-book/book/
- https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio identity说明

## dotnetWebApi

### 增加Docker部署

```
docker build -t dotnetwebapi .

docker build -t mymicroservice .

docker images

docker run -it --rm -p 3000:80 --name mymicroservicecontainer mymicroservice

docker ps
```

### 微服务

### docker-compose

通过 docker-compose.yml 文件来启动。

### 参考

- https://dotnet.microsoft.com/learn/aspnet/microservice-tutorial/docker-file
- https://docs.microsoft.com/zh-cn/learn/modules/dotnet-microservices/2-what-are-microservices 微服务
- https://www.runoob.com/docker/docker-compose.html docker-compose 相关
