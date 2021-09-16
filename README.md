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

docker compose 中配置 nginx 参考 [文章](https://medium.com/@xroms123/docker-%E5%BB%BA%E7%AB%8B-nginx-%E5%9F%BA%E7%A4%8E%E5%88%86%E4%BA%AB-68c0771457fb)

**重点，从0-5扩展**
```
由
backend:
    ports:
      - "3000:80"

改为如下
    expose: 
      - "80"
```

然后运行
```
docker-compose up --scale backend=5
```
这样，即一个load-balance + 5 个服务。

**扩展部分参考**，这个 [文章](https://dotnetthoughts.net/how-to-nginx-reverse-proxy-with-docker-compose/)。

### 参考

- https://dotnet.microsoft.com/learn/aspnet/microservice-tutorial/docker-file
- https://docs.microsoft.com/zh-cn/learn/modules/dotnet-microservices/2-what-are-microservices 微服务
- https://www.runoob.com/docker/docker-compose.html docker-compose 相关
- https://www.jianshu.com/p/9cab14732dba docker-compose 一次性启动两个 web
- https://docs.microsoft.com/zh-cn/dotnet/architecture/microservices/ 微服务相关
- https://github.com/dotnet/aspnetcore github dotnet 源码

