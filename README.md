# Bus Ticket Search and Listing

This project represents a web application where users can search for bus tickets and list the available travel options. Users can query bus journeys by specifying criteria such as departure location, destination, and date. The results display detailed information about suitable trips, allowing users to easily select and make reservations.
## Features

- ASP.NET Core MVC: The web framework forming the foundational infrastructure of the project, facilitating the operation of the web application.
- .NET 8: The latest version of the .NET platform used for project development.
- Redis Usage: Utilizing the Redis database to store user searches as cookies, enhancing the user experience.
- Onion Architecture: Structuring the project in a layered architecture, separating responsibilities such as business logic, database access, and user interface for easier maintenance.
- User-Friendly Interface: A simple and effective design for easy navigation, allowing users to effortlessly search and understand the results.


To install obilet case, you need to have .NET 8 SDK installed on your system. You also need to clone this repository to your local machine using the following command :
```
git clone https://github.com/talhabuyukkose/obiletcase.git
```
Then, navigate to the project directory and run the following command to restore the dependencies:
```
dotnet restore
```

Save the following script a file type yml
```
version: '3.8'

services:
  redis:
    container_name: ObiletRedis
    image: redis/redis-stack:latest
    # restart: always
    ports:
      - 6381:6379
    environment:
      - REDIS_PASSWORD=pass_obilet
      - REDIS_DATABASE=db_obilet
    volumes:
      #- /Users/talhabuyukkose/Desktop/Projects/Interviews/Obilet/DockerVolume:/data/

  jaeger:
    image: jaegertracing/all-in-one:latest
    ports:
      - "16686:16686"
      - "14268:14268"
      - "4317:4317"     # OTLP port
    environment:
      - COLLECTOR_OTLP_ENABLED=true
      - LOG_LEVEL=debug
      - OTEL_EXPORTER_JAEGER_AGENT_HOST=localhost
      - OTEL_EXPORTER_JAEGER_AGENT_PORT=6831
      - OTEL_EXPORTER_JAEGER_ENDPOINT=http://jaeger:14268/api/traces
      - OTEL_EXPORTER_JAEGER_PROTOCOL=udp/thrift.compact

networks:
  jaeger-example:
```

Run the following command to start the Redis server using Docker:

```
docker-compose up -d
```
