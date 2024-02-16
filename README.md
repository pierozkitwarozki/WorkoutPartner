# Workout partner (temporary title)

In short: iOS/Android application letting user plan and register gym/bodyweight/cardio workouts.

## Planned infrastructure
### API (currently in development)
- minimal API with .NET 8 and EntityFramework code first approach
- db SQLite (dev), Postgres (prod)

### Frontend
- mobile application (react-native)
- web application (simple landing page with support only)

### CI/CD
- GitHub Actions

### Hosting
- docker-compose with API, frontend, nginx and db containers
