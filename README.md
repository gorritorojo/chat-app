## base de datos en docker

```bash
 docker run -d --name chatapp-postgres -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=pgJuly_1971 -e POSTGRES_DB=chatapp_db -p 5432:5432 postgres:latest
```


## broker mqtt en local con docker

```
docker run -d --name emqx -p 1883:1883 -p 8083:8083 -p 8084:8084 -p 8883:8883 -p 18083:18083  emqx/emqx-enterprise:5.8.6
```
