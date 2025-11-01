# Build
FROM maven:3.9-eclipse-temurin-17 AS build
WORKDIR /app
COPY . .
RUN mvn -B -DskipTests clean package

# Runtime
FROM eclipse-temurin:17-jre-alpine
WORKDIR /app
# ajuste se o nome do JAR for diferente
COPY --from=build /app/target/*.jar app.jar
EXPOSE 8080
ENTRYPOINT ["java","-jar","/app/app.jar"]
