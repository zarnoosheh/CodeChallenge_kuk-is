# Code Challenge Project


- The Project is built with ASP Core 6.0 Web API (restful)
- The main architecture is "Onion Architecture"
- The DDD pattern is used for handling logic, but as it has little logic, it's almost a simple model.
- CQRS + Mediator pattern is also used.
- For validations, The FluentValidation package is used.
- Validation errors are being handled inside the application layer while other unhandled exceptions are being handled using an exception handler middleware
- For persistence, the Ef core InMemory provider is used which doesn't need migrations.
- Because of using the above design patterns, the application is fully testable.
- The application can be executed without any prerequisites.
